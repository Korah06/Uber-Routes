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
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using App.MVVM.Model;
using App.Core;

namespace App
{
    /// <summary>
    /// Lógica de interacción para Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        DataProvider ejemplo = new DataProvider();
        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
        string[] emptyArray = new string[0];
        public Register()
        {
            InitializeComponent();
        }


        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            if (txtEmail.Text == "" || txtName.Text == "" || txtPassword.Password == "" || txtSurname.Text == "" || txtUser.Text == "")
            {
                MessageBox.Show("Rellene todos los campos");
            }
            else
            {
                if (Regex.IsMatch(txtEmail.Text, pattern))
                {
                    User usuario = new User()
                    {
                        _id = txtUser.Text,
                        name = txtName.Text,
                        surname = txtSurname.Text,
                        password = txtPassword.Password,
                        following = new List<string>(),
                        followers = new List<string>(),
                        email = txtEmail.Text,
                        picture = "example",
                        register = "example",
                        web = "example",

                    };

                    UserProvider.token = await ejemplo.Register(usuario);
                    UserProvider.userLogged = usuario;

                    MainWindow main = new MainWindow();
                    main.Administration.Visibility = Visibility.Hidden;
                    this.Close();
                    main.Show();


                }
                else
                {
                    MessageBox.Show("La dirección de correo electrónico no es válida");



                }


            }

            
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
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
    }
}
