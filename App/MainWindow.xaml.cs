using App.MVVM.View;
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
using Login = App.MVVM.View.Login;

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
            changeImg();
        }

        public void changeImg()
        {
            ImageBrush brush = (ImageBrush)userBtn.Background;
            brush.ImageSource = new BitmapImage(new Uri("http://localhost:9999/users/img/example-user.png", UriKind.RelativeOrAbsolute));
            //brush.OpacityMask = new SolidColorBrush(Colors.Transparent);

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

            radioHome.IsChecked = false;
            //radioRoutes.IsChecked = false;
        }

        private void closeSession_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult result = MessageBox.Show("Desea cerrar sesion?","Cierre de sesion",MessageBoxButton.YesNo);

            if(result == MessageBoxResult.Yes)
            {
                MessageBox.Show("¡Hasta la proxima!");

                UserProvider.token = null;
                UserProvider.userLogged = null;
                Login login = new Login();
                this.Close();
                login.Show();
            }
            else
            {

            }
            

        }
    }
}
