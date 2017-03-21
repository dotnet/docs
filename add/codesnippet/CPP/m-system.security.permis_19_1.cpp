//Copy creates and returns an identical copy of the current permission.
void CopyDemo()
{
    Console::WriteLine("\n*************************  Copy() Demo *************************\n");

    UIPermission ^ uiPerm1 = gcnew UIPermission(UIPermissionWindow::SafeTopLevelWindows);
    UIPermission ^ uiPerm2 = gcnew UIPermission(PermissionState::None);
    uiPerm2 = (UIPermission ^)uiPerm1->Copy();
    if (uiPerm2 != nullptr)
        Console::WriteLine("The copy succeeded:  " + uiPerm2->ToString());
}