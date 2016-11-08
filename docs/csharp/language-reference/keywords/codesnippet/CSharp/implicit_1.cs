        class Digit
        {
            public Digit(double d) { val = d; }
            public double val;
            // ...other members

            // User-defined conversion from Digit to double
            public static implicit operator double(Digit d)
            {
                return d.val;
            }
            //  User-defined conversion from double to Digit
            public static implicit operator Digit(double d)
            {
                return new Digit(d);
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                Digit dig = new Digit(7);
                //This call invokes the implicit "double" operator
                double num = dig;
                //This call invokes the implicit "Digit" operator
                Digit dig2 = 12;
                Console.WriteLine("num = {0} dig2 = {1}", num, dig2.val);
                Console.ReadLine();
            }
        }