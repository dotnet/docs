// UIPermCPP.cpp : main project file.



// <snippet1>
// This sample demonstrates the IsSubsetOf, Union, Intersect, Copy, ToXml and FromXml methods 
// of the UIPermission class.

using namespace System;
using namespace System::Security;
using namespace System::Security::Permissions;
using namespace System::Runtime::InteropServices;

void IsSubsetOfDemo();          // Forward references
void CopyDemo();
void UnionDemo();
void IntersectDemo();
void ToFromXmlDemo();


int main()
{
    IsSubsetOfDemo();
    CopyDemo();
    UnionDemo();
    IntersectDemo();
    ToFromXmlDemo();
}



// <Snippet2>
// IsSubsetOf determines whether the current permission is a subset of the specified permission.

void IsSubsetOfDemo()
{
    Console::WriteLine("\n**********************  IsSubsetOf() Demo **********************\n");
//<Snippet8>
    UIPermission ^ uiPerm1 = gcnew UIPermission(UIPermissionWindow::SafeTopLevelWindows);
//</Snippet8>
    UIPermission ^ uiPerm2 = gcnew UIPermission(UIPermissionWindow::SafeSubWindows);

    Console::WriteLine("   {0} is {1}a subset of {2} ", uiPerm1->Window,
                            uiPerm1->IsSubsetOf(uiPerm2)?"":"not ", uiPerm2->Window);

    Console::WriteLine("   {0} is {1}a subset of {2} ", uiPerm2->Window,
                            uiPerm2->IsSubsetOf(uiPerm1)?"":"not ", uiPerm1->Window);

//<Snippet9>
    uiPerm1 = gcnew UIPermission(UIPermissionClipboard::AllClipboard);
//</Snippet9>
    uiPerm2 = gcnew UIPermission(UIPermissionClipboard::OwnClipboard);

    Console::WriteLine("   {0} is {1}a subset of {2} ", uiPerm1->Clipboard,
                            uiPerm1->IsSubsetOf(uiPerm2)?"":"not ", uiPerm2->Clipboard);

    Console::WriteLine("   {0} is {1}a subset of {2} ", uiPerm2->Clipboard,
                            uiPerm2->IsSubsetOf(uiPerm1)?"":"not ", uiPerm1->Clipboard);
}
// </Snippet2>



// <Snippet3>
   // Union creates a new permission that is the union of the current permission
   // and the specified permission.
void UnionDemo()
{
    Console::WriteLine("\n************************  Union() Demo *************************\n");

    UIPermission ^ uiPerm1 = gcnew UIPermission(UIPermissionWindow::SafeTopLevelWindows);
    UIPermission ^ uiPerm2 = gcnew UIPermission(UIPermissionWindow::SafeSubWindows);

    UIPermission ^ p3 = dynamic_cast<UIPermission^>(uiPerm1->Union(uiPerm2));
    Console::WriteLine("   The union of {0} and  \n\t{1} = {2} ", uiPerm1->Window,
                               uiPerm2->Window, (nullptr != p3)?p3->Window.ToString():"null");
}
// </Snippet3>

// <Snippet4>
// Intersect creates and returns a new permission that is the intersection of the
// current permission and the permission specified.
void IntersectDemo()
{
    Console::WriteLine("\n**********************  Intersect() Demo ***********************\n");
//<Snippet10>
    UIPermission ^ uiPerm1 = gcnew UIPermission(UIPermissionWindow::SafeTopLevelWindows,UIPermissionClipboard::OwnClipboard);
//</Snippet10>
    UIPermission ^ uiPerm2 = gcnew UIPermission(UIPermissionWindow::SafeSubWindows,UIPermissionClipboard::NoClipboard);
    UIPermission ^ p3 = (UIPermission^)uiPerm1->Intersect(uiPerm2);

        Console::WriteLine("   The intersection of {0} and \n\t{1} = {2} ", uiPerm1->Window,
                               uiPerm1->Window, (nullptr != p3)?p3->Window.ToString():"null");

        Console::WriteLine("   The intersection of " + uiPerm1->Clipboard.ToString() + " and \n\t" +
                uiPerm2->Clipboard.ToString() + " is " + p3->Clipboard.ToString());
}
//</Snippet4>


//<Snippet5>
//Copy creates and returns an identical copy of the current permission.
void CopyDemo()
{
    Console::WriteLine("\n*************************  Copy() Demo *************************\n");

    UIPermission ^ uiPerm1 = gcnew UIPermission(UIPermissionWindow::SafeTopLevelWindows);
    //<Snippet7>
    UIPermission ^ uiPerm2 = gcnew UIPermission(PermissionState::None);
    //</Snippet7>
    uiPerm2 = (UIPermission ^)uiPerm1->Copy();
    if (uiPerm2 != nullptr)
        Console::WriteLine("The copy succeeded:  " + uiPerm2->ToString());
}
//</Snippet5>

//<Snippet6>

// ToXml creates an XML encoding of the permission and its current state; FromXml reconstructs a
// permission with the specified state from the XML encoding.
void ToFromXmlDemo()
{
    Console::WriteLine("\n**********************  To/From XML() Demo *********************\n");

    UIPermission ^ uiPerm1 = gcnew UIPermission(UIPermissionWindow::SafeTopLevelWindows);
    UIPermission ^ uiPerm2 = gcnew UIPermission(PermissionState::None);
    uiPerm2->FromXml(uiPerm1->ToXml());
    bool result = uiPerm2->Equals(uiPerm1);
    if (result)
        Console::WriteLine("Result of ToFromXml = " + uiPerm2->ToString());
    else
        {
        Console::WriteLine(uiPerm2->ToString());
        Console::WriteLine(uiPerm1->ToString());
        }
}
//</Snippet6>
//</snippet1>

/*
// This code example creates the following output:

**********************  IsSubsetOf() Demo **********************

   SafeTopLevelWindows is not a subset of SafeSubWindows
   SafeSubWindows is a subset of SafeTopLevelWindows
   AllClipboard is not a subset of OwnClipboard
   OwnClipboard is a subset of AllClipboard

*************************  Copy() Demo *************************

The copy succeeded:  <IPermission class="System.Security.Permissions.UIPermissio
n, mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
version="1"
Window="SafeTopLevelWindows"/>


************************  Union() Demo *************************

   The union of SafeTopLevelWindows and
        SafeSubWindows = SafeTopLevelWindows

**********************  Intersect() Demo ***********************

   The intersection of SafeTopLevelWindows and
        SafeTopLevelWindows = SafeSubWindows
   The intersection of OwnClipboard and
        NoClipboard is NoClipboard

**********************  To/From XML() Demo *********************

Result of ToFromXml = <IPermission class="System.Security.Permissions.UIPermissi
on, mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"

version="1"
Window="SafeTopLevelWindows"/>

*/ 