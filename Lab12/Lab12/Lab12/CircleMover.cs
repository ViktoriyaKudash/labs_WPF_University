using System.Windows;
using System.Windows.Controls;

namespace Lab12
{
    public class CircleMover
    {
        public static void MoveCircle(AbstractCircle circle, Vector vector)
        {
            if (vector.X != 0)
            {
                Canvas.SetLeft(circle.Shape, Canvas.GetLeft(circle.Shape) + vector.X);
            }
            if (vector.Y != 0)
            {
                Canvas.SetTop(circle.Shape, Canvas.GetTop(circle.Shape) + vector.Y);
            }
        }
    }
}
