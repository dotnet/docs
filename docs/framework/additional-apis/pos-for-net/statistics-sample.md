---
title: Statistics Sample
description: Statistics Sample (POS for .NET v1.14 SDK Documentation)
ms.date: 03/03/2014
ms.topic: how-to
ms.custom: pos-restored-from-archive
---

# Statistics Sample (POS for .NET v1.14 SDK Documentation)

Microsoft Point of Service for .NET (POS for .NET) Service Objects continually track and update a number of device statistics for each connected device. The statistic tracking is accomplished using the <xref:Microsoft.PointOfService.BaseServiceObjects.DeviceStatistics> class, which contains methods for resetting, retrieving, and updating statistics, as well as helper methods for creating statistics, incrementing statistics, and loading or saving statistics to or from XML file storage.

Statistics reporting in POS for .NET supports statistics stored in either hardware or software. Software-based statistics are stored in an XML statistics file, \\Program Files\\Common Files\\Microsoft Shared\\Point of Service\\Statistics\\PosDeviceStatistics.xml, and updated at a globally defined flush interval which is determined at the time of system installation and setup. By default, this flush interval is 1 second. When the application claims a device, POS for .NET loads the appropriate statistics from the XML file.

Device specific statistics management is supported by the **Base** or **Basic** device class interface. Service Objects inheriting from a **Base** or **Basic** class are typically only required to call **IncrementStatistic**, which increments the value of a specified statistic, or **SetStatistic**, which sets one statistic to a specified value. All other statistics implementation is provided by the **Base** or **Basic** class interface.

The key members of the **DeviceStatistics** class are detailed below:

- **CapStatisticsReporting** identifies the statistics reporting capabilities of the device. When **CapStatisticsReporting** is set to **false**, no statistical data regarding the device is available. If **CapStatisticsReporting** is **true**, some statistical data is available, and the device may begin accumulating various statistics regarding usage. The information accumulated and reported is device-specific, and is retrieved using the **RetrieveStatistics** method.

- **CapUpdateStatistics** defines whether the gathered statistics can be reset or updated by an application employing the **UpdateStatistics** and **ResetStatistics** methods. This property is only valid if **CapStatisticsReporting** is **true**. If **CapStatisticsReporting** is **false**, the **CapUpdateStatistics** property is always **false**.

- **ResetStatistics** can only be called if both **CapStatisticsReporting** and **CapUpdateStatistics** are **true**. This method resets one, some, or all of the resettable device statistics to zero. It resets the defined resettable statistics in a device to zero. All the requested statistics must be successfully reset in order for this method to complete successfully. Otherwise, an error is thrown with the Extended **ErrorCode** method. This method is always executed synchronously.

- **UpdateStatistics** sets one, some, or all of the resettable device statistics to the specified values. All the requested statistics must be successfully updated in order for this method to complete successfully. If some cannot be updated for any reason, an **ErrorCode** event is returned. Both **CapStatisticsReporting** and **CapUpdateStatistics** must be set to **true** to call this method. The **UpdateStatistics** method is always executed synchronously.

- **RetrieveStatistics** retrieves the requested statistics from a device. **CapStatisticsReporting** must be **true** in order to successfully use this method. All calls to **RetrieveStatistics** will return the following XML as a minimum.

    ```xml
    <?xml version='1.0'?>
    <UPOSStat version="1.10.0"
    xmlns:xsi=http://www.w3.org/2001/XMLSchema-instance
    xmlns="http://www.nrf-arts.org/IXRetail/namespace/"
    xsi:schemaLocation="http://www.nrf-arts.org/IXRetail/namespace/
    UPOSStat.xsd">
        <Event>
            <Parameter>
                <Name>RequestedStatistic</Name>
                <Value>1234</Value>
            </Parameter>
        </Event>
        <Equipment>
        <UnifiedPOSVersion>1.10</UnifiedPOSVersion>
        <DeviceCategory UPOS="CashDrawer"/>
        <ManufacturerName>Cashdrawers R Us</ManufacturerName>
        <ModelName>CD-123</ModelName>
        <SerialNumber>12345</SerialNumber>
        <FirmwareRevision>1.0 Rev. B</FirmwareRevision>
        <Interface>RS232</Interface>
        <InstallationDate>2000-03-01</InstallationDate>
        </Equipment>
    </UPOSStat>
    ```

    If the application requests a statistic name that the device does not support, the `<Parameter>` entry will be returned with an empty `<Value>`. For example:

    ```xml
    <Parameter>
        <Name>RequestedStatistic</Name>
        <Value></Value>
    </Parameter>
    ```

    All statistics that the device collects that are manufacturer specific and not defined in the schema will be returned in a `<ManufacturerSpecific>` tag instead of a `<Parameter>` tag. For example:

    ```xml
    <ManufacturerSpecific>
        <Name>TheAnswer</Name>
        <Value>42</Value>
    </ManufacturerSpecific>
    ```

    When an application requests all statistics from the device, the device returns a `<Parameter>` entry for every defined statistic in the device category. The device category is defined by the version of the XML schema specified by the **version** attribute in the `<UPOSStat>` tag. If the device does not record any statistics, the `<Value>` tag will be empty.

POS for .NET uses handlers to perform the reading and writing of statistics in a manner similar to the way events are handled. When one of these statistic handlers is created, it is assigned to a particular device statistic. When this statistic is read or updated, the handler calls a delegate that is able to read from or write to the device as necessary.

Statistic handlers use different types of delegates to perform different statistics operations. <xref:Microsoft.PointOfService.BaseServiceObjects.GetStatistic> delegates are used to retrieve statistic values, while <xref:Microsoft.PointOfService.BaseServiceObjects.SetStatistic> delegates assign statistic values. **GetStatistics** delegates take the name of the statistic to be retrieved as a parameter and return a string representing the value of that statistic. **SetStatistic** delegates take the name of the statistic to be changed and the value which is to be assigned to that statistic as parameters. **SetStatistic** delegates do not return any values.

Statistics handlers may be assigned to any of the standard statistics defined by the Unified Point Of Service (UnifiedPOS) specification, but custom handlers for any statistics that are created using **CreateStatistic** by Service Object code are also supported.

## Example

The following code example demonstrates how to enable, handle, and retrieve statistics data from an MSR device.

```csharp
// File FORM1.CS
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;

using Microsoft.PointOfService;
using Microsoft.PointOfService.BaseServiceObjects;

namespace Statistics
{
    public partial class SampleStatistics : Form
    {
        // Indicates whether or not the Service Object has
        // been started.
        bool ServiceObjectStarted = false;

        // The Service Object.
        PosCommon so = null;

        public SampleStatistics()
        {
            InitializeComponent();

            // Disable the buttons until the SO is loaded successfully.
            UpdateControls();
        }

        public void UpdateControls()
        {
            btnGenerateStatistics.Enabled = ServiceObjectStarted;
            btnRetrieveStatistics.Enabled = ServiceObjectStarted ;
            txtStatisticName.Enabled = ServiceObjectStarted;

            // The statistic name text box is disabled until the
            // Service Object is loaded.
            if (ServiceObjectStarted)
            {
                btnStartSO.Text = "Close SO";
            }
            else
            {
                txtStatisticName.Clear();
                txtRetrievedStatistics.Clear();
                btnStartSO.Text = "Start SO";
            }

            // The retrieve one statistic button is disabled until
            // the user has entered a statistic name.
            if (txtStatisticName.TextLength > 0)
            {
                btnRetrieveStatistic.Enabled = true;
            }
            else
            {
                btnRetrieveStatistic.Enabled = false;
            }
        }

        private void StartServiceObject(object sender, EventArgs e)
        {
            PosExplorer explorer = new PosExplorer(this);
            string SOName = "SampleStatistics";

            if (ServiceObjectStarted)
            {
                so.DeviceEnabled = false;
                so.Close();
                so = null;
                ServiceObjectStarted = false;
                UpdateControls();
            }
            else
            {
                foreach (DeviceInfo d in explorer.GetDevices())
                {
                    if (d.ServiceObjectName == SOName)
                    {
                        try
                        {
                            // Standard Service Object startup.
                            so = explorer.CreateInstance(d)
                                            as PosCommon;

                            so.Open();
                            so.Claim(0);
                            so.DeviceEnabled = true;

                            // Application-specific setup.
                            ServiceObjectStarted = true;
                            UpdateControls();
                        }
                        catch
                        {
                            // Something went wrong starting the SO
                            MessageBox.Show("The Service Object '" +
                                SOName + "' failed to load",
                                "Service Object Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                            return;
                        }

                        break;
                    }
                }

                if (so == null)
                {
                    // No Service Object with the
                    // specified name could be found.
                    MessageBox.Show("The Service Object '" +
                        SOName + "' could not be found",
                        "Service Object Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
            }
        }

        private void GenerateStatistics(object sender, EventArgs e)
        {
            // In this example case, you use this
            // property to tell the Service Object to change statistic
            // values.
            so.DeviceEnabled = true;

            // Report status.
            txtRetrievedStatistics.Text = "DeviceEnabled called to" +
                        " to modify statistic values.";
        }

        private void RetrieveStatistics(object sender, EventArgs e)
        {
            string statistics;
            bool IsXml = true;

            try
            {
                statistics = so.RetrieveStatistics();
            }
            catch
            {
                statistics = "No statistics found";
                IsXml = false;
            }

            DisplayStatistics(statistics, IsXml);
        }

        private void RetrieveOneStatistic(object sender, EventArgs e)
        {
            string statistics;
            bool IsXml = true;

            try
            {
                statistics = so.RetrieveStatistic(
                            txtStatisticName.Text);
            }
            catch
            {
                statistics = "Statistic not found: " +
                            txtStatisticName.Text;

                IsXml = false;
            }

            DisplayStatistics(statistics, IsXml);
            txtStatisticName.Clear();
            btnRetrieveStatistic.Enabled = false;
        }

        private void StatisticSizeChanged(object sender, EventArgs e)
        {
            if (txtStatisticName.TextLength > 0)
            {
                btnRetrieveStatistic.Enabled = true;
            }
            else
            {
                btnRetrieveStatistic.Enabled = false;
            }
        }

        // When retrieving statistics, POS for .NET returns a block
        // of XML (as specified in the UPOS specification). This
        // method will make it look readable with white space
        // and indenting and then display it in the text box.
        private void DisplayStatistics(string inputString, bool isXml)
        {
            string s = null;

            // In case of an exception, you do not have an XML
            // string, so just display the error description. Otherwise,
            // load the XML string into an XmlDocument object and
            // make it look readable.
            if (!isXml)
            {
                s = inputString;
            }
            if(isXml)
            {
                // Create new XML document and load the statistics
                // XML string.
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(inputString);

                // Create a XmlTextWriter using a MemoryStream and
                // tell it to indent the XML output (so that it is
                // readable.)
                MemoryStream m = new MemoryStream();
                XmlTextWriter writer = new XmlTextWriter(m, null);
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 4;

                // Save the document to the memory stream using the
                // XmlWriter.
                doc.Save(writer);

                // The stream will be encoded as UTF8, so convert the
                // buffer into a string.
                UTF8Encoding u = new UTF8Encoding();
                s = u.GetString(m.GetBuffer());
            }

            // Write the string to the text box.
            txtRetrievedStatistics.Text = s;
        }
    }
}
```

```csharp
// File FORM1.DESIGNER.CS
namespace Statistics
{
    partial class SampleStatistics
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStartSO = new System.Windows.Forms.Button();
            this.btnGenerateStatistics = new System.Windows.Forms.Button();
            this.btnRetrieveStatistics = new System.Windows.Forms.Button();
            this.txtStatisticName = new System.Windows.Forms.TextBox();
            this.txtRetrievedStatistics = new System.Windows.Forms.TextBox();
            this.btnRetrieveStatistic = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            //
            // btnStartSO
            //
            this.btnStartSO.Location = new System.Drawing.Point(45, 35);
            this.btnStartSO.Name = "btnStartSO";
            this.btnStartSO.Size = new System.Drawing.Size(133, 23);
            this.btnStartSO.TabIndex = 0;
            this.btnStartSO.Text = "Start SO";
            this.btnStartSO.UseVisualStyleBackColor = true;
            this.btnStartSO.Click += new System.EventHandler(this.StartServiceObject);
            //
            // btnGenerateStatistics
            //
            this.btnGenerateStatistics.Location = new System.Drawing.Point(45, 75);
            this.btnGenerateStatistics.Name = "btnGenerateStatistics";
            this.btnGenerateStatistics.Size = new System.Drawing.Size(133, 23);
            this.btnGenerateStatistics.TabIndex = 1;
            this.btnGenerateStatistics.Text = "GenerateStatistics";
            this.btnGenerateStatistics.UseVisualStyleBackColor = true;
            this.btnGenerateStatistics.Click += new System.EventHandler(this.GenerateStatistics);
            //
            // btnRetrieveStatistics
            //
            this.btnRetrieveStatistics.Location = new System.Drawing.Point(45, 117);
            this.btnRetrieveStatistics.Name = "btnRetrieveStatistics";
            this.btnRetrieveStatistics.Size = new System.Drawing.Size(133, 23);
            this.btnRetrieveStatistics.TabIndex = 2;
            this.btnRetrieveStatistics.Text = "Retrieve Statistics";
            this.btnRetrieveStatistics.UseVisualStyleBackColor = true;
            this.btnRetrieveStatistics.Click += new System.EventHandler(this.RetrieveStatistics);
            //
            // txtStatisticName
            //
            this.txtStatisticName.Location = new System.Drawing.Point(16, 68);
            this.txtStatisticName.Name = "txtStatisticName";
            this.txtStatisticName.Size = new System.Drawing.Size(205, 20);
            this.txtStatisticName.TabIndex = 4;
            this.txtStatisticName.TextChanged += new System.EventHandler(this.StatisticSizeChanged);
            //
            // txtRetrievedStatistics
            //
            this.txtRetrievedStatistics.BackColor = System.Drawing.Color.White;
            this.txtRetrievedStatistics.Location = new System.Drawing.Point(45, 157);
            this.txtRetrievedStatistics.Multiline = true;
            this.txtRetrievedStatistics.Name = "txtRetrievedStatistics";
            this.txtRetrievedStatistics.ReadOnly = true;
            this.txtRetrievedStatistics.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtRetrievedStatistics.Size = new System.Drawing.Size(476, 247);
            this.txtRetrievedStatistics.TabIndex = 5;
            //
            // btnRetrieveStatistic
            //
            this.btnRetrieveStatistic.Location = new System.Drawing.Point(16, 30);
            this.btnRetrieveStatistic.Name = "btnRetrieveStatistic";
            this.btnRetrieveStatistic.Size = new System.Drawing.Size(133, 23);
            this.btnRetrieveStatistic.TabIndex = 6;
            this.btnRetrieveStatistic.Text = "Retrieve Statistic";
            this.btnRetrieveStatistic.UseVisualStyleBackColor = true;
            this.btnRetrieveStatistic.Click += new System.EventHandler(this.RetrieveOneStatistic);
            //
            // groupBox1
            //
            this.groupBox1.Controls.Add(this.btnRetrieveStatistic);
            this.groupBox1.Controls.Add(this.txtStatisticName);
            this.groupBox1.Location = new System.Drawing.Point(219, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(302, 105);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Single Statistic";
            //
            // SampleStatistics
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuBar;
            this.ClientSize = new System.Drawing.Size(565, 439);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtRetrievedStatistics);
            this.Controls.Add(this.btnRetrieveStatistics);
            this.Controls.Add(this.btnGenerateStatistics);
            this.Controls.Add(this.btnStartSO);
            this.Name = "SampleStatistics";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartSO;
        private System.Windows.Forms.Button btnGenerateStatistics;
        private System.Windows.Forms.Button btnRetrieveStatistics;
        private System.Windows.Forms.TextBox txtStatisticName;
        private System.Windows.Forms.TextBox txtRetrievedStatistics;
        private System.Windows.Forms.Button btnRetrieveStatistic;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
```

```csharp
// File STATISTICSSO.CS
using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.PointOfService;
using Microsoft.PointOfService.BaseServiceObjects;

[assembly: PosAssembly("Service Object Contractors, Inc.")]

namespace SOSamples.Statistics
{
    [ServiceObject(DeviceType.Msr,
        "SampleStatistics",
        "Sample Statistics Service Object",
        1,
        9)]

    public class StatisticsTest : MsrBase
    {
        // This will be incremented every time DeviceEnabled
        // is set so that different sets of demonstration
        // statistics can be generated.
        int enableCount = 0;

        // The name of a custom created statistic used to demonstrate
        // custom Statistic handlers.
        private const string PollingStatistic = "Polling Interval";

        // Statistic used to demonstrate IncrementStatistic.
        private const string TestIncrement = "MyIncrementableStat";

        // String returned from CheckHealth
        private string MyHealthText;

        public StatisticsTest()
        {
            DevicePath = "Sample Statistics";
        }

        // This is the delegate which will be called for each
        // statistic that we have associated with this delegate by
        // calling SetStatisticHandler().
        //
        // Delegates like this should most commonly be used
        // to get and set statistics in hardware. The delegate
        // allows the POS for .NET statistic subsystem to query
        // the value of a statistic in real time, before it is
        // returned to the application.
        private string GetHardwareInfo(string name)
        {
            // Add your code to query values from hardware here.

            // Very simple demonstration: just return the name
            // of the statistic as its value;
            return name;
        }

        // In a typical Service Object implementation, statistics
        // will be modified throughout the Service Object code. This
        // method demonstrates the methods used to modify statistic
        // values.
        public void SetDemonstrationStatistics()
        {
            // IncrementStatistic can be used to easily
            // increment a numeric statistic.
            IncrementStatistic(TestIncrement);

            switch(enableCount)
            {
                case 0:
                    SetStatisticValue(StatisticManufacturerName,
                        "Microsoft Corporation");
                    break;
                case 1:
                    SetStatisticValue(StatisticManufacturerName,
                        "Service Control Contractors, Inc.");
                    break;
                case 2:
                    SetStatisticValue(StatisticManufacturerName,
                        "Point of Service Controls .com");
                    break;
            }

            if (++enableCount == 3 )
            {
                enableCount = 0;
            }
        }

        #region PosCommon overrides
        // Returns the result of the last call to CheckHealth()

        public override void Open()
        {
            base.Open();

            // In your implementation of Open(), your Service Object
            // code should:
            //    1. Initialize statistics.
            //    2. Create custom statistics.
            //    3. Set statistic handlers for hardware Statistics.

            // 1. Initialize statistics
            SetStatisticValue(StatisticManufacturerName,
                            "Microsoft Corporation");
            SetStatisticValue(StatisticManufactureDate,
                            "2004-10-23");
            SetStatisticValue(StatisticModelName,
                            "Statistic Sample");
            SetStatisticValue(StatisticMechanicalRevision,
                            "1.0");
            SetStatisticValue(StatisticInterface,
                            "USB");

            // 2a. Create a new new statistic to test Increment
            // method. No custom handler needed.
            CreateStatistic(TestIncrement, false, "blobs");

            // 2b. Create a new manufacturer statistic to demonstrate
            // custom attributes with StatisticHandlers.
            CreateStatistic(PollingStatistic, false,
                            "milliseconds");

            // 3. Set handlers for statistics stored in hardware.
            SetStatisticHandlers(PollingStatistic,
                        new GetStatistic(GetHardwareInfo), null);
            SetStatisticHandlers(StatisticSerialNumber,
                        new GetStatistic(GetHardwareInfo), null);
        }

        public override bool DeviceEnabled
        {
            get
            {
                return base.DeviceEnabled;
            }
            set
            {
                // This method will set various statistics to
                // demonstrate the statistic APIs. We are going
                // to change statistic values every time the device
                // is enabled. This operation is just for
                // demonstration and would not be found in live code.
                SetDemonstrationStatistics();

                base.DeviceEnabled = value;
            }
        }

        public override string CheckHealthText
        {
            get
            {
                // MsrBasic.VerifyState(musBeClaimed,
                // mustBeEnabled). This may throw an exception
                VerifyState(false, false);

                return MyHealthText;
            }
        }

        public override string CheckHealth(
                        HealthCheckLevel level)
        {
            // Verify that device is open, claimed, and enabled.
            VerifyState(true, true);

            // Your code here:
            // check the health of the device and return a
            // descriptive string.

            // Cache result in the CheckHealthText property.
            MyHealthText = "Ok";
            return MyHealthText;
        }

        public override DirectIOData DirectIO(
                        int command,
                        int data,
                        object obj)
        {
            // Verify that the device is open.
            VerifyState(false, false);

            return new DirectIOData(data, obj);
        }
        #endregion  PosCommon overrides

        #region MsrBasic Overrides
        protected override MsrFieldData ParseMsrFieldData(
                        byte[] track1Data,
                        byte[] track2Data,
                        byte[] track3Data,
                        byte[] track4Data,
                        CardType cardType)
        {
            // Your code here:
            // Implement this method to parse track data
            // into fields which will be returned as
            // properties to the application (e.g.,FirstName,
            // AccountNumber, etc.)
            return new MsrFieldData();
        }

        protected override MsrTrackData ParseMsrTrackData(
                        byte[] track1Data,
                        byte[] track2Data,
                        byte[] track3Data,
                        byte[] track4Data,
                        CardType cardType)
        {
            // Your code here:
            // Implement this method to convert raw track data.
            return new MsrTrackData();
        }
        #endregion MsrBasic Overrides
    }
}
```

## Compiling the Code

- For additional information about creating and compiling a Service Object project, see [Service Object Samples: Getting Started](service-object-samples-getting-started.md).

## See Also

#### Other Resources

- [Developing a Custom Service Object](developing-a-custom-service-object.md)
- [System Configuration](system-configuration.md)
