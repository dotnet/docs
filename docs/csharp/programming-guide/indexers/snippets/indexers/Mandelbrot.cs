namespace Indexers;
public class Mandelbrot(int maxIterations)
{

    public int this[double x, double y]
    {
        get
        {
            var iterations = 0;
            var x0 = x;
            var y0 = y;

            while ((x * x + y * y < 4) &&
                (iterations < maxIterations))
            { 
                (x, y) = (x * x - y * y + x0, 2 * x * y + y0);
                iterations++;
            }
            return iterations;
        }
    }
}
