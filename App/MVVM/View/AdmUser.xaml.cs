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
using static System.Net.Mime.MediaTypeNames;
using Image = System.Windows.Controls.Image;

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
                comboBoxId.Items.Add(user._id);
            }

            generateUserGrid();

        }

        private void generateUserGrid()
        {

            foreach(User user in users) {
                SolidColorBrush fondo;
                if (comboBoxId.SelectedValue != user._id)
                {
                    fondo = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#56AB91"));
                }
                else
                {
                    fondo = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#358F80"));
                }

                Border gridBorder = new Border();
                gridBorder.BorderBrush = fondo;
                gridBorder.Background = fondo;
                gridBorder.BorderThickness = new Thickness(2);
                gridBorder.CornerRadius = new CornerRadius(4);
                gridBorder.Margin = new Thickness(0, 0, 20, 10);
                gridBorder.Height = 60;
                gridBorder.Width = 890;


                Grid userGrid = new Grid
                {
                    Height = 50,
                    Width = 890,
                    Background = fondo,
                    Margin = new Thickness(0, 0, 0, 10),
                    Tag = user._id,
                };

                StackPanel stack = new StackPanel();
                stack.Width = 890;
                stack.Orientation = Orientation.Horizontal;
                userGrid.Children.Add(stack);

                Image image = new Image
                {
                    Margin = new Thickness(5, 5, 5, 5),
                    Source = new BitmapImage(new Uri("http://localhost:9999/users/img/" + user.picture, UriKind.RelativeOrAbsolute)),
                };
                stack.Children.Add(image);

                Border idBorder = new Border();
                idBorder.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#248277"));
                idBorder.BorderThickness = new Thickness(8);
                idBorder.CornerRadius = new CornerRadius(4);
                idBorder.Margin = new Thickness(0, 0, 5, 0);
                idBorder.Height = 27;


                TextBlock idText = new TextBlock
                {
                    Text = user._id,
                    Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#248277")),
                    Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF")),
                    VerticalAlignment = VerticalAlignment.Center,
                };
                idBorder.Child = idText;

                stack.Children.Add(idBorder);

                Border emailBorder = new Border();
                emailBorder.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#248277"));
                emailBorder.BorderThickness = new Thickness(8);
                emailBorder.CornerRadius = new CornerRadius(4);
                emailBorder.Margin = new Thickness(0, 0, 5, 0);
                emailBorder.Height = 27;

                TextBlock emailText = new TextBlock
                {
                    Text = user.email,
                   Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#248277")),
                    Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF")),
                    VerticalAlignment = VerticalAlignment.Center,
                };

                emailBorder.Child = emailText;

                stack.Children.Add(emailBorder);

                Border nameBorder = new Border();
                nameBorder.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#248277"));
                nameBorder.BorderThickness = new Thickness(8);
                nameBorder.CornerRadius = new CornerRadius(4);
                nameBorder.Margin = new Thickness(0, 0, 5, 0);
                nameBorder.Height = 27;


                TextBlock nameText = new TextBlock
                {
                    Text = user.name,
                    Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#248277")),
                    Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF")),
                    VerticalAlignment = VerticalAlignment.Center,
                };

                nameBorder.Child = nameText;

                stack.Children.Add(nameBorder);

                Border surnameBorder = new Border();
                surnameBorder.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#248277"));
                surnameBorder.BorderThickness = new Thickness(8);
                surnameBorder.CornerRadius = new CornerRadius(4);
                surnameBorder.Margin = new Thickness(0, 0, 5, 0);
                surnameBorder.Height = 27;

                TextBlock surnameText = new TextBlock
                {
                    Text = user.surname,
                    Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#248277")),
                    Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF")),
                    VerticalAlignment = VerticalAlignment.Center,

                };
                surnameBorder.Child = surnameText;

                stack.Children.Add(surnameBorder);

                Border webBorder = new Border();
                webBorder.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#248277"));
                webBorder.BorderThickness = new Thickness(8);
                webBorder.CornerRadius = new CornerRadius(4);
                webBorder.Margin = new Thickness(0, 0, 5, 0);
                webBorder.Height = 27;

                TextBlock webText = new TextBlock
                {
                    Text = user.web,
                    Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#248277")),
                    Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF")),
                    VerticalAlignment = VerticalAlignment.Center,
                };
                webBorder.Child = webText;

                stack.Children.Add(webBorder);

                Border registerBorder = new Border();
                registerBorder.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#248277"));
                registerBorder.BorderThickness = new Thickness(8);
                registerBorder.CornerRadius = new CornerRadius(4);
                registerBorder.Margin = new Thickness(0, 0, 5, 0);
                registerBorder.Height = 27;

                TextBlock registerText = new TextBlock
                {
                    Text = user.register,
                    Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#248277")),
                    Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF")),
                    VerticalAlignment = VerticalAlignment.Center,
                };
                registerBorder.Child = registerText;

                stack.Children.Add(registerBorder);

                if (user.admin)
                {

                    Border adminBorder = new Border();
                    adminBorder.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#248277"));
                    adminBorder.BorderThickness = new Thickness(8);
                    adminBorder.CornerRadius = new CornerRadius(4);
                    adminBorder.Margin = new Thickness(0, 0, 5, 0);
                    adminBorder.Height = 27;

                    TextBlock adminText = new TextBlock
                    {
                        Text = "Admin",
                        Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#248277")),
                    Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF")),
                        VerticalAlignment = VerticalAlignment.Center,
                    };
                    adminBorder.Child = adminText;

                    stack.Children.Add(adminBorder);
                }
                else
                {

                    Border adminBorder = new Border();
                    adminBorder.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#248277"));
                    adminBorder.BorderThickness = new Thickness(8);
                    adminBorder.CornerRadius = new CornerRadius(4);
                    adminBorder.Margin = new Thickness(0, 0, 5, 0);
                    adminBorder.Height = 27;

                    TextBlock adminText = new TextBlock
                    {
                        Text = "No Admin",
                        VerticalAlignment = VerticalAlignment.Center,
                        Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF")),
                        Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#248277")),
                    };
                    adminBorder.Child = adminText;

                    stack.Children.Add(adminBorder);
                }

                userGrid.MouseLeftButtonDown += new MouseButtonEventHandler(usergrid_MouseDown);

                void usergrid_MouseDown(object sender, MouseEventArgs e)
                {
                    comboBoxId.SelectedValue = userGrid.Tag;
                }

                gridBorder.Child = userGrid;
                stackPanel.Children.Add(gridBorder);

                if (comboBoxId.SelectedValue == userGrid.Tag)
                {
                    userGrid.Focus();
                }
            }

            

        }

        public AdmUser()
        {
            getterUsers();
            InitializeComponent();
        }

        public void deleteComponents()
        {
            stackPanel.Children.Clear();
        }

        private void comboBoxId_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Boolean admin;
            deleteComponents();
            generateUserGrid();

            foreach (User user in users)
            {
                if (user._id == comboBoxId.SelectedValue)
                {
                    if(user.admin)
                    {
                        adminBox.SelectedIndex = 0;
                    }
                    else
                    {
                        adminBox.SelectedIndex = 1;
                    }

                    nameText.Text = user.name;
                    surnameText.Text = user.surname;
                    webText.Text = user.web;
                    break;
                }
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            User userUpdate = null;

            foreach (User user in users)
            {
                if (user._id == comboBoxId.SelectedValue)
                {
                    userUpdate = user;
                    userUpdate.surname = surnameText.Text;
                    userUpdate.web = webText.Text;
                    userUpdate.name = nameText.Text;

                    if (adminBox.SelectedIndex == 0)
                    {
                        userUpdate.admin = true;
                    }
                    else
                    {
                        userUpdate.admin = false;

                    }
                }
            }

            if (postUpdate == null)
            {
                MessageBox.Show("No se ha seleccionado ningúna publicación");
            }
            else
            {
                DataProvider a = new DataProvider();
                a.updatePost(postUpdate);
                rechargePage();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            User userDelete = null;

            foreach (User user in users)
            {
                if (user._id == comboBoxId.SelectedValue)
                {
                    userDelete = user;
                }
            }

            DataProvider a = new DataProvider();
            a.deleteUser(userDelete);
            deleteComponents();
            getterUsers();

        }

        private void btnImage_Click(object sender, RoutedEventArgs e)
        {
            

            User userSend = null;

            foreach (User user in users)
            {
                if (user._id == comboBoxId.SelectedValue)
                {
                    userSend = user;
                }
            }



            DataProvider a = new DataProvider();
            a.UploadUserImg(userSend);

            nameText.Text = "";
            surnameText.Text = "";
            nameText.Text = "";
            webText.Text = "";
            comboBoxId.ItemsSource = null;

            deleteComponents();
            getterUsers();
        }
    }
}
