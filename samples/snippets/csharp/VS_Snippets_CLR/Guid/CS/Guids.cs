//<Snippet1>
using System;
using System.Runtime.InteropServices;

// Guid for the interface IMyInterface.
[Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4")]
interface IMyInterface
{
    void MyMethod();
}

// Guid for the coclass MyTestClass.
[Guid("936DA01F-9ABD-4d9d-80C7-02AF85C822A8")]
public class MyTestClass : IMyInterface
{
    public void MyMethod() {}

    public static void Main( string []args )
    {
        GuidAttribute IMyInterfaceAttribute = (GuidAttribute) Attribute.GetCustomAttribute(typeof(IMyInterface), typeof(GuidAttribute));
        
        System.Console.WriteLine("IMyInterface Attribute: " + IMyInterfaceAttribute.Value );    

        // Use the string to create a guid.
        Guid myGuid1 = new Guid(IMyInterfaceAttribute.Value );
        // Use a byte array to create a guid.
        Guid myGuid2 = new Guid(myGuid1.ToByteArray());

        if (myGuid1.Equals(myGuid2))
            System.Console.WriteLine("myGuid1 equals myGuid2");
        else
            System.Console.WriteLine("myGuid1 does not equal myGuid2" );

        // Equality operator can also be used to determine if two guids have same value.
        if ( myGuid1 == myGuid2 )
            System.Console.WriteLine( "myGuid1 == myGuid2" );
        else
            System.Console.WriteLine( "myGuid1 != myGuid2" );
    }
}
// The example displays the following output:
//       IMyInterface Attribute: F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4
//       myGuid1 equals myGuid2
//       myGuid1 == myGuid2
//</Snippet1>
