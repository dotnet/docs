            string sentence = "the quick brown fox jumps over the lazy dog";

            // Split the string into individual words.
            string[] words = sentence.Split(' ');

            // Use Aggregate() to prepend each word to the beginning of the 
            // new sentence to reverse the word order.
            string reversed =
                words.AsQueryable().Aggregate(
                (workingSentence, next) => next + " " + workingSentence
                );

            Console.WriteLine(reversed);

            // This code produces the following output:
            //
            // dog lazy the over jumps fox brown quick the 
