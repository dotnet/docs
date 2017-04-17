// <snippet1>

/* File name: controlBuilderAttribute.cs. */

using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;


namespace CustomControls

{
  public class MyCS_Item : Control 
  /* Class name: MyCS_Item. 
   * Defines the child control class.
   */
    {

      private String _message;

      public String Message 
      {
        get 
        {
          return _message;
        }
        set 
        {
           _message = value;
        }
     }
    }


    public class CustomParseControlBuilder : ControlBuilder 
    /* Class name: CustomParserControlBuilder.
     * Defines the functions and data to be used in building custom controls. 
     * This class is referenced using the ControlBuilderAttribute class. See class below.
     */
    {
      [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")] 
      public override Type GetChildControlType(String tagName, IDictionary attributes) 
      {
        if (String.Compare(tagName, "customitem", true) == 0) 
        {
           return typeof(MyCS_Item);
        }
        return null;
      }
    }


    [ 
       ControlBuilderAttribute(typeof(CustomParseControlBuilder)) 
    ]
    public class MyCS_CustomParse : Control 
    /* Class name: MyCS_CustomParse.
     * Performs custom parsing of a MyCS_CustomParse control type 
     * child control. 
     * If the child control is of the allowed type, it is added to an 
     * array list. This list is accessed, using the container control attribute 
     * SelectedIndex, to obtain the related child control Message attribute to be displayed.
     */
    {

       private ArrayList _items         = new ArrayList();
       private int       _selectedIndex = 0;

       public int SelectedIndex 
       { 
           get 
           {
              return _selectedIndex;
           }
           set 
           {
              _selectedIndex = value;
           }
       }

       [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")] 
       protected override void AddParsedSubObject(Object obj) 
       /* Function name: AddParsedSubObject.
        * Updates the array list with the allowed child objects.
        * This function is called during the parsing of the child controls and 
        * after the GetChildControlType function defined in the associated control 
        * builder class.
        */
       {
          if (obj is MyCS_Item) 
         {
              _items.Add(obj);
           }
       }

       [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")] 
       protected override void Render(HtmlTextWriter output) 
       /* Function name: Render.
        * Establishes the rules to render the built control. In this case, a message is
        * rendered that is a function of the parent control SelectedIndex attribute and 
        * the related child Message attribute.
        */
       {
          if (SelectedIndex < _items.Count) 
         {
              output.Write("<span style='background-color:aqua; color:red; font:8pt tahoma, verdana;'><b>" +
              ((MyCS_Item) _items[SelectedIndex]).Message + "</b></span>" );
         }
       }
    }    
}

// </snippet1>


