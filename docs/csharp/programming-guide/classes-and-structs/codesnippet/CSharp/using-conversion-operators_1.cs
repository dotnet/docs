        struct Digit
        {
            byte value;

            public Digit(byte value)  //constructor
            {
                if (value > 9)
                {
                    throw new System.ArgumentException();
                }
                this.value = value;
            }

            public static explicit operator Digit(byte b)  // explicit byte to digit conversion operator
            {
                Digit d = new Digit(b);  // explicit conversion

                System.Console.WriteLine("Conversion occurred.");
                return d;
            }
        }

        class TestExplicitConversion
        {
            static void Main()
            {
                try
                {
                    byte b = 3;
                    Digit d = (Digit)b;  // explicit conversion
                }
                catch (System.Exception e)
                {
                    System.Console.WriteLine("{0} Exception caught.", e);
                }
            }
        }
        // Output: Conversion occurred.