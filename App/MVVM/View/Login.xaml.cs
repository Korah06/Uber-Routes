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

namespace App.MVVM.View
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {

        DataProvider ejemplo = new DataProvider();
        List<MVVM.Model.User> users;

        public async void saveUsers(){


           await ejemplo.GetUsers().ContinueWith(task =>
           {
               users = task.Result;
           });

            MessageBox.Show(users[0].name);
        }

        public Login()
        {
            InitializeComponent();
            saveUsers();
            
        }


        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if(txtUser.Text == "admin" && txtPassword.Password == "admin")
            {
                MainWindow main = new MainWindow();

                this.Close();
                main.Show();
            }

            var userFound = users.Where(x => x.email == txtUser.Text && x.username == txtPassword.Password);

            if (userFound.Count() > 0)
            {
                
                MainWindow main = new MainWindow();
                main.Administration.Visibility = Visibility.Hidden;
                this.Close();
                main.Show();
            }
            else
            {
                userFound = users.Where(x => x.email == txtUser.Text);

                if(userFound.Count() > 0)
                {
                    MessageBox.Show("La contraseña no es correcta");
                }
                else
                {
                    MessageBox.Show("El usuario no existe");
                }


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
