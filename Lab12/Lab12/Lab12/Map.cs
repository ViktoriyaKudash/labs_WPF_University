using System.Collections.Generic;
using System.Linq;
using System.Windows.Shapes;

namespace Lab12
{
    public class Map : IComponent
    {
        private readonly List<IComponent> map = new List<IComponent>();

        public Shape Shape
        {
            get { return null; }
        }

        public IComponent Find(Shape shape)
        {
            return map.FirstOrDefault(t => t.Shape == shape);
        }

        public void Add(IComponent component)
        {
            map.Add(component);
        }

        public List<IComponent> GetAll()
        {
            return map;
        }
    }
}
