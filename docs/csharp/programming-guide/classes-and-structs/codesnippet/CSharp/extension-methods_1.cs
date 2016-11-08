    class ExtensionMethods2    
    {
        
        static void Main()
        {            
            int[] ints = { 10, 45, 15, 39, 21, 26 };
            var result = ints.OrderBy(g => g);
            foreach (var i in result)
            {
                System.Console.Write(i + " ");
            }           
        }        
    }
    //Output: 10 15 21 26 39 45