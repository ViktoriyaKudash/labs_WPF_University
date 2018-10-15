using System.Windows;

namespace Lab12
{
    public class MoveCommand : ICommand
    {
        private AbstractFigure hero;
        private Vector vector;

        public MoveCommand(AbstractFigure hero, Vector vector)
        {
            this.hero = hero;
            this.vector = vector;
        }

        public void Execute()
        {
            AbstractCircle target = null;

            if (hero is AbstractCircle)
            {
                target = hero as AbstractCircle;
            }
            else if (hero is AbstractRectangle)
            {
                target = new RectrangleAdapter(hero as AbstractRectangle);
            }
            else
            {
                return;
            }

            CircleMover.MoveCircle(target, vector);
        }
    }
}
