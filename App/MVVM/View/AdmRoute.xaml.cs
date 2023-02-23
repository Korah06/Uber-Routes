using App.Core;
using App.MVVM.Model;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
        DataProvider ejemplo = new DataProvider();
        List<Post> posts = new List<Post>();

        string filePath;
        public async void getterPosts()
        {
            posts = await ejemplo.GetPosts();

            if(posts != null)
            {
                foreach (Post post in posts)
                {
                    comboBoxId.Items.Add(post._id);

                    
                }
                makePageGrid();
            }
            


        }

        

        public AdmRoute()
        {
            getterPosts();
            InitializeComponent();
            comboBoxCat.Items.Add("Ciclismo");
            comboBoxCat.Items.Add("Senderismo");
            comboBoxCat.Items.Add("Kayac");
            comboBoxCat.Items.Add("Natacion");
        }

        private void makePageGrid()
        {
            foreach (Post post in posts)
            {
                SolidColorBrush fondo;
                if (comboBoxId.SelectedValue != post._id)
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
                gridBorder.CornerRadius = new CornerRadius(7);
                gridBorder.Margin = new Thickness(0, 5, 20, 5);
                gridBorder.Height = 270;
                gridBorder.Width = 890;


                Grid postGrid = new Grid
                {
                    Height = 270,
                    Background = fondo,
                    Width = 890,
                    Margin = new Thickness(0, 0, 0, 10),
                    Tag = post._id,
                };



                postGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                postGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                postGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                postGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                postGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
                postGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
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
                    Source = new BitmapImage(new Uri("http://localhost:9999/posts/img/" + post.image, UriKind.RelativeOrAbsolute))
                };
                Grid.SetRow(image, 1);
                Grid.SetColumn(image, 0);
                postGrid.Children.Add(image);

                TextBlock descriptionText = new TextBlock
                {
                    Text = post.description,
                    TextWrapping = TextWrapping.Wrap,
                    Margin = new Thickness(10,0,50,0),
                };
                Grid.SetRow(descriptionText, 1);
                Grid.SetColumn(descriptionText, 1);
                Grid.SetColumnSpan(descriptionText,2);
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

                TextBlock dateText = new TextBlock { Text = "Date: " + post.date };
                creatorAndDate.Children.Add(creatorText);
                creatorAndDate.Children.Add(dateText);
                Grid.SetRow(creatorAndDate, 2);
                Grid.SetColumn(creatorAndDate, 0);
                postGrid.Children.Add(creatorAndDate);

                Button commentButton = new Button();
                commentButton.Name = "commentButton";
                commentButton.HorizontalAlignment = HorizontalAlignment.Right;
                commentButton.BorderThickness = new Thickness(0);
                commentButton.Content = "Ver comentarios";
                commentButton.Foreground = Brushes.White;
                commentButton.FontSize = 10;
                commentButton.FontFamily = new FontFamily("Montserrat");
                commentButton.Cursor = Cursors.Hand;
                commentButton.Margin = new Thickness(0, 0, 20, 0);
                commentButton.Click += commentButton_Click;

                Style buttonStyle = new Style(typeof(Button));
                buttonStyle.Setters.Add(new Setter(Button.BackgroundProperty, new SolidColorBrush(Color.FromRgb(53, 143, 128))));
                Trigger mouseOverTrigger = new Trigger() { Property = Button.IsMouseOverProperty, Value = true };
                mouseOverTrigger.Setters.Add(new Setter(Button.BackgroundProperty, new SolidColorBrush(Color.FromRgb(39, 139, 239))));
                buttonStyle.Triggers.Add(mouseOverTrigger);
                commentButton.Style = buttonStyle;

                ControlTemplate buttonTemplate = new ControlTemplate(typeof(Button));
                FrameworkElementFactory borderFactory = new FrameworkElementFactory(typeof(Border));
                borderFactory.SetValue(Border.WidthProperty, 90.0);
                borderFactory.SetValue(Border.HeightProperty, 20.0);
                borderFactory.SetValue(Border.CornerRadiusProperty, new CornerRadius(10));
                borderFactory.SetValue(Border.BackgroundProperty, new TemplateBindingExtension(Button.BackgroundProperty));
                FrameworkElementFactory contentPresenterFactory = new FrameworkElementFactory(typeof(ContentPresenter));
                contentPresenterFactory.SetValue(ContentPresenter.VerticalAlignmentProperty, VerticalAlignment.Center);
                contentPresenterFactory.SetValue(ContentPresenter.HorizontalAlignmentProperty, HorizontalAlignment.Center);
                borderFactory.AppendChild(contentPresenterFactory);
                buttonTemplate.VisualTree = borderFactory;
                commentButton.Template = buttonTemplate;

                void commentButton_Click(object sender, RoutedEventArgs e)
                {
                    CommentsView commentsView = new CommentsView(post._id);
                    commentsView.Show();
                }


                Grid.SetRow(commentButton,3);
                Grid.SetColumn(commentButton, 3);
                postGrid.Children.Add(commentButton);

                postGrid.MouseLeftButtonDown += new MouseButtonEventHandler(postgrid_MouseDown);

                void postgrid_MouseDown(object sender, MouseEventArgs e)
                {
                    comboBoxId.SelectedValue = postGrid.Tag;
                }

                gridBorder.Child = postGrid;
                stackPanel.Children.Add(gridBorder);

                if(comboBoxId.SelectedValue == postGrid.Tag)
                {
                    postGrid.Focus();
                }



            }
        }

        public void deleteComponents()
        {
            stackPanel.Children.Clear();
        }



        public async void rechargePage()
        {
            posts = await ejemplo.GetPosts();
            foreach (Post post in posts)
            {
                comboBoxId.Items.Add(post._id);

            }

            deleteComponents();
            makePageGrid();

        }
        private void comboBoxId_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            deleteComponents();
            makePageGrid();


            foreach(Post post in posts)
            {
                if(post._id == comboBoxId.SelectedValue)
                {
                    comboBoxCat.SelectedItem = post.category;
                    //catText.Text = post.category;
                    distText.Text = post.distance;
                    nameText.Text = post.name;
                    diffText.Text = post.difficulty;
                    break;
                }
            }

        }

        private void btnImage_Click(object sender, RoutedEventArgs e)
        {
            Post postSend = null;

            foreach (Post post in posts)
            {
                if (post._id == comboBoxId.SelectedValue)
                {
                    postSend = post;
                    ejemplo.UploadPostImg(postSend);
                }
            }
            

            rechargePage();

            comboBoxCat.SelectedIndex = -1;
            //catText.Text = "";
            distText.Text = "";
            nameText.Text = "";
            diffText.Text = "";


        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Post postUpdate = null;

            foreach (Post post in posts)
            {
                if (post._id == comboBoxId.SelectedValue)
                {
                    postUpdate = post;
                    postUpdate.distance = distText.Text;
                    postUpdate.category = comboBoxCat.Text;
                    //postUpdate.category = catText.Text;
                    postUpdate.name = nameText.Text;
                    postUpdate.difficulty = diffText.Text;
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
            Post postDelete = null;

            foreach (Post post in posts)
            {
                if (post._id == comboBoxId.SelectedValue)
                {
                    postDelete = post;
                }
            }

            if(postDelete == null)
            {
                MessageBox.Show("No se ha seleccionado ningúna publicación");
            }
            else
            {
                DataProvider a = new DataProvider();
                a.deletePost(postDelete);
                rechargePage();
            }

            
        }
    }
}
