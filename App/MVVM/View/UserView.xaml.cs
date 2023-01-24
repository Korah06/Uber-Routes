using App.Core;
using App.MVVM.Model;
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
using System.Windows.Shapes;

namespace App.MVVM.View
{
    /// <summary>
    /// Lógica de interacción para UserView.xaml
    /// </summary>
    public partial class UserView : UserControl
    {
        User usuario;
        public UserView()
        {
            usuario = UserProvider.userLogged;
            InitializeComponent();
            generateView();
        }

        private void generateView()
        {
            Console.WriteLine(usuario._id);
            UsernameTxt.Text = ""+ usuario._id;
        }
    }
}
