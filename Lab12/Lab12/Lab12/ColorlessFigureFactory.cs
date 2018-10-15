namespace Lab12
{
	public class ColorlessFigureFactory : AbstractFigureFactory
    {
        public override AbstractCircle CreateCircle()
        {
            return new ColorlessCircle();
        }

        public override AbstractRectangle CreateRectangle()
        {
            return new ColorlessRectangle();
        }
    }
}
