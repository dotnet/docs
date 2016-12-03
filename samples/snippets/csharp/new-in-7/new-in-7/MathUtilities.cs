using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace new_in_7
{
    public static class MathUtilities
    {
        #region 37_LocalFunctionFactorial
        public static int LocalFunctionFactorial(int n)
        {
            return nthFactorial(n);
            int nthFactorial(int number) => (number < 2) ? 
                1 : number * nthFactorial(number - 1);
        }
        #endregion

        #region 38_LambdaFactorial
        public static int LambdaFactorial(int n)
        {
            Func<int, int> nthFactorial = default(Func<int, int>);
            nthFactorial = (number) => (number < 2) ? 
                1 : number * nthFactorial(number - 1);
            return nthFactorial(n);
        }
        #endregion
    }
}
