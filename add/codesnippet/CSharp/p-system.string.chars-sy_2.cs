			Console.Write("Type a string : ");
			string myString = Console.ReadLine();
			for (int i = 0; i < myString.Length; i ++)
               if(Uri.IsHexDigit(myString[i]))
                  Console.WriteLine("{0} is a hexadecimal digit.", myString[i]); 
               else
                  Console.WriteLine("{0} is not a hexadecimal digit.", myString[i]); 
            // The example produces output like the following:
            //    Type a string : 3f5EaZ
            //    3 is a hexadecimal digit.
            //    f is a hexadecimal digit.
            //    5 is a hexadecimal digit.
            //    E is a hexadecimal digit.
            //    a is a hexadecimal digit.
            //    Z is not a hexadecimal digit.            