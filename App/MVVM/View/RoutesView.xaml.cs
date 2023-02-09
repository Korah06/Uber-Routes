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
using Windows.UI.Xaml.Controls;
using Color = System.Windows.Media.Color;
using ColorConverter = System.Windows.Media.ColorConverter;
using Image = System.Windows.Controls.Image;
using TextBlock = System.Windows.Controls.TextBlock;

namespace App.MVVM.View
{
    /// <summary>
    /// Lógica de interacción para RoutesView.xaml
    /// </summary>
    public partial class RoutesView : UserControl
    {
        DataProvider ejemplo = new DataProvider();
        List<Post> posts = new List<Post>();

        public async void getterPosts() {
            posts = await ejemplo.GetPosts();

            foreach (Post post in posts) {
                Console.WriteLine(post.name);

            }
            makePageGrid();


        }

        public RoutesView()
        {
            getterPosts();
            InitializeComponent();

        }


        private void makePageGrid()
        {
            foreach (Post post in posts) {


                Grid postGrid = new Grid
                {
                    Height = 270,
                    Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#99E2B4")),
                    Margin = new Thickness(0,0,0,10)
                };

                postGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                postGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                postGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                postGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
                postGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

                TextBlock titleText = new TextBlock
                {
                    FontSize = 30,
                    Text = post.name,
                };
                Grid.SetRow(titleText, 0);
                Grid.SetColumn(titleText, 0);
                postGrid.Children.Add(titleText);

                Image image = new Image
                {
                    Width = 270,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Source = new BitmapImage(new Uri("../../Images/niagara.jpg", UriKind.RelativeOrAbsolute))
                };
                Grid.SetRow(image, 1);
                Grid.SetColumn(image, 0);
                postGrid.Children.Add(image);

                TextBlock descriptionText = new TextBlock
                {
                    Text = post.description,
                };
                Grid.SetRow(descriptionText, 1);

                Grid.SetColumn(descriptionText, 1);
                postGrid.Children.Add(descriptionText);

                StackPanel creatorAndDate = new StackPanel
                {
                    Orientation = Orientation.Vertical,
                    VerticalAlignment = VerticalAlignment.Bottom
                };
                TextBlock creatorText = new TextBlock
                {
                    Text = "Creator: " + post.user
                };

                TextBlock dateText = new TextBlock { Text = "Date: 01/01/2022" };
                creatorAndDate.Children.Add(creatorText);
                creatorAndDate.Children.Add(dateText);
                Grid.SetRow(creatorAndDate, 2);
                Grid.SetColumn(creatorAndDate, 0);
                postGrid.Children.Add(creatorAndDate);

                stack.Children.Add(postGrid);

                Console.WriteLine(post._id);

            }

            

            


        }

    }
}
