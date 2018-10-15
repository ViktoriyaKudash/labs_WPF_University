namespace Lab12
{
	public class Rectangle : AbstractRectangle
    {
        public Rectangle()
        {
            Fill = RandomColor.GetRandomColor();
            Width = 50;
            Height = 50;
        }

        public Rectangle(Rectangle rectangle)
        {
            Width = rectangle.Width;
            Height = rectangle.Height;
            Fill = rectangle.Fill;
        }

        public override AbstractFigure Clone()
        {
            return new Rectangle(this);
        }
    }
}
