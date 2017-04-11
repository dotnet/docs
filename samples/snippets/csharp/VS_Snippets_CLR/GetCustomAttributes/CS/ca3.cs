// <Snippet3>
using System;
using System.Runtime.InteropServices;

namespace CustAttrs3CS {
    // Set a GUID and ProgId attribute for this class.
    [Guid("BF235B41-52D1-46CC-9C55-046793DB363F")]
    [ProgId("CustAttrs3CS.ClassWithGuidAndProgId")]
    public class ClassWithGuidAndProgId {
    }

    class DemoClass {
        static void Main(string[] args) {
            // Get the Class type to access its metadata.
            Type clsType = typeof(ClassWithGuidAndProgId);

            // Iterate through all the attributes for the class.
            foreach(Attribute attr in Attribute.GetCustomAttributes(clsType)) {
                // Check for the Guid attribute.
                if (attr.GetType() == typeof(GuidAttribute)) {
                    // Display the GUID.
                    Console.WriteLine("Class {0} has a GUID.", clsType.Name);
                    Console.WriteLine("GUID: {" + 
                        ((GuidAttribute)attr).Value + "}.");
                }

                // Check for the ProgId attribute.
                else if (attr.GetType() == typeof(ProgIdAttribute)) {
                    // Display the ProgId.
                    Console.WriteLine("Class {0} has a ProgId.", clsType.Name);
                    Console.WriteLine("ProgId: \"{0}\".",
                        ((ProgIdAttribute)attr).Value);
                }
            }
        }
    }
}

/* 
 * Output:
 * Class ClassWithGuidAndProgId has a GUID.
 * GUID: {BF235B41-52D1-46CC-9C55-046793DB363F}.
 * Class ClassWithGuidAndProgId has a ProgId.
 * ProgId: "CustAttrs3CS.ClassWithGuidAndProgId".
 */
// </Snippet3>
