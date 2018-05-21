            int? num1 = 10;
            int? num2 = null;
            if (num1 >= num2)
            {
                Console.WriteLine("num1 is greater than or equal to num2");
            }
            else
            {
                // This clause is selected, but num1 is not less than num2.
                Console.WriteLine("num1 >= num2 returned false (but num1 < num2 also is false)");
            }

            if (num1 < num2)
            {
                Console.WriteLine("num1 is less than num2");
            }
            else
            {
                // The else clause is selected again, but num1 is not greater than
                // or equal to num2.
                Console.WriteLine("num1 < num2 returned false (but num1 >= num2 also is false)");
            }

            if (num1 != num2)
            {
                // This comparison is true, num1 and num2 are not equal.
                Console.WriteLine("Finally, num1 != num2 returns true!");
            }

            // Change the value of num1, so that both num1 and num2 are null.
            num1 = null;
            if (num1 == num2)
            {
                // The equality comparison returns true when both operands are null.
                Console.WriteLine("num1 == num2 returns true when the value of each is null");
            }

            /* Output:
             * num1 >= num2 returned false (but num1 < num2 also is false)
             * num1 < num2 returned false (but num1 >= num2 also is false)
             * Finally, num1 != num2 returns true!
             * num1 == num2 returns true when the value of each is null
             */