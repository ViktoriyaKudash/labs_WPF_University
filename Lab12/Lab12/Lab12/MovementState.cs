using System.Windows;
using System.Windows.Input;

namespace Lab12
{
    public class MovementState : IObjectState
    {
        private Key input;

        public MovementState(Key input)
        {
            this.input = input;
        }

        public void HandleInput(AbstractFigure hero, Key input)
        {
            if (input == Key.Up ||
                input == Key.Down ||
                input == Key.Left ||
                input == Key.Right)
            {
                hero.ChangeState(new MovementState(input));
            }
            else if (input == Key.Q)
            {
                hero.ChangeState(new ChangeColorState());
            }
        }

        public void Update(AbstractFigure hero)
        {
            ICommand command = null;

            switch (input)
            {
                case Key.Left:
                    command = new MoveCommand(hero, new Vector(-20, 0));
                    break;

                case Key.Up:
                    command = new MoveCommand(hero, new Vector(0, -20));
                    break;

                case Key.Right:
                    command = new MoveCommand(hero, new Vector(20, 0));
                    break;

                case Key.Down:
                    command = new MoveCommand(hero, new Vector(0, 20));
                    break;
            }

            if (command != null)
            {
                command.Execute();
            }
        }
    }
}
