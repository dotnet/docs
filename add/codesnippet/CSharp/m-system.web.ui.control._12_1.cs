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