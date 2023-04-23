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

namespace Debugging_of_individual_modules_of_a_software_project
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public BitmapImage image = new BitmapImage(new Uri("C:\\Users\\Даниил\\source\\repos\\Debugging_of_individual_modules_of_a_software project\\Debugging_of_individual_modules_of_a_software project\\Images\\product-ia-00281-1.jpg", UriKind.Relative));
        public BitmapImage image1 = new BitmapImage(new Uri("C:\\Users\\Даниил\\source\\repos\\Debugging_of_individual_modules_of_a_software project\\Debugging_of_individual_modules_of_a_software project\\Images\\значок-ве-икобритании-ф-ага-к-ассический-ве-икобританский-87766473.jpg", UriKind.Relative));
        
        public MainWindow()
        {
            InitializeComponent();


            ImageBrush brush = new ImageBrush(image);
            FillRect.Fill = brush;

            //ImageBrush brush = new ImageBrush(image);
            //brush.Viewport = new Rect(0, 0, 0.25, 0.25);
            //brush.ViewportUnits = BrushMappingMode.RelativeToBoundingBox;
            //brush.TileMode = TileMode.Tile;
            //FillRect.Fill = brush;



        }

        private void ButRename_Click(object sender, RoutedEventArgs e)
        {
            if(NameFlag.Text == "Флаг России")
            {
                NameFlag.Text = "Флаг Англии";
            }
            else
            {
                NameFlag.Text = "Флаг России";
            }
        }

        private void Mozaika_Click(object sender, RoutedEventArgs e)
        {
            
            
            if (NameFlag.Text == "Флаг России")
            {
                ImageBrush brush = new ImageBrush(image);
                brush.Viewport = new Rect(0, 0, 0.25, 0.25);
                brush.ViewportUnits = BrushMappingMode.RelativeToBoundingBox;
                brush.TileMode = TileMode.Tile;
                FillRect.Fill = brush;
                
            }
            else
            {
                ImageBrush brush2 = new ImageBrush(image1);
                brush2.Viewport = new Rect(0, 0, 0.25, 0.25);
                brush2.ViewportUnits = BrushMappingMode.RelativeToBoundingBox;
                brush2.TileMode = TileMode.Tile;
                FillRect.Fill = brush2;
            }
           
            

        }

        private void FlagRenName_Click(object sender, RoutedEventArgs e)
        {
            ImageBrush brush = new ImageBrush(image1);
            if (NameFlag.Text == "Флаг России")
            {
                NameFlag.Text = "Флаг Англии";
                FillRect.Fill = brush;
            }
            else
            {
                ImageBrush brush1 = new ImageBrush(image);
                NameFlag.Text = "Флаг России";
                FillRect.Fill = brush1;
                
            }
        }

        private void ImageRight_Click(object sender, RoutedEventArgs e)
        {
            if(NameFlag.Text == "Флаг России")
            {
                ImageBrush brush = new ImageBrush(image);
                TranslateTransform transform = new TranslateTransform();
                transform.X = 40;
                transform.Y = 130;
                brush.Transform = transform;
                FillRect.Fill = brush;
            }
            else
            {
                ImageBrush brush = new ImageBrush(image1);
                TranslateTransform transform = new TranslateTransform();
                transform.X = 20;
                transform.Y = 60;
                brush.Transform = transform;
                FillRect.Fill = brush;
            }

           
        }
    }
}
