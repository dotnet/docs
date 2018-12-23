    // Declare the English units interface:
    interface IEnglishDimensions
    {
        float Length();
        float Width();
    }

    // Declare the metric units interface:
    interface IMetricDimensions
    {
        float Length();
        float Width();
    }

    // Declare the Box class that implements the two interfaces:
    // IEnglishDimensions and IMetricDimensions:
    class Box : IEnglishDimensions, IMetricDimensions
    {
        float lengthInches;
        float widthInches;

        public Box(float lengthInches, float widthInches)
        {
            this.lengthInches = lengthInches;
            this.widthInches = widthInches;
        }

        // Explicitly implement the members of IEnglishDimensions:
        float IEnglishDimensions.Length() => lengthInches;

        float IEnglishDimensions.Width() => widthInches;

        // Explicitly implement the members of IMetricDimensions:
        float IMetricDimensions.Length() => lengthInches * 2.54f;

        float IMetricDimensions.Width() => widthInches * 2.54f;

        static void Main()
        {
            // Declare a class instance box1:
            Box box1 = new Box(30.0f, 20.0f);

            // Declare an instance of the English units interface:
            IEnglishDimensions eDimensions = box1;

            // Declare an instance of the metric units interface:
            IMetricDimensions mDimensions = box1;

            // Print dimensions in English units:
            System.Console.WriteLine("Length(in): {0}", eDimensions.Length());
            System.Console.WriteLine("Width (in): {0}", eDimensions.Width());

            // Print dimensions in metric units:
            System.Console.WriteLine("Length(cm): {0}", mDimensions.Length());
            System.Console.WriteLine("Width (cm): {0}", mDimensions.Width());
        }
    }
    /* Output:
        Length(in): 30
        Width (in): 20
        Length(cm): 76.2
        Width (cm): 50.8
    */
