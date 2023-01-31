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
    /// Lógica de interacción para AdmRoute.xaml
    /// </summary>
    public partial class AdmRoute : UserControl
    {
        public AdmRoute()
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

            Button deleteButton = new Button();

            Style myButtonStyle = new Style(typeof(Button), (Style)FindResource(typeof(Button)));
            myButtonStyle.Setters.Add(new Setter(Button.BackgroundProperty, Brushes.Red));
            myButtonStyle.Setters.Add(new Setter(Button.BorderBrushProperty, Brushes.Red));
            deleteButton.Style = myButtonStyle;


            deleteButton.Content = "Delete";
            deleteButton.Width = 75;
            deleteButton.Height = 30;
            deleteButton.Click += myButton_Click;

            Grid.SetRow(deleteButton, 2);
            Grid.SetColumn(deleteButton, 1);


            StackPanel stackPanelBtn = new StackPanel();
            stackPanelBtn.Orientation = Orientation.Horizontal;

            Grid.SetRow(stackPanelBtn, 2);
            Grid.SetColumn(stackPanelBtn, 1);

            Button changeButton = new Button();

            Style myButtonChangeStyle = new Style(typeof(Button), (Style)FindResource(typeof(Button)));
            myButtonChangeStyle.Setters.Add(new Setter(Button.BackgroundProperty, Brushes.DarkOliveGreen));
            myButtonChangeStyle.Setters.Add(new Setter(Button.BorderBrushProperty, Brushes.DarkOliveGreen));
            changeButton.Style = myButtonChangeStyle;


            changeButton.Content = "Change Route Name";
            changeButton.Width = 180;
            changeButton.Height = 30;
            changeButton.Click += myButton_Click;

            Grid.SetRow(changeButton, 2);
            Grid.SetColumn(changeButton, 1);

            stackPanelBtn.Children.Add(deleteButton);
            stackPanelBtn.Children.Add(changeButton);

            postGrid.Children.Add(valorationText);
            postGrid.Children.Add(stackPanelBtn);

            scroll.Content = postGrid;


        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
