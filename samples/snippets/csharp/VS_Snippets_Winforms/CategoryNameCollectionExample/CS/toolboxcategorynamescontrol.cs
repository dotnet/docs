//<Snippet2>
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Data;
using System.Windows.Forms;

namespace ToolboxCategoryNamesControl
{    
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")] 
	public class ToolboxCategoryNamesControl : System.Windows.Forms.UserControl
	{		
        private System.Drawing.Design.IToolboxService toolboxService;
        private System.Drawing.Design.CategoryNameCollection categoryNames;

		public ToolboxCategoryNamesControl()
		{
            this.BackColor = System.Drawing.Color.Beige;
            this.Name = "Category Names Display Control";
            this.Size = new System.Drawing.Size(264, 200);
		}

        // Obtain or reset IToolboxService reference on each siting of control.
        public override System.ComponentModel.ISite Site
        {
            get
            {
                return base.Site;
            }
            set
            {     
                base.Site = value;

                // If the component was sited, attempt to obtain 
                // an IToolboxService instance.
                if( base.Site != null )
                {
                    toolboxService = (IToolboxService)this.GetService(typeof(IToolboxService));
                    // If an IToolboxService was located, update the category list.
                    if( toolboxService != null )
                        categoryNames = toolboxService.CategoryNames;                   
                }
                else
                    toolboxService = null;
            }
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {            
            if( categoryNames != null )
            {
                e.Graphics.DrawString("IToolboxService category names list:", new Font("Arial", 9), Brushes.Black, 10, 10);
                //<Snippet1>                
                // categoryNames is a CategoryNameCollection obtained from 
                // the IToolboxService. CategoryNameCollection is a read-only 
                // string collection.                                
                
                // Output each category name in the CategoryNameCollection.                                                
                for( int i=0; i< categoryNames.Count; i++ )                                    
                    e.Graphics.DrawString(categoryNames[i], new Font("Arial", 8), Brushes.Black, 10, 24+(10*i));                
                //</Snippet1>
            }            
        }
	}    
}
//</Snippet2>