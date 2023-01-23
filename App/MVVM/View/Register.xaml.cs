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

namespace App
{
    /// <summary>
    /// Lógica de interacción para Register.xaml
    /// </summary>
    public partial class Register : Window
    {

        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
        public Register()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            if (txtEmail.Text == "" || txtName.Text == "" || txtPassword.Password == "" || txtSurname.Text == "" || txtUser.Text == "")
            {
                MessageBox.Show("Rellene todos los campos");
            }
            else
            {
                if (Regex.IsMatch(txtEmail.Text, pattern))
                {
                    MainWindow main = new MainWindow();

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
