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
using Color = System.Windows.Media.Color;
using ColorConverter = System.Windows.Media.ColorConverter;

namespace App.MVVM.View
{
    /// <summary>
    /// Lógica de interacción para CommentsView.xaml
    /// </summary>
    public partial class CommentsView : Window
    {
        List<Coment> comments = new List<Coment>();
        public CommentsView()
        {
            InitializeComponent();
        }

        public void generateView()
        {


            foreach(Coment coment in comments)


            {
                Grid mainGrid = new Grid
                {
                    Height = 270,
                    Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#56AB91")),
                    Width = 550,
                    Margin = new Thickness(0, 0, 0, 10),
                    Tag = coment._id,
                };

                mainGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                mainGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                mainGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });

                StackPanel initPanel = new StackPanel();
                initPanel.Orientation = Orientation.Horizontal;

                TextBlock userText = new TextBlock
                {
                    FontSize = 15,
                    Text = coment.user,
                    HorizontalAlignment = HorizontalAlignment.Left,
                };
                TextBlock dateText = new TextBlock
                {
                    FontSize = 15,
                    Text = coment.date,
                    HorizontalAlignment = HorizontalAlignment.Left,
                };
                initPanel.Children.Add(userText);
                initPanel.Children.Add(dateText);

                Grid.SetRow(initPanel, 1);
                mainGrid.Children.Add(initPanel);

                TextBlock descriptionText = new TextBlock
                {
                    Text = coment.description,
                    TextWrapping = TextWrapping.Wrap,
                    Margin = new Thickness(0, 0, 100, 0),
                };
                Grid.SetRow(descriptionText, 1);
                mainGrid.Children.Add(descriptionText);



            }
        }
        //FIN GENERATE
    }
}
