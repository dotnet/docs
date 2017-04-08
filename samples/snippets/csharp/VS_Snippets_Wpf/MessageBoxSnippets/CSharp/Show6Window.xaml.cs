using System;
using System.Windows;

namespace CSharp {

  public partial class Show6Window : Window {

    public Show6Window() {
      InitializeComponent();
    }

    //<SnippetMessageBoxShow6CODE>
    void showMessageBoxButton_Click(object sender, RoutedEventArgs e) {
      // Configure message box
      string message = "Hello, MessageBox!";
      string caption = "Caption text";
      MessageBoxButton buttons = MessageBoxButton.OKCancel;
      MessageBoxImage icon = MessageBoxImage.Information;
      MessageBoxResult defaultResult = MessageBoxResult.OK;
      MessageBoxOptions options = MessageBoxOptions.RtlReading;
      // Show message box
      MessageBoxResult result = MessageBox.Show(message, caption, buttons, icon, defaultResult, options);
    }
    //</SnippetMessageBoxShow6CODE>
  }
}