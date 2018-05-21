            // If the previous sum is attempted in a checked environment, an 
            // OverflowException error is raised.

            // Checked expression.
            Console.WriteLine(checked(2147483647 + ten));

            // Checked block.
            checked
            {
                int i3 = 2147483647 + ten;
                Console.WriteLine(i3);
            }