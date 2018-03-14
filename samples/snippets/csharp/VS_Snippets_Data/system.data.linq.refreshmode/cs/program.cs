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
            try
            {
                db.SubmitChanges(ConflictMode.ContinueOnConflict);
            }

            catch (ChangeConflictException e)
            {
                Console.WriteLine(e.Message);
                foreach (ObjectChangeConflict occ in db.ChangeConflicts)
                {
                    // All database values overwrite current values.
                    occ.Resolve(RefreshMode.OverwriteCurrentValues);
                }
            }
            // </Snippet1>

            // <Snippet2> 
            try
            {
                db.SubmitChanges(ConflictMode.ContinueOnConflict);
            }

            catch (ChangeConflictException e)
            {
                Console.WriteLine(e.Message);
                foreach (ObjectChangeConflict occ in db.ChangeConflicts)
                {
                    //No database values are merged into current.
                    occ.Resolve(RefreshMode.KeepCurrentValues);
                }
            }
            // </Snippet2>

            // <Snippet3>
            try
            {
                db.SubmitChanges(ConflictMode.ContinueOnConflict);
            }

            catch (ChangeConflictException e)
            {
                Console.WriteLine(e.Message);
                // Automerge database values for members that client
                // has not modified.
                foreach (ObjectChangeConflict occ in db.ChangeConflicts)
                {
                    occ.Resolve(RefreshMode.KeepChanges);
                }
            }

            // Submit succeeds on second try.
            db.SubmitChanges(ConflictMode.FailOnFirstConflict);
            // </Snippet3>
        }
    }
}
