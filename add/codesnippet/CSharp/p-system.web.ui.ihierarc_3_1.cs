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