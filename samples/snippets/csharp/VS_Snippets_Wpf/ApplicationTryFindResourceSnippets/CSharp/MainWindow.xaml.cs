using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ApplicationTryFindResourceSnippets {

  public partial class MainWindow : Window {
    public MainWindow() {
      InitializeComponent();
    }
    //<SnippetApplicationCallTryFindResourceCODEBEHIND1>    
    void tryFindResourceButton_Click(object sender, RoutedEventArgs e) {
      object resource = Application.Current.TryFindResource("ApplicationResource");
      // If resource found, do something with it
      if (resource != null) {
        //</SnippetApplicationCallTryFindResourceCODEBEHIND1>
        //<SnippetApplicationCallTryFindResourceCODEBEHIND2>
      }
    }
    //</SnippetApplicationCallTryFindResourceCODEBEHIND2>
  }
}