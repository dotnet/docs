// IsSubsetOf determines whether the current permission is a subset of the specified permission.

void IsSubsetOfDemo()
{
    Console::WriteLine("\n**********************  IsSubsetOf() Demo **********************\n");
    UIPermission ^ uiPerm1 = gcnew UIPermission(UIPermissionWindow::SafeTopLevelWindows);
    UIPermission ^ uiPerm2 = gcnew UIPermission(UIPermissionWindow::SafeSubWindows);

    Console::WriteLine("   {0} is {1}a subset of {2} ", uiPerm1->Window,
                            uiPerm1->IsSubsetOf(uiPerm2)?"":"not ", uiPerm2->Window);

    Console::WriteLine("   {0} is {1}a subset of {2} ", uiPerm2->Window,
                            uiPerm2->IsSubsetOf(uiPerm1)?"":"not ", uiPerm1->Window);

    uiPerm1 = gcnew UIPermission(UIPermissionClipboard::AllClipboard);
    uiPerm2 = gcnew UIPermission(UIPermissionClipboard::OwnClipboard);

    Console::WriteLine("   {0} is {1}a subset of {2} ", uiPerm1->Clipboard,
                            uiPerm1->IsSubsetOf(uiPerm2)?"":"not ", uiPerm2->Clipboard);

    Console::WriteLine("   {0} is {1}a subset of {2} ", uiPerm2->Clipboard,
                            uiPerm2->IsSubsetOf(uiPerm1)?"":"not ", uiPerm1->Clipboard);
}