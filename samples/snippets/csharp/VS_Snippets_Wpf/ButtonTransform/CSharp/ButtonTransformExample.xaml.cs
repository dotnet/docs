using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WCSample
{
    //<Snippet1cb>
    public partial class TransformExample : Page
    {
        private void Enter(object sender, MouseEventArgs args)
        {
            myScaleTransform.ScaleX = 2;
            myScaleTransform.ScaleY = 2;
        }

        private void Leave(object sender, MouseEventArgs args)
        {
            myScaleTransform.ScaleX = 1;
            myScaleTransform.ScaleY = 1;
        }
    }
    //</Snippet1cb>
}
