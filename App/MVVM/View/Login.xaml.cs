using App.Core;
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
using App.MVVM.Model;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;
using Application = System.Windows.Application;

namespace App.MVVM.View
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {

        DataProvider ejemplo = new DataProvider();
        MVVM.Model.User user;

        

        public Login()
        {
            InitializeComponent();
        }



        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            
            LoginResponse a = await ejemplo.Login(txtUser.Text, txtPassword.Password);

            if(a != null) {
                UserProvider.token = a.token;
                user = a.data;
                UserProvider.userLogged = user;
            }
            else
            {
                UserProvider.token =null;
                user = null;
            }



            Console.WriteLine(UserProvider.token);

            if (UserProvider.token != null || UserProvider.token != "")
            {

                MainWindow main = new MainWindow();
                this.Close();
                main.Show();
            }
            else
            {
                MessageBox.Show("El usuario no existe");
            }
            

            


        }

        

        private void txtPassword_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            //Minimizar ventana
            WindowState = WindowState.Minimized;
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            //Cerrar Aplicacion
            Application.Current.Shutdown();
        }

        

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //Para poder mover la pantalla
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Register registro = new Register();

            registro.Show();
            this.Close();

        }

        private void TextBlock_MouseDown_1(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
