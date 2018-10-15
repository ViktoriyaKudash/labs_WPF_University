using System.Windows.Input;

namespace Lab12
{
    public class IdleState : IObjectState
    {
        public void HandleInput(AbstractFigure hero, Key input)
        {
            if (input == Key.Up ||
                input == Key.Down ||
                input == Key.Left ||
                input == Key.Right)
            {
                hero.ChangeState(new MovementState(input));
            }
            else if(input == Key.Q)
            {
                hero.ChangeState(new ChangeColorState());
            }
        }

        public void Update(AbstractFigure hero)
        {

        }
    }
}
