    class SwitchTest
    {
        static void Main()
        {
            Console.WriteLine("Coffee sizes: 1=small 2=medium 3=large");
            Console.Write("Please enter your selection: ");
            string str = Console.ReadLine();
            int cost = 0;

            // Notice the goto statements in cases 2 and 3. The base cost of 25
            // cents is added to the additional cost for the medium and large sizes.
            switch (str)
            {
                case "1":
                case "small":
                    cost += 25;
                    break;
                case "2":
                case "medium":
                    cost += 25;
                    goto case "1";
                case "3":
                case "large":
                    cost += 50;
                    goto case "1";
                default:
                    Console.WriteLine("Invalid selection. Please select 1, 2, or 3.");
                    break;
            }
            if (cost != 0)
            {
                Console.WriteLine("Please insert {0} cents.", cost);
            }
            Console.WriteLine("Thank you for your business.");
        }
    }
    /*
        Sample Input: 2
     
        Sample Output:
        Coffee sizes: 1=small 2=medium 3=large
        Please enter your selection: 2
        Please insert 50 cents.
        Thank you for your business.
    */