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
using App.MVVM.View;
using Login = App.MVVM.View.Login;

namespace App
{
    /// <summary>
    /// Lógica de interacción para Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        DataProvider ejemplo = new DataProvider();
        string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
        string usernamePattern = @"^[a-zA-Z0-9]{3,}$";
        string passwordPattern = "^(?=.*[A-Z])(?=.*[0-9])[a-zA-Z0-9._-]{6,}$";
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
                if (Regex.IsMatch(txtUser.Text,usernamePattern))
                {
                    if (Regex.IsMatch(txtPassword.Password,passwordPattern))
                    {
                        if (Regex.IsMatch(txtEmail.Text, emailPattern))
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
                                picture = "example-user.png",
                                register = "example",
                                web = "no Web",
                                admin = true,

                            };

                            UserProvider.token = await ejemplo.Register(usuario);
                            UserProvider.userLogged = usuario;

                            MainWindow main = new MainWindow();
                            this.Close();
                            main.Show();


                        }
                        else
                        {
                            MessageBox.Show("La dirección de correo electrónico no es válida");
                        }
                    }
                    else
                    {
                        MessageBox.Show("La contraseña debe de tener al menos una mayuscula, un número y debe ser de minimo 6 caracteres");
                    }
                }
                else
                {
                    MessageBox.Show("El nombre de usuario debe de ser alfanumerico y tener minimo 3 caracteres");
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

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();

            login.Show();
            this.Close();
        }
    }
}
