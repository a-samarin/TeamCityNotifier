using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using TeamCityNotifier.DataContract;

namespace TeamCityNotifier.WinUI.Converters
{
    internal class BuildStatusToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is BuildStatus)
            {
                var buildStatus = (BuildStatus) value;

                switch (buildStatus)
                {
                    case BuildStatus.Success:
                        return Application.Current.Resources.First(r => r.Key == "SuccessLightGreenBrush");
                    case BuildStatus.Failure:
                        return Application.Current.Resources.First(r => r.Key == "FailedLightRedBrush");
                    default:
                        return Application.Current.Resources.First(r => r.Key == "FailedLightRedBrush");
                }
            }
            
            throw new ArgumentException("Wrong parameter type", nameof(value));
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
