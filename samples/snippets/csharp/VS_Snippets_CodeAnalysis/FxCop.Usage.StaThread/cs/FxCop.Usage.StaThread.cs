//<Snippet1>
using System; 
using  System.Windows.Forms;

namespace UsageLibrary
{
    public class MyForm: Form
    {
        public MyForm()
        {
            this.Text = "Hello World!";
        }
        
        // Satisfies rule: MarkWindowsFormsEntryPointsWithStaThread.
        [STAThread]
        public static void Main()
        {
            MyForm aform = new MyForm();
            Application.Run(aform);
        }
    }
}
//</Snippet1>
