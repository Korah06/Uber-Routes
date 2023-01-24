﻿using App.MVVM.View;
using App.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using App.MVVM.Model;
using System.Windows.Shapes;
using App.Core;
using User = App.MVVM.Model.User;

namespace App
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        User usuario = UserProvider.userLogged;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void userBtn_Click(object sender, RoutedEventArgs e)
        {
            //userBtn.SetBinding()

            radioCreate.IsChecked = false;
            radioHome.IsChecked = false;
            radioRoutes.IsChecked = false;
        }
    }
}
