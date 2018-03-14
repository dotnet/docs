    // compile with: /doc:DocFileName.xml 

    /// comment for class
    public class TestClass
    {
        /// <summary>
        /// Creates a new array of arbitrary type <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">The element type of the array</typeparam>
        public static T[] mkArray<T>(int n)
        {
            return new T[n];
        }
    }