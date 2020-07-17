using System.Windows;

public partial class OwnerWindow : System.Windows.Window
{
    public OwnerWindow()
    {
        InitializeComponent();
    }

    void OpenOwnedWindow()
    {
        // NOTE: Owner must be shown before it can own another window

        // Create new owned window and show it
        OwnedWindow ownedWindow = new OwnedWindow();
        ownedWindow.Owner = this;
        ownedWindow.Show();
    }
}