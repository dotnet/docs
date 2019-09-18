### Modernization of the FolderBrowserDialog

The <xref:System.Windows.Forms.FolderBrowserDialog> control has change in Windows Forms applications for .NET Core.

#### Change description

In the .NET Framework, Windows forms uses the following dialog for the <xref:System.Windows.Forms.FolderBrowserDialog> control.

![The FolderBrowserDialogControl in the .NET Framework](~/includes/core-changes/windowsforms/media/folderdlg-framework.png)

In .NET Core 3.0, Windows Forms users a newer COM-based control that was introduced in Windows Vista:

![The FolderBrowserDialogControl in the .NET Core](~/includes/core-changes/windowsforms/media/folderdlg-core.png)

#### Version introduced

3.0

#### Recommended action

The dialog will be upgraded automatically.

If you desire to retain the original dialog, set the <xref:System.Windows.Forms.FolderBrowserDialog.AutoUpgradeEnabled?displayProperty=nameWithType> property to `false` before showing the dialog, as illustrated by the following code fragment:

```csharp
var dialog = new FolderBrowserDialog();
dialog.AutoUpgradeEnabled = false;
dialog.ShowDialog();
```

#### Category

Windows Forms

#### Affected APIs

- None

<!-- 

### Affected APIs

Not detectable via API analysis

-->