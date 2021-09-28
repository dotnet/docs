using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections;

namespace SDKSample
{
    //<SnippetSingletonPanel>
    public class SingletonPanel : StackPanel
    {
        //private UIElementCollection _children;
        private FrameworkElement _child;

        public SingletonPanel()
        {
        }

        public FrameworkElement SingleChild
        {

            get { return _child; }
            set
            {
                if (value == null)
                {
                    RemoveLogicalChild(_child);
                }
                else
                {
                    if (_child == null)
                    {
                        _child = value;
                    }
                    else
                    {
                        // raise an exception?
                        MessageBox.Show("Needs to be a single element");
                    }
                }
            }
        }
        public void SetSingleChild(object child)
        {
            this.AddLogicalChild(child);
        }

        public new void AddLogicalChild(object child)
        {
            _child = (FrameworkElement)child;
            if (this.Children.Count == 1)
            {
                this.RemoveLogicalChild(this.Children[0]);
                this.Children.Add((UIElement)child);
            }
            else
            {
                this.Children.Add((UIElement)child);
            }
        }

        public new void RemoveLogicalChild(object child)
        {
            _child = null;
            this.Children.Clear();
        }
        protected override IEnumerator LogicalChildren
        {
            get
            {
                // cheat, make a list with one member and return the enumerator
                ArrayList _list = new ArrayList();
                _list.Add(_child);
                return (IEnumerator)_list.GetEnumerator();
            }
        }
    }
    //</SnippetSingletonPanel>
}
