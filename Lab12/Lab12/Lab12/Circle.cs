namespace Lab12
{
	public class Circle : AbstractCircle
    {
        public Circle()
        {
            Fill = RandomColor.GetRandomColor();
            Width = 50;
            Height = 50;
        }

        public Circle(Circle circle)
        {
            Width = circle.Width;
            Height = circle.Height;
            Fill = circle.Fill;
        }

        public override AbstractFigure Clone()
        {
            return new Circle(this);
        }
    }
}
