namespace Lab12
{
	public class ComplexBuilder : AbstractFigureBuilder
    {
        private ComplexFigure product = new ComplexFigure();

        public override void BuildPartA(AbstractFigureFactory factory)
        {
            product.Add(factory.CreateCircle());
        }

        public override void BuildPartB(AbstractFigureFactory factory)
        {
            product.Add(factory.CreateRectangle());
        }

        public override ComplexFigure GetResult()
        {
            return product;
        }
    }
}
