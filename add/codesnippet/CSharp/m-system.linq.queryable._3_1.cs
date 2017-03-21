            char[] apple = { 'a', 'p', 'p', 'l', 'e' };

            // Reverse the order of the characters in the collection.
            IQueryable<char> reversed = apple.AsQueryable().Reverse();

            foreach (char chr in reversed)
                Console.Write(chr + " ");
            Console.WriteLine();

            /*
                This code produces the following output:

                e l p p a
            */
