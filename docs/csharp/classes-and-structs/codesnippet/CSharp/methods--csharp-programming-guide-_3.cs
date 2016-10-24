        public void Caller()
        {
            int numA = 4;
            // Call with an int variable.
            int productA = Square(numA);

            int numB = 32;
            // Call with another int variable.
            int productB = Square(numB);

            // Call with an integer literal.
            int productC = Square(12);

            // Call with an expression that evaulates to int.
            productC = Square(productA * 3);
        }
       
        int Square(int i)
        {
            // Store input argument in a local variable.
            int input = i;
            return input * input;
        }