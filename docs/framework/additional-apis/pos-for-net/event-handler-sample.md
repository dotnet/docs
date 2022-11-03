---
title: Event Handler Sample
description: Event Handler Sample (POS for .NET v1.14 SDK Documentation)
ms.date: 03/03/2014
ms.topic: how-to
ms.custom: pos-restored-from-archive
---

# Event Handler Sample (POS for .NET v1.14 SDK Documentation)

This sample demonstrates how applications can register handlers for any of the five event types supported by Microsoft Point of Service for .NET (POS for .NET):

- DataEvent
- ErrorEvent
- StatusUpdateEvent
- OutputCompleteEvent
- DirectIOEvent

It also shows how an application manages asynchronous output requests to a <xref:Microsoft.PointOfService.PosPrinter> device.

## To create the sample project

1. Compile and install the Service Object sample code from [Asynchronous Output Sample](asynchronous-output-sample.md).

2. Create a Windows Forms Application project in Microsoft Visual Studio 2013.

3. The code section below includes two files, **AsyncApp.cs** and **AsyncApp.Designer.cs**.

4. In the newly created project, replace **Form1.cs** with **AsyncApp.cs** and **Form1.Designer.cs** with **AsyncApp.Designer.cs**.

5. If it doesn’t already exist, add an assembly reference to Microsoft.PointOfService.dll. In a standard install, you can find this file under **Program Files (x86)\\Microsoft Point Of Service\\SDK**.

6. Compile and run.

## To run the sample

1. This sample displays a GUI user interface that allows the user to send asynchronous and synchronous print requests to the [Asynchronous Output Sample](asynchronous-output-sample.md) Service Object.

2. The Service Object waits for several seconds before returning from a request, whether it is synchronous or asynchronous.

3. The UI displays the status of each request in the text box.

## Example

This sample code demonstrates several key points:

- Using an **OutputCompleteEvent** event to notify the application that the Service Object has completed an output request.
- Registering event handlers, including using reflection to do so.
- Using <xref:Microsoft.PointOfService.PosExplorer> to search for specific Service Objects.

To demonstrate how reflection can be used to discover which events are available on a given object, this code uses the <xref:Microsoft.PointOfService.PosCommon> object returned from <xref:Microsoft.PointOfService.PosExplorer.CreateInstance(Microsoft.PointOfService.DeviceInfo)> without first casting it to a **PosPrinter**. In most cases, an application does not need to be generic in that way and so would cast the object as appropriate.

```csharp
// ASYNCAPP.CS
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Reflection;
using Microsoft.PointOfService;

namespace AsyncOutputApp
{
    public partial class AsyncApp : Form
    {
        PosCommon posCommon;
        PosExplorer posExplorer;

        public AsyncApp()
        {
            InitializeComponent();

            btnPrintAsync.Enabled = true;
            btnPrintSync.Enabled = true;

            posExplorer = new PosExplorer(this);
            posCommon = null;

            string SOName = "AsyncOutputPrinter";

            try
            {
                OpenDevice(SOName);
                SetupEvents();
            }
            catch
            {
                MessageBox.Show("The Service Object '" +
                        SOName + "' failed to load",
                        "Service Object Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);

                btnPrintAsync.Enabled = false;
                btnPrintSync.Enabled = false;
            }
        }

        private void OpenDevice(string SOName)
        {
            string str = txtPrintResults.Text;
            DeviceInfo device = null;

            txtPrintResults.Clear();

            {
                // Retrieve the list of PosPrinter Service Objects.
                DeviceCollection devices =
                        posExplorer.GetDevices(
                        DeviceType.PosPrinter);

                // Iterate through the list looking for the one
                // needed for this sample.
                foreach(DeviceInfo d in devices)
                {
                    if(d.ServiceObjectName == SOName)
                    {
                        device = d;
                        break;
                    }
                }

                if (device == null)
                {
                    throw new Exception("Service Object not found");
                }

                txtPrintResults.Text = "Opening device: " +
                        device.ServiceObjectName + ", type: " +
                        device.Type + "\r\n";

                posCommon =
                        (PosCommon)posExplorer.CreateInstance(device);

                posCommon.Open();
                posCommon.Claim(0);
                posCommon.DeviceEnabled = true;
            }
        }

        // When this button is pressed, AsyncMode is turned off,
        // and the application waits for each print request
        // to complete before regaining control.
        private void btnPrintSync_Click(object sender, EventArgs e)
        {
            PosPrinter posPrinter = posCommon as PosPrinter;
            posPrinter.AsyncMode = false;

            txtPrintResults.AppendText(
                        "Printing will take place " +
                        "synchronously.\r\n");

            StartPrinting();
        }

        // When this button is pressed, AsyncMode is turned on. Print
        // requests will be queued and delivered on a
        // first-in-first-out basis.
        private void btnPrintAsync_Click(object sender, EventArgs e)
        {
            PosPrinter posPrinter = posCommon as PosPrinter;
            posPrinter.AsyncMode = true;

            txtPrintResults.AppendText(
                        "Printing will take place " +
                        "asynchronously.\r\n");

            StartPrinting();
        }

        private void StartPrinting()
        {
            PosPrinter posPrinter = posCommon as PosPrinter;

            txtPrintResults.AppendText(
                        "Calling PrintNormal to start " +
                        "printing...\r\n");

            // Notice that calling PrintNormal() here may not result
            // in a print request being sent immediately to the
            // printer. In asynchronous mode, the requested is
            // placed in a first-in-first-out queue managed by
            // POS for .NET.
            try
            {
                posPrinter.PrintNormal(
                            PrinterStation.Receipt,
                            "This is do-nothing print data");
            }
            catch (PosControlException e)
            {
                txtPrintResults.AppendText(
                            "PrintNormal threw a " +
                            "PosControlException! Description: " +
                            e.Message + "\r\n");

                return;
            }

            // When data is sent to an output device, POS for .NET
            // updates the OutputId property in the target object.
            // When an OutputCompleteEvent is sent to the app,
            // the OutputCompleteEventArgs will contain this id.
            Int32 id = posPrinter.OutputId;

            txtPrintResults.AppendText(
                        "PrintNormal has returned! OutputID = " +
                        id + "\r\n");
        }

        // Visual Studio-generated code.
        private void AsyncApp_Load(object sender, EventArgs e)
        {
        }

        #region Event Registration
        private void SetupEvents()
        {
            // All PosCommon objects support StatusUpdateEvent and
            // DirectIOEvent events, so simply register a handler
            // for those events.
            posCommon.StatusUpdateEvent +=
                        new StatusUpdateEventHandler(
                        co_OnStatusUpdateEvent);

            posCommon.DirectIOEvent +=
                        new DirectIOEventHandler(
                        co_OnDirectIOEvent);

            // In addition to the events common to all devices
            // (StatusUpdateEvent and DirectIOEvent), a device
            // type may also support DataEvent, ErrorEvent, or
            // OutputCompleteEvent events.
            //
            // In this example, the following code uses reflection
            // to determine which events are supported by this
            // object (posCommon).
            //
            // However, in the general case, an application will know
            // what type of device was returned when PosExplorer
            // CreateInstance() was called;therefore will not
            // need to use reflection, but can instead register
            // event handlers using the mechanism used for
            // StatusUpdateEvent and DirectIOEvent events above.
            EventInfo dataEvent =
                        posCommon.GetType().GetEvent(
                        "DataEvent");
            if (dataEvent != null)
            {
                dataEvent.AddEventHandler(posCommon,
                        new DataEventHandler(
                        co_OnDataEvent));

                txtPrintResults.AppendText("Registering Event: " +
                        "DataEvent\r\n");
            }

            EventInfo errorEvent =
                        posCommon.GetType().GetEvent(
                        "ErrorEvent");
            if (errorEvent != null)
            {
                errorEvent.AddEventHandler(posCommon,
                        new DeviceErrorEventHandler(
                        co_OnErrorEvent));

                txtPrintResults.AppendText("Registering Event: " +
                        "ErrorEvent\r\n");
            }

            EventInfo outputCompleteEvent =
                        posCommon.GetType().GetEvent(
                        "OutputCompleteEvent");
            if (outputCompleteEvent != null)
            {
                outputCompleteEvent.AddEventHandler(
                        posCommon, new OutputCompleteEventHandler(
                        co_OnOutputCompleteEvent));

                txtPrintResults.AppendText("Registering Event: " +
                        "OutputCompleteEvent\r\n");
            }
        }
        #endregion Event Registration

        #region Event Handlers
        private void co_OnDataEvent(
                        object obj,
                        DataEventArgs d)
        {
            txtPrintResults.AppendText(d.ToString() + "\r\n");
        }

        private void co_OnStatusUpdateEvent(
                        object source,
                        StatusUpdateEventArgs d)
        {
            txtPrintResults.AppendText(d.ToString() + "\r\n");
        }

        private void co_OnDirectIOEvent(
                        object source,
                        DirectIOEventArgs d)
        {
            txtPrintResults.AppendText(d.ToString() + "\r\n");
        }

        private void co_OnErrorEvent(
                        object source,
                        DeviceErrorEventArgs d)
        {
            string str = d.ToString();

            MessageBox.Show(d.ToString(),
                        "OnErrorEvent called",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

            txtPrintResults.AppendText(d.ToString() + "\r\n");
        }

        private void co_OnOutputCompleteEvent(
                        object source,
                        OutputCompleteEventArgs d)
        {
            txtPrintResults.AppendText(d.ToString() + "\r\n");
        }
        #endregion Event Handlers
    }
}

// ASYNCAPP.DESIGNER.CS
namespace AsyncOutputApp
{
    partial class AsyncApp
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
            this.txtPrintResults = new System.Windows.Forms.TextBox();
            this.btnPrintSync = new System.Windows.Forms.Button();
            this.btnPrintAsync = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // txtPrintResults
            //
            this.txtPrintResults.BackColor = System.Drawing.SystemColors.Window;
            this.txtPrintResults.Location = new System.Drawing.Point(12, 119);
            this.txtPrintResults.Multiline = true;
            this.txtPrintResults.Name = "txtPrintResults";
            this.txtPrintResults.ReadOnly = true;
            this.txtPrintResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPrintResults.Size = new System.Drawing.Size(650, 200);
            this.txtPrintResults.TabIndex = 3;
            //
            // btnPrintSync
            //
            this.btnPrintSync.Location = new System.Drawing.Point(12, 12);
            this.btnPrintSync.Name = "btnPrintSync";
            this.btnPrintSync.Size = new System.Drawing.Size(132, 39);
            this.btnPrintSync.TabIndex = 1;
            this.btnPrintSync.Text = "Print Synchronous";
            this.btnPrintSync.UseVisualStyleBackColor = true;
            this.btnPrintSync.Click += new System.EventHandler(this.btnPrintSync_Click);
            //
            // btnPrintAsync
            //
            this.btnPrintAsync.Location = new System.Drawing.Point(12, 57);
            this.btnPrintAsync.Name = "btnPrintAsync";
            this.btnPrintAsync.Size = new System.Drawing.Size(132, 39);
            this.btnPrintAsync.TabIndex = 2;
            this.btnPrintAsync.Text = "Print Asynchronously";
            this.btnPrintAsync.UseVisualStyleBackColor = true;
            this.btnPrintAsync.Click += new System.EventHandler(this.btnPrintAsync_Click);
            //
            // AsyncApp
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 331);
            this.Controls.Add(this.btnPrintAsync);
            this.Controls.Add(this.btnPrintSync);
            this.Controls.Add(this.txtPrintResults);
            this.Name = "AsyncApp";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.AsyncApp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPrintResults;
        private System.Windows.Forms.Button btnPrintSync;
        private System.Windows.Forms.Button btnPrintAsync;
    }
}
```

The program should display the following text if you first press the **Print Synchronous** and then the **Print Asynchronous** button.

Opening device: AsyncOutputPrinter, type: PosPrinterRegistering Event: ErrorEventRegistering Event: OutputCompleteEventPrinting will take place synchronously.Calling PrintNormal to start printing...PrintNormal has returned\! OutputID = 0Printing will take place asynchronously.Calling PrintNormal to start printing...PrintNormal has returned\! OutputID = 1Microsoft.PointOfService.OutputCompleteEventArgs, TimeStamp: 11:35:39 AM, EventId: 1, OutputId: 1.

## See Also

#### Tasks

- [Asynchronous Output Sample](asynchronous-output-sample.md)

#### Concepts

- [Event Management](event-management.md)

#### Other Resources

- [Developing a Custom Service Object](developing-a-custom-service-object.md)
