using System.Windows.Input;

namespace Lab12
{
    public class ChangeColorState : IObjectState
    {
        public void HandleInput(AbstractFigure hero, Key input)
        {
            if (input == Key.Q)
            {
                hero.ChangeState(new IdleState());
            }
        }

        public void Update(AbstractFigure hero)
        {
            var command = new ChangeColorCommand(hero);
            command.Execute();
        }
    }
}
