using System.Windows.Shapes;

namespace Lab12
{
	public abstract class AbstractCircle : AbstractFigure
    {
        protected override Shape CreateShape()
        {
            if (shape == null)
            {
                Ellipse ellipse = new Ellipse();
                ellipse.Width = Width;
                ellipse.Height = Height;
                ellipse.Fill = Fill;
                shape = ellipse;
            }

            return shape;
        }
    }
}
