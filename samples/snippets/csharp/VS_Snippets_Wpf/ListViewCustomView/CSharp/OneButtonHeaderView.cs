using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Globalization;
using System.ComponentModel;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Xml;
using System.Windows.Automation.Peers;
using System.Collections.Generic;

namespace SDKSample
{
    //<SnippetIVAPCreate>
    public class OneButtonHeaderView : ViewBase
    {
        protected override IViewAutomationPeer GetAutomationPeer(ListView parent)
        {
            return new OneButtonHeaderViewAutomationPeer( this, parent );
        }
    //</SnippetIVAPCreate>

        protected override object DefaultStyleKey
        {
          get
          {
            return new ComponentResourceKey(this.GetType(),
                             "OneButtonHeaderViewDSK");
          }
        }

        protected override object ItemContainerDefaultStyleKey
        {
          get
          {
            return new ComponentResourceKey(this.GetType(),
                            "OneButtonHeaderViewItemDSK");
          }
        }
    }

    //<SnippetIVAP>
    public class OneButtonHeaderViewAutomationPeer : IViewAutomationPeer
    {
        ListView m_lv;

        public OneButtonHeaderViewAutomationPeer(OneButtonHeaderView control, ListView parent)
        {
            m_lv = parent;
        }

        ItemAutomationPeer IViewAutomationPeer.CreateItemAutomationPeer(Object item)
        {
            ListViewAutomationPeer lvAP = UIElementAutomationPeer.FromElement(m_lv) as ListViewAutomationPeer;
            return new ListBoxItemAutomationPeer(item, lvAP);
        }

        AutomationControlType IViewAutomationPeer.GetAutomationControlType()
        {
            return AutomationControlType.List;
        }

        List<AutomationPeer> IViewAutomationPeer.GetChildren(List<AutomationPeer> children)
        {
            // the children parameter is a list of automation peers for all the known items
            // our view must add its banner button peer to this list.

            Button b = (Button)m_lv.Template.FindName("BannerButton", m_lv);
            AutomationPeer peer = UIElementAutomationPeer.CreatePeerForElement(b);

            //If children is null, we still need to create an empty list to insert the button
            children ??= new List<AutomationPeer>();

            children.Insert(0, peer);

            return children;
        }

        Object IViewAutomationPeer.GetPattern(PatternInterface patternInterface)
        {
            // we can invoke the banner button
            if (patternInterface == PatternInterface.Invoke)
            {
                Button b = (Button)m_lv.Template.FindName("BannerButton", m_lv);
                AutomationPeer peer = UIElementAutomationPeer.FromElement(b);
                if (peer != null)
                    return peer;
            }

            // if this view does not have special handling for the pattern interface, return null
            // the ListViewAutomationPeer.GetPattern default handling will be used.
            return null;
        }

        void IViewAutomationPeer.ItemsChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e) { }

        void IViewAutomationPeer.ViewDetached() { }
    }
    //</SnippetIVAP>
}