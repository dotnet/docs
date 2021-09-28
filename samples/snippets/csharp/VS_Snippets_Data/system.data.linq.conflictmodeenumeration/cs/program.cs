using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace cs_conflictmodeenum
{
    class Program
    {
        static void Main(string[] args)
        {
            // <Snippet1>
            Northwnd db = new Northwnd("...");

            // Create, update, delete code.

            db.SubmitChanges(ConflictMode.FailOnFirstConflict);
            // or
            db.SubmitChanges(ConflictMode.ContinueOnConflict);
            // </Snippet1>
        }
    }
}
