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
    /// Lógica de interacción para AdmUser.xaml
    /// </summary>
    public partial class AdmUser : UserControl
    {

        DataProvider provider = new DataProvider();
        List<User> users = new List<User>();

        public async void getterUsers()
        {
            users = await provider.GetUsers();

            foreach(User user in users)
            {
                comboBox.Items.Add(user.name);
            }

        }

        public AdmUser()
        {
            getterUsers();
            InitializeComponent();
        }


    }
}
