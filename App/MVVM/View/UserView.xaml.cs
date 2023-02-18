using App.Core;
using App.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
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
using Brushes = System.Windows.Media.Brushes;
using Color = System.Windows.Media.Color;
using ColorConverter = System.Windows.Media.ColorConverter;
using Image = System.Windows.Controls.Image;

namespace App.MVVM.View
{
    /// <summary>
    /// Lógica de interacción para UserView.xaml
    /// </summary>
    public partial class UserView : UserControl
    {
        User usuario = UserProvider.userLogged;

        DataProvider ejemplo = new DataProvider();
        List<Post> posts = new List<Post>();

        string filePath;
        public async void getterPosts()
        {
            posts = await ejemplo.getPostsByUser(usuario);
            generateView();


        }


        public UserView()
        {
            usuario = UserProvider.userLogged;
            getterPosts();
            InitializeComponent();
        }

        private void generateView()
        {
            string url = "http://localhost:9999/users/img/" + usuario.picture;

            logoUser.Source = new BitmapImage(new Uri(url,UriKind.RelativeOrAbsolute));
            NFollowers.Text = usuario.followers.Count.ToString();
            NFollowing.Text = usuario.following.Count.ToString();
            UsernameTxt.Text = ""+ usuario._id;
            datetxt.Text = usuario.register;
            NameSurname.Text = usuario.name + " " +usuario.surname;

            if(usuario.web == "no Web")
            {
                webTxt.Text = "";
            }
            else
            {
                webTxt.Text = usuario.web;
            }


            foreach (Post post in posts)
            {
                Border stackBorder = new Border();
                stackBorder.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#56AB91")); ;
                stackBorder.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#56AB91")); ;
                stackBorder.BorderThickness = new Thickness(2);
                stackBorder.CornerRadius = new CornerRadius(7);
                stackBorder.Margin = new Thickness(0, 0, 20, 10);
                //stackBorder.Height = 270;
                //stackBorder.Width = 890;

                StackPanel ruta = new StackPanel();
                ruta.Orientation = Orientation.Vertical;
                ruta.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#56AB91"));

                TextBlock textBlock = new TextBlock();
                textBlock.Text = post.name;
                textBlock.Foreground = Brushes.White;
                textBlock.FontSize = 25;
                textBlock.FontWeight = FontWeights.Medium;
                textBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                textBlock.Margin = new Thickness(10,0,10,0);

                ruta.Children.Add(textBlock);

                Image image = new Image
                {
                    Width = 200,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Source = new BitmapImage(new Uri("http://localhost:9999/posts/img/" + post.image, UriKind.RelativeOrAbsolute)),
                    Margin = new Thickness(20,0,20,0),
                };

                ruta.Children.Add(image);

                stackBorder.Child = ruta;

                routes.Children.Add(stackBorder);
            }

            
        }
    }
}
