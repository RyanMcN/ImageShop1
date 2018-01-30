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
using System.Drawing;
using System.Drawing.Imaging;


namespace ImageShop1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            try
            {
                ImageSource imSource = new BitmapImage(new Uri(Tboxx.Text));
                imageBoxx.Source = imSource;
                Bitmap imgg = (Bitmap)System.Drawing.Image.FromFile((@Tboxx.Text), true);
                //GetRedImage(0);//tookthisout to test new open image method

            }
            catch
            {
                MessageBox.Show("File Does Not Exist. Try Again!");
            }
        }
        int iii = 0;

        public void FilterTheImageMethod(int redVal, int greenVal, int blueVal)
        { //MessageBox.Show("you made it to here");
            Bitmap imgg = (Bitmap)System.Drawing.Image.FromFile((@Tboxx.Text), true);
            System.Drawing.Image sourceImage = imgg;
            using (Bitmap bmp = new Bitmap(sourceImage))
            using (Bitmap redBmp = new Bitmap(sourceImage.Width, sourceImage.Height))
            {
                //int tempVal = 0;
                // int tempRed = 0;
                int tempR;
                int tempG;
                int tempB;
                //byte red;
                // int bob = 0;
                for (int x = 0; x < bmp.Width; x++)
                {
                    for (int y = 0; y < bmp.Height; y++)
                    {
                        System.Drawing.Color pxl = bmp.GetPixel(x, y);
                        //Red
                        if ((pxl.R + redVal) >= 255)
                        {
                            tempR = 255;
                        }
                        else
                        {
                            tempR = pxl.R + redVal;
                        }
                        //Green
                        if ((pxl.G + greenVal) >= 255)
                        {
                            tempG = 255;
                        }
                        else
                        {
                            tempG = pxl.G + greenVal;
                        }
                        //Blue
                        if ((pxl.B + blueVal) >= 255)
                        {
                            tempB = 255;
                        }
                        else
                        {
                            tempB = pxl.B + blueVal;
                        }
                        System.Drawing.Color redPxl = System.Drawing.Color.FromArgb(tempR, tempG, tempB);

                        redBmp.SetPixel(x, y, redPxl);
                    }
                }

                iii++;

                string mystring = iii.ToString();

                //redBmp.Save(Tboxx.Text + "_REDD.bmp");
                //ImageSource newimSource = new BitmapImage(new Uri(Tboxx.Text + "_REDD.bmp"));
                redBmp.Save(Tboxx.Text + "_REDD" + mystring + ".bmp");
                ImageSource newimSource = new BitmapImage(new Uri(Tboxx.Text + "_REDD" + mystring + ".bmp"));
                imageBoxx.Source = newimSource;

            }
        }

        private void backSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int rednessVal = (int)backSliderRed.Value;
            int greenessVal = (int)backSliderGreen.Value;
            int bluenessVal = (int)backSliderBlue.Value;
            FilterTheImageMethod(rednessVal, greenessVal, bluenessVal);
        }






















    }
}
