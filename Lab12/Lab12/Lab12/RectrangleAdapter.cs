using System.Windows.Shapes;

namespace Lab12
{
    public class RectrangleAdapter : AbstractCircle
    {
        private AbstractRectangle rectangle;

        public RectrangleAdapter(AbstractRectangle rectangle)
        {
            this.rectangle = rectangle;
        }

        public override Shape Shape
        {
            get
            {
                return rectangle.Shape;
            }
        }

        public override AbstractFigure Clone()
        {
            return null;
        }
    }
}
