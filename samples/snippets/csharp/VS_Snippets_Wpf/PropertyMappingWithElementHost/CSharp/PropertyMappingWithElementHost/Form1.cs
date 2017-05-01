// <snippet1>
using System;
using System.Drawing;
using System.Windows.Forms;

// <snippet10>
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Forms.Integration;
// </snippet10>

namespace PropertyMappingWithElementHost
{
    public partial class Form1 : Form
    {
        // <snippet16>
        ElementHost elemHost = null;
        // </snippet16>

        public Form1()
        {
            InitializeComponent();
        }

        // <snippet11>
        private void Form1_Load(object sender, EventArgs e)
        {
            // Create the ElementHost control.
            elemHost = new ElementHost();
            elemHost.Dock = DockStyle.Fill;
            this.Controls.Add(elemHost);

            // Create a Windows Presentation Foundation Button element 
            // and assign it as the ElementHost control's child. 
            System.Windows.Controls.Button wpfButton = new System.Windows.Controls.Button();
            wpfButton.Content = "Windows Presentation Foundation Button";
            elemHost.Child = wpfButton;

            // Map the Margin property.
            this.AddMarginMapping();

            // Remove the mapping for the Cursor property.
            this.RemoveCursorMapping();

            // Add a mapping for the Region property.
            this.AddRegionMapping();

            // Add another mapping for the BackColor property.
            this.ExtendBackColorMapping();

            // Cause the OnMarginChange delegate to be called.
            elemHost.Margin = new Padding(23, 23, 23, 23);

            // Cause the OnRegionChange delegate to be called.
            elemHost.Region = new Region();

            // Cause the OnBackColorChange delegate to be called.
            elemHost.BackColor = System.Drawing.Color.AliceBlue;
        }
        // </snippet11>

        // <snippet12>
        // The AddMarginMapping method adds a new property mapping
        // for the Margin property.
        private void AddMarginMapping()
        {
            elemHost.PropertyMap.Add(
                "Margin",
                new PropertyTranslator(OnMarginChange));
        }

        // The OnMarginChange method implements the mapping 
        // from the Windows Forms Margin property to the
        // Windows Presentation Foundation Margin property.
        //
        // The provided Padding value is used to construct 
        // a Thickness value for the hosted element's Margin
        // property.
        private void OnMarginChange(object h, String propertyName, object value)
        {
            ElementHost host = h as ElementHost;
            Padding p = (Padding)value;
            System.Windows.Controls.Button wpfButton = 
                host.Child as System.Windows.Controls.Button;

            Thickness t = new Thickness(p.Left, p.Top, p.Right, p.Bottom );

            wpfButton.Margin = t;
        }
        // </snippet12>

        // <snippet13>
        // The RemoveCursorMapping method deletes the default
        // mapping for the Cursor property.
        private void RemoveCursorMapping()
        {
            elemHost.PropertyMap.Remove("Cursor");
        }
        // </snippet13>

        // <snippet14>
        // The AddRegionMapping method assigns a custom 
        // mapping for the Region property.
        private void AddRegionMapping()
        {
            elemHost.PropertyMap.Add(
                "Region",
                new PropertyTranslator(OnRegionChange));
        }

        // The OnRegionChange method assigns an EllipseGeometry to
        // the hosted element's Clip property.
        private void OnRegionChange(
            object h, 
            String propertyName, 
            object value)
        {
            ElementHost host = h as ElementHost;
            System.Windows.Controls.Button wpfButton = 
                host.Child as System.Windows.Controls.Button;

            wpfButton.Clip = new EllipseGeometry(new Rect(
                0, 
                0, 
                wpfButton.ActualWidth, 
                wpfButton.ActualHeight));
        }

        // The Form1_Resize method handles the form's Resize event.
        // It calls the OnRegionChange method explicitly to 
        // assign a new clipping geometry to the hosted element.
        private void Form1_Resize(object sender, EventArgs e)
        {
            this.OnRegionChange(elemHost, "Region", null);
        }
        // </snippet14>

        // <snippet15>
        // The ExtendBackColorMapping method adds a property
        // translator if a mapping already exists.
        private void ExtendBackColorMapping()
        {
            if (elemHost.PropertyMap["BackColor"] != null)
            {
                elemHost.PropertyMap["BackColor"] += 
                    new PropertyTranslator(OnBackColorChange);
            }
        }

        // The OnBackColorChange method assigns a specific image 
        // to the hosted element's Background property.
        private void OnBackColorChange(object h, String propertyName, object value)
        {
            ElementHost host = h as ElementHost;
            System.Windows.Controls.Button wpfButton = 
                host.Child as System.Windows.Controls.Button;

            ImageBrush b = new ImageBrush(new BitmapImage(
                new Uri(@"file:///C:\WINDOWS\Santa Fe Stucco.bmp")));
            wpfButton.Background = b;
        }
        // </snippet15>
    }
}
// </snippet1>