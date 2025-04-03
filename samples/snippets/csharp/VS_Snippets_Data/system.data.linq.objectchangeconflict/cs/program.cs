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
                Console.WriteLine("Optimistic concurrency error.");
                Console.WriteLine(e.Message);
                foreach (ObjectChangeConflict occ in db.ChangeConflicts)
                {
                    MetaTable metatable = db.Mapping.GetTable(occ.Object.GetType());
                    Customer entityInConflict = (Customer)occ.Object;
                    Console.WriteLine($"Table name: {metatable.TableName}");
                    Console.Write("Customer ID: ");
                    Console.WriteLine(entityInConflict.CustomerID);
                    Console.ReadLine();
                }
            }
            // </Snippet1>
        }
    }
}
