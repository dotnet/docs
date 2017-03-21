using System;
using System.Windows;

namespace CSharp {

  public partial class Show1Window : Window {

    public Show1Window() {
      InitializeComponent();
    }
    
    //<SnippetMessageBoxShow1CODE>
    void showMessageBoxButton_Click(object sender, RoutedEventArgs e) {
      // Configure message box
      string message = "Hello, MessageBox!";
      // Show message box
      MessageBoxResult result = MessageBox.Show(message);
    }
    //</SnippetMessageBoxShow1CODE>
  }
}