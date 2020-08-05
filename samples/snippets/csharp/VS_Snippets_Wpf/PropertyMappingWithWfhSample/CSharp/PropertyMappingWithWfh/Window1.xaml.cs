// <Snippet10>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

// <Snippet20>
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
// </Snippet20>

namespace PropertyMappingWithWfh
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        // <Snippet11>
        // The WindowLoaded method handles the Loaded event.
        // It enables Windows Forms visual styles, creates
        // a Windows Forms checkbox control, and assigns the
        // control as the child of the WindowsFormsHost element.
        // This method also modifies property mappings on the
        // WindowsFormsHost element.
        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.Application.EnableVisualStyles();

            // Create a Windows Forms checkbox control and assign
            // it as the WindowsFormsHost element's child.
            System.Windows.Forms.CheckBox cb = new System.Windows.Forms.CheckBox();
            cb.Text = "Windows Forms checkbox";
            cb.Dock = DockStyle.Fill;
            cb.TextAlign = ContentAlignment.MiddleCenter;
            cb.CheckedChanged += new EventHandler(cb_CheckedChanged);
            wfHost.Child = cb;

            // Replace the default mapping for the FlowDirection property.
            this.ReplaceFlowDirectionMapping();

            // Remove the mapping for the Cursor property.
            this.RemoveCursorMapping();

            // Add the mapping for the Clip property.
            this.AddClipMapping();

            // Add another mapping for the Background property.
            this.ExtendBackgroundMapping();

            // Cause the OnFlowDirectionChange delegate to be called.
            wfHost.FlowDirection = System.Windows.FlowDirection.LeftToRight;

            // Cause the OnClipChange delegate to be called.
            wfHost.Clip = new RectangleGeometry();

            // Cause the OnBackgroundChange delegate to be called.
            wfHost.Background = new ImageBrush();
        }
        // </Snippet11>

        // <Snippet12>
        // The ReplaceFlowDirectionMapping method replaces the
        // default mapping for the FlowDirection property.
        private void ReplaceFlowDirectionMapping()
        {
            wfHost.PropertyMap.Remove("FlowDirection");

            wfHost.PropertyMap.Add(
                "FlowDirection",
                new PropertyTranslator(OnFlowDirectionChange));
        }

        // The OnFlowDirectionChange method translates a
        // Windows Presentation Foundation FlowDirection value
        // to a Windows Forms RightToLeft value and assigns
        // the result to the hosted control's RightToLeft property.
        private void OnFlowDirectionChange(object h, String propertyName, object value)
        {
            WindowsFormsHost host = h as WindowsFormsHost;
            System.Windows.FlowDirection fd = (System.Windows.FlowDirection)value;
            System.Windows.Forms.CheckBox cb = host.Child as System.Windows.Forms.CheckBox;

            cb.RightToLeft = (fd == System.Windows.FlowDirection.RightToLeft ) ?
                RightToLeft.Yes : RightToLeft.No;
        }

        // The cb_CheckedChanged method handles the hosted control's
        // CheckedChanged event. If the Checked property is true,
        // the flow direction is set to RightToLeft, otherwise it is
        // set to LeftToRight.
        private void cb_CheckedChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.CheckBox cb = sender as System.Windows.Forms.CheckBox;

            wfHost.FlowDirection = ( cb.CheckState == CheckState.Checked ) ?
                    System.Windows.FlowDirection.RightToLeft :
                    System.Windows.FlowDirection.LeftToRight;
        }
        // </Snippet12>

        // <Snippet13>
        // The RemoveCursorMapping method deletes the default
        // mapping for the Cursor property.
        private void RemoveCursorMapping()
        {
            wfHost.PropertyMap.Remove("Cursor");
        }
        // </Snippet13>

        // <Snippet14>
        // The AddClipMapping method adds a custom
        // mapping for the Clip property.
        private void AddClipMapping()
        {
            wfHost.PropertyMap.Add(
                "Clip",
                new PropertyTranslator(OnClipChange));
        }

        // The OnClipChange method assigns an elliptical clipping
        // region to the hosted control's Region property.
        private void OnClipChange(object h, String propertyName, object value)
        {
            WindowsFormsHost host = h as WindowsFormsHost;
            System.Windows.Forms.CheckBox cb = host.Child as System.Windows.Forms.CheckBox;

            if (cb != null)
            {
                cb.Region = this.CreateClipRegion();
            }
        }

        // The Window1_SizeChanged method handles the window's
        // SizeChanged event. It calls the OnClipChange method explicitly
        // to assign a new clipping region to the hosted control.
        private void Window1_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.OnClipChange(wfHost, "Clip", null);
        }

        // The CreateClipRegion method creates a Region from an
        // elliptical GraphicsPath.
        private Region CreateClipRegion()
        {
            GraphicsPath path = new GraphicsPath();

            path.StartFigure();

            path.AddEllipse(new System.Drawing.Rectangle(
                0,
                0,
                (int)wfHost.ActualWidth,
                (int)wfHost.ActualHeight ) );

            path.CloseFigure();

            return( new Region(path) );
        }
        // </Snippet14>

        // <Snippet15>
        // The ExtendBackgroundMapping method adds a property
        // translator if a mapping already exists.
        private void ExtendBackgroundMapping()
        {
            if (wfHost.PropertyMap["Background"] != null)
            {
                wfHost.PropertyMap["Background"] += new PropertyTranslator(OnBackgroundChange);
            }
        }

        // The OnBackgroundChange method assigns a specific image
        // to the hosted control's BackgroundImage property.
        private void OnBackgroundChange(object h, String propertyName, object value)
        {
            WindowsFormsHost host = h as WindowsFormsHost;
            System.Windows.Forms.CheckBox cb = host.Child as System.Windows.Forms.CheckBox;
            ImageBrush b = value as ImageBrush;

            if (b != null)
            {
                cb.BackgroundImage = new System.Drawing.Bitmap(@"C:\WINDOWS\Santa Fe Stucco.bmp");
            }
        }
        // </Snippet15>
    }
}
// </Snippet10>