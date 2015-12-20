using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using TeamCityNotifier.UIController.Helper;
using TeamCityNotifier.UIController.ViewModel.Login;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TeamCityNotifier.WinUI
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            this.InitializeComponent();
            DataContext = new LoginViewModel();
        }

        private void Login_OnClick(object sender, RoutedEventArgs e)
        {
            ((LoginViewModel)DataContext).Save();
            this.Frame.Navigate(typeof(ProjectPage));
        }
    }
}
