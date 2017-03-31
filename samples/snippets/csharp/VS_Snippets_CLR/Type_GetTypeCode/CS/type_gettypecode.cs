// System.Type.GetTypeCode()
// System.Type.GetProperties()
// System.Type.GetTypeArray()
// System.Type.GetType(String,Boolean,Boolean)

/* The following example demonstrates the  'GetTypeCode()', 'GetProperties()', 'GetTypeArray()',
    'GetType(String,Boolean,Boolean)' methods of 'Type' class.
    An object of 'Type' corresponding to 'System.Int32 is obtained '. Properties of 'System.Type' 
    is retrieved into 'PropertyInfo' array and displayed. Array of 'Type' objects is created 
    which represents the type specified by an arbitary    set of objects. When 'Type' object is 
    attempted to create for 'sYSTem.iNT32', an exception is thrown when case-sensitive search 
    is done.  
 */
using System;
using System.Reflection;

namespace TypeCodeNamespace
{
    class MyClass
    {
        static void Main(string[] args)
        {
// <Snippet1>
            // Create an object of 'Type' class.
            Type myType1 = Type.GetType("System.Int32");
            // Get the 'TypeCode' of the 'Type' class object created above.
            TypeCode myTypeCode = Type.GetTypeCode(myType1);
            Console.WriteLine("TypeCode is: {0}",myTypeCode);
// </Snippet1>
// <Snippet2>
            PropertyInfo[] myPropertyInfo;
            // Get the properties of 'Type' class object.
            myPropertyInfo = Type.GetType("System.Type").GetProperties();
            Console.WriteLine("Properties of System.Type are:");
            for (int i = 0; i < myPropertyInfo.Length; i++)
            {
                Console.WriteLine(myPropertyInfo[i].ToString());
            }
// </Snippet2>
// <Snippet3>
            Object[] myObject = new Object[3];
            myObject[0] = 66;
            myObject[1] = "puri";
            myObject[2] = 33.33;
            // Get the array of 'Type' class objects.
            Type[] myTypeArray = Type.GetTypeArray(myObject);
            Console.WriteLine("Full names of the 'Type' objects in the array are:");
            for(int h = 0; h < myTypeArray.Length ; h++)
            {
                Console.WriteLine(myTypeArray[h].FullName);
            }
// </Snippet3>
// <Snippet4>
            try
            {
                // Throws 'TypeLoadException' because of case-sensitive search.
                Type myType2 = Type.GetType("sYSTem.iNT32",true,false);
                Console.WriteLine(myType2.FullName);
            }
            catch(TypeLoadException e)
            {
                Console.WriteLine(e.Message);
            }
// </Snippet4>
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

