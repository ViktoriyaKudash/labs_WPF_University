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

using Microsoft.Win32;
using System.IO;

namespace Lab4_5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow(int v)
        {
           
            InitializeComponent();
           
        }
      

        private void Font_Size_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                if (Font_Size.IsFocused && Font_Size.Value > 0)
                {
                    TextRange tr = new TextRange(MainText.Document.ContentStart, MainText.Document.ContentEnd);

                    tr.ApplyPropertyValue(FontSizeProperty, Font_Size.Value);
                }
                else if (Font_Size.Value == 0)
                {
                    MessageBox.Show("ошибка, размер не может быть отрицательным.");
                    Font_Size.Value = 12;
                }
            }
            catch
            {
                MessageBox.Show("ошибка");
            }
        }
        private void FontTypes_GotFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (FontTypes.IsFocused)
                {
                    switch (FontTypes.SelectedIndex)
                    {
                        case 0:
                            {
                                TextRange tr = new TextRange(MainText.Document.ContentStart, MainText.Document.ContentEnd);
                                tr.ApplyPropertyValue(FontFamilyProperty, "Arial");
                                break;
                            }
                        case 1:
                            {
                                TextRange tr = new TextRange(MainText.Document.ContentStart, MainText.Document.ContentEnd);
                                tr.ApplyPropertyValue(FontFamilyProperty, "Calibri");
                                break;
                            }
                        case 2:
                            {
                                TextRange tr = new TextRange(MainText.Document.ContentStart, MainText.Document.ContentEnd);
                                tr.ApplyPropertyValue(FontFamilyProperty, "Times New Roman");
                                break;
                            }
                        case 3:
                            {
                                TextRange tr = new TextRange(MainText.Document.ContentStart, MainText.Document.ContentEnd);
                                tr.ApplyPropertyValue(FontFamilyProperty, "Bauhaus 93");
                                break;
                            }
                        case 4:
                            {
                                TextRange tr = new TextRange(MainText.Document.ContentStart, MainText.Document.ContentEnd);
                                tr.ApplyPropertyValue(FontFamilyProperty, "Broadway");
                                break;
                            }
                    }
                }
            }
            catch
            {
                MessageBox.Show("ошибка");
            }
        }

        private void Font_Size_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (FontTypes.IsFocused)
                {
                    switch (FontTypes.SelectedIndex)
                    {
                        case 0:
                            {
                                TextRange tr = new TextRange(MainText.Document.ContentStart, MainText.Document.ContentEnd);
                                tr.ApplyPropertyValue(FontFamilyProperty, "Arial");
                                break;
                            }
                        case 1:
                            {
                                TextRange tr = new TextRange(MainText.Document.ContentStart, MainText.Document.ContentEnd);
                                tr.ApplyPropertyValue(FontFamilyProperty, "Calibri");
                                break;
                            }
                        case 2:
                            {
                                TextRange tr = new TextRange(MainText.Document.ContentStart, MainText.Document.ContentEnd);
                                tr.ApplyPropertyValue(FontFamilyProperty, "Times New Roman");
                                break;
                            }
                        case 3:
                            {
                                TextRange tr = new TextRange(MainText.Document.ContentStart, MainText.Document.ContentEnd);
                                tr.ApplyPropertyValue(FontFamilyProperty, "Bauhaus 93");
                                break;
                            }
                        case 4:
                            {
                                TextRange tr = new TextRange(MainText.Document.ContentStart, MainText.Document.ContentEnd);
                                tr.ApplyPropertyValue(FontFamilyProperty, "Broadway");
                                break;
                            }
                    }
                }
            }
            catch
            {
                MessageBox.Show("ОШИБКА");
            }
        }
      
      
    

        private void Font_Size_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Font_Size.IsFocused)
            {
                ToolTip = Font_Size.Value.ToString();
            }

        }
        private void Bold_Unchecked(object sender, RoutedEventArgs e)
        {
            MainText.FontWeight = FontWeights.Normal;
        }

        private void Italic_Unchecked(object sender, RoutedEventArgs e)
        {
            MainText.FontStyle = FontStyles.Normal;
        }

        private void UnderLine_Unchecked(object sender, RoutedEventArgs e)
        {

        }
        private void Color_Chenge(object sender, RoutedEventArgs e)
        {
            var Selection = MainText.Selection;
            Selection.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush((Color)BackColor.SelectedColor));

        }
        private void ChangeFontSize()
        {
            TextRange tr = new TextRange(MainText.Document.ContentStart, MainText.Document.ContentEnd);
            tr.ApplyPropertyValue(FontSizeProperty, Font_Size.Value);
        }

        private void FontSizeTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                double value;
                if (this.FontSizeTextBox.Text.Equals(String.Empty))
                {
                    Font_Size.Value = 12;
                    this.FontSizeTextBox.Text = Font_Size.Value.ToString();
                    throw new Exception("напишите размер");
                }
                if ((value = Convert.ToDouble(this.FontSizeTextBox.Text)) < 0 && value > 100)
                {
                    MessageBox.Show("некорректный размер");
                }
                else
                {
                    this.Font_Size.Value = Convert.ToDouble(this.FontSizeTextBox.Text);
                    ChangeFontSize();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error: " + ex.Message);
            }
        }
    }
}
