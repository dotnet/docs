    class TryFinallyTest
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
        string s = null; // For demonstration purposes.

        try
        {            
            ProcessString(s);
        }

        catch (Exception e)
        {
            Console.WriteLine("{0} Exception caught.", e);
        }
    }
}
    /*
    Output:
    System.ArgumentNullException: Value cannot be null.
       at TryFinallyTest.Main() Exception caught.
     * */
