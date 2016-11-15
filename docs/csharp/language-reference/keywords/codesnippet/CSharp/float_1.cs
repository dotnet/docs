    class FloatTest 
    {
        static void Main() 
        {
            int x = 3;
            float y = 4.5f;
            short z = 5;
            var result = x * y / z;
            Console.WriteLine("The result is {0}", result);
            Type type = result.GetType();
            Console.WriteLine("result is of type {0}", type.ToString());
        }
    }
    /* Output: 
      The result is 2.7
      result is of type System.Single //'float' is alias for 'Single'
     */