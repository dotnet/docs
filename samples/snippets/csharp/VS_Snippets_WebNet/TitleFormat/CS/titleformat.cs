using System.Web.UI.WebControls;

namespace PageLoadExample
{
   class Class1
   {
      Calendar Calendar1 = new Calendar();
      // <snippet1>
      private void Page_Load(object sender, System.EventArgs e)
      {
         // Change the title format of Calendar1.
         Calendar1.TitleFormat = TitleFormat.Month;
      }
      // </snippet1>
   }
}