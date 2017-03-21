   [
     DataBindingHandlerAttribute(typeof(System.Web.UI.Design.TextDataBindingHandler))
   ]
   public class SimpleWebControl:WebControl
   {
      // Insert code for class members here
   }

   class TestAttributes
   {
      public static void Main()
      {
         System.ComponentModel.AttributeCollection myAttributes = 
            TypeDescriptor.GetAttributes(typeof(SimpleWebControl));

         DataBindingHandlerAttribute myDataBindingHandlerAttribute = 
            myAttributes[typeof(DataBindingHandlerAttribute)] as DataBindingHandlerAttribute;

         if(myDataBindingHandlerAttribute != null)
         {
            Console.Write("DataBindingHandlerAttribute's HandlerTypeName is : " + 
                  myDataBindingHandlerAttribute.HandlerTypeName);
         }
      }
   }