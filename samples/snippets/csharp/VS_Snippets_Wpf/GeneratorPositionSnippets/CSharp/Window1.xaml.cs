using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace GeneratorPositionSnippets {
  /// <summary>
  /// Interaction logic for Window1.xaml
  /// </summary>

  public partial class Window1 : Window {

    public Window1() {
      InitializeComponent();
    }
    
    void GenerateForwardFromBeginning() {
      //<SnippetGenerateForwardFromBeginningCODE>
      // Start generating items forward from the beginning of the item list
      GeneratorPosition position = new GeneratorPosition(-1, 0);
      GeneratorDirection direction = GeneratorDirection.Forward;
      IItemContainerGenerator generator = (IItemContainerGenerator)this.itemsControl.ItemContainerGenerator;
      generator.StartAt(position, direction);
      //</SnippetGenerateForwardFromBeginningCODE>
    }

    void GenerateBackFromEnd() {
      //<SnippetGenerateBackwardFromEndCODE>
      // Start generating items backward from the end of the item list
      GeneratorPosition position = new GeneratorPosition(-1, 0);
      GeneratorDirection direction = GeneratorDirection.Backward;
      IItemContainerGenerator generator = (IItemContainerGenerator)this.itemsControl.ItemContainerGenerator;
      generator.StartAt(position, direction);
      //</SnippetGenerateBackwardFromEndCODE>
    }

    void GenerateForwardFromMiddle() {
      //<SnippetGenerateForwardFromMiddleCODE>
      // Start generating items forward,
      // starting with the first unrealized item (offset of 1),
      // after the 5th realized item
      // (the item with index 4 among all realized items) in the list
      GeneratorPosition position = new GeneratorPosition(4, 1);
      GeneratorDirection direction = GeneratorDirection.Forward;
      IItemContainerGenerator generator = (IItemContainerGenerator)this.itemsControl.ItemContainerGenerator;
      generator.StartAt(position, direction);
      //</SnippetGenerateForwardFromMiddleCODE>
    }
  }
}