using System;
using System.Text;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Data;
using Foo;

namespace Foo {
    public class MyData
    {
        public MyData()
        {
            _value = "Default value";
        }
        public string CustomProperty
        {
            get { return _value; }
            set { _value = (String)value; }
        }
        private string _value;
    }
  public partial class Page1 :Page {
    void dropHandler(object sender, DragEventArgs e)
    {}
    
//<SnippetFocus>
    void FocusOnParagraph(object sender, RoutedEventArgs e)
    {
      ContentElement ce = this.FindName("focusableP") as ContentElement;
      ce.Focus();
    }
//</SnippetFocus>
//<SnippetIsMouseCaptured>
    private void CaptureMouseCommandExecuted(object sender, ExecutedRoutedEventArgs e)
    {
      MessageBox.Show("Mouse Command");
      IInputElement target = Mouse.DirectlyOver;
    
      target = target as Control;
      if (target != null)
      {
        if (!target.IsMouseCaptured)
        {
          Mouse.Capture(target);
        } else {
          Mouse.Capture(null);
        }
      }
    }
//</SnippetIsMouseCaptured>
//<SnippetIsEnabled>
    void MakeSpecialLink(object sender, RoutedEventArgs e)
    {
      Hyperlink h2 = new Hyperlink(new Run("Now Click here"));
      // Associate event handler to the link. You can remove the event 
      // handler using "-=" syntax rather than "+=".
      h2.Click  += new RoutedEventHandler(Onh2Click);
      h2.Style = (Style)FindResource("SpecialHLink");
      focusableP.Inlines.Add(h2);
      text1.Text = "Now click the second link...";
      h1.IsEnabled = false;
    }
    //</SnippetIsEnabled>
    //<SnippetAddHandlerHandledToo>
    void PrimeHandledToo(object sender, EventArgs e)
    {
        myflowdocument.AddHandler(Hyperlink.ClickEvent, new RoutedEventHandler(GetHandledToo), true);
    }
    //</SnippetAddHandlerHandledToo>
    //<SnippetFindName>
    void HighlightParagraph(string paraName)
    {
        try
        {
            Paragraph wantedNode = (Paragraph)myflowdocument.FindName(paraName);
            if (wantedNode != null)
            {
                wantedNode.Background = Brushes.LightYellow;
            }
        }
        catch { }//handle paragraph not found in UI }
    }
    //</SnippetFindName>
    //<SnippetFindResource>
      void SetBGByResource(object sender, RoutedEventArgs e)
      {
          Block b = sender as Block;
          b.Background = (Brush)this.FindResource("RainbowBrush");
      }
    //</SnippetFindResource>
    //<SnippetTryFindResource>
      void SetBGByResourceTry(object sender, RoutedEventArgs e)
      {
          Block b = sender as Block;
          b.Background = (Brush)this.TryFindResource("RainbowBrush");
      }
    //</SnippetTryFindResource>
      void FindIntro(object sender, RoutedEventArgs e)
      {
          HighlightParagraph("introParagraph");
          MakeMenu();
      }
      //<SnippetCMProcedural>
      void MakeMenu()
      {
          Paragraph p1 = new Paragraph();
          p1.Inlines.Add(new Run("Created with C#"));
          myflowdocument.Blocks.Add(p1);
          ContextMenu cm = new ContextMenu();
          p1.ContextMenu = cm;
          MenuItem m1 = new MenuItem();
          m1.Header = "Edit";
          MenuItem m2 = new MenuItem();
          m2.Header = "Print";
          cm.Items.Add(m1);
          cm.Items.Add(m2);

      }
      //</SnippetCMProcedural>
      //<SnippetIsLoaded>
      private void OnLoad(object sender, RoutedEventArgs e)
      {
          displayData();
      }
      private void updateSummary(object sender, RoutedEventArgs e)
      {
          if (myflowdocument.IsLoaded)
              displayData();
      }
      //</SnippetIsLoaded>
      void displayData()
      {
          //<SnippetGetBindingExpression>
          Binding binding = introParagraph.GetBindingExpression(FrameworkContentElement.TagProperty).ParentBinding;
          //</SnippetGetBindingExpression>
          //<SnippetSetBinding>
          DateTime myDataObject = new DateTime();
          Binding myBinding = new Binding();
          myBinding.Source = myDataObject;
          introParagraph.SetBinding(Paragraph.TagProperty, myBinding);
          //</SnippetSetBinding>
      }
      void displayData2()
      {
          //<SnippetDataContext>
          MyData myDataObject = new MyData();
          myflowdocument.DataContext = myDataObject;
          introParagraph.SetBinding(Paragraph.TagProperty, "CustomData");
          //</SnippetDataContext>
      }
      void readyanim()
      {
          //<SnippetNameRegisterName>
          Hyperlink myLink = new Hyperlink();
          myLink.Name = "myLink";
          this.RegisterName(myLink.Name, myLink);
          //</SnippetNameRegisterName>
      }
    void GetHandledToo(object sender, RoutedEventArgs e) { }

    void Onh2Click(object sender, RoutedEventArgs e) { }
  }
  public class MyCustomLink : Hyperlink {
//<SnippetAddRemoveHandler>
    public static readonly RoutedEvent TapEvent = EventManager.RegisterRoutedEvent("Tap", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(MyCustomLink));
    public event RoutedEventHandler Tap
    {
      add { AddHandler(TapEvent, value); } 
      remove { RemoveHandler(TapEvent, value); }
     }
//</SnippetAddRemoveHandler>
//<SnippetRaiseEvent>
    void RaiseTapEvent()
    {
      RoutedEventArgs newEventArgs = new RoutedEventArgs();
      newEventArgs.RoutedEvent = MyCustomLink.TapEvent;
      //newEvent.SetSource(this);
      RaiseEvent(newEventArgs);
    }
//</SnippetRaiseEvent>
  }
  //<SnippetDefaultStyleKeyClass>
  public class MyExtraBold : Bold
  {
      static MyExtraBold()
      {
          DefaultStyleKeyProperty.OverrideMetadata(typeof(MyExtraBold), new FrameworkPropertyMetadata(typeof(MyExtraBold)));
      }
      public MyExtraBold()
      { }
  }
  //</SnippetDefaultStyleKeyClass>
}








