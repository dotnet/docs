        // Only members of the CalculatorClients group can call this method.
        [PrincipalPermission(SecurityAction.Demand, Role = "Users")]
        public double Add(double a, double b)
        {
            return a + b;
        }