using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;
using System.Collections.Generic;

namespace MyNamespace
{
  public partial class MyCode : Canvas
  {
      void MakeANewThing(object sender, RoutedEventArgs e)
      {
      DockPanel myDockPanel = new DockPanel();
      CheckBox myCheckBox = new CheckBox();
      myCheckBox.Content = "Hello";
      myDockPanel.Children.Add(myCheckBox);
      DockPanel.SetDock(myCheckBox, Dock.Top);
      }

        public static readonly DependencyProperty IsSpinningProperty = 
          DependencyProperty.Register(
          "IsSpinning", typeof(Boolean),
          typeof(MyCode)
          );
      public bool IsSpinning
      {
          get { return (bool)GetValue(IsSpinningProperty); }
          set { SetValue(IsSpinningProperty, value); }
      }
      void DoAqStuff()
      {
          Aquarium myAq1 = new Aquarium();
          Aquarium myAq2 = new Aquarium();
          Fish f1 = new Fish();
          Fish f2 = new Fish();
          myAq1.AquariumContents.Add(f1);
          myAq2.AquariumContents.Add(f2);
          MessageBox.Show("aq1 contains " + myAq1.AquariumContents.Count.ToString() + " things");
          MessageBox.Show("aq2 contains " + myAq2.AquariumContents.Count.ToString() + " things");
      }
      void BAQ(object sender, EventArgs e)
      {
          DoAqStuff();
      }
  }
//<SnippetCollectionProblemDefinition>
    public class Fish : FrameworkElement { }
    public class Aquarium : DependencyObject {
        private static readonly DependencyPropertyKey AquariumContentsPropertyKey =
            DependencyProperty.RegisterReadOnly(
              "AquariumContents",
              typeof(List<FrameworkElement>),
              typeof(Aquarium),
              new FrameworkPropertyMetadata(new List<FrameworkElement>())
            );
        public static readonly DependencyProperty AquariumContentsProperty =
            AquariumContentsPropertyKey.DependencyProperty;

        public List<FrameworkElement> AquariumContents
        {
            get { return (List<FrameworkElement>)GetValue(AquariumContentsProperty); }
        }

        // ...

    }
//</SnippetCollectionProblemDefinition>
}
