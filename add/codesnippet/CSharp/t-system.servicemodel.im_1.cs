		[OperationBehavior(Impersonation = ImpersonationOption.Required)]
        public double Add(double n1, double n2)
        {
            double result = n1 + n2;
            Console.WriteLine("Received Add({0},{1})", n1, n2);
            Console.WriteLine("Return: {0}", result);
			DisplayIdentityInformation();
			return result;
        }