using System;
using System.Windows;

namespace CSharp {

  public partial class Show3Window : Window {

    public Show3Window() {
      InitializeComponent();
    }

    //<SnippetMessageBoxShow3CODE>
    void showMessageBoxButton_Click(object sender, RoutedEventArgs e) {
      // Configure message box
      string message = "Hello, MessageBox!";
      string caption = "Caption text";
      MessageBoxButton buttons = MessageBoxButton.OKCancel;
      // Show message box
      MessageBoxResult result = MessageBox.Show(message, caption, buttons);
    }
    //</SnippetMessageBoxShow3CODE>
  }
}