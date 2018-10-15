using System.Windows.Media;

namespace Lab12
{
	public class ColorlessCircle : AbstractCircle
    {
        public ColorlessCircle()
        {
            Fill = Brushes.Gray;
            Width = 50;
            Height = 50;
        }

        public ColorlessCircle(ColorlessCircle circle)
        {
            Width = circle.Width;
            Height = circle.Height;
            Fill = circle.Fill;
        }

        public override AbstractFigure Clone()
        {
            return new ColorlessCircle(this);
        }
    }
}
