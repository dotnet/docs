    class ThrowTest3
    {
        static void ProcessString(string s)
        {
            if (s == null)
            {
                throw new ArgumentNullException();
            }
        }

        static void Main()
        {
            try
            {
                string s = null;
                ProcessString(s);
            }
            // Most specific:
            catch (ArgumentNullException e)
            {
                Console.WriteLine("{0} First exception caught.", e);
            }
            // Least specific:
            catch (Exception e)
            {
                Console.WriteLine("{0} Second exception caught.", e);
            }
        }
    }
    /*
     Output:
     System.ArgumentNullException: Value cannot be null.
     at Test.ThrowTest3.ProcessString(String s) ... First exception caught.
    */