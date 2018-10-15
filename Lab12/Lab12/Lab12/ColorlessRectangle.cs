using System.Windows.Media;

namespace Lab12
{
	public class ColorlessRectangle : AbstractRectangle
    {
        public ColorlessRectangle()
        {
            Fill = Brushes.Gray;
            Width = 50;
            Height = 50;
        }

        public ColorlessRectangle(ColorlessRectangle rectangle)
        {
            Width = rectangle.Width;
            Height = rectangle.Height;
            Fill = rectangle.Fill;
        }

        public override AbstractFigure Clone()
        {
            return new ColorlessRectangle(this);
        }
    }
}
