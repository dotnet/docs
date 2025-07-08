using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

[GeneratedComInterface]
[Guid("5401c312-ab23-4dd3-aa40-3cb4b3a4683e")]
partial interface IComInterface
{
    void DoWork();
}

internal partial class MyNativeLib
{
    [LibraryImport(nameof(MyNativeLib))]
    public static partial void GetComInterface(out IComInterface comInterface);
}
