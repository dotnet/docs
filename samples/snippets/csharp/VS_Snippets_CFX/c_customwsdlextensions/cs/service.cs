using System;
using System.ServiceModel;

namespace Microsoft.WCF.Documentation
{
	public class Fibonacci : IFibonacci
	{
		public int Compute(int num)
		{
			if (num < 0)
				return 0;

			if (num < 2)
				return 1;

			return Compute(num - 1) + Compute(num - 2);
		}

    public Person GetPerson(int a, int b)
    {
      return new Person("Last name, first name"); 
    }
	}
}
