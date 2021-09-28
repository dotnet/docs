using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace attributes
{
    class InitializeMembers
    {
    }

    // <MemberNotNullExample>
    public class Container
    {
        private string _uniqueIdentifier; // must be initialized.
        private string? _optionalMessage;

        public Container()
        {
            Helper();
        }

        public Container(string message)
        {
            Helper();
            _optionalMessage = message;
        }

        [MemberNotNull(nameof(_uniqueIdentifier))]
        private void Helper()
        {
            _uniqueIdentifier = DateTime.Now.Ticks.ToString();
        }
    }
    // </MemberNotNullExample>
}
