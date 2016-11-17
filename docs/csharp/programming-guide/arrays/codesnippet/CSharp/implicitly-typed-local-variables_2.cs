            class ImplicitlyTypedLocals2
            {
                static void Main()
                {
                    string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };

                    // If a query produces a sequence of anonymous types, 
                    // then use var in the foreach statement to access the properties.
                    var upperLowerWords =
                         from w in words
                         select new { Upper = w.ToUpper(), Lower = w.ToLower() };

                    // Execute the query
                    foreach (var ul in upperLowerWords)
                    {
                        Console.WriteLine("Uppercase: {0}, Lowercase: {1}", ul.Upper, ul.Lower);
                    }
                }
            }
            /* Outputs:
                Uppercase: APPLE, Lowercase: apple
                Uppercase: BLUEBERRY, Lowercase: blueberry
                Uppercase: CHERRY, Lowercase: cherry        
             */