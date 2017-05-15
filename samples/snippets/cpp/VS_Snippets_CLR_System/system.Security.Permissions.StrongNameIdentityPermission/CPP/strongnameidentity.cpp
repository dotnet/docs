
// <Snippet1>
using namespace System;
using namespace System::Security;
using namespace System::Security::Permissions;
using namespace System::Runtime::InteropServices;

// This class generates StrongNameIdentityPermission objects.

[assembly:CLSCompliant(true)];

public ref class StrongNameIdentityDemo
{
private:
    // Public key
    static array<Byte>^b1 = {0,36,0,0,4,128,0,0,148,0,0,0,6,2,0,0,0,36,0,0,82,83,65,49,0,4,0,0,1,0,1,0,237,146,145,51,34,97,123,196,90,174,41,170,173,221,41,193,175,39,7,151,178,0,230,152,218,8,206,206,170,84,111,145,26,208,158,240,246,219,228,34,31,163,11,130,16,199,111,224,4,112,46,84,0,104,229,38,39,63,53,189,0,157,32,38,34,109,0,171,114,244,34,59,9,232,150,192,247,175,104,143,171,42,219,66,66,194,191,218,121,59,92,42,37,158,13,108,210,189,9,203,204,32,48,91,212,101,193,19,227,107,25,133,70,2,220,83,206,71,102,245,104,252,87,109,190,56,34,180};
    static StrongNamePublicKeyBlob^ blob = gcnew StrongNamePublicKeyBlob( b1 );

    // Use this version number.
    static Version^ v1 = gcnew Version( "1.0.0.0" );

    //<Snippet2>
    // IsSubsetOf determines whether the current permission is a subset of the specified permission.
    bool IsSubsetOfDemo()
    {
        bool returnValue = true;

        StrongNameIdentityPermission^ snIdPerm1;
        StrongNameIdentityPermission^ snIdPerm2;

        //<Snippet8>
        snIdPerm1 = gcnew StrongNameIdentityPermission(blob, "MyCompany.MyDepartment.*", gcnew Version("1.0.0.0"));
        //</Snippet8>
        snIdPerm2 = gcnew StrongNameIdentityPermission(blob, "MyCompany.MyDepartment.MyFile", gcnew Version("1.0.0.0"));

        if (snIdPerm1->IsSubsetOf(snIdPerm2))
        {

            Console::WriteLine("MyCompany.MyDepartment.* is a subset " +
                "of MyCompany.MyDepartment.MyFile \n");
        }
        else
        {
            Console::WriteLine("MyCompany.MyDepartment.*" +
                " is not a subset of MyCompany.MyDepartment.MyFile \n");
        }

        return returnValue;
    }


    //</Snippet2>
    //<Snippet3>
    // Union creates a new permission that is the union of the current permission and the specified permission.
    bool UnionDemo()
    {
        bool returnValue = true;
        StrongNameIdentityPermission^ snIdPerm1;
        StrongNameIdentityPermission^ snIdPerm2;
        IPermission^ snIdPerm3;
        snIdPerm1 = gcnew StrongNameIdentityPermission(blob, "MyCompany.MyDepartment.*", gcnew Version("1.0.0.0"));
        snIdPerm2 = gcnew StrongNameIdentityPermission(blob, "MyCompany.MyDepartment.MyFile", gcnew Version("1.0.0.0"));
        snIdPerm3 = dynamic_cast<StrongNameIdentityPermission^>(snIdPerm1->Union( snIdPerm2 ));
        snIdPerm3 = snIdPerm1->Union( snIdPerm2 );

        try
        {
            Console::WriteLine("The union of MyCompany.MyDepartment.*" +
                "and MyCompany.MyDepartment.MyFile is " +
                (dynamic_cast<StrongNameIdentityPermission^>(snIdPerm3))->Name); 
        }
        catch (Exception^ e)
        {
            Console::WriteLine("An expected exception was thrown: " + e->Message);
        }


        return returnValue;
    }


    //</Snippet3>
    //<Snippet4>
    // Intersect creates and returns a new permission that is the intersection of the current
    // permission and the permission specified.
    bool IntersectDemo()
    {
        bool returnValue = true;
        StrongNameIdentityPermission^ snIdPerm1;
        StrongNameIdentityPermission^ snIdPerm2;
        StrongNameIdentityPermission^ snIdPerm3;
        snIdPerm1 = gcnew StrongNameIdentityPermission(blob, "MyCompany.MyDepartment.*", gcnew Version("1.0.0.0"));
        snIdPerm2 = gcnew StrongNameIdentityPermission(blob, "MyCompany.MyDepartment.MyFile", gcnew Version("1.0.0.0"));

        try
        {

            snIdPerm3 = dynamic_cast<StrongNameIdentityPermission^>(snIdPerm1->Intersect(snIdPerm2));

            Console::WriteLine("The intersection of MyCompany.MyDepartment.*" +
                "and MyCompany.MyDepartment.MyFile is " +
                (dynamic_cast<StrongNameIdentityPermission^>(snIdPerm3))->Name);
        }
        catch (Exception^ e)
        {
            Console::WriteLine("An exception was thrown: " + e);
            returnValue = false;
        }

        return returnValue;

    }


    //</Snippet4>
    //<Snippet5>
    //Copy creates and returns an identical copy of the current permission.
    bool CopyDemo()
    {
        bool returnValue = true;
        StrongNameIdentityPermission^ snIdPerm1;
        StrongNameIdentityPermission^ snIdPerm2;
        snIdPerm1 = gcnew StrongNameIdentityPermission(blob, "MyCompany.MyDepartment.*", gcnew Version("1.0.0.0"));
        //<Snippet7>
        snIdPerm2 = gcnew StrongNameIdentityPermission(PermissionState::None);
        //</Snippet7>

        snIdPerm2 = dynamic_cast<StrongNameIdentityPermission^>(snIdPerm1->Copy());
        Console::WriteLine("Result of copy = " + snIdPerm2->ToString() + "\n");

        return returnValue;
    }


    //</Snippet5>
    //<Snippet6>
    // ToXml creates an XML encoding of the permission and its current state;
    //FromXml reconstructs a permission with the specified state from the XML encoding.
    bool ToFromXmlDemo()
    {
        bool returnValue = true;
        StrongNameIdentityPermission^ snIdPerm1;
        StrongNameIdentityPermission^ snIdPerm2;
        snIdPerm1 = gcnew StrongNameIdentityPermission(blob, "MyCompany.MyDepartment.*", gcnew Version("1.0.0.0"));    
        snIdPerm2 = gcnew StrongNameIdentityPermission(PermissionState::None);
        snIdPerm2->FromXml(snIdPerm1->ToXml());
        Console::WriteLine("Result of ToFromXml = " + snIdPerm2->ToString() + "\n");

        return returnValue;
    }


public:

    //</Snippet6>
    // Invoke all demos.
    bool RunDemo()
    {
        bool ret = true;
        bool retTmp;

        // Call the IsSubsetOf demo.
        if ( retTmp = IsSubsetOfDemo() )
            Console::WriteLine( "IsSubsetOf demo completed successfully." );
        else
            Console::WriteLine( "IsSubsetOf demo failed." );

        ret = retTmp && ret;

        // Call the Union demo.
        if ( retTmp = UnionDemo() )
            Console::WriteLine( "Union demo completed successfully." );
        else
            Console::WriteLine( "Union demo failed." );

        ret = retTmp && ret;

        // Call the Intersect demo.
        if ( retTmp = IntersectDemo() )
            Console::WriteLine( "Intersect demo completed successfully." );
        else
            Console::WriteLine( "Intersect demo failed." );

        ret = retTmp && ret;

        // Call the Copy demo.
        if ( retTmp = CopyDemo() )
            Console::WriteLine( "Copy demo completed successfully" );
        else
            Console::WriteLine( "Copy demo failed." );

        ret = retTmp && ret;

        // Call the ToFromXml demo.
        if ( retTmp = ToFromXmlDemo() )
            Console::WriteLine( "ToFromXml demo completed successfully" );
        else
            Console::WriteLine( "ToFromXml demo failed." );

        ret = retTmp && ret;
        Console::WriteLine( "********************************************************\n" );
        return (ret);
    }

};


// Test harness.
int main()
{
    try
    {
        StrongNameIdentityDemo^ democase = gcnew StrongNameIdentityDemo;
        bool ret = democase->RunDemo();
        if ( ret )
        {
            Console::WriteLine( "StrongNameIdentity demo completed successfully." );
            Console::WriteLine( "Press the Enter key to exit." );
            Console::ReadLine();
            System::Environment::ExitCode = 100;
        }
        else
        {
            Console::WriteLine( "StrongNameIdentity demo failed." );
            Console::WriteLine( "Press the Enter key to exit." );
            Console::ReadLine();
            System::Environment::ExitCode = 101;
        }
    }
    catch ( Exception^ e ) 
    {
        Console::WriteLine( "StrongNameIdentity demo failed." );
        Console::WriteLine( e );
        Console::WriteLine( "Press the Enter key to exit." );
        Console::ReadLine();
        System::Environment::ExitCode = 101;
    }

}

// </Snippet1>



