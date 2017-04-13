// System.Web.UI.Control.AddParsedSubObject;

/*
   The following example demonstrates the method 'AddParsedSubObject' of class
   'Control'. The program associates a custom control builder using attributes 
   to a custom control 'MyControl'. 'MyControl' class internally maintains an 
   ArrayList to store it's child controls before they are added to the
   ControlCollection.

   The Control Builder ensures that only tagnames "myitem" would be passed on 
   to make controls of type TextBox. AddParsedSubObject has been overridden to
   add all such controls parsed into the internal ArrayList.
   These are then added to the ControlCollection in CreateChildControl.
*/

using System;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ControlSample 
{
// <Snippet1>
   // Custom ControlBuilder class. Interprets nested tag name "myitem" as a textbox. 
   public class MyControlBuilder : ControlBuilder 
   {
      public override Type GetChildControlType(String tagName,
                                          IDictionary attributes)
      {
         if (String.Compare(tagName, "myitem", true) == 0) 
         {
            return typeof(TextBox);
         }
         return null;
      }
   }

   [ 
   ControlBuilderAttribute(typeof(MyControlBuilder)) 
   ]
   public class MyControl : Control
   {
      // Store all the controls specified as nested tags.
      private ArrayList items = new ArrayList();
      
      // This function is internally invoked by IParserAccessor.AddParsedSubObject(Object).
      protected override void AddParsedSubObject(Object obj) 
      {
         if (obj is TextBox) 
         {
            items.Add(obj);
         }
      }

      // Override 'CreateChildControls'. 
      protected override void CreateChildControls()
      {
         System.Collections.IEnumerator myEnumerator = items.GetEnumerator();
         while(myEnumerator.MoveNext())
             this.Controls.Add((TextBox)myEnumerator.Current);
      }
   }    
// </Snippet1>
}

