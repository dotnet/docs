// <snippet2>
using System;
using System.Collections;
using System.ComponentModel;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Samples.AspNet.CS.Controls {

    [AspNetHostingPermission(SecurityAction.Demand, 
        Level=AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand, 
        Level=AspNetHostingPermissionLevel.Minimal)]
    public class GeneologyTree : HierarchicalDataBoundControl {

        private TreeNode rootNode;
        public TreeNode RootNode {
            get {
                if (rootNode == null) {
                    rootNode = new TreeNode(String.Empty);
                }
                return rootNode;
            }
        }
        
        private ArrayList nodes;
        public ArrayList Nodes {
            get {
                if (null == nodes) {
                    nodes = new ArrayList();
                }
                return nodes;
            }
        }
// <snippet3>
        public string DataTextField {
            get {
                object o = ViewState["DataTextField"];
                return((o == null) ? string.Empty : (string)o);
            }
            set {
                ViewState["DataTextField"] = value;
                if (Initialized) {
                    OnDataPropertyChanged();
                }
            }
        }
// </snippet3>
        private int _maxDepth = 0;
// <snippet4>        
        protected override void PerformDataBinding() {
            base.PerformDataBinding();

            // Do not attempt to bind data if there is no
            // data source set.
            if (!IsBoundUsingDataSourceID && (DataSource == null)) {
                return;
            }
            
            HierarchicalDataSourceView view = GetData(RootNode.DataPath);
            
            if (view == null) {
                throw new InvalidOperationException
                    ("No view returned by data source control.");
            }                                  
            
            IHierarchicalEnumerable enumerable = view.Select();
            if (enumerable != null) {
                            
                Nodes.Clear();
                                
                try {
                    RecurseDataBindInternal(RootNode, enumerable, 1);
                }
                finally {
                
                }
            }
        }
// <snippet5>
        private void RecurseDataBindInternal(TreeNode node, 
            IHierarchicalEnumerable enumerable, int depth) {                                    
                        
            foreach(object item in enumerable) {
                IHierarchyData data = enumerable.GetHierarchyData(item);

                if (null != data) {
                    // Create an object that represents the bound data
                    // to the control.
                    TreeNode newNode = new TreeNode();
                    RootViewNode rvnode = new RootViewNode();
                    
                    rvnode.Node = newNode;
                    rvnode.Depth = depth;

                    // The dataItem is not just a string, but potentially
                    // an XML node or some other container. 
                    // If DataTextField is set, use it to determine which 
                    // field to render. Otherwise, use the first field.                    
                    if (DataTextField.Length > 0) {
                        newNode.Text = DataBinder.GetPropertyValue
                            (data, DataTextField, null);
                    }
                    else {
                        PropertyDescriptorCollection props = 
                            TypeDescriptor.GetProperties(data);

                        // Set the "default" value of the node.
                        newNode.Text = String.Empty;                        

                        // Set the true data-bound value of the TextBox,
                        // if possible.
                        if (props.Count >= 1) {                        
                            if (null != props[0].GetValue(data)) {
                                newNode.Text = 
                                    props[0].GetValue(data).ToString();
                            } 
                        }
                    }

                    Nodes.Add(rvnode);                    
                    
                    if (data.HasChildren) {
                        IHierarchicalEnumerable newEnumerable = 
                            data.GetChildren();
                        if (newEnumerable != null) {                            
                            RecurseDataBindInternal(newNode, 
                                newEnumerable, depth+1 );
                        }
                    }
                    
                    if ( _maxDepth < depth) _maxDepth = depth;
                    
                }
            }
        }
// </snippet4>
// </snippet5>
        protected override void Render(HtmlTextWriter writer) {
                        
            writer.WriteLine("<PRE>");                        
            int currentDepth = 1;
            int currentTextLen = 0;
            
            foreach (RootViewNode rvnode in Nodes) {
                if (rvnode.Depth == currentDepth) {
                    string output = "  " + rvnode.Node.Text + "  ";
                    writer.Write(output);
                    currentTextLen = currentTextLen + output.Length;
                }
                else {
                    writer.WriteLine("");
                    // Some very basic whitespace formatting
                    int halfLine = currentTextLen / 2;
                    for (int i=0;i<halfLine;i++) {
                        writer.Write(' ');
                    }
                    writer.Write('|');
                    writer.WriteLine("");
                    ++currentDepth; 
                    currentTextLen = 0;
                    for (int j=0;j<halfLine;j++) {
                        writer.Write(' ');
                    }
                    string output = "  " + rvnode.Node.Text + "  ";
                    writer.Write(output);
                    currentTextLen = currentTextLen + output.Length;                    
                }                                                           
            }
            writer.WriteLine("</PRE>");
        }
        
        private class RootViewNode { 
            public TreeNode Node;
            public int Depth;
        }
    }
}
// </snippet2>