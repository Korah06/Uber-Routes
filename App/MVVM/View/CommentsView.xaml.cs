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
using System.Windows.Shapes;
using System.Xml.Linq;
using Brushes = System.Windows.Media.Brushes;
using Color = System.Windows.Media.Color;
using ColorConverter = System.Windows.Media.ColorConverter;
using Rectangle = System.Windows.Shapes.Rectangle;

namespace App.MVVM.View
{
    /// <summary>
    /// Lógica de interacción para CommentsView.xaml
    /// </summary>
    public partial class CommentsView : Window
    {
        List<Coment> comments = new List<Coment>();
        DataProvider provider = new DataProvider();
        string post;
        public CommentsView(string id)
        {
            post = id;
            getComments();
            InitializeComponent();
        }

        public async void getComments()
        {
            comments = await provider.getComments(post);
            if(comments != null)
            {
                cleanView();
                generateView();
            }
        }

        public void cleanView()
        {
            stackPanel.Children.Clear();
        }

        public async void delete(string comment)
        {
            provider.deleteComment(comment);
            getComments();
        }

        public void generateView()
        {
            foreach(Coment coment in comments)
            {
                Border gridBorder = new Border();
                gridBorder.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#56AB91"));
                gridBorder.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#56AB91"));
                gridBorder.BorderThickness = new Thickness(2);
                gridBorder.CornerRadius = new CornerRadius(7);
                gridBorder.Margin = new Thickness(0, 5, 20, 5);
                gridBorder.Height = Double.NaN;
                gridBorder.Width = 550;

                Grid mainGrid = new Grid
                {
                    Height = Double.NaN,
                    Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#56AB91")),
                    Width = 550,
                    Margin = new Thickness(5, 5, 5, 5),
                    Tag = coment._id,
                };

                mainGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                mainGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                mainGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });

                gridBorder.Child = mainGrid;

                Border initBorder = new Border();
                initBorder.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#14746F"));
                initBorder.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#14746F"));
                initBorder.BorderThickness = new Thickness(2);
                initBorder.CornerRadius = new CornerRadius(5);
                initBorder.Width = 530;
                initBorder.HorizontalAlignment = HorizontalAlignment.Left;

                Grid.SetRow(initBorder, 0);
                mainGrid.Children.Add(initBorder);


                StackPanel initPanel = new StackPanel();
                initPanel.Orientation = Orientation.Horizontal;
                initBorder.Child = initPanel;

                TextBlock userText = new TextBlock
                {
                    FontSize = 15,
                    Text = coment.user,
                    HorizontalAlignment = HorizontalAlignment.Left,
                };
                initPanel.Children.Add(userText);
                TextBlock dateText = new TextBlock
                {
                    FontSize = 10,
                    Margin = new Thickness(10, 0, 0, 0),
                    Opacity = 0.5,
                    Text = coment.date,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Bottom,
                };
                
                initPanel.Children.Add(dateText);

                TextBlock descriptionText = new TextBlock
                {
                    Text = coment.description,
                    TextWrapping = TextWrapping.Wrap,
                    Margin = new Thickness(0, 0, 10, 0),
                };
                Grid.SetRow(descriptionText, 1);
                mainGrid.Children.Add(descriptionText);

                Button deleteButton = new Button();
                deleteButton.Name = "commentButton";
                deleteButton.HorizontalAlignment = HorizontalAlignment.Right;
                deleteButton.BorderThickness = new Thickness(0);
                deleteButton.Content = "Eliminar comentario";
                deleteButton.Foreground = Brushes.White;
                deleteButton.FontSize = 10;
                deleteButton.Cursor = Cursors.Hand;
                deleteButton.Margin = new Thickness(0, 0, 20, 0);
                deleteButton.Click += deleteButton_Click;

                Style buttonStyle = new Style(typeof(Button));
                buttonStyle.Setters.Add(new Setter(Button.BackgroundProperty, new SolidColorBrush(Color.FromRgb(157, 2, 8))));
                Trigger mouseOverTrigger = new Trigger() { Property = Button.IsMouseOverProperty, Value = true };
                mouseOverTrigger.Setters.Add(new Setter(Button.BackgroundProperty, new SolidColorBrush(Color.FromRgb(208, 0, 0))));
                buttonStyle.Triggers.Add(mouseOverTrigger);
                deleteButton.Style = buttonStyle;

                ControlTemplate buttonTemplate = new ControlTemplate(typeof(Button));
                FrameworkElementFactory borderFactory = new FrameworkElementFactory(typeof(Border));
                borderFactory.SetValue(Border.WidthProperty, 100.0);
                borderFactory.SetValue(Border.HeightProperty, 20.0);
                borderFactory.SetValue(Border.CornerRadiusProperty, new CornerRadius(10));
                borderFactory.SetValue(Border.BackgroundProperty, new TemplateBindingExtension(Button.BackgroundProperty));
                FrameworkElementFactory contentPresenterFactory = new FrameworkElementFactory(typeof(ContentPresenter));
                contentPresenterFactory.SetValue(ContentPresenter.VerticalAlignmentProperty, VerticalAlignment.Center);
                contentPresenterFactory.SetValue(ContentPresenter.HorizontalAlignmentProperty, HorizontalAlignment.Center);
                borderFactory.AppendChild(contentPresenterFactory);
                buttonTemplate.VisualTree = borderFactory;
                deleteButton.Template = buttonTemplate;

                void deleteButton_Click(object sender, RoutedEventArgs e)
                {
                    delete(coment._id);
                }

                Grid.SetRow(deleteButton, 2);
                mainGrid.Children.Add(deleteButton);

                stackPanel.Children.Add(gridBorder);


            }
        }
        //FIN GENERATE

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
