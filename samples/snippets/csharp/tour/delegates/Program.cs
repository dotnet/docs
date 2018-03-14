namespace DelegateTour
{
    using System;
    delegate double Function(double x);
    class Multiplier
    {
        double factor;
        public Multiplier(double factor) 
        {
            this.factor = factor;
        }
        public double Multiply(double x) 
        {
            return x * factor;
        }
    }
    class DelegateExample
    {
        static double Square(double x) 
        {
            return x * x;
        }
        static double[] Apply(double[] a, Function f) 
        {
            double[] result = new double[a.Length];
            for (int i = 0; i < a.Length; i++) result[i] = f(a[i]);
            return result;
        }
        static void Main() 
        {
            double[] a = {0.0, 0.5, 1.0};
            double[] squares = Apply(a, Square);
            double[] sines = Apply(a, Math.Sin);
            Multiplier m = new Multiplier(2.0);
            double[] doubles =  Apply(a, m.Multiply);
        }
    }

    class Lambda
    {
        static void ApplyDelegate()
        {
            double[] a = {0.0, 0.5, 1.0};
            double[] doubles =  Apply(a, (double x) => x * 2.0);
        }
        static double[] Apply(double[] a, Function f) 
        {
            double[] result = new double[a.Length];
            for (int i = 0; i < a.Length; i++) result[i] = f(a[i]);
            return result;
        }
    }
}
