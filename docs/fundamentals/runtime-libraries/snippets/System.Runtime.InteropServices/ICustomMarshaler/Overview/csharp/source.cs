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
    Object MarshalNativeToManaged(IntPtr pNativeData);
    IntPtr MarshalManagedToNative(Object ManagedObj);
    void CleanUpNativeData(IntPtr pNativeData);
    void CleanUpManagedData(Object ManagedObj);
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
             MarshalType="NewOldMarshaler")]
        INew pINew
        );
    }
    // </Snippet5>
}

// <Snippet6>
public class NewOldMarshaler : ICustomMarshaler
{
    public static ICustomMarshaler GetInstance(string pstrCookie)
        => new NewOldMarshaler();

    public Object MarshalNativeToManaged(IntPtr pNativeData) => throw new NotImplementedException();
    public IntPtr MarshalManagedToNative(Object ManagedObj) => throw new NotImplementedException();
    public void CleanUpNativeData(IntPtr pNativeData) => throw new NotImplementedException();
    public void CleanUpManagedData(Object ManagedObj) => throw new NotImplementedException();
    public int GetNativeDataSize() => throw new NotImplementedException();
}
// </Snippet6>

class StubClass
{
    public static void Main() { }
}
