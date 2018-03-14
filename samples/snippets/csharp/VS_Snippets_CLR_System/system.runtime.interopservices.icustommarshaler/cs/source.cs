using System;
// <Snippet4>
using System.Runtime.InteropServices;
// </Snippet4>

// <Snippet1>
public interface INew
{
    void NewMethod();
}
// </Snippet1>


// <Snippet2>
public interface ICustomMarshaler
{
     Object MarshalNativeToManaged( IntPtr pNativeData );
     IntPtr MarshalManagedToNative( Object ManagedObj );
     void CleanUpNativeData( IntPtr pNativeData );
     void CleanUpManagedData( Object ManagedObj );
     int GetNativeDataSize();
}
// </Snippet2>

namespace scope1
{
// <Snippet3>
interface IUserData
{
    void DoSomeStuff(INew pINew);
}
// </Snippet3>
}

namespace scope2
{
// <Snippet5>
interface IUserData
{
    void DoSomeStuff(
        [MarshalAs(UnmanagedType.CustomMarshaler,
             MarshalType="MyCompany.NewOldMarshaler")]
        INew pINew
    );
}
// </Snippet5>
}

class StubClass
{
    public static void Main() {}
}