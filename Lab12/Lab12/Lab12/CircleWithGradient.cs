using System.Windows;
using System.Windows.Media;

namespace Lab12
{
    public class CircleWithGradient : AbstractCircleDecorator
    {
        private readonly Color[] colors;

        public CircleWithGradient(Circle circle, params Color[] colors) 
            : base(circle)
        {
            this.colors = colors;
        }

        public override Brush Fill
        {
            get
            {
                var stops = new GradientStopCollection();
                var offset = 0.0;

                foreach (var item in colors)
                {
                    stops.Add(new GradientStop()
                    {
                        Color = item,
                        Offset = offset + 0.1
                    });
                }

                var gradientBrush = new LinearGradientBrush()
                {
                    StartPoint = new Point(0.0, 0.5),
                    EndPoint = new Point(0.5, 0.9),
                    GradientStops = stops
                };

                return gradientBrush;
            }
            set { }
        }
    }
}
