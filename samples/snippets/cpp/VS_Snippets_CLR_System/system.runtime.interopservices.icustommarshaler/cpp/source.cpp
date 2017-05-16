using namespace System;
// <Snippet4>
using namespace System::Runtime::InteropServices;
// </Snippet4>

// <Snippet1>
public interface class INew
{
    void NewMethod();
};
// </Snippet1>


// <Snippet2>
public interface class ICustomMarshaler
{
     Object^ MarshalNativeToManaged( IntPtr^ pNativeData );
     IntPtr^ MarshalManagedToNative( Object^ ManagedObj );
     void CleanUpNativeData( IntPtr^ pNativeData );
     void CleanUpManagedData( Object^ ManagedObj );
     int GetNativeDataSize();
};
// </Snippet2>

namespace scope1
{
// <Snippet3>
public interface class IUserData
{
    void DoSomeStuff(INew^ pINew);
};
// </Snippet3>
}

namespace scope2
{
// <Snippet5>
public interface class IUserData
{
    void DoSomeStuff(
        [MarshalAs(UnmanagedType::CustomMarshaler,
             MarshalType="MyCompany.NewOldMarshaler")]
        INew^ pINew
    );
};
// </Snippet5>
}

int main() {}