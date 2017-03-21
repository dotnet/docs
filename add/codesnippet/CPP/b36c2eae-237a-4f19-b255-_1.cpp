// Intersect creates and returns a new permission that is the intersection of the
// current permission and the permission specified.
void IntersectDemo()
{
    Console::WriteLine("\n**********************  Intersect() Demo ***********************\n");
    UIPermission ^ uiPerm1 = gcnew UIPermission(UIPermissionWindow::SafeTopLevelWindows,UIPermissionClipboard::OwnClipboard);
    UIPermission ^ uiPerm2 = gcnew UIPermission(UIPermissionWindow::SafeSubWindows,UIPermissionClipboard::NoClipboard);
    UIPermission ^ p3 = (UIPermission^)uiPerm1->Intersect(uiPerm2);

        Console::WriteLine("   The intersection of {0} and \n\t{1} = {2} ", uiPerm1->Window,
                               uiPerm1->Window, (nullptr != p3)?p3->Window.ToString():"null");

        Console::WriteLine("   The intersection of " + uiPerm1->Clipboard.ToString() + " and \n\t" +
                uiPerm2->Clipboard.ToString() + " is " + p3->Clipboard.ToString());
}