 // <Snippet1>
using System;
using System.IO;
using System.ComponentModel;
using System.Configuration;

namespace Samples.AspNet
{
  
    public sealed class UsingTypeNameConverter
    {
        public static void GetTypeName()
        {
            try
            {
           
                CustomSection section =
                    ConfigurationManager.GetSection("CustomSection")
                    as CustomSection;

                Console.WriteLine("CustomSection type: {0}",
                    section);
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
// </Snippet1>
