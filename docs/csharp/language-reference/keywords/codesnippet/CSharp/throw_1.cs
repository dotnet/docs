    public class ThrowTest2
    {

        static int GetNumber(int index)
        {
            int[] nums = { 300, 600, 900 };
            if (index > nums.Length)
            {
                throw new IndexOutOfRangeException();
            }
            return nums[index];
 
        }
        static void Main() 
        {
            int result = GetNumber(3);
            
        }
    }
    /*
        Output:
        The System.IndexOutOfRangeException exception occurs.
    */
