        public static void Test()
        {
            Box box1 = new Box(30.0f, 20.0f);
            IMetricDimensions mDimensions = (IMetricDimensions)box1;

            System.Console.WriteLine("Length(in): {0}", box1.Length());
            System.Console.WriteLine("Width (in): {0}", box1.Width());
            System.Console.WriteLine("Length(cm): {0}", mDimensions.Length());
            System.Console.WriteLine("Width (cm): {0}", mDimensions.Width());
        }