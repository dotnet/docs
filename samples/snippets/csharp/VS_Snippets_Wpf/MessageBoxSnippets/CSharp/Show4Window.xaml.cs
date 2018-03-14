using System;
using System.Windows;

namespace CSharp {

  public partial class Show4Window : Window {

    public Show4Window() {
      InitializeComponent();
    }

    //<SnippetMessageBoxShow4CODE>
    void showMessageBoxButton_Click(object sender, RoutedEventArgs e) {
      // Configure message box
      string message = "Hello, MessageBox!";
      string caption = "Caption text";
      MessageBoxButton buttons = MessageBoxButton.OKCancel;
      MessageBoxImage icon = MessageBoxImage.Information;
      // Show message box
      MessageBoxResult result = MessageBox.Show(message, caption, buttons, icon);
    }
    //</SnippetMessageBoxShow4CODE>
  }
}