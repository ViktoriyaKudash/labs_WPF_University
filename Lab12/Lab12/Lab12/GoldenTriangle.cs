using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Lab12
{
	public class GoldenTriangle : AbstractFigure
    {
        private static GoldenTriangle instance;

        private GoldenTriangle()
        {
            Fill = Brushes.Gold;
        }

        public static GoldenTriangle Instance
        {
            get
            {
                return instance ?? (instance = new GoldenTriangle());
            }
        }

        public override AbstractFigure Clone()
        {
            return instance; //???
        }

        protected override Shape CreateShape()
        {
            if (shape == null)
            {
                Polygon polygon = new Polygon();
                polygon.Fill = Fill;
                polygon.Points = new PointCollection()
                {
                    new Point(0, -50),
                    new Point(50, 50),
                    new Point(-50, 50)
                };
                shape = polygon;
            }

            return shape;
        }
    }
}
