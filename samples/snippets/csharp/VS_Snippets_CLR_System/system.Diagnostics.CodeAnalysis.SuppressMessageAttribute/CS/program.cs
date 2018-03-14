//<Snippet1>
#define CODE_ANALYSIS
using System;
using System.Diagnostics.CodeAnalysis;

namespace CodeAnalysisSample
{
    class Library
    {
        //<Snippet2>
        [SuppressMessage("Microsoft.Performance", "CA1801:ReviewUnusedParameters", MessageId = "isChecked")]
        [SuppressMessage("Microsoft.Performance", "CA1804:RemoveUnusedLocals", MessageId = "fileIdentifier")]
        static void FileNode(string name, bool isChecked)
        {
            string fileIdentifier = name;
            string fileName = name;
            string version = String.Empty;
        }
        //</Snippet2>

    }
}
//</Snippet1>