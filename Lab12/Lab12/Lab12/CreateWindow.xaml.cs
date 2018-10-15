using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace Lab12
{
    public partial class CreateWindow : Window
    {
        public CreateWindow()
        {
            InitializeComponent();

            comboBoxType.ItemsSource = new List<string>()
            {
                FigureType.Rectangle.ToString(),
                FigureType.Circle.ToString()
            };
        }

        public FigureType Type { get; private set; }
        public int Count { get; private set; }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Button_Click_Ok(object sender, RoutedEventArgs e)
        {
            if (Enum.TryParse((string)comboBoxType.SelectedValue, out FigureType type))
            {
                Type = type;
            }
            if (int.TryParse(textBoxCount.Text, out int count))
            {
                Count = count;
            }
            DialogResult = true;
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
