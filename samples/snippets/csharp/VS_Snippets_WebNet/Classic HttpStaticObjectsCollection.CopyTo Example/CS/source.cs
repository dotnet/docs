using System;
using System.Web;
using System.Web.UI;

public class Page1: Page
{
 private void Page_Load(Object sender, EventArgs e)
 {
// <Snippet1>
// Find the number of members in the StaticObjects collection.
int ObjCount = Application.StaticObjects.Count;
// Create an array of the same size.
Object[] MyObjArray = new Object[ObjCount];
// Copy the entire collection into the array.
Application.StaticObjects.CopyTo(MyObjArray, 0);

// </Snippet1>
 }
}
