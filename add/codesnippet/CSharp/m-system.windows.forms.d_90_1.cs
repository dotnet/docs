public class CustomDataGridView : DataGridView
{
    [System.Security.Permissions.UIPermission(
        System.Security.Permissions.SecurityAction.LinkDemand,
        Window = System.Security.Permissions.UIPermissionWindow.AllWindows)]
    protected override bool ProcessDialogKey(Keys keyData)
    {
        // Extract the key code from the key value. 
        Keys key = (keyData & Keys.KeyCode);

        // Handle the ENTER key as if it were a RIGHT ARROW key. 
        if (key == Keys.Enter)
        {
            return this.ProcessRightKey(keyData);
        }
        return base.ProcessDialogKey(keyData);
    }

    [System.Security.Permissions.SecurityPermission(
        System.Security.Permissions.SecurityAction.LinkDemand, Flags = 
        System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode)]
    protected override bool ProcessDataGridViewKey(KeyEventArgs e)
    {
        // Handle the ENTER key as if it were a RIGHT ARROW key. 
        if (e.KeyCode == Keys.Enter)
        {
            return this.ProcessRightKey(e.KeyData);
        }
        return base.ProcessDataGridViewKey(e);
    }
}