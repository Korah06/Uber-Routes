﻿using App.Core;
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

            foreach (Post post in posts)
            {
                comboBoxId.Items.Add(post._id);

            }
            makePageGrid();


        }

        

        public AdmRoute()
        {
            getterPosts();
            InitializeComponent();
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
                gridBorder.Margin = new Thickness(0, 0, 20, 10);
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
                    Source = new BitmapImage(new Uri("http://localhost:9999/posts/img/" + post.image, UriKind.RelativeOrAbsolute))
                };
                Grid.SetRow(image, 1);
                Grid.SetColumn(image, 0);
                postGrid.Children.Add(image);

                TextBlock descriptionText = new TextBlock
                {
                    Text = post.description,
                    TextWrapping = TextWrapping.Wrap,
                    Margin = new Thickness(0,0,100,0),
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

                TextBlock dateText = new TextBlock { Text = "Date: " + post.date };
                creatorAndDate.Children.Add(creatorText);
                creatorAndDate.Children.Add(dateText);
                Grid.SetRow(creatorAndDate, 2);
                Grid.SetColumn(creatorAndDate, 0);
                postGrid.Children.Add(creatorAndDate);

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
                    catText.Text = post.category;
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
                }
            }

            

            DataProvider a = new DataProvider();
            a.UploadPostImg(postSend);

            rechargePage();
            
            catText.Text = "";
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
                    postUpdate.category = catText.Text;
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
