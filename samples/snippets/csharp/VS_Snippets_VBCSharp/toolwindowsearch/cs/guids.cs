// Guids.cs
// MUST match guids.h
using System;

namespace Microsoft.TestToolWindowSearch
{
    static class GuidList
    {
        public const string guidTestToolWindowSearchPkgString = "c4a554cd-cbc4-4b4f-95dd-77834c99fa8e";
        public const string guidTestToolWindowSearchCmdSetString = "61100c71-238e-4577-8ebe-5c6163c190b5";
        public const string guidToolWindowPersistanceString = "c35081aa-153d-4a84-b1f1-6608ba87de39";

        public static readonly Guid guidTestToolWindowSearchCmdSet = new Guid(guidTestToolWindowSearchCmdSetString);
    };
}