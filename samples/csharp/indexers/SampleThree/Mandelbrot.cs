
namespace IndexersSamples.SampleThree
{
    public class Mandelbrot
    {
        readonly private int maxIterations;

        public Mandelbrot(int maxIterations)
        {
            this.maxIterations = maxIterations;
        }

        public int this [double x, double y]
        {
            get
            {
                var iterations = 0;
                var x0 = x;
                var y0 = y;

                while ((x*x + y * y < 4) &&
                    (iterations < maxIterations))
                {
                    var newX = x * x - y * y + x0;
                    y = 2 * x * y + y0;
                    x = newX;
                    iterations++;
                }
                return iterations;
            }
        }
    }
}
