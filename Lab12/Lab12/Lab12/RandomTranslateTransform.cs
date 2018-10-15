using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Lab12
{
	public static class RandomTranslateTransform
    {
        private static Random r = new Random();

        public static TranslateTransform GetTranslateTransform(Shape shape, Canvas canvas)
        {
			var minX = (int)(shape.ActualWidth * 2);
			var minY = (int)(shape.ActualHeight * 2);

			var maxX = (int)canvas.ActualWidth - minX;
			var maxY = (int)canvas.ActualHeight - minY;

			return new TranslateTransform()
            {
                X = r.Next(minX, maxX < minX ? minX + 1 : maxX),
                Y = r.Next(minY, maxY < minY ? minY + 1 : maxY)
            };
        }
    }
}
