//<Snippet1>
using System;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;


class SafeHandlesExample
{

    static void Main()
    {
        UnmanagedMutex uMutex = new UnmanagedMutex("YourCompanyName_SafeHandlesExample_MUTEX");

        try
        {

            uMutex.Create();
            Console.WriteLine("Mutex created. Press Enter to release it.");
            Console.ReadLine();


        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        finally
        {
            uMutex.Release();
            Console.WriteLine("Mutex Released.");
        }

        Console.ReadLine();


    }
}

class UnmanagedMutex 
{


    // Use interop to call the CreateMutex function.
    // For more information about CreateMutex,
    // see the unmanaged MSDN reference library.
    [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
    static extern IntPtr CreateMutex(IntPtr lpMutexAttributes, bool bInitialOwner,
   string lpName);


    [DllImport("kernel32.dll")]
    public static extern bool ReleaseMutex(SafeWaitHandle hMutex);



    private SafeWaitHandle handleValue = null;
    private IntPtr mutexAttrValue = IntPtr.Zero;
    private string nameValue = null;

    public UnmanagedMutex(string Name)
    {
        nameValue = Name;
    }


    public void Create()
    {
        if (nameValue == null && nameValue.Length == 0)
        {
            throw new ArgumentNullException("nameValue");
        }

         IntPtr ptr = CreateMutex(mutexAttrValue,
                                        true, nameValue);

         handleValue = new SafeWaitHandle(ptr, true);

         // If the handle is invalid,
        // get the last Win32 error 
        // and throw a Win32Exception.
        if (handleValue.IsInvalid)
        {
            Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
        }
    }

    public SafeWaitHandle Handle
    {
        get
        {
            // If the handle is valid,
            // return it.
            if (!handleValue.IsInvalid)
            {
                return handleValue;
            }
            else
            {
                return null;
            }
        }

    }

    public string Name
    {
        get
        {
            return nameValue;
        }

    }


    public void Release()
    {
        ReleaseMutex(handleValue);
    }

}
//</Snippet1>