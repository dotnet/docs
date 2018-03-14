// <Snippet1>
using System.Runtime.InteropServices;

//Interface is exposed to COM as dual.
interface IMyInterface1 
{
    //Insert code here.
}

//Interface is exposed to COM as IDispatch.
[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
interface IMyInterface2 
{
    //Insert code here.
}
// </Snippet1>

