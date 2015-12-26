﻿using System;
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
using TeamCityNotifier.UIController.ViewModel.Project;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TeamCityNotifier.WinUI
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ProjectPage : Page
    {
        public ProjectPage()
        {
            this.InitializeComponent();
            DataContext = new ProjectViewModel();
        }

        private void MyRectangle_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            //NewStory.Begin();
        }
    }
}
