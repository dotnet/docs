using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Xml;

namespace SDKSample
{
    public class CoolView : ViewBase
    {
        protected override object DefaultStyleKey
        {
            get
            {
                return new ComponentResourceKey(this.GetType(), "MyViewDSK");
            }
        }

        protected override object ItemContainerDefaultStyleKey
        {
            get
            {
                return new ComponentResourceKey(this.GetType(), "MyViewItemDSK");
            }
        }
    }
}
