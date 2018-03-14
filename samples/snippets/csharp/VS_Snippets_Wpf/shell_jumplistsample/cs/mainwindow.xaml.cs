// <snippet200>
using System;
using System.IO;
using System.Windows;
using System.Windows.Shell;

namespace JumpListSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        // <snippet240>
        private void AddTask(object sender, RoutedEventArgs e)
        {
            // <snippet241>
            // Configure a new JumpTask.
            JumpTask jumpTask1 = new JumpTask();
            // Get the path to Calculator and set the JumpTask properties.
            jumpTask1.ApplicationPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.SystemX86), "calc.exe");
            jumpTask1.IconResourcePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.SystemX86), "calc.exe");
            jumpTask1.Title = "Calculator";
            jumpTask1.Description = "Open Calculator.";
            jumpTask1.CustomCategory = "User Added Tasks";
            // </snippet241>
            // <snippet242>
            // Get the JumpList from the application and update it.
            JumpList jumpList1 = JumpList.GetJumpList(App.Current);
            jumpList1.JumpItems.Add(jumpTask1);
            JumpList.AddToRecentCategory(jumpTask1);
            jumpList1.Apply();
            // </snippet242>
        }
        // </snippet240>
        // <snippet230>
        private void ClearJumpList(object sender, RoutedEventArgs e)
        {
            JumpList jumpList1 = JumpList.GetJumpList(App.Current);
            jumpList1.JumpItems.Clear();
            jumpList1.Apply();
        }
        // </snippet230>
        // <snippet210>
        private void SetNewJumpList(object sender, RoutedEventArgs e)
        {
            //Configure a new JumpTask
            JumpTask jumpTask1 = new JumpTask();
            // Get the path to WordPad and set the JumpTask properties.
            jumpTask1.ApplicationPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "write.exe");
            jumpTask1.IconResourcePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "write.exe");
            jumpTask1.Title = "WordPad";
            jumpTask1.Description = "Open WordPad.";
            jumpTask1.CustomCategory = "Jump List 2";
            // Create and set the new JumpList.
            JumpList jumpList2 = new JumpList();
            jumpList2.JumpItems.Add(jumpTask1);
            JumpList.SetJumpList(App.Current, jumpList2);
        }
        // </snippet210>
    }
}
// </snippet200>
