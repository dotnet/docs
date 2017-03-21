                List<int> numbers = new List<int> { 1, 2 };

                // Determine if the list contains any elements.
                bool hasElements = numbers.AsQueryable().Any();

                Console.WriteLine("The list {0} empty.",
                    hasElements ? "is not" : "is");

                // This code produces the following output:
                //
                // The list is not empty. 
