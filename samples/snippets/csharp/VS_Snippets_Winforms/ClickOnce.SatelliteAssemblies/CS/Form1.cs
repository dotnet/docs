using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using System.Deployment.Application;
using System.Reflection;

namespace ClickOnce.SatelliteAssemblies
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Handle the AssemblyResolve event so we can download satellite assemblies
            // on demand.
        }
    }
}