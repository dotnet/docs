using System;
using System.Collections.ObjectModel;
using System.AddIn.Hosting;
using System.Windows;

using HostViews;

namespace Host
{
    public partial class MainWindow : Window
    {
        IWPFAddInHostView wpfAddInHostView;

        public MainWindow()
        {
            InitializeComponent();
        }

        void fileExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        void loadAddInUIMenuItem_Click(object sender, RoutedEventArgs e)
        {
//<SnippetGetUICode>
// Get add-in pipeline folder (the folder in which this application was launched from)
string appPath = Environment.CurrentDirectory;

// Rebuild visual add-in pipeline
string[] warnings = AddInStore.Rebuild(appPath);
if (warnings.Length > 0)
{
    string msg = "Could not rebuild pipeline:";
    foreach (string warning in warnings) msg += "\n" + warning;
    MessageBox.Show(msg);
    return;
}

// Activate add-in with Internet zone security isolation
Collection<AddInToken> addInTokens = AddInStore.FindAddIns(typeof(IWPFAddInHostView), appPath);
AddInToken wpfAddInToken = addInTokens[0];
this.wpfAddInHostView = wpfAddInToken.Activate<IWPFAddInHostView>(AddInSecurityLevel.Internet);

// Get and display add-in UI
FrameworkElement addInUI = this.wpfAddInHostView.GetAddInUI();
this.addInUIHostGrid.Children.Add(addInUI);
//</SnippetGetUICode>
        }

        void unloadAddInUIMenuItem_Click(object sender, RoutedEventArgs e)
        {
            // Stop displyaing add-in UI
            this.addInUIHostGrid.Children.Clear();

            // Unload add-in
            AddInController addInController = AddInController.GetAddInController(this.wpfAddInHostView);
            addInController.Shutdown();
        }
    }
}
//</SnippetHostAppMainWindowCodeBehind>
