//<SnippetWindowRestoreBoundsCODEBEHIND1>
using System;
using System.ComponentModel;
using System.IO;
using System.IO.IsolatedStorage;
using System.Windows;

//</SnippetWindowRestoreBoundsCODEBEHIND1>
namespace WindowRestoreBoundsSnippets {
  //<SnippetWindowRestoreBoundsCODEBEHIND2>
  public partial class MainWindow : Window {

    string filename = "settings.txt";

    public MainWindow() {
      InitializeComponent();

      // Refresh restore bounds from previous window opening
      IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForAssembly();
      try {
        using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(this.filename, FileMode.Open, storage))
        using (StreamReader reader = new StreamReader(stream)) {

          // Read restore bounds value from file
          Rect restoreBounds = Rect.Parse(reader.ReadLine());
          this.Left = restoreBounds.Left;
          this.Top = restoreBounds.Top;
          this.Width = restoreBounds.Width;
          this.Height = restoreBounds.Height;
        }
      }
      catch (FileNotFoundException ex) {
        // Handle when file is not found in isolated storage, which is when:
        // * This is first application session
        // * The file has been deleted
      }
      
    }

    void MainWindow_Closing(object sender, CancelEventArgs e) {
      // Save restore bounds for the next time this window is opened
      IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForAssembly();
      using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(this.filename, FileMode.Create, storage))
      using (StreamWriter writer = new StreamWriter(stream)) {
        // Write restore bounds value to file
        writer.WriteLine(this.RestoreBounds.ToString());
      }
    }
  }
  //</SnippetWindowRestoreBoundsCODEBEHIND2>
}