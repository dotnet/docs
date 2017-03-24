    class Fraction
    {
        int num, den;
        public Fraction(int num, int den)
        {
            this.num = num;
            this.den = den;
        }

        // overload operator +
        public static Fraction operator +(Fraction a, Fraction b)
        {
            return new Fraction(a.num * b.den + b.num * a.den,
               a.den * b.den);
        }

        // overload operator *
        public static Fraction operator *(Fraction a, Fraction b)
        {
            return new Fraction(a.num * b.num, a.den * b.den);
        }

        // user-defined conversion from Fraction to double
        public static implicit operator double(Fraction f)
        {
            return (double)f.num / f.den;
        }
    }

    class Test
    {
        static void Main()
        {
            Fraction a = new Fraction(1, 2);
            Fraction b = new Fraction(3, 7);
            Fraction c = new Fraction(2, 3);
            Console.WriteLine((double)(a * b + c));
        }
    }
    /*
    Output
    0.880952380952381
    */
