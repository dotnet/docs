    public class Automobile
    {
        public static int NumberOfWheels = 4;
        public static int SizeOfGasTank
        {
            get
            {
                return 15;
            }
        }
        public static void Drive() { }
        public static event EventType RunOutOfGas;

        // Other non-static fields and properties...
    }