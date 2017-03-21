            string[] fruits = { "apple", "banana", "mango", "orange", 
                                  "passionfruit", "grape" };

            // Project an anonymous type that contains the
            // index of the string in the source array, and
            // a string that contains the same number of characters
            // as the string's index in the source array.
            var query =
                fruits.AsQueryable()
                .Select((fruit, index) =>
                            new { index, str = fruit.Substring(0, index) });

            foreach (var obj in query)
                Console.WriteLine("{0}", obj);

            /*
                This code produces the following output:

                { index = 0, str =  }
                { index = 1, str = b }
                { index = 2, str = ma }
                { index = 3, str = ora }
                { index = 4, str = pass }
                { index = 5, str = grape }
            */
