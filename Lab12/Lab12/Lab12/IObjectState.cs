using System.Windows.Input;

namespace Lab12
{
    public interface IObjectState
    {
        void HandleInput(AbstractFigure hero, Key input);
        void Update(AbstractFigure hero);
    }
}
