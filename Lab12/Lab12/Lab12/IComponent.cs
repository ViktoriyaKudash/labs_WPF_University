using System.Windows.Shapes;

namespace Lab12
{

    public interface IComponent
    {
        Shape Shape { get; }
        IComponent Find(Shape shape);
    }
}
