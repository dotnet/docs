using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Collections;
using System.Collections.ObjectModel;

namespace HwCaps_CS
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            // Handle StylusButtonDown event
            this.StylusButtonDown += new StylusButtonEventHandler(Window1_StylusButtonDown);
        }

        void Window1_StylusButtonDown(object sender, StylusButtonEventArgs e)
        {
            // <Snippet27>
            // Get tablet device that generated event
            //TabletDevice myTabletDevice = e.TabletDevice;
            //TabletDevice myTabletDevice = (TabletDevice) e.Device;
            // </Snippet27>
        }

        // To use Loaded event put Loaded="WindowLoaded" attribute in root element of .xaml file.
        // private void WindowLoaded(object sender, EventArgs e) {}

        // When user clicks button,
        // barf out capabilities into panel
        private void Button1Click(object sender, RoutedEventArgs e)
        {
            // Clear the textbox if they clicked once before
            textbox1.Clear();

            // Find out if we have more than one tablet device
            int count = Tablet.TabletDevices.Count;

            if (count == 1)
            {
                textbox1.AppendText("There is one tablet device\n");
            }
            else
            {
                textbox1.AppendText("There are " + count + " tablet devices\n");
            }

            // <Snippet7>
            // Get the current tablet device, if it exists
            TabletDevice myCurrentTabletDevice = Tablet.CurrentTabletDevice;
            // </Snippet7>

            if (null != myCurrentTabletDevice)
            {
                textbox1.AppendText("INFO: Got the current tablet device\n");
            }
            else
            {
                textbox1.AppendText("INFO: Cannot get the current tablet device\n");
            }

            // <Snippet15>
            // Get the TabletDevice objects
            TabletDeviceCollection myTabletDeviceCollection = Tablet.TabletDevices;

            // <Snippet24>
            // Display the types of TabletDevices            
            foreach (TabletDevice td in myTabletDeviceCollection)
            {
                Console.WriteLine(td.Type);
            }
            // </Snippet24>
            // </Snippet15>

            // Store them in an array of strings
            // <Snippet16>
            // Get the number of tablet devices
            int numTabletDevices = myTabletDeviceCollection.Count;
            // </Snippet16>

            // <Snippet19>
            string[] myTabletDeviceNamesArray = new string[numTabletDevices];

            for (int i = 0; i < numTabletDevices; i++)
            {
                myTabletDeviceNamesArray[i] = myTabletDeviceCollection[i].Name;
            }
            // </Snippet19>

            bool gotCurrentTabletDevice = false;

            // Barf out list of tablet device names
            for (int i = 0; i < numTabletDevices; i++)
            {
                TabletDevice theTD = myTabletDeviceCollection[i];

                textbox1.AppendText("TabletDevice[" + i + "].Name == \"" + theTD.Name + "\"");

                // Is this one the current TabletDevice?
                if (theTD == myCurrentTabletDevice)
                {
                    textbox1.AppendText(" (current tablet device)\n\n");

                    gotCurrentTabletDevice = true;
                }
                else
                {
                    textbox1.AppendText("\n\n");
                }
            }

            if (!gotCurrentTabletDevice)
            {
                textbox1.AppendText("No match for current tablet device\n\n");
            }


            // <Snippet17>
            // Is the collection thread safe?        
            if (!myTabletDeviceCollection.IsSynchronized)
            {
                // If not, use SyncRoot to lock access
                lock (myTabletDeviceCollection.SyncRoot)
                {
                    // work with collection
                }
            }
            // </Snippet17>

            TabletDevice[] myTabletDeviceArray = new TabletDevice[100];
            int index = 0;

            // <Snippet18>
            // Copy the collection to array of tablet devices starting at position index
            myTabletDeviceCollection.CopyTo(myTabletDeviceArray, index);
            // </Snippet18>

            // <Snippet3>
            // Get the first tablet device
            TabletDevice myTabletDevice = Tablet.TabletDevices[0];
            // </Snippet3>

            // If tablet device exists, display its capabilities
            if (null != myTabletDevice)
            {
                textbox1.AppendText("TABLET\n\n");
                textbox1.AppendText("Properties\n\n");

                // Display the tablet device properties

                // <Snippet4>
                PresentationSource myPresentationSource = myTabletDevice.ActiveSource;

                if (null != myPresentationSource)
                {
                    textbox1.AppendText("ActiveSource.RootVisual: " + myPresentationSource.RootVisual.ToString() + "\n");
                }
                else
                {
                    textbox1.AppendText("ActiveSource: null\n");
                }
                // </Snippet4>

                // <Snippet5>
                System.Windows.Threading.Dispatcher myDispatcher = myTabletDevice.Dispatcher;

                if (null != myDispatcher)
                {
                    textbox1.AppendText("Dispatcher: " + myDispatcher.ToString() + "\n");
                }
                else
                {
                    textbox1.AppendText("Dispatcher: null\n");
                }
                // </Snippet5>

                // <Snippet8>
                textbox1.AppendText("Id: " + myTabletDevice.Id + "\n");
                // </Snippet8>

                // <Snippet9>
                textbox1.AppendText("Name: " + myTabletDevice.Name + "\n");
                // </Snippet9>

                // <Snippet10>
                textbox1.AppendText("ProductId: " + myTabletDevice.ProductId + "\n");
                // </Snippet10>

                // <Snippet11>
                // Get the StylusDevice objects.
                StylusDeviceCollection myStylusDeviceCollection = myTabletDevice.StylusDevices;

                // Get the names of all of the of StylusDevice objects.
                string[] myStylusDeviceNames = new string[myStylusDeviceCollection.Count];

                for (int i = 0; i < myStylusDeviceCollection.Count; i++)
                {
                    myStylusDeviceNames[i] = myStylusDeviceCollection[i].Name;
                }
                // </Snippet11>

                // Or store them in an array of strings

                // <Snippet20>
                // Get the number of stylus devices
                int numStylusDevices = myStylusDeviceCollection.Count;
                // </Snippet20>

                // <Snippet21>
                string[] myStylusDeviceNamesArray = new string[numStylusDevices];

                for (int i = 0; i < numStylusDevices; i++)
                {
                    myStylusDeviceNamesArray[i] = myStylusDeviceCollection[i].Name;
                }
                // </Snippet21>

                // <Snippet22>
                // Is the collection thread safe?
                //if (!myStylusDeviceCollection.IsSynchronized)
                //{
                //    // If not, use SyncRoot to lock access
                //    lock (myStylusDeviceCollection.SyncRoot)
                //    {
                //        // work with collection
                //    }
                //}
                // </Snippet22>

                StylusDevice[] myStylusDeviceArray = new StylusDevice[100];
                index = 0;

                // <Snippet23>
                // Copy the collection to array of stylus devices starting at position index
                myStylusDeviceCollection.CopyTo(myStylusDeviceArray, index);
                // </Snippet23>

                for (int i = 0; i < myStylusDeviceCollection.Count; i++)
                {
                    textbox1.AppendText("StylusDevice[" + i + "] name: " + myStylusDeviceCollection[i].Name + "\n");
                }

                // <Snippet12>
                //StylusPointDescription myStylusPointDescription = myTabletDevice.StylusPacketDescription;
                // </Snippet12>

                //if (null != myStylusPointDescription)
                //{
                //    textbox1.AppendText("StylusPointDescription\n");
                //    textbox1.AppendText("    Number of buttons: " + myStylusPointDescription.ButtonCount + "\n");

                //    // Buttons
                //    for (int k = 0; k < myTabletDevice.StylusPacketDescription.ButtonCount; k++)
                //    {
                //        textbox1.AppendText("        Button[" + k + "] GUID: " + myStylusPointDescription.GetButton(k).ToString() + "\n");
                //    }

                //    textbox1.AppendText("    Packet size: " + myStylusPointDescription.PacketSize + "\n");
                //    textbox1.AppendText("    Number of values: " + myStylusPointDescription.ValueCount + "\n");

                //    // Stylus metrics
                //    ReadOnlyCollection<StylusPointPropertyInfo> myStylusPointProperties = 
                //                                    myStylusPointDescription.GetStylusPointProperties();

                //    // If metrics exist, display them
                //    if (null != myStylusPointProperties)
                //    {
                //        for (int j = 0; j < myStylusPointProperties.Length; j++)
                //        {
                //            textbox1.AppendText("    Metric[" + j + "]\n");
                //            textbox1.AppendText("        Name:       " + GetPacketValueName(myStylusPointProperties[j].Guid) + "\n");
                //            textbox1.AppendText("        Guid:       " + myStylusPointProperties[j].Id.ToString() + "\n");
                //            textbox1.AppendText("        Min:        " + myStylusPointProperties[j].Minimum.ToString() + "\n");
                //            textbox1.AppendText("        Max:        " + myStylusPointProperties[j].Maximum.ToString() + "\n");
                //            textbox1.AppendText("        Unit:       " + myStylusPointProperties[j].Unit.ToString() + "\n");
                //            textbox1.AppendText("        Resolution: " + myStylusPointProperties[j].Resolution.ToString() + "\n");
                //            textbox1.AppendText("\n");
                //        }
                //    }
                //}
                //else
                //{
                //    textbox1.AppendText("StylusPacketDescription: null\n");
                //}

                // <Snippet13>
                if (null != myTabletDevice.Target)
                {
                    textbox1.AppendText("Target: " + myTabletDevice.Target.GetType().Name + "\n");
                }
                else
                {
                    textbox1.AppendText("Target: null\n");
                }
                // </Snippet13>

                // <Snippet2>
                // Get the type of tablet device
                TabletDeviceType myTabletDeviceType = myTabletDevice.Type;

                // Display the type of tablet device
                textbox1.AppendText("Type: ");

                switch (myTabletDeviceType)
                {
                    case TabletDeviceType.Stylus:
                        textbox1.AppendText("Stylus\n");
                        break;

                    default: // TabletDeviceType.Touch:
                        textbox1.AppendText("Touch Pad\n");
                        break;
                }
                // </Snippet2>

                // Show output from TabletDevice.ToString()
                // <Snippet14>
                textbox1.AppendText("\n\nTablet Device:" + myTabletDevice.ToString() + "\n\n");
                // </Snippet14>

                textbox1.AppendText("\n");


                // <Snippet1>
                // Get the capabilities of the current tablet device
                TabletHardwareCapabilities myHWCaps = myTabletDevice.TabletHardwareCapabilities;
                // </Snippet1>


                // <Snippet26>
                if ((Tablet.CurrentTabletDevice.TabletHardwareCapabilities
                   & TabletHardwareCapabilities.SupportsPressure) ==
                     TabletHardwareCapabilities.SupportsPressure)
                {
                    textbox1.AppendText("The tablet can detect the pressure of the teblet pen.");
                }
                // </Snippet26>

                textbox1.AppendText("\n");

                //// Get the current stylus, if it exists:
                //StylusDevice myStylusDevice = myTabletDevice.StylusDevices[0];

                //// If stylus exists, print its properties
                //if (null != myStylusDevice)
                //{
                //    textbox1.AppendText("STYLUS\n\n");

                //    textbox1.AppendText("ActiveSource: " + GetStringOrNull(myStylusDevice.ActiveSource) + "\n");
                //    textbox1.AppendText("Captured: " + GetStringOrNull(myStylusDevice.Captured) + "\n");
                //    textbox1.AppendText("DirectlyOver: " + GetStringOrNull(myStylusDevice.DirectlyOver) + "\n");
                //    textbox1.AppendText("Dispatcher: " + GetStringOrNull(myStylusDevice.Dispatcher) + "\n");
                //    textbox1.AppendText("ID: " + GetStringOrNull(myStylusDevice.Id) + "\n");
                //    textbox1.AppendText("InAir: " + GetStringOrNull(myStylusDevice.InAir) + "\n");
                //    textbox1.AppendText("InRange: " + GetStringOrNull(myStylusDevice.InRange) + "\n");
                //    textbox1.AppendText("Inverted: " + GetStringOrNull(myStylusDevice.Inverted) + "\n");
                //    textbox1.AppendText("Name: " + GetStringOrNull(myStylusDevice.Name) + "\n");
                //    textbox1.AppendText("PacketCount: " + GetStringOrNull(myStylusDevice.GetPackets(null).PacketCount) + "\n");
                //    textbox1.AppendText("Tablet Device: " + GetStringOrNull(myStylusDevice.TabletDevice.Name) + "\n");
                //    textbox1.AppendText("Tablet Position: " + GetStringOrNull(myStylusDevice.GetPosition(null)) + "\n");
                //    textbox1.AppendText("Target: " + GetStringOrNull(myStylusDevice.Target) + "\n");
                //}
            }
        }

        // Retrieve the names of the tablet devices
        private static string[] GetTabletNames()
        {
            // <Snippet6>        
            int numberOfNames = Tablet.TabletDevices.Count;
            // </Snippet6>

            if (numberOfNames == 0)
            {
                return null;
            }

            string[] names = new string[numberOfNames];

            for (int i = 0; i < numberOfNames; i++)
            {
                names[i] = Tablet.TabletDevices[i].Name;
            }

            return names;
        }

        //private string GetStringOrNull(object o)
        //{
        //    if (null == o)
        //    {
        //        return "null";
        //    }

        //    return (o.ToString());
        //}

        private static string GetPacketValueName(Guid guid)
        {
            //if (guid == StylusPacketValue.X)
            //{
            //    return "X";
            //}
            //if (guid == StylusPacketValue.Y)
            //{
            //    return "Y";
            //}
            //if (guid == StylusPacketValue.AltitudeOrientation)
            //{
            //    return "AltitudeOrientation";
            //}
            //if (guid == StylusPacketValue.AzimuthOrientation)
            //{
            //    return "AzimuthOrientation";
            //}
            //if (guid == StylusPacketValue.BarrelButton)
            //{
            //    return "BarrelButton";
            //}
            //if (guid == StylusPacketValue.ButtonPressure)
            //{
            //    return "ButtonPressure";
            //}
            //if (guid == StylusPacketValue.NormalPressure)
            //{
            //    return "NormalPressure";
            //}
            //if (guid == StylusPacketValue.PacketStatus)
            //{
            //    return "PacketStatus";
            //}
            //if (guid == StylusPacketValue.PitchRotation)
            //{
            //    return "PitchRotation";
            //}
            //if (guid == StylusPacketValue.RollRotation)
            //{
            //    return "RollRotation";
            //}
            //if (guid == StylusPacketValue.SecondaryTipButton)
            //{
            //    return "SecondaryTipButton";
            //}
            //if (guid == StylusPacketValue.SerialNumber)
            //{
            //    return "SerialNumber";
            //}
            //if (guid == StylusPacketValue.TangentPressure)
            //{
            //    return "TangentPressure";
            //}
            //if (guid == StylusPacketValue.TimerTick)
            //{
            //    return "TimerTick";
            //}
            //if (guid == StylusPacketValue.TipButton)
            //{
            //    return "TipButton";
            //}
            //if (guid == StylusPacketValue.TwistOrientation)
            //{
            //    return "TwistOrientation";
            //}
            //if (guid == StylusPacketValue.XTiltOrientation)
            //{
            //    return "XTiltOrientation";
            //}
            //if (guid == StylusPacketValue.YawRotation)
            //{
            //    return "YawRotation";
            //}
            //if (guid == StylusPacketValue.YTiltOrientation)
            //{
            //    return "YTiltOrientation";
            //}
            //if (guid == StylusPacketValue.Z)
            //{
            //    return "Z";
            //}

            return "";
        }
    }
}