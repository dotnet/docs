using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Collections;


namespace StylusSnippets_CS
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            textbox0.Text = "";

            // Set event handler for stylus down event in button
            // <Snippet18>
            button1.StylusDown += new StylusDownEventHandler(button1_StylusDown);
            // </Snippet18>

            button1.StylusUp += new StylusEventHandler(button1_StylusUp);

            button1.MouseLeftButtonDown += new MouseButtonEventHandler(button1_MouseLeftButtonDown);
            button1.MouseLeftButtonUp += new MouseButtonEventHandler(button1_MouseLeftButtonUp);
        }

        void button1_StylusDown(object sender, StylusDownEventArgs e)
        {
            // Notify base class of event
            base.OnStylusDown(e);

            // Barf out a message that the stylus is down
            textbox0.Text = "Stylus Down";
        }

        // This isn't hooked up to anything.
        // <Snippet24>
        void OnStylusButtonDown(object sender, StylusButtonEventArgs e)
        {
            StylusButton myStylusButton = e.StylusButton;

            if (myStylusButton.Guid == StylusPointProperties.BarrelButton.Id)
            {
                // the barrel button on the stylus has been pressed
            }
        }
        // </Snippet24>


        void button1_StylusUp(object sender, StylusEventArgs e)
        {
            // Notify base class of event
            base.OnStylusUp(e);

            textbox0.Text = "";
        }

        void button1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Notify base class of event
            base.OnMouseLeftButtonDown(e);

            textbox0.Text = "Mouse Left Button Down";
        }

        void button1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // Notify base class of event
            base.OnMouseLeftButtonUp(e);

            textbox0.Text = "";
        }

        // When user clicks button,
        // barf out capabilities into panel
        private void Button1Click(object sender, RoutedEventArgs e)
        {
            // Clear the textbox if they clicked once before
            textbox1.Clear();

            // <Snippet1>
            // Get the current stylus device
            StylusDevice myStylusDevice = Stylus.CurrentStylusDevice;
            // </Snippet1>

            // Check whether we got the current stylus
            if (null == myStylusDevice)
            {
                textbox1.AppendText("No current stylus device\n");

                // Try to get it through the default tablet
                TabletDevice defaultTabletDevice = Tablet.TabletDevices[0];

                // Quit if we did not get the default tablet
                if (null == defaultTabletDevice)
                {
                    textbox1.AppendText("No default tablet device. Goodby!\n");
                    return;
                }

                // Now try to get the default stylus device through the default tablet device
                StylusDeviceCollection myStylusDeviceCollection = defaultTabletDevice.StylusDevices;

                int numStylusDevices = myStylusDeviceCollection.Count;

                // If none returned, we are toast, so quit
                if (numStylusDevices < 1)
                {
                    textbox1.AppendText("No stylus devices attached.\n");
                    return;
                }
                else
                {
                    // We have at least one stylus device, so just grab the first one
                    textbox1.AppendText("Got " + numStylusDevices + " stylus device through default tablet\n");
                    myStylusDevice = myStylusDeviceCollection[0];
                }
            }

            // See what properties the default stylus device has

            // <Snippet2>
            PresentationSource myPresentationSource = myStylusDevice.ActiveSource;

            if (null == myPresentationSource)
            {
                textbox1.AppendText("ActiveSource : null\n");
            }
            else
            {
                textbox1.AppendText("ActiveSource :" + myPresentationSource.ToString() + "\n");
            }
            // </Snippet2>

            // <Snippet15>
            TabletDevice myTabletDevice = myStylusDevice.TabletDevice;
            // </Snippet15>

            // <Snippet3>
            // Bind stylus to tablet's input element
            myStylusDevice.Capture(myStylusDevice.Target);
            // </Snippet3>

            // <Snippet4>
            // See to what Captured property is set
            // First see if it's null
            if (null == myStylusDevice.Captured)
            {
                textbox1.AppendText("Captured: null\n");
            }
            else
            {
                // Otherwise display the underlying type
                textbox1.AppendText("Captured: " + myStylusDevice.Captured.GetType().Name + "\n");
            }
            // </Snippet4>

            // <Snippet5>
            // Bind stylus to tablet's input element
            // through entire subtree
            myStylusDevice.Capture(myStylusDevice.Target, CaptureMode.SubTree);
            // </Snippet5>            

            // <Snippet6>
            // See to what DirectlyOver property is set
            // First see if it's null
            if (null == myStylusDevice.DirectlyOver)
            {
                textbox1.AppendText("DirectlyOver: null\n");
            }
            else
            {
                // Otherwise display the underlying type
                textbox1.AppendText("DirectlyOver: " + myStylusDevice.DirectlyOver.GetType().Name + "\n");
            }
            // </Snippet6>

            //StylusPointDescription 

            // <Snippet7>
            StylusPointCollection myStylusPoints =
                        myStylusDevice.GetStylusPoints(myStylusDevice.Target);
            textbox1.AppendText("Got " + myStylusPoints.Count.ToString() + " packets\n");
            // </Snippet7>

            // <Snippet8>
            Point myPoint = myStylusDevice.GetPosition(myStylusDevice.Target);
            textbox1.AppendText("The relative position is: (" + myPoint.X.ToString() + "," + myPoint.Y.ToString() + ")\n");
            // </Snippet8>

            // <Snippet9>
            textbox1.AppendText("Id: " + myStylusDevice.Id.ToString() + "\n");
            // </Snippet9>

            // <Snippet11>
            textbox1.AppendText("InRange: " + myStylusDevice.InRange.ToString() + "\n");
            // </Snippet11>

            // <Snippet13>
            textbox1.AppendText("Name: " + myStylusDevice.Name + "\n");
            // </Snippet13>

            // <Snippet14>
            StylusButtonCollection myStylusButtonCollection = myStylusDevice.StylusButtons;

            if (null == myStylusButtonCollection)
            {
                textbox1.AppendText("StylusButtons: null\n");
            }
            else
            {
                textbox1.AppendText("# of StylusButtons == " + myStylusButtonCollection.Count.ToString() + "\n");
            }
            // </Snippet14>

            // Snippet 15 (TabletDevice property) is between snippet 2 and snippet 3

            // <Snippet16>
            // See to what Target property is set
            // First see if it's null
            if (null == myStylusDevice.Target)
            {
                textbox1.AppendText("Target: null\n");
            }
            else
            {
                // Otherwise display the underlying type
                textbox1.AppendText("Target: " + myStylusDevice.Target.GetType().Name + "\n");
            }
            // </Snippet16>

            // <Snippet17>
            textbox1.AppendText("\n" + "StylusDevice: " + myStylusDevice.ToString() + "\n");
            // </Snippet17>

            // StylusButton members

            // Dummy array to hold result of CopyTo method
            StylusButton[] myStylusButtonArray = new StylusButton[100];

            int index = 0;

            // <Snippet19>
            myStylusButtonCollection.CopyTo(myStylusButtonArray, index);
            // </Snippet19>

            // <Snippet20>
            // Get the names of the buttons
            for (int i = 0; i < myStylusButtonCollection.Count; i++)
            {
                textbox1.AppendText("Button[" + i + "]: " + myStylusButtonCollection[i].Name);
            }
            // </Snippet20>

            // <Snippet21>
            // Ensure collection access is synchronized
            //if (!myStylusButtonCollection.IsSynchronized)
            //{
            //    lock (myStylusButtonCollection.SyncRoot)
            //    {
            //        // work with collection
            //    }
            //}
            // </Snippet21>

            // <Snippet22>
            // Get the names of all of the of StylusButton objects
            // and store them in an ArrayList
            ArrayList myStylusButtonNamesArrayList = new ArrayList();

            foreach (StylusButton sb in myStylusButtonCollection)
            {
                myStylusButtonNamesArrayList.Add(sb.Name);
            }
            // </Snippet22>

            // <Snippet23>
            // Get the first StylusButton, if it exists
            if (myStylusButtonCollection.Count > 0)
            {
                StylusButton mySB = myStylusButtonCollection[0];
            }
            // </Snippet23>

            StylusButton myStylusButton = myStylusButtonCollection[0];

            // <Snippet25>
            // Get the name of the StylusButton
            textbox1.AppendText("StylusButton.Name: " + myStylusButton.Name + "\n");
            // </Snippet25>

            // <Snippet26>
            // Get the state of the StylusButton
            switch (myStylusButton.StylusButtonState)
            {
                case StylusButtonState.Down:
                    textbox1.AppendText("StylusButton.State: Down\n");
                    break;

                default:  // StylusButtonState.Up
                    textbox1.AppendText("StylusButton.State: Up\n");
                    break;
            }
            // </Snippet26>

            // <Snippet27>
            // Get the name of the StylusDevice to which the StylusButton is attached
            textbox1.AppendText("StylusButton.StylusDevice: " + myStylusButton.StylusDevice.Name + "\n");
            // </Snippet27>

            // <Snippet28>
            // Get string representation of the StylusButton
            textbox1.AppendText("\n" + myStylusButton.ToString() + "\n");
            // </Snippet28>
        }

        // This isn't hooked up to anything.
        // <Snippet10>
        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            StylusDevice myStylusDevice = e.StylusDevice;

            if (myStylusDevice != null)
            {
                if (myStylusDevice.InAir)
                {
                    textbox1.Text = "stylus moves in air";
                }
                else
                {
                    textbox1.Text = "stylus moves with pen down";
                }
            }
        }
        // </Snippet10>

        // This isn't hooked up to anything.
        // <Snippet12>
        private void OnStylusMove(object sender, StylusEventArgs e)
        {
            StylusDevice myStylusDevice = e.StylusDevice;

            if (myStylusDevice != null)
            {
                if (myStylusDevice.Inverted)
                {
                    textbox1.Text = "stylus moves with eraser down";
                }
                else
                {
                    textbox1.Text = "stylus moves with pen down";
                }
            }
        }
        // </Snippet12>
    }
}