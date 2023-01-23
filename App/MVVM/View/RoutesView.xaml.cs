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
using Windows.UI.Xaml.Controls;
using TextBlock = System.Windows.Controls.TextBlock;

namespace App.MVVM.View
{
    /// <summary>
    /// Lógica de interacción para RoutesView.xaml
    /// </summary>
    public partial class RoutesView : UserControl
    {
        public RoutesView()
        {
            InitializeComponent();

            makePageGrid();
        }


        private void makePageGrid()
        {
            

            Grid postGrid = new Grid
            {
                Height = 270,
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#99E2B4"))
            };

            postGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            postGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            postGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            postGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
            postGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            TextBlock titleText = new TextBlock
            {
                FontSize = 30,
                Text = "Post Title"
            };
            Grid.SetRow(titleText, 0);
            Grid.SetColumn(titleText, 0);
            postGrid.Children.Add(titleText);

            Image image = new Image
            {
                Width = 270,
                HorizontalAlignment = HorizontalAlignment.Left,
                Source = new BitmapImage(new Uri("../../Images/niagara.jpg", UriKind.Relative))
            };
            Grid.SetRow(image, 1);
            Grid.SetColumn(image, 0);
            postGrid.Children.Add(image);

            TextBlock descriptionText = new TextBlock
            {
                Text = "Description"
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
                Text = "Creator John Doe" 
            };

            TextBlock dateText = new TextBlock { Text = "Date: 01/01/2022" };
            creatorAndDate.Children.Add(creatorText);
            creatorAndDate.Children.Add(dateText);
            Grid.SetRow(creatorAndDate, 2);
            Grid.SetColumn(creatorAndDate, 0);
            postGrid.Children.Add(creatorAndDate);

            TextBlock valorationText = new TextBlock
            {
                Text = "Valoration: 5/5",
                Margin = new Thickness(0, 30, 20, 0),
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Bottom
            };
            Grid.SetRow(valorationText, 2);
            Grid.SetColumn(valorationText, 1);
            postGrid.Children.Add(valorationText);

            scroll.Content = postGrid;


        }

    }
}
