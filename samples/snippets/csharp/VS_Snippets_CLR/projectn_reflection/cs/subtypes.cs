using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
//using Windows.Foundation.Collections;
// using Windows.UI.Xaml;
// using Windows.UI.Xaml.Controls;
// using Windows.UI.Xaml.Controls.Primitives;
// using Windows.UI.Xaml.Data;
// using Windows.UI.Xaml.Input;
// using Windows.UI.Xaml.Media;
// using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
public class Page
{ }

public class TextBlock
{
   public string Text;
}

namespace Examples
{
   public partial class MainPage
   {
      public TextBlock block = new TextBlock();
      private void InitializeComponent() {}
   }
}

// <Snippet5>
namespace Examples
{
   using System.Reflection;
   using Examples.Libraries;

   public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            Derived1 d1 = new Derived1();
            block.Text += d1.ToString() + Environment.NewLine;

            Type derivedType = typeof(Derived1);
            Object obj = Activator.CreateInstance(derivedType);
            block.Text += obj.GetType().FullName + Environment.NewLine;
            
        }
    }
}
// </Snippet5>

// <Snippet4>
namespace Examples.Libraries
{
   public class BaseClass
   {
      public BaseClass()
      { }
       
      public override string ToString()
      {
 	      return String.Format("{0} Version  {1}", this.GetType().Name, Version);
      }
      public virtual double Version
      { get { return 1.0; }}
    }

   public class Derived1 : BaseClass
   {
      public Derived1() : base()
      {}

      public override double Version
      { get { return 1.1; }}

      public override string ToString()
      { 
         return String.Format("{0} Version {1}", this.GetType().Name, Version);
      }
   }
}
// </Snippet4>