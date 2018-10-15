using System;
using System.Windows.Media;

namespace Lab12
{
	public static class RandomColor
    {
        private static Random r = new Random();

        public static Brush GetRandomColor()
        {
            return new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255), (byte)r.Next(1, 255), (byte)r.Next(1, 233)));
        }
    }
}
