using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Lab12
{
    public class ComplexFigure : AbstractFigure
    {
        private List<AbstractFigure> parts = new List<AbstractFigure>();

        public ComplexFigure()
        {
            Width = 50;
            Height = 50;
        }

        public ComplexFigure(ComplexFigure complexFigure)
        {
            parts = new List<AbstractFigure>(complexFigure.parts.Select(p => p.Clone()));
        }

        public void Add(AbstractFigure part)
        {
            parts.Add(part);
        }

        public override AbstractFigure Clone()
        {
            return new ComplexFigure(this);
        }

        protected override Shape CreateShape()
        {
            if (shape == null)
            {
                var path = new Path();
                
                var group = new GeometryGroup();

                foreach (var part in parts)
                {
                    var shape = part.Shape;

                    if (path.Fill == null)
                    {
                        path.Fill = shape.Fill;
                    }

					Geometry geometry = null;

					if(shape is System.Windows.Shapes.Rectangle)
					{
						var rect = shape as System.Windows.Shapes.Rectangle;

						RectangleGeometry rectangleGeometry = new RectangleGeometry();
						rectangleGeometry.Rect = new Rect(0, 0, rect.Width, rect.Height);

						geometry = rectangleGeometry;
					}

					if(shape is Ellipse)
					{
						var ellipse = shape as Ellipse;

						EllipseGeometry ellipseGeometry = new EllipseGeometry();
						ellipseGeometry.Center = new Point(0, 0);
						ellipseGeometry.RadiusX = ellipse.Width;
						ellipseGeometry.RadiusY = ellipse.Height;

						geometry = ellipseGeometry;
					}

					group.Children.Add(geometry);

				}

                path.Data = group;
                shape = path;
            }

            return shape;
        }
    }
}
