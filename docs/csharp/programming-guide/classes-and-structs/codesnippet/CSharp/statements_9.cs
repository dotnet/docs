                // An over-simplified example of unreachable code.
                const int val = 5;
                if (val < 4)
                {
                    System.Console.WriteLine("I'll never write anything."); //CS0162
                }