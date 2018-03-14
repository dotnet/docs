using System;
using System.ComponentModel.Design;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;


namespace FreeformActivityDesignerSnippets
{
    //<snippet0>
    class ProcessActvityDesigner : FreeformActivityDesigner
    {
        private ConnectionPoint GetConnectionPoint(Activity activity, Int32 connectorIndex, DesignerEdges edge)
        {
            ActivityDesigner designer = null;

            if (activity != null && activity.Site != null)
            {
                IDesignerHost designerHost = activity.Site.GetService(typeof(IDesignerHost)) as IDesignerHost;
                if (designerHost != null)
                    designer = designerHost.GetDesigner(activity) as ActivityDesigner;
            }
            return new ConnectionPoint(designer, edge, connectorIndex);
        }

        protected override void OnLayoutPosition(ActivityDesignerLayoutEventArgs e)
        {
            base.OnLayoutPosition(e);

            // Draw a connector between the first and second activities contained in 
            // the sequence activity used by this designer
            if (this.IsRootDesigner)
            {
                CompositeActivity parentActivity = (CompositeActivity)this.Activity;
                ConnectionPoint sourcePoint = GetConnectionPoint(parentActivity.Activities[0], 1, DesignerEdges.Bottom);
                ConnectionPoint targetPoint = GetConnectionPoint(parentActivity.Activities[1], 0, DesignerEdges.Top);

                this.AddConnector(sourcePoint, targetPoint);
            }
        }
        //</snippet0>

        
    }
}
