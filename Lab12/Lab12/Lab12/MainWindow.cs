using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Lab12
{
    public partial class MainWindow : Window
    {
        private Map map = new Map();
        private Shape SelectedShape;

        private AbstractFigure SelectedFigure
        {
            get
            {
                if (SelectedShape == null)
                {
                    return null; 
                }
                else
                {
                    return map.Find(SelectedShape) as AbstractFigure;
                } 
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            map.Add(GoldenTriangle.Instance);

            var builder = new ComplexBuilder();
            var factory = new ColorlessFigureFactory();
            var director = new FigureDirector(builder, factory);
            director.Construct();
            var complexFigure = builder.GetResult();

            map.Add(complexFigure);

            var anotherFactory = new FigureFactory();
            map.Add(new CircleWithGradient(anotherFactory.CreateCircle() as Circle, Colors.Red, Colors.Blue));

            UpdateFigures();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var createWindow = new CreateWindow();
            if (createWindow.ShowDialog() == true)
            {
                var factory = new FigureFactory();

                for (int i = 0; i < createWindow.Count; i++)
                {
                    AbstractFigure figure = null;

                    if (createWindow.Type == FigureType.Circle)
                    {
                        figure = factory.CreateCircle();
                    }
                    else if (createWindow.Type == FigureType.Rectangle)
                    {
                        figure = factory.CreateRectangle();
                    }

                    map.Add(figure);
                }

                UpdateFigures();
            }
        }

        private void UpdateFigures()
        {
            canvasArea.Children.Clear();
            foreach (var figure in map.GetAll())
            {
                var shape = figure.Shape;
                var transform = RandomTranslateTransform.GetTranslateTransform(shape, canvasArea);

                Canvas.SetLeft(shape, transform.X);
                Canvas.SetTop(shape, transform.Y);

                if (canvasArea.Children.Contains(shape) == false)
                {
                    canvasArea.Children.Add(shape);
                }
            }
        }

        private void Button_Click_Clone(object sender, RoutedEventArgs e)
        {
            if (SelectedShape != null)
            {
                var newFigure = SelectedFigure.Clone();
                map.Add(newFigure);
                UpdateFigures();
            }
        }

        private void canvasArea_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point pt = e.GetPosition((Canvas)sender);
            HitTestResult result = VisualTreeHelper.HitTest(canvasArea, pt);
            if (result != null)
            {
                SelectedShape = result.VisualHit as Shape;
            }
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (SelectedShape != null)
            {
                SelectedFigure.HandleInput(e.Key);
            }
        }
    }
}
