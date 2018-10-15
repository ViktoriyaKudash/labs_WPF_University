namespace Lab12
{
	public class FigureFactory : AbstractFigureFactory
    {
        public override AbstractCircle CreateCircle()
        {
            return new Circle();
        }

        public override AbstractRectangle CreateRectangle()
        {
            return new Rectangle();
        }
    }
}
