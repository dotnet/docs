using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace CSharp {
  public partial class MainWindow : Window {
  
    public MainWindow() {
      InitializeComponent();
    }

    void Show1(object sender, RoutedEventArgs e) {
      (new Show1Window()).ShowDialog();
    }
    void Show2(object sender, RoutedEventArgs e) {
      (new Show2Window()).ShowDialog();
    }
    void Show3(object sender, RoutedEventArgs e) {
      (new Show3Window()).ShowDialog();
    }
    void Show4(object sender, RoutedEventArgs e) {
      (new Show4Window()).ShowDialog();
    }
    void Show5(object sender, RoutedEventArgs e) {
      (new Show5Window()).ShowDialog();
    }
    void Show6(object sender, RoutedEventArgs e) {
      (new Show6Window()).ShowDialog();
    }
  }
}