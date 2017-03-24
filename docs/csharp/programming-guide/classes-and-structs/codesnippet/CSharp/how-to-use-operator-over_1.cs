        public struct Complex
        {
            public int real;
            public int imaginary;

            // Constructor.
            public Complex(int real, int imaginary)  
            {
                this.real = real;
                this.imaginary = imaginary;
            }

            // Specify which operator to overload (+), 
            // the types that can be added (two Complex objects),
            // and the return type (Complex).
            public static Complex operator +(Complex c1, Complex c2)
            {
                return new Complex(c1.real + c2.real, c1.imaginary + c2.imaginary);
            }

            // Override the ToString() method to display a complex number 
            // in the traditional format:
            public override string ToString()
            {
                return (System.String.Format("{0} + {1}i", real, imaginary));
            }
        }

        class TestComplex
        {
            static void Main()
            {
                Complex num1 = new Complex(2, 3);
                Complex num2 = new Complex(3, 4);

                // Add two Complex objects by using the overloaded + operator.
                Complex sum = num1 + num2;

                // Print the numbers and the sum by using the overridden 
                // ToString method.
                System.Console.WriteLine("First complex number:  {0}", num1);
                System.Console.WriteLine("Second complex number: {0}", num2);
                System.Console.WriteLine("The sum of the two numbers: {0}", sum);

                // Keep the console window open in debug mode.
                System.Console.WriteLine("Press any key to exit.");
                System.Console.ReadKey();
            }
        }
        /* Output:
            First complex number:  2 + 3i
            Second complex number: 3 + 4i
            The sum of the two numbers: 5 + 7i
        */