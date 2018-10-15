using System.Linq;

namespace Lab12
{
	public class FigureDirector
    {
        private readonly AbstractFigureBuilder builder;
        private readonly AbstractFigureFactory factory;

        public FigureDirector(AbstractFigureBuilder builder, AbstractFigureFactory factory)
        {
            this.builder = builder;
            this.factory = factory;
        }

        public void Construct()
        {
            builder.BuildPartA(factory);
            builder.BuildPartB(factory);
        }
    }
}
