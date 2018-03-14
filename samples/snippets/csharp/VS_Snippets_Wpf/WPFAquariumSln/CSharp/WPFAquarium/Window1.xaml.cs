using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPFAquariumObjects;


namespace WPFAquarium
{
  /// <summary>
  /// Interaction logic for Window1.xaml
  /// </summary>

  public partial class Window1 : Window
  {

    public Window1()
    {
      InitializeComponent();

    }
      void WashMe(object sender, RoutedEventArgs e)
      {
          Aquarium aq = sender as Aquarium;
          MessageBox.Show("Dirty!");
      }
      void FireClean(object sender, RoutedEventArgs e)
      {
          Aquarium aq = (Aquarium)this.FindName("theAquarium");
          aq.RaiseEvent(new RoutedEventArgs(AquariumFilter.NeedsCleaningEvent));
      }
  }
}