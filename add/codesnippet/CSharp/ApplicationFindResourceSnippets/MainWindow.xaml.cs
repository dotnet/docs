using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ApplicationFindResourceSnippets {

  public partial class MainWindow : Window {
    public MainWindow() {
      InitializeComponent();
    }
    //<SnippetApplicationCallFindResourceCODEBEHIND>    
    void findResourceButton_Click(object sender, RoutedEventArgs e) {
      try {
        object resource = Application.Current.FindResource("UnfindableResource");
      }
      catch (ResourceReferenceKeyNotFoundException ex) {
        MessageBox.Show("Resource not found.");
      }
    }
    //</SnippetApplicationCallFindResourceCODEBEHIND>
  }
}