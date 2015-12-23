using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.System.Threading;
using Windows.UI.Core;
using Windows.UI.Xaml;
using TeamCityNotifier.DataContract;
using TeamCityNotifier.UIController.Annotations;

namespace TeamCityNotifier.UIController.Base
{
    public abstract class Notifiable : INotifyPropertyChanged
    {

        //        public event PropertyChangedEventHandler PropertyChanged;

        //        [NotifyPropertyChangedInvocator]
        //        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //        {
        //            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //        }


        #region Private Data

        private PropertyChangedEventHandler _propertyChangedEvent;

        #endregion //Private Data

        #region Protected Properties

        /// <summary>
        /// If set to True, then PropertyChanged events will not be reaised
        /// </summary>
        internal bool DisablePropertyChangedEvent
        {
            get;
            set;
        }

        #endregion //Protected Properties

        #region Public Properties

        /// <summary>
        /// Gets validation status of data model
        /// </summary>
        /// <remarks>
        /// It is always true if data model not implementing IDataErrorInfo attribute
        /// Otherwise it is called this[propertyName] to validate each property marked with attribute ValidationProperty to calculate validation status
        /// </remarks>
        public virtual bool IsValid
        {
            get
            {
                if (this is INotifyDataErrorInfo)
                {
                    var errorProvider = (INotifyDataErrorInfo)this;
        
                    bool isValid = true;
        
                    PropertyInfo[] properties = GetType().GetProperties();
        
                    foreach (var property in properties)
                    {
        
                        if (property.GetCustomAttributes(typeof(ValidationPropertyAttribute), false).Any())
                        {
//                            if (!string.IsNullOrEmpty(errorProvider[property.Name]))
//                            {
//                                isValid = false;
//                                break;
//                            }
                        }
                    }
        
                    return isValid;
                }
        
                return true;
            }
        }

        /// <summary>
        /// Gets list of errors
        /// </summary>
        public List<string> Errors
        {
            get
            {
                var errorList = new List<string>();

                if (this is INotifyDataErrorInfo)
                {
                    var errorProvider = (INotifyDataErrorInfo)this;

                    PropertyInfo[] properties = GetType().GetProperties();

                    foreach (var property in properties)
                    {
                        if (property.GetCustomAttributes(typeof(ValidationPropertyAttribute), false).Any())
                        {
//                            if (!string.IsNullOrEmpty(errorProvider[property.Name]))
//                            {
//                                errorList.Add(errorProvider[property.Name]);
//                                break;
//                            }
                        }
                    }


                }

                return errorList;
            }
        }

        #endregion //Public Properties

        #region Events

        /// <summary>
        /// PropertyChanged event for INotifyPropertyChanged implementation.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged
        {
            add
            {
                VerifyCalledOnUIThread();
                _propertyChangedEvent += value;
            }
            remove
            {
                VerifyCalledOnUIThread();
                _propertyChangedEvent -= value;
            }
        }

        #endregion //Events

        #region Public Methods

        /// <summary>
        /// Utility function for use by subclasses to notify that a property has changed.
        /// </summary>
        /// <param name="propertyNames">The names of the properties.</param>
        public void SendPropertyChanged(params string[] propertyNames)
        {
            if (!DisablePropertyChangedEvent)
            {
                VerifyCalledOnUIThread();
                if (_propertyChangedEvent != null)
                {
                    foreach (string propertyName in propertyNames)
                    {
                        _propertyChangedEvent(this, new PropertyChangedEventArgs(propertyName));
                    }
                }
            }
        }

        /// <summary>
        /// Marshals a call onto the UI thread. 
        /// </summary>
        /// <param name="callback"></param>
        public void QueueForUIThread(DispatchedHandler callback)
        {
            QueueForUIThread(callback, CoreDispatcherPriority.Normal);
        }

        /// <summary>
        /// Marshals a call onto the UI thread with the specified dispatcher priority.
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="dispatcherPriority"></param>
        public void QueueForUIThread(DispatchedHandler callback, CoreDispatcherPriority dispatcherPriority)
        {
            //CoreApplication.MainView.CoreWindow.Dispatcher
            if (Window.Current?.Dispatcher == DispatcherProvider.GetForUI())
            {
                callback();
            }
            else
            {
                DispatcherProvider.GetForUI().RunAsync(dispatcherPriority, callback);
            }
        }

        /// <summary>
        /// Puts a call onto a background thread
        /// </summary>
        /// <param name="callback"></param>
        public void QueueForBackgroundThread(DispatchedHandler callback)
        {
            QueueForBackgroundThread(false, callback);
        }

        /// <summary>
        /// Puts a call onto a background thread
        /// </summary>
        /// <param name="synchronize">When set to true, a new thread is not used.  It will run the callback method in current thread.</param>
        /// <param name="callback"></param>
        public void QueueForBackgroundThread(bool synchronize, DispatchedHandler callback)
        {
            // If synchronized, then we do not want to create a new thread.
            // This is useful in cases such as reporting
            if (synchronize)
            {
                callback();
            }
            else
            {
                Task.Run(() =>
                        {
                            try
                            {
                                callback();
                            }
                            catch (Exception e)
                            {
                                //if an exception occured, then marshal it onto the UI thread before re-throwing
                                QueueForUIThread
                                (
                                    delegate
                                    {
                                        throw new Exception(e.Message, e);
                                    }
                                );
                            }
                        });
            }
        }

        /// <summary>
        /// Removes any PropertyChanged Event Listeners of a specified type.
        /// 
        /// One example of how this method is used is when a model (Notifiable) is moved from one
        /// ItemsControl to another ItemsControl.  A new UI Container will be created, and if the 
        /// UIContainer is a listener, the old UI Container will still be referenced by the model.
        /// 
        /// If the (Notifiable) model is moved around a lot, there will be an increasing amount of
        /// unused UI Containers receiving notification every time the PropertyChanged event is fired.
        /// 
        /// To avoid this, calling this model will remove all listeners belonging to a class of the specified
        /// type.
        /// 
        /// In the unlikely case you have multiple UI Containers of the same type deliberately referencing the same 
        /// (Notifiable) model, then they will ALL be effected when you call this method - and you may not want that.
        /// </summary>
        public void ClearPropertyChangedEventListeners(Type type)
        {
            VerifyCalledOnUIThread();

            if (_propertyChangedEvent != null)
            {
                foreach (PropertyChangedEventHandler eventDelegate in _propertyChangedEvent.GetInvocationList())
                {
                    if (eventDelegate.Target.GetType() == type)
                    {
                        PropertyChanged -= eventDelegate;
                    }
                }
            }
        }

        /// <summary>
        /// Removes any event handlers listening to the property changed event of this object
        /// </summary>
        public void ClearAllPropertyChangedEventListeners()
        {
            VerifyCalledOnUIThread();

            if (_propertyChangedEvent != null)
            {
                foreach (PropertyChangedEventHandler eventDelegate in _propertyChangedEvent.GetInvocationList())
                {
                    PropertyChanged -= eventDelegate;
                }
            }
        }

        #endregion //Public Methods

        #region Protected Methods

        /// <summary>
        /// Debugging utility to make sure functions are called on the UI thread.
        /// </summary>
        [Conditional("DEBUG")]
        protected void VerifyCalledOnUIThread()
        {
            Debug.Assert(Window.Current?.Dispatcher == DispatcherProvider.GetForUI(), "Call must be made on UI thread.");
        }

        #endregion //Protected Methods
    }

    public abstract class Notifiable<TDataContract> : Notifiable where TDataContract : ObjectBase
    {
        #region Protected Data

        protected ObjectBase _DataContract;

        #endregion //Protected Data

        #region Public Properties

        /// <summary>
        /// Strongly typed accessor to the <see cref="ObjectBase"/>-derived data contract associated with this <see cref="Notifiable"/> instance.
        /// </summary>
        public TDataContract DataContract
        {
            get { return (TDataContract)_DataContract; }
            protected set { _DataContract = value; }
        }

        #endregion //Public Properties
    }
}