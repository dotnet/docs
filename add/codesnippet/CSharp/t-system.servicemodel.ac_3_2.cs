    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class CalculatorService : ICalculatorSession
    {
        double result
        {   // Store result in AspNet session.
            get
            {
                if (HttpContext.Current.Session["Result"] != null)
                    return (double)HttpContext.Current.Session["Result"];
                return 0.0D;
            }
            set
            {
                HttpContext.Current.Session["Result"] = value;
            }
        }

        public void Clear()
        {
            
        }

        public void AddTo(double n)
        {
            result += n;
        }

        public void SubtractFrom(double n)
        {
            result -= n;
        }

        public void MultiplyBy(double n)
        {
            result *= n;
        }

        public void DivideBy(double n)
        {
            result /= n;
        }

        public double Equals()
        {
            return result;
        }
    }