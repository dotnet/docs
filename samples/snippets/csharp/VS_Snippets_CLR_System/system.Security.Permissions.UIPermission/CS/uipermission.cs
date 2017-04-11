// <Snippet1>
using System;
using System.Security;
using System.Security.Permissions;

public class UIPermissionDemo
{

    public static void Main(String[] args)
    {
        IsSubsetOfDemo();
        CopyDemo();
        UnionDemo();
        IntersectDemo();
        ToFromXmlDemo();
    }

    // <Snippet2>
    // IsSubsetOf determines whether the current permission is a subset of the specified permission.
    private static void IsSubsetOfDemo()
    {
        //<Snippet8>
        UIPermission uiPerm1 = new UIPermission(UIPermissionWindow.SafeTopLevelWindows);
        //</Snippet8>
        UIPermission uiPerm2 = new UIPermission(UIPermissionWindow.SafeSubWindows);
        CheckIsSubsetOfWindow(uiPerm1, uiPerm2);
        //<Snippet9>
        uiPerm1 = new UIPermission(UIPermissionClipboard.AllClipboard);
        //</Snippet9>
        uiPerm2 = new UIPermission(UIPermissionClipboard.OwnClipboard);
        CheckIsSubsetOfClipBoard(uiPerm1, uiPerm2);
    }
    private static void CheckIsSubsetOfWindow(UIPermission uiPerm1, UIPermission uiPerm2)
    {
        if (uiPerm1.IsSubsetOf(uiPerm2))
        {
            Console.WriteLine(uiPerm1.Window.ToString() + " is a subset of " +
                uiPerm2.Window.ToString());
        }
        else
        {
            Console.WriteLine(uiPerm1.Window.ToString() + " is not a subset of " +
                uiPerm2.Window.ToString());

        }
        if (uiPerm2.IsSubsetOf(uiPerm1))
        {
            Console.WriteLine(uiPerm2.Window.ToString() + " is a subset of " +
                uiPerm1.Window.ToString());
        }
        else
        {
            Console.WriteLine(uiPerm2.Window.ToString() + " is not a subset of " +
                uiPerm1.Window.ToString());

        }
    }
    private static void CheckIsSubsetOfClipBoard(UIPermission uiPerm1, UIPermission uiPerm2)
    {
        if (uiPerm1.IsSubsetOf(uiPerm2))
        {
            Console.WriteLine(uiPerm1.Clipboard.ToString() + " is a subset of " +
                uiPerm2.Clipboard.ToString());
        }
        else
        {
            Console.WriteLine(uiPerm1.Clipboard.ToString() + " is not a subset of " +
                uiPerm2.Clipboard.ToString());

        }
        if (uiPerm2.IsSubsetOf(uiPerm1))
        {
            Console.WriteLine(uiPerm2.Clipboard.ToString() + " is a subset of " +
                uiPerm1.Clipboard.ToString());
        }
        else
        {
            Console.WriteLine(uiPerm2.Clipboard.ToString() + " is not a subset of " +
                uiPerm1.Clipboard.ToString());

        }
    }
    // </Snippet2>
    // <Snippet3>
    // Union creates a new permission that is the union of the current permission
    // and the specified permission.
    private static void UnionDemo()
    {
        UIPermission uiPerm1 = new UIPermission(UIPermissionWindow.SafeTopLevelWindows);
        UIPermission uiPerm2 = new UIPermission(UIPermissionWindow.SafeSubWindows);
        UIPermission p3 = (UIPermission)uiPerm1.Union(uiPerm2);
        try
        {
            if (p3 != null)
            {
                Console.WriteLine("The union of " + uiPerm1.Window.ToString() +
                    " and \n\t" + uiPerm2.Window.ToString() + " is \n\t"
                    + p3.Window.ToString() + "\n");

            }
            else
            {
                Console.WriteLine("The union of " + uiPerm1.Window.ToString() +
                    " and \n\t" + uiPerm2.Window.ToString() + " is null.\n");
            }
        }
        catch (SystemException e)
        {
            Console.WriteLine("The union of " + uiPerm1.Window.ToString() +
                    " and \n\t" + uiPerm2.Window.ToString() + " failed.");

            Console.WriteLine(e.Message);
        }

    }
    // </Snippet3>
    // <Snippet4>
    // Intersect creates and returns a new permission that is the intersection of the
    // current permission and the permission specified.
    private static void IntersectDemo()
    {
        //<Snippet10>
        UIPermission uiPerm1 = new UIPermission(UIPermissionWindow.SafeTopLevelWindows, UIPermissionClipboard.OwnClipboard);
        //</Snippet10>
        UIPermission uiPerm2 = new UIPermission(UIPermissionWindow.SafeSubWindows, UIPermissionClipboard.NoClipboard);
        UIPermission p3 = (UIPermission)uiPerm1.Intersect(uiPerm2);

        Console.WriteLine("The intersection of " + uiPerm1.Window.ToString() + " and \n\t" +
            uiPerm2.Window.ToString() + " is " + p3.Window.ToString() + "\n");
        Console.WriteLine("The intersection of " + uiPerm1.Clipboard.ToString() + " and \n\t" +
                uiPerm2.Clipboard.ToString() + " is " + p3.Clipboard.ToString() + "\n");

    }
    //</Snippet4>
    //<Snippet5>
    //Copy creates and returns an identical copy of the current permission.
    private static void CopyDemo()
    {

        UIPermission uiPerm1 = new UIPermission(UIPermissionWindow.SafeTopLevelWindows);
        //<Snippet7>
        UIPermission uiPerm2 = new UIPermission(PermissionState.None);
        //</Snippet7>
        uiPerm2 = (UIPermission)uiPerm1.Copy();
        if (uiPerm2 != null)
        {
            Console.WriteLine("The copy succeeded:  " + uiPerm2.ToString() + " \n");
        }

    }
    //</Snippet5>
    //<Snippet6>
    // ToXml creates an XML encoding of the permission and its current state; FromXml reconstructs a
    // permission with the specified state from the XML encoding.
    private static void ToFromXmlDemo()
    {


        UIPermission uiPerm1 = new UIPermission(UIPermissionWindow.SafeTopLevelWindows);
        UIPermission uiPerm2 = new UIPermission(PermissionState.None);
        uiPerm2.FromXml(uiPerm1.ToXml());
        bool result = uiPerm2.Equals(uiPerm1);
        if (result)
        {
            Console.WriteLine("Result of ToFromXml = " + uiPerm2.ToString());
        }
        else
        {
            Console.WriteLine(uiPerm2.ToString());
            Console.WriteLine(uiPerm1.ToString());
        }

    }
    //</Snippet6>

}

// </Snippet1>
// This code example creates the following output:

//SafeTopLevelWindows is not a subset of SafeSubWindows
//SafeSubWindows is a subset of SafeTopLevelWindows
//AllClipboard is not a subset of OwnClipboard
//OwnClipboard is a subset of AllClipboard
//The copy succeeded:  <IPermission class="System.Security.Permissions.UIPermissio
//n, mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
//version="1"
//Window="SafeTopLevelWindows"/>


//The union of SafeTopLevelWindows and
//        SafeSubWindows is
//        SafeTopLevelWindows

//The intersection of SafeTopLevelWindows and
//        SafeSubWindows is SafeSubWindows

//The intersection of OwnClipboard and
//        NoClipboard is NoClipboard

//Result of ToFromXml = <IPermission class="System.Security.Permissions.UIPermissi
//on, mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"

//version="1"
//Window="SafeTopLevelWindows"/>