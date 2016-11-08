            // Preferred syntax. Note that you cannot use var here instead of string[].
            string[] vowels1 = { "a", "e", "i", "o", "u" };


            // If you use explicit instantiation, you can use var.
            var vowels2 = new string[] { "a", "e", "i", "o", "u" };

            // If you specify an array size, you must initialize the elements one at a time.
            var vowels3 = new string[5];
            vowels3[0] = "a";
            vowels3[1] = "e";
            // And so on.