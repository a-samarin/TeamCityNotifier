using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace TeamCityNotifier.WinUI.Controls
{
    public sealed partial class ProjectListControl : UserControl
    {
        public ProjectListControl()
        {
            this.InitializeComponent();
        }

        private void Login_OnClick(object sender, RoutedEventArgs e)
        {
            //this.Frame.Navigate(typeof(LoginPage));
        }
    }
}
