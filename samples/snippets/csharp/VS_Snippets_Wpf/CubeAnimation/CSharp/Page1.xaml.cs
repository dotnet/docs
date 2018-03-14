using System;
using System.Data;
using System.Windows;
using System.Windows.Data;
using System.Configuration;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using System.IO;
using DemoDev;

namespace Ribbon
{

    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void OnLoaded(object sender, EventArgs e)
        {
            // setup trackball for moving the model around
            _trackball = new Trackball();
            _trackball.Attach(this);
            _trackball.Slaves.Add(myViewport3D);
            _trackball.Enabled = true;

        }

        #region Events
//<SnippetFEBeginStoryboard>
        private void OnImage1Animate(object sender, RoutedEventArgs e)
        {
            Storyboard s;

            s = (Storyboard)this.FindResource("RotateStoryboard");
            this.BeginStoryboard(s);
        }
//</SnippetFEBeginStoryboard>
        #endregion

        #region Globals

        Trackball _trackball;

        #endregion
    }

   
}



