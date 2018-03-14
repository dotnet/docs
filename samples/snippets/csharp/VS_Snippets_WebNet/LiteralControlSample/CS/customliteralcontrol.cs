// System.Web.UI.LiteralControl.Text
// System.Web.UI.LiteralControl.CreateControlCollection
// System.Web.UI.LiteralControl.Render
/*
  The following example demonstrates 'Text' property ,'Render' , 'CreateControlCollection'  methods and  'LiteralControl()' 'LiteralControl(string)' of 'LiteralControl' class.
  Literal controls behave as text holders.
  They are actually used to increase the performance of the server.
  All the controls that donot require server side execution are stored as literalcontrols.
  A custom control is developed from Literal control.
  A class is derived from LiteralControl class.
  'Render' Method is overridden to be able to render the CustomControl.
  'CreateControlCollection' method is overridden to be able to allow child control creation.
  The  'Text'  property is overridden to be able to display the text of the control
 */
using System;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomLiteralControl
{
   public class CustomLiteralControlClass : LiteralControl, INamingContainer
   {
      private string _text;
      private ControlCollection myControlCollection;
      public CustomLiteralControlClass() : base()
      {
      }
      public CustomLiteralControlClass(string text) : base(text)
      {
         _text = text;
      }
// <Snippet1>
      public override string Text
      {
         [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")] 
         get
         {
            return _text;
         }
         [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")] 
         set
         {
            _text=value;
         }
      }

// </Snippet1>
// <Snippet2>
      [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")] 
      protected override ControlCollection CreateControlCollection()
      {
         myControlCollection=new ControlCollection(this);
         return myControlCollection;
      }
// </Snippet2>
// <Snippet3>
      [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")] 
      protected override void Render(HtmlTextWriter writer)
      {
         IEnumerator myEnumerator=myControlCollection.GetEnumerator();
         Button tempButton= new Button();
         writer.Write("<br><br><b> CustomLiteralControlClass has child controls = </b>" 
                     + this.HasControls() );
         while(myEnumerator.MoveNext())
         {
            object myObject = myEnumerator.Current;
            if(myObject.GetType().Equals(typeof(Button)))
            {
               Button childControlButton=(Button)myEnumerator.Current;
               writer.Write("<br><br><b> This is the  text of the child Control  :</b>"
                           +childControlButton.Text+"<br>");
            }
         }
         string builder="<h3>";
         for (int i=0;i<_text.Length;i++)
         {
            string currentChar = _text.Substring(i,1);
            if (i%2==0)
               builder += "<font color=red>" + currentChar + "</font>";
            else
               builder += "<font color=blue>" + currentChar + "</font>";
         }
         builder += "</h3>";
         writer.Write(builder);
      }
// </Snippet3>
   }
}
