using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tuples
{
    class Program
    {
        static void Main(string[] args)
        {
            InitializationStatements();

            AssignmentStatements();
        }

        private static void AssignmentStatements()
        {
            #region 03_VariableCreation
            // The 'arity' and 'shape' of all these
            // tuples are compatible. The only
            // difference is the field names being 
            // used.
            var unnamed = (42, "The meaning of life");
            var anonymous = (16, "a perfect square");
            var named = (answer: 42, message: "The meaning of life");
            var differentNamed = (secretConstant: 42, label: "The meaning of life");
            #endregion

            #region 04_VariableAssignment
            // unnamed to named:
            unnamed = named;

            // named to unnamed:
            named = unnamed;
            // 'named' still has fields that can be referred to
            // as 'answer', and 'message':
            Console.WriteLine($"{named.answer}, {named.message}");

            // unnamed to unnamed:
            anonymous = unnamed;
            
            // named tuples.
            named = differentNamed;
            // The field names are not assigned.
            // 'named' still has fields that can be referred to
            // as 'answer' and 'message':
            Console.WriteLine($"{named.answer}, {named.message}");
            #endregion

        }

        private static void InitializationStatements()
        {
            #region 01_UnNamedTuple
            var unnamed = ("one", "two");
            #endregion

            #region 02_NamedTuple
            var named = (first: "one", second: "two");
            #endregion


        }
    }
}
