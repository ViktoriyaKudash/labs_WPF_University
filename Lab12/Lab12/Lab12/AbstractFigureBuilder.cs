namespace Lab12
{
    public abstract class AbstractFigureBuilder
    {
        public abstract void BuildPartA(AbstractFigureFactory factory);
        public abstract void BuildPartB(AbstractFigureFactory factory);
        public abstract ComplexFigure GetResult();
    }
}
