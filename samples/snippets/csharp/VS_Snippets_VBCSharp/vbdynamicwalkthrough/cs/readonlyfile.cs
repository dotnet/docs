using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//<Snippet1>
using System.IO;
using System.Dynamic;
//</Snippet1>

namespace DynamicWalkthrough
{
    //<Snippet2>
    public enum StringSearchOption
    {
        StartsWith,
        Contains,
        EndsWith
    }
    //</Snippet2>

    //<Snippet3>
    class ReadOnlyFile : DynamicObject
    //</Snippet3>
    {
        //<Snippet4>
        // Store the path to the file and the initial line count value.
        private string p_filePath;

        // Public constructor. Verify that file exists and store the path in
        // the private variable.
        public ReadOnlyFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new Exception("File path does not exist.");
            }

            p_filePath = filePath;
        }
        //</Snippet4>

        //<Snippet7>
        // Implement the TryInvokeMember method of the DynamicObject class for
        // dynamic member calls that have arguments.
        public override bool TryInvokeMember(InvokeMemberBinder binder,
                                             object[] args,
                                             out object result)
        {
            StringSearchOption StringSearchOption = StringSearchOption.StartsWith;
            bool trimSpaces = true;

            try
            {
                if (args.Length > 0) { StringSearchOption = (StringSearchOption)args[0]; }
            }
            catch
            {
                throw new ArgumentException("StringSearchOption argument must be a StringSearchOption enum value.");
            }

            try
            {
                if (args.Length > 1) { trimSpaces = (bool)args[1]; }
            }
            catch
            {
                throw new ArgumentException("trimSpaces argument must be a Boolean value.");
            }

            result = GetPropertyValue(binder.Name, StringSearchOption, trimSpaces);

            return result == null ? false : true;
        }
        //</Snippet7>

        //<Snippet6>
        // Implement the TryGetMember method of the DynamicObject class for dynamic member calls.
        public override bool TryGetMember(GetMemberBinder binder,
                                          out object result)
        {
            result = GetPropertyValue(binder.Name);
            return result == null ? false : true;
        }
        //</Snippet6>

        //<Snippet5>
        public List<string> GetPropertyValue(string propertyName,
                                             StringSearchOption StringSearchOption = StringSearchOption.StartsWith,
                                             bool trimSpaces = true)
        {
            StreamReader sr = null;
            List<string> results = new List<string>();
            string line = "";
            string testLine = "";

            try
            {
                sr = new StreamReader(p_filePath);

                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();

                    // Perform a case-insensitive search by using the specified search options.
                    testLine = line.ToUpper();
                    if (trimSpaces) { testLine = testLine.Trim(); }

                    switch (StringSearchOption)
                    {
                        case StringSearchOption.StartsWith:
                            if (testLine.StartsWith(propertyName.ToUpper())) { results.Add(line); }
                            break;
                        case StringSearchOption.Contains:
                            if (testLine.Contains(propertyName.ToUpper())) { results.Add(line); }
                            break;
                        case StringSearchOption.EndsWith:
                            if (testLine.EndsWith(propertyName.ToUpper())) { results.Add(line); }
                            break;
                    }
                }
            }
            catch
            {
                // Trap any exception that occurs in reading the file and return null.
                results = null;
            }
            finally
            {
                if (sr != null) {sr.Close();}
            }

            return results;
        }
        //</Snippet5>
    }
}
