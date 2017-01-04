using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace new_in_7
{
    public class ExpressionMembersExample
    {
        #region 36_ExpressionBodiedEverything
        // Expression-bodied constructor
        public ExpressionMembersExample(string label) => this.Label = label;

        // expression-bodied finalizer
        ~ExpressionMembersExample() => Console.Error.WriteLine("Finalized!");

        private string label;

        // expression-bodied get / set accessors.
        public string Label
        {
            get => label;
            set => this.label = value ?? "Default label";
        }
        #endregion
    }
}
