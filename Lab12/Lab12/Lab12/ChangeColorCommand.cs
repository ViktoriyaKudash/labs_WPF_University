namespace Lab12
{
    public class ChangeColorCommand : ICommand
    {
        private AbstractFigure hero;

        public ChangeColorCommand(AbstractFigure hero)
        {
            this.hero = hero;
        }

        public void Execute()
        {
            var color = RandomColor.GetRandomColor();

            hero.Fill = color;
            hero.Shape.Fill = color;
        }
    }
}
