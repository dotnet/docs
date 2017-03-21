      bool done = false;
      string inp;
      do {
         Console.Write("Enter a real number: ");
         inp = Console.ReadLine();
         try {
            d = Double.Parse(inp);
            Console.WriteLine("You entered {0}.", d.ToString());
            done = true;
         } 
         catch (FormatException) {
            Console.WriteLine("You did not enter a number.");
         }
		 catch (ArgumentNullException) {
            Console.WriteLine("You did not supply any input.");
         }
         catch (OverflowException) {
             Console.WriteLine("The value you entered, {0}, is out of range.", inp);      
         }
      } while (!done);