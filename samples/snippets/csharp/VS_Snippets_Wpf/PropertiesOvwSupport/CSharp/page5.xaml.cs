using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;
using System.Collections.Generic;


namespace MyAquarium {

  public partial class MyCode : Page {
      void UpdateFish(object sender, EventArgs e)
      {
          Fish f = (Fish) aq.AquariumContents[0];
          f.Species = "Guppy";
      }
  }

  public class Fish : FrameworkElement {
      public static readonly DependencyProperty SpeciesProperty = 
      DependencyProperty.Register(
      "Species",
      typeof(string),
      typeof(Fish),
      new FrameworkPropertyMetadata("Default")
      );
      public string Species {
          get {return (string) GetValue(SpeciesProperty);}
          set {SetValue(SpeciesProperty,(string)value);}
      }
  }
  public class Aquarium : Canvas
  {
    private static readonly DependencyProperty AquariumContentsProperty =
      DependencyProperty.Register(
        "AquariumContents",
        typeof(FreezableCollection<FrameworkElement>),
        typeof(Aquarium),
        new FrameworkPropertyMetadata(new FreezableCollection<FrameworkElement>())
      );
    public FreezableCollection<FrameworkElement>
      AquariumContents
      {
      get {
          return (FreezableCollection<FrameworkElement>)GetValue(AquariumContentsProperty); 
      }
    }
    public Aquarium() : base()
    {
      SetValue(AquariumContentsProperty, new FreezableCollection<FrameworkElement>());
    }
  }
}

        