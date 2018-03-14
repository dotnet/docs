        struct RomanNumeral
        {
            private int value;

            public RomanNumeral(int value)  //constructor
            {
                this.value = value;
            }

            static public implicit operator RomanNumeral(int value)
            {
                return new RomanNumeral(value);
            }

            static public implicit operator RomanNumeral(BinaryNumeral binary)
            {
                return new RomanNumeral((int)binary);
            }

            static public explicit operator int(RomanNumeral roman)
            {
                return roman.value;
            }

            static public implicit operator string(RomanNumeral roman)
            {
                return ("Conversion to string is not implemented");
            }
        }

        struct BinaryNumeral
        {
            private int value;

            public BinaryNumeral(int value)  //constructor
            {
                this.value = value;
            }

            static public implicit operator BinaryNumeral(int value)
            {
                return new BinaryNumeral(value);
            }

            static public explicit operator int(BinaryNumeral binary)
            {
                return (binary.value);
            }

            static public implicit operator string(BinaryNumeral binary)
            {
                return ("Conversion to string is not implemented");
            }
        }

        class TestConversions
        {
            static void Main()
            {
                RomanNumeral roman;
                BinaryNumeral binary;

                roman = 10;

                // Perform a conversion from a RomanNumeral to a BinaryNumeral:
                binary = (BinaryNumeral)(int)roman;

                // Perform a conversion from a BinaryNumeral to a RomanNumeral:
                // No cast is required:
                roman = binary;

                System.Console.WriteLine((int)binary);
                System.Console.WriteLine(binary);

                // Keep the console window open in debug mode.
                System.Console.WriteLine("Press any key to exit.");
                System.Console.ReadKey();
            }
        }
        /* Output:
            10
            Conversion not yet implemented
        */