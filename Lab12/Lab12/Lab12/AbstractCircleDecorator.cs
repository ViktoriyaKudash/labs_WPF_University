namespace Lab12
{
    public abstract class AbstractCircleDecorator : Circle
    {
        public AbstractCircleDecorator(Circle circle) 
            : base(circle)
        {
        }
    }
}
