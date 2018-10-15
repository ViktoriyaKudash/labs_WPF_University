using System.Windows.Shapes;

namespace Lab12
{
	public abstract class AbstractRectangle : AbstractFigure
    {
        protected override Shape CreateShape()
        {
            if (shape == null)
            {
                System.Windows.Shapes.Rectangle rectangle = new System.Windows.Shapes.Rectangle();
                rectangle.Width = Width;
                rectangle.Height = Height;
                rectangle.Fill = Fill;
                shape = rectangle;
            }

            return shape;
        }
    }
}
