    // compile with: /doc:DocFileName.xml 

    /// Comment for class
    public class EClass : System.Exception
    {
        // class definition...
    }

    /// Comment for class
    class TestClass
    {
        /// <exception cref="System.Exception">Thrown when...</exception>
        public void DoSomething()
        {
            try
            {
            }
            catch (EClass)
            {
            }
        }
    }