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

namespace lr6
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        int c = 1;
        public MainWindow(int v)
        {
            c = v + 1;
            InitializeComponent();
            Uri iconUri = new Uri("pack://application:,,,/Resources/BI.ico");
            this.Icon = BitmapFrame.Create(iconUri);
            MainText.AddHandler(RichTextBox.DragOverEvent, new DragEventHandler(DragItem), true);
            MainText.AddHandler(RichTextBox.DropEvent, new DragEventHandler(DropItem), true);
        }
        public MainWindow()
        {
            InitializeComponent();

            List<string> styles = new List<string> { "Day", "night" };
            Theme.SelectionChanged += Theme_SelectionChanged;
            Theme.ItemsSource = styles;
            Theme.SelectedItem = "night";

            Uri iconUri = new Uri("pack://application:,,,/Resources/BI.ico");
            this.Icon = BitmapFrame.Create(iconUri);
            MainText.AddHandler(RichTextBox.DragOverEvent, new DragEventHandler(DragItem), true);
            MainText.AddHandler(RichTextBox.DropEvent, new DragEventHandler(DropItem), true);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    FileName = "text.txt",
                    InitialDirectory = "D:\\УНИВЕР\\2kurs\\2semestr\\STPMS\\lr4"
                };
                saveFileDialog.Filter = "Text Files (*.txt)|*.txt|RichText Files (*.rtf)|*.rtf|XAML Files (*.xaml)|*.xaml|All files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == true)
                {
                    TextRange textRange = new TextRange(MainText.Document.ContentStart, MainText.Document.ContentEnd);
                    using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.OpenOrCreate))
                    {
                        if (Path.GetExtension(saveFileDialog.FileName).ToLower() == ".rtf")
                            textRange.Save(fs, DataFormats.Rtf);
                        else if (Path.GetExtension(saveFileDialog.FileName).ToLower() == ".txt")
                            textRange.Save(fs, DataFormats.Text);
                        else
                            textRange.Save(fs, DataFormats.Xaml);
                    }
                }
                else
                {
                    throw new Exception("неправильное расширение");
                }
            }
            catch
            {
                MessageBox.Show("ошибка сохранения");
            }
        }
        //private void lbl1_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    Label lbl = (Label)sender;
        //    DragDrop.DoDragDrop(lbl, lbl.Content, DragDropEffects.Copy);
        //}

        //private void txtTarget_Drop(object sender, DragEventArgs e)
        //{
        //    ((TextBlock)sender).Text = (string)e.Data.GetData(DataFormats.Text);
        //}

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

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    FileName = "text.txt",
                    InitialDirectory = "D:\\УНИВЕР\\2kurs\\2semestr\\STPMS\\lr4"
                };
                openFileDialog.Filter = "Text Files (*.txt)|*.txt|RichText Files (*.rtf)|*.rtf|XAML Files (*.xaml)|*.xaml|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == true)
                {
                    TextRange textRange = new TextRange(MainText.Document.ContentStart, MainText.Document.ContentEnd);
                    using (FileStream fs = new FileStream(openFileDialog.FileName, FileMode.OpenOrCreate))
                    {
                        if (Path.GetExtension(openFileDialog.FileName).ToLower() == ".rtf")
                            textRange.Load(fs, DataFormats.Rtf);
                        else if (Path.GetExtension(openFileDialog.FileName).ToLower() == ".txt")
                            textRange.Load(fs, DataFormats.Text);
                        else
                            textRange.Load(fs, DataFormats.Xaml);
                    }

                    if (lr4.Properties.Settings.Default.UsedFiles == null)
                    {
                        lr4.Properties.Settings.Default.UsedFiles = new System.Collections.Specialized.StringCollection();
                    }

                    if (lr4.Properties.Settings.Default.UsedFiles.Count >= 5)
                    {
                        lr4.Properties.Settings.Default.UsedFiles.RemoveAt(0);
                    }

                    lr4.Properties.Settings.Default.UsedFiles.Add(openFileDialog.FileName);
                    lr4.Properties.Settings.Default.Save();
                }
                else
                {
                    throw new Exception("неправильное расширение");
                }
            }
            catch
            {
                MessageBox.Show("ошибка сохранения");
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
        private void SetRussian(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Resources = new ResourceDictionary()
                {
                    Source = new
                        Uri("pack://application:,,,/resources/RU.xaml")
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("ОШибка: " + ex.Message);
            }
        }

        private void SetEnglish(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Resources = new ResourceDictionary()
                {
                    Source = new
                    Uri("pack://application:,,,/resources/EN.xaml")
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("ОШИбка: " + ex.Message);
            }
        }
        private void NewWind(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow(c);

            mw.Title = "Window" + c.ToString();
            mw.Show();
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
        private void DragItem(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effects = DragDropEffects.All;
            }
            else
            {
                e.Effects = DragDropEffects.None;
            }
            e.Handled = false;
        }

        private void DropItem(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    string[] docPath = (string[])e.Data.GetData(DataFormats.FileDrop);
                    if (System.IO.File.Exists(docPath[0]))
                    {
                        try
                        {
                            TextRange range = new TextRange(MainText.Document.ContentStart, MainText.Document.ContentEnd);
                            FileStream fStream = new FileStream(docPath[0], FileMode.OpenOrCreate);
                            range.Load(fStream, DataFormats.Rtf);
                            fStream.Close();
                            this.Title = "Text Editor (" + docPath[0] + ") ";
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("File could not be opened. Make sure the file is a text file.");
                        }
                    }
                }
            }
        }
        private int Count_simbols()
        {
            string stroka= new TextRange(MainText.Document.ContentStart, MainText.Selection.End).Text;
            int l=stroka.Length;
            return 0;

        }

        private void File_Click(object sender, RoutedEventArgs e)
        {
            usedFilesMenuItem.Items.Clear();
            if (lr4.Properties.Settings.Default.UsedFiles != null)
            {
                foreach (var item in lr4.Properties.Settings.Default.UsedFiles)
                {
                    usedFilesMenuItem.Items.Add(new MenuItem() { Header = item });
                }
            }
        }

        private void Theme_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string style = Theme.SelectedItem as string;

            var uri = new Uri("Resources\\" + style + ".xaml", UriKind.Relative);

            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;

            Application.Current.Resources.Clear();

            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }
        
    }
}
