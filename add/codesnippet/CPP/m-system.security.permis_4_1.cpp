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