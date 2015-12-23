using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.Xaml;

namespace TeamCityNotifier.UIController.Base
{
    /// <summary>
    /// Provides access to UI thread dispacther, to be used in view and data models
    /// </summary>
    public static class DispatcherProvider
    {
        private static UIDispatcherHolder _UIDispatcherHolder;

        static DispatcherProvider()
        {
            _UIDispatcherHolder = new UIDispatcherHolder();
        }

        private class UIDispatcherHolder
        {
            public CoreDispatcher UIDispatcher { get; set; }
        }

        /// <summary>
        /// Get UI thread dispatcher
        /// </summary>
        /// <returns></returns>
        public static CoreDispatcher GetForUI()
        {
            if (_UIDispatcherHolder.UIDispatcher == null)
            {
                throw new InvalidOperationException("UIDispatcher has not been initialized. You must call SetForUI method on application start from UI thread.");
            }

            return _UIDispatcherHolder.UIDispatcher;
        }

        /// <summary>
        /// Set current dispatcher as UI dispacther, must be called at UI thread
        /// </summary>
        public static void SetForUI()
        {
            _UIDispatcherHolder.UIDispatcher = CoreApplication.MainView.CoreWindow.Dispatcher;
            //Window.Current.Dispatcher;
            //CoreApplication.MainView.CoreWindow.Dispatcher;

            //            var dis = CoreApplication.GetCurrentView().CoreWindow.Dispatcher;
            //            var dis = CoreApplication.MainView.CoreWindow.Dispatcher;
            //            var dis = CoreWindow.GetForCurrentThread().Dispatcher;
        }
    }
}
