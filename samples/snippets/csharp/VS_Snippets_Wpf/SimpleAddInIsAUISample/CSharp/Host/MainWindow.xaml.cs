using System;
using System.Collections.ObjectModel;
using System.AddIn.Hosting;
using System.Windows;

using HostViews;

namespace Host
{
    public partial class MainWindow : Window
    {
        WPFAddInHostView wpfAddInHostView;

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
Collection<AddInToken> addInTokens = AddInStore.FindAddIns(typeof(WPFAddInHostView), appPath);
AddInToken wpfAddInToken = addInTokens[0];
this.wpfAddInHostView = wpfAddInToken.Activate<WPFAddInHostView>(AddInSecurityLevel.Internet);

// Display add-in UI
this.addInUIHostGrid.Children.Add(this.wpfAddInHostView);
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