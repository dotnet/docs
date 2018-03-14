//<Snippet2>
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;

namespace DesignerHostTest
{	
	// Note: Don't forget to include a reference to the System.Design assembly
	public class DesignerHostDesigner : ComponentDesigner
	{
		public DesignerHostDesigner()
		{
		}

		public override void DoDefaultAction()
		{
			//<Snippet1>
			// Requests an IDesignerHost service from the design time environment using Component.Site.GetService()
			IDesignerHost dh = (IDesignerHost) this.Component.Site.GetService(typeof(IDesignerHost));			
			//</Snippet1>
		}		
	}
}
//</Snippet2>