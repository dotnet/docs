using System;
using System.IO;
using System.Reflection;

namespace Microsoft.Samples.Entity
{
    class Program
    {
        static void Main(string[] args)
        {
            Source.ExectueRefTypeQuery(@"SELECT REF(p) FROM AdventureWorksEntities.Products as p where p.ProductID == @productID");
            return;

            FileStream stream = new FileStream("c:\\ObjectServices"
                + DateTime.Now.Day + DateTime.Now.Hour
                + DateTime.Now.Minute
                + ".log", FileMode.Create);
            StreamWriter writer = new StreamWriter(stream);

            try
            {
                Console.SetOut(writer);
                Console.WriteLine("Start Object Services tests:");
                Console.WriteLine(DateTime.Now.ToString());

                //Set the method to run. Use "all" to run all methods.
                RunMethod("All");
                //RunMethod("PolymorphicQuery");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                writer.Close();
            }
        }

        static void RunMethod(string name)
        {
            if (name.ToUpper() != "ALL")
            {
                try
                {
                    Source s = new Source();
                    MethodInfo method = typeof(Source).GetMethod(name);
                    method.Invoke(s, null);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            else
            {
                Source s = new Source();

                try
                {
                    foreach (MethodInfo method in typeof(Source).GetMembers(
                        BindingFlags.Static |
                        BindingFlags.DeclaredOnly |
                        BindingFlags.Public))
                    {
                        try
                        {
                            method.Invoke(s, null);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("An exception occured in method: "
                                + method.Name);
                            Console.WriteLine(ex.ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unhandled Exception in the harness.");
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
