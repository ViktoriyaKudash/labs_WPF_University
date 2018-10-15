using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Lab12
{
    public abstract class AbstractFigure : IComponent
    {
        protected Shape shape;
        private IObjectState state;
        private Memento memento;

        public virtual Brush Fill { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public virtual Shape Shape
        {
            get
            {
                return CreateShape();
            }
        }

        public AbstractFigure()
        {
            state = new IdleState();
        }

        public abstract AbstractFigure Clone();

        public IComponent Find(Shape shape)
        {
            return null;
        }

        protected abstract Shape CreateShape();

        public void ChangeState(IObjectState state)
        {
            this.state = state;
        }

        public void HandleInput(Key input)
        {
            if (input == Key.S)
            {
                Save();
                return;
            }
            else if (input == Key.R)
            {
                Restore();
                return;
            }

            state.HandleInput(this, input);
            Update();
        }

        private void Restore()
        {
            if (memento != null)
            {
                Fill = memento.Fill;
                Shape.Fill = memento.Fill;

                Canvas.SetLeft(Shape, memento.Position.X);
                Canvas.SetTop(Shape, memento.Position.Y);
            }
        }

        private void Save()
        {
            memento = new Memento()
            {
                Fill = Fill,
                Position = new Vector(Canvas.GetLeft(Shape), Canvas.GetTop(Shape))
            };
        }

        private void Update()
        {
            state.Update(this);
        }
    }
}
