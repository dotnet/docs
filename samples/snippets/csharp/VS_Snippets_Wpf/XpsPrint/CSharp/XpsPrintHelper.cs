// XpsPrint SDK Sample - XpsPrintHelper.cs
// Copyright (c) Microsoft Corporation. All rights reserved.

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Packaging;
using System.Printing;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Documents.Serialization;
using System.Windows.Media;
using System.Windows.Xps;
using System.Windows.Xps.Packaging;
using System.Windows.Xps.Serialization;
using SDKSample;

namespace SDKSampleHelper
{
    // ----------------------- class AsyncSaveEventArgs -----------------------
    /// <summary>
    ///   Event arguments class for asynchronous print events.</summary>
    public class AsyncPrintEventArgs : EventArgs
    {
        private String _status;
        private bool _completed;

        public String Status
        {
            get { return _status; }
        }

        public bool Completed
        {
            get { return _completed; }
        }

        public AsyncPrintEventArgs(String status, bool completed)
        {
            _completed = completed;
            _status = status;
        }
    }// end:class AsyncSaveEventArgs

    // ------------------------- class XpsPrintHelper -------------------------
    public class XpsPrintHelper
    {
        internal delegate void AsyncPrintChangeHandler(
            object printHelper, AsyncPrintEventArgs asycnInformation);

        internal event AsyncPrintChangeHandler OnAsyncPrintChange;

        #region Constructors
        public XpsPrintHelper(String contentPath)
        {
            _wpfContent = new WPFContent(contentPath);
            _contentDir = contentPath;
        }
        #endregion Constructors

        #region Print Interface
        // -------------------------- GetPrintDialog --------------------------
        /// <summary>
        ///   Displays a printer dialog that allows the
        ///   user to chose the printer to output to.</summary>
        /// <returns>
        ///   The print dialog with the results of the user selection;
        ///   or NULL if the user clicks "Cancel" to the dialog.</returns>
        public PrintDialog GetPrintDialog()
        {
            PrintDialog printDialog = null;

            // Create a Print dialog.
            PrintDialog dlg = new PrintDialog();

            // Show the printer dialog.  If the return is "true",
            // the user made a valid selection and clicked "Ok".
            if (dlg.ShowDialog() == true)
                printDialog = dlg;  // return the dialog the user selections.

            return printDialog;
        }// end:GetPrintDialog()

        // ------------------------- PrintSingleVisual ------------------------
        /// <summary>
        ///   Prints a single visual element.</summary>
        /// <param name="pq">
        ///   The print queue to print to.</param>
        /// <param name="async">
        ///   true to print asynchronously; false to print synchronously.</param>
        public void PrintSingleVisual(PrintQueue pq, bool async)
        {
            // Create a single visual element.
            Canvas v = _wpfContent.CreateFirstVisual(true);

            // Create a document writer to print to.
            XpsDocumentWriter xdwPrint = GetPrintXpsDocumentWriter(pq);

            // Transform the visual to fit the printer.
            Visual transformedVisual = PerformTransform(v, pq);

            // Print either asynchronously or synchronously.
            if (async)
                PrintVisualAsync(xdwPrint, transformedVisual);
            else
                PrintVisual(xdwPrint, transformedVisual);
        }// end:PrintSingleVisual()

        // ----------------------- PrintMultipleVisuals -----------------------
        /// <summary>
        ///   Prints a collection of multiple visual elements.</summary>
        /// <param name="pq">
        ///   The print queue to print to.</param>
        /// <param name="async">
        ///   true to print asynchronously; false to print synchronously.</param>
        public void PrintMultipleVisuals(PrintQueue pq, bool async)
        {
            // Create a collection of visuals
            List<Visual> vc = new List<Visual>();

            //Create Visuals
            Visual v;
            v = _wpfContent.CreateFirstVisual(true);
            Visual transformedVisual = PerformTransform(v, pq);
            vc.Add(transformedVisual);

            v = _wpfContent.CreateSecondVisual(true);
            transformedVisual = PerformTransform(v, pq);
            vc.Add(transformedVisual);

            v = _wpfContent.CreateThirdVisual(true);
            transformedVisual = PerformTransform(v, pq);
            vc.Add(transformedVisual);

            // Retrieve Print Ticket from PrintQueue and
            // change the orientation to Landscape.
            PrintTicket pt = pq.UserPrintTicket;
            pt.PageOrientation = PageOrientation.Landscape;

            // Create an printing XPSDocumentWriter
            XpsDocumentWriter xdwPrint = GetPrintXpsDocumentWriter(pq);

            // Print either asynchronously or synchronously.
            if (async)
                PrintVisualsAsync(xdwPrint, vc);
            else
                // Print content using helper function
                PrintVisuals(xdwPrint, vc);
        }// end:PrintMultipleVisuals()

        // ------------------ PrintSingleFlowContentDocument ------------------
        /// <summary>
        ///   Prints the content of a single flow document.</summary>
        /// <param name="pq">
        ///   The print queue to print to.</param>
        /// <param name="async">
        ///   true to print asynchronously; false to print synchronously.</param>
        public void PrintSingleFlowContentDocument(PrintQueue pq, bool async)
        {
            // Create a paginated flow document.
            DocumentPaginator idp =
                _wpfContent.CreateFlowDocument().DocumentPaginator;

            // Create a document writer to print to.
            XpsDocumentWriter xdwPrint = GetPrintXpsDocumentWriter(pq);

            // Scale the paginated flow document to a visual for printing.
            Visual visual = _wpfContent.AdjustFlowDocumentToPage(idp, pq);

            // Print either asynchronously or synchronously.
            if (async)
                PrintVisual(xdwPrint, visual);
            else
                PrintVisualAsync(xdwPrint, visual);
        }// end:PrintSingleFlowContentDocument()

        // ------------------ PrintSingleFixedContentDocument -----------------
        /// <summary>
        ///   Prints the content of a single fixed document.</summary>
        /// <param name="pq">
        ///   The print queue to print to.</param>
        /// <param name="async">
        ///   true to print asynchronously; false to print synchronously.</param>
        public void PrintSingleFixedContentDocument(PrintQueue pq, bool async)
        {
            // Create a FixedDocument with associated PrintTicket.
            FixedDocument fd = _wpfContent.CreateFixedDocumentWithPages(pq);

            // Create a document writer to print to.
            XpsDocumentWriter xdwPrint = GetPrintXpsDocumentWriter(pq);

            // Print either asynchronously or synchronously.
            if (async)
                PrintSingleFixedContentDocumentAsync(xdwPrint, fd);
            else
                PrintSingleFixedContentDocument(xdwPrint, fd);
        }// end:PrintSingleFixedContentDocument()

		//<SnippetPrintMultipleFixedContentDocuments>

        // ---------------- PrintMultipleFixedContentDocuments ----------------
        /// <summary>
        ///   Prints the content of a multiple fixed document sequence.</summary>
        /// <param name="pq">
        ///   The print queue to print to.</param>
        /// <param name="async">
        ///   true to print asynchronously; false to print synchronously.</param>
        public void PrintMultipleFixedContentDocuments(PrintQueue pq, bool async)
        {
            // Create a multiple document FixedDocumentSequence.
            FixedDocumentSequence fds =
                _wpfContent.LoadFixedDocumentSequenceFromDocument();

            // Create a document writer to print to.
            XpsDocumentWriter xdwPrint = GetPrintXpsDocumentWriter(pq);

            // Set the event handler for creating print tickets for
            // each document within the fixed document sequence.
            xdwPrint.WritingPrintTicketRequired +=
                new WritingPrintTicketRequiredEventHandler(
                    MultipleFixedContentDocuments_WritingPrintTicketRequired);
            _firstDocumentPrintTicket = 0;

            // Print either asynchronously or synchronously.
            if (async)
                PrintMultipleFixedContentDocumentsAsync(xdwPrint, fds);
            else
                PrintMultipleFixedContentDocuments(xdwPrint, fds);
        }// end:PrintMultipleFixedContentDocuments()

		//</SnippetPrintMultipleFixedContentDocuments>

        // -------------------- PrintDocumentViewerContent --------------------
        /// <summary>
        ///   Prints the content displayed in a
        ///   given DocumentViewer control.</summary>
        /// <param name="dv">
        ///   The DocumentViewer content to print.</param>
        /// <param name="pq">
        ///   The print queue to print to.</param>
        /// <param name="async">
        ///   true to print asynchronously; false to print synchronously.</param>
        public void PrintDocumentViewerContent(
            DocumentViewer dv, PrintQueue pq, bool async)
        {
            // Create a document writer for printing
            XpsDocumentWriter xdwPrint = GetPrintXpsDocumentWriter(pq);

            // Scale the DocumentViewer content for the printer.
            DocumentPaginator idp = dv.Document.DocumentPaginator;
            Visual visual = _wpfContent.AdjustFlowDocumentToPage(idp, pq);

            // Print either asynchronously or synchronously.
            if (async)
                PrintVisual(xdwPrint, visual);
            else
                PrintVisualAsync(xdwPrint, visual);
        }// end:PrintDocumentViewerContent()

        #endregion // Print Interface

        #region Synchronous Print Methods

        // ------------------------- PrintVisualAsync -------------------------
        /// <summary>
        ///   Synchronously prints a given visual
        ///   to a specified document writer.</summary>
        /// <param name="xpsdw">
        ///   The document writer to output to.</param>
        /// <param name="v">
        ///   The visual to print.</param>
        private void PrintVisual(XpsDocumentWriter xpsdw, Visual v)
        {
            xpsdw.Write(v);     // Write visual to single page
        }

        // --------------------------- PrintVisuals ---------------------------
        /// <summary>
        ///   Synchronously prints of a given list of
        ///   visuals to a specified document writer.</summary>
        /// <param name="xpsdw">
        ///   The document writer to output to.</param>
        /// <param name="vc">
        ///   The list of visuals to print.</param>
        private void PrintVisuals(XpsDocumentWriter xpsdw, List<Visual> vc)
        {
            // Setup for writing multiple visuals
            VisualsToXpsDocument vToXpsD =
                (VisualsToXpsDocument)xpsdw.CreateVisualsCollator();

            // Iterate through all visuals in the collection
            foreach (Visual v in vc)
            {
                vToXpsD.Write(v);   //Write each visual to single page
            }

            // End writing multiple visuals
            vToXpsD.EndBatchWrite();
        }

        // ------------------ PrintSingleFlowContentDocument ------------------
        /// <summary>
        ///   Synchronously prints a given paginated flow
        ///   document to a specified document writer.</summary>
        /// <param name="xpsdw">
        ///   The document writer to output to.</param>
        /// <param name="idp">
        ///   The paginated flow document to print.</param>
        private void PrintSingleFlowContentDocument(
            XpsDocumentWriter xpsdw, DocumentPaginator idp)
        {
            xpsdw.Write(idp);   // Write the IDP as a document
        }

        // ----------------- PrintSingleFixedContentDocument ------------------
        /// <summary>
        ///   Synchronously prints of a given fixed
        ///   document to a specified document writer.</summary>
        /// <param name="xpsdw">
        ///   The document writer to output to.</param>
        /// <param name="fd">
        ///   The fixed document to print.</param>
        private void PrintSingleFixedContentDocument(
            XpsDocumentWriter xpsdw, FixedDocument fd)
        {
            xpsdw.Write(fd);    // Write the FixedDocument as a document.
        }

        // ---------------- PrintMultipleFixedContentDocuments ----------------
        /// <summary>
        ///   Synchronously prints multiple fixed documents from a given
        ///   FixedDocumentSequence to a specified DocumentWriter.</summary>
        /// <param name="xpsdw">
        ///   The document writer to output to.</param>
        /// <param name="fds">
        ///   The fixed document sequence to print.</param>
        private void PrintMultipleFixedContentDocuments(
            XpsDocumentWriter xpsdw, FixedDocumentSequence fds)
        {
            xpsdw.Write(fds);   // Write as a collection of documents.
        }

        #endregion // Synchronous Print Methods

        #region Asynchronous Print Methods

        // ------------------------- PrintVisualAsync -------------------------
        /// <summary>
        ///   Initiates asynchronous output of a given
        ///   visual to a specified document writer.</summary>
        /// <param name="xpsdw">
        ///   The document writer to output to.</param>
        /// <param name="v">
        ///   The visual to print.</param>
        private void PrintVisualAsync(XpsDocumentWriter xpsdw, Visual v)
        {
            _xpsdwActive = xpsdw;   // Save the active document writer.

            xpsdw.WritingCompleted +=
                new WritingCompletedEventHandler(AsyncPrintCompleted);

            xpsdw.WriteAsync(v);    // Write the visual to a single page.
        }

        // ------------------------- PrintVisualsAsync ------------------------
        /// <summary>
        ///   Initiates asynchronous output of a given list of
        ///   visuals to a specified document writer.</summary>
        /// <param name="xpsdw">
        ///   The document writer to output to.</param>
        /// <param name="vc">
        ///   The list of visuals to print.</param>
        private void PrintVisualsAsync(XpsDocumentWriter xpsdw, List<Visual> vc)
        {
            _xpsdwActive = xpsdw;   // Save the active document writer.

            xpsdw.WritingCompleted +=
                new WritingCompletedEventHandler(AsyncPrintCompleted);

            xpsdw.WritingProgressChanged +=
                new WritingProgressChangedEventHandler(AsyncPrintingProgress);

            // Setup for writing multiple visuals
            VisualsToXpsDocument vToXpsD =
                (VisualsToXpsDocument)xpsdw.CreateVisualsCollator();

            _batchProgress = 0;
            _activeVtoXPSD = vToXpsD;

            // Iterate through all visuals in the collection.
            foreach (Visual v in vc)
            {
                vToXpsD.WriteAsync(v);  //Write each visual to a single page.
            }
        }// end:PrintVisualsAsync()

        // --------------- PrintSingleFlowContentDocumentAsync ----------------
        /// <summary>
        ///   Initiates asynchronous output of a given paginated
        ///   flow document to a specified document writer.</summary>
        /// <param name="xpsdw">
        ///   The document writer to output to.</param>
        /// <param name="idp">
        ///   The paginated flow document to print.</param>
        private void PrintSingleFlowContentDocumentAsync(
            XpsDocumentWriter xpsdw, DocumentPaginator idp)
        {
            _xpsdwActive = xpsdw;   // Save the active document writer.

            xpsdw.WritingCompleted +=
                new WritingCompletedEventHandler(AsyncPrintCompleted);

            xpsdw.WriteAsync(idp);  // Write the IDP as a document.
        }// end:PrintSingleFlowContentDocumentAsync()

        // --------------- PrintSingleFixedContentDocumentAsync ---------------
        /// <summary>
        ///   Initiates asynchronous print of a given fixed
        ///   document to a specified document writer.</summary>
        /// <param name="xpsdw">
        ///   The document writer to output to.</param>
        /// <param name="fd">
        ///   The fixed document to print.</param>
        private void PrintSingleFixedContentDocumentAsync(
                        XpsDocumentWriter xpsdw, FixedDocument fd)
        {
            _xpsdwActive = xpsdw;   // Save the active document writer.

            xpsdw.WritingCompleted +=
                new WritingCompletedEventHandler(AsyncPrintCompleted);

            xpsdw.WriteAsync(fd);   // Print the FixedDocument.
        }

        // -------------- PrintMultipleFixedContentDocumentsAsync -------------
        /// <summary>
        ///   Initiates asynchronous print of multiple fixed documents from a
        ///   given FixedDocumentSequence to a specified DocumentWriter.</summary>
        /// <param name="xpsdw">
        ///   The document writer to output to.</param>
        /// <param name="fds">
        ///   The fixed document sequence to print.</param>
        private void PrintMultipleFixedContentDocumentsAsync(
                        XpsDocumentWriter xpsdw, FixedDocumentSequence fds)
        {
            _xpsdwActive = xpsdw;   // Save the active document writer.

            xpsdw.WritingCompleted +=
                new WritingCompletedEventHandler(AsyncPrintCompleted);

            xpsdw.WritingProgressChanged +=
                new WritingProgressChangedEventHandler(AsyncPrintingProgress);

            // Write the FixedDocumentSequence as a
            // collection of documents asynchronously.
            xpsdw.WriteAsync(fds);
        }// end:PrintMultipleFixedContentDocumentsAsync()

        // ---------------------------- CancelAsync ---------------------------
        /// <summary>
        ///   Cancels the current asynchronous print opertion.</summary>
        public void CancelAsync()
        {
            _xpsdwActive.CancelAsync();
        }

        #endregion // Asynchronous Print Methods

        #region Async Event Handlers

        // ------------------------ AsyncPrintCompleted -----------------------
        /// <summary>
        ///   Creates an "async operation complete" event handler
        ///   for print completion of a FixedDocumentSequence.</summary>
        private void AsyncPrintCompleted(
                        object sender, WritingCompletedEventArgs e)
        {
            string result = null;
            if (e.Cancelled)
                result = "Canceled";
            else if (e.Error != null)
                result = "Error";
            else
                result = "Asynchronous Print Completed";

            if (OnAsyncPrintChange != null)
            {
                AsyncPrintEventArgs asyncInfo =
                    new AsyncPrintEventArgs(result, true);
                OnAsyncPrintChange(this, asyncInfo);  // update display status
            }
        }// end:AsyncPrintCompleted()

        // ----------------------- AsyncPrintingProgress ----------------------
        /// <summary>
        ///   Creates an "async operation progress" event handler for tracking
        ///   the progress in printing a FixedDocumentSequence.</summary>
        private void AsyncPrintingProgress(
                         object sender, WritingProgressChangedEventArgs e)
        {
            _batchProgress++;

            if (OnAsyncPrintChange != null)
            {
                String progress = String.Format("{0} - {1}",
                    e.WritingLevel.ToString(), e.Number.ToString());
                AsyncPrintEventArgs asyncInfo =
                    new AsyncPrintEventArgs(progress, false);
                OnAsyncPrintChange(this, asyncInfo);  // update display status
            }

            // Will only called EndBatchWrite when serializing Multiple Visuals
            if (_activeVtoXPSD != null && _batchProgress == 3)
            {
                _activeVtoXPSD.EndBatchWrite();
            }
        }// end:AsyncPrintingProgress()

		//<SnippetMultipleFixedContentDocuments_WritingPrintTicketRequired>

        // ----- MultipleFixedContentDocuments_WritingPrintTicketRequired -----
        /// <summary>
        ///   Creates a PrintTicket event handler for
        ///   printing a FixedDocumentSequence.</summary>
        private void MultipleFixedContentDocuments_WritingPrintTicketRequired(
                        Object sender, WritingPrintTicketRequiredEventArgs e)
        {
            if (e.CurrentPrintTicketLevel ==
                    PrintTicketLevel.FixedDocumentSequencePrintTicket)
            {
                // Create a PrintTicket for the FixedDocumentSequence. Any
                // PrintTicket setting specified at the FixedDocumentSequence
                // level will be inherited by lower level (i.e. FixedDocument or
                // FixedPage) unless there exists lower level PrintTicket that
                // sets the setting differently, in which case the lower level
                // PrintTicket setting will override the higher level setting.
                PrintTicket ptFDS = new PrintTicket();
                ptFDS.PageOrientation = PageOrientation.Portrait;
                ptFDS.Duplexing = Duplexing.TwoSidedLongEdge;
                e.CurrentPrintTicket = ptFDS;
            }

            else if (e.CurrentPrintTicketLevel ==
                PrintTicketLevel.FixedDocumentPrintTicket)
            {
                // <SnippetOutputColorAndPageOrientation>
                // Use different PrintTickets for different FixedDocuments.
                PrintTicket ptFD = new PrintTicket();

                if (_firstDocumentPrintTicket <= 1)
                {   // Print the first document in black/white and in portrait
                    // orientation.  Since the PrintTicket at the
                    // FixedDocumentSequence level already specifies portrait
                    // orientation, this FixedDocument can just inherit that
                    // setting without having to set it again.
                    ptFD.PageOrientation = PageOrientation.Portrait;
                    ptFD.OutputColor = OutputColor.Monochrome;
                    _firstDocumentPrintTicket++;
                }

                else // if (_firstDocumentPrintTicket > 1)
                {   // Print the second document in color and in landscape
                    // orientation.  Since the PrintTicket at the
                    // FixedDocumentSequence level already specifies portrait
                    // orientation, this FixedDocument needs to set its
                    // PrintTicket with landscape orientation in order to
                    // override the higher level setting.
                    ptFD.PageOrientation = PageOrientation.Landscape;
                    ptFD.OutputColor = OutputColor.Color;
                }
                // </SnippetOutputColorAndPageOrientation>

                e.CurrentPrintTicket = ptFD;
            }// end:else if (CurrentPrintTicketLevel==FixedDocumentPrintTicket)

            // Even though we don't show code for specifying PrintTicket for
            // the FixedPage level, the same inheritance-override logic applies
            // to FixedPage as well.
        }// end:MultipleFixedContentDocuments_WritingPrintTicketRequired()

		//</SnippetMultipleFixedContentDocuments_WritingPrintTicketRequired>

        // -------------- CreateFixedDocumentSequencePrintTicket --------------
        /// <summary>
        ///   Creates a FixedDocumentSequence compatible PrintTicket.</summary>
        /// <returns>
        ///   A FixedDocumentSequence compatible PrintTicket.</returns>
        private PrintTicket CreateFixedDocumentSequencePrintTicket()
        {
            // Create a local print server
            LocalPrintServer ps = new LocalPrintServer();

            // Get the default print queue
            PrintQueue pq = ps.DefaultPrintQueue;

            // Get the default user print ticket
            PrintTicket pt = pq.UserPrintTicket;

            // Set Duplexing value for each document in the job
            pt.Duplexing = Duplexing.OneSided;

            return pt;
        }// end:CreateFixedDocumentSequencePrintTicket()

        // ------------------ CreateFixedDocumentPrintTicket ------------------
        /// <summary>
        ///   Creates a FixedDocument compatible PrintTicket.</summary>
        /// <param name="isLandscaped">
        ///   true to output in landscape; false to output in portrait.</param>
        /// <returns>
        ///   A FixedDocument compatible PrintTicket.</returns>
        private PrintTicket CreateFixedDocumentPrintTicket(bool isLandscaped)
        {
            // Create a local print server
            LocalPrintServer ps = new LocalPrintServer();

            // Get the default print queue
            PrintQueue pq = ps.DefaultPrintQueue;

            // Get the default user print ticket
            PrintTicket pt = pq.UserPrintTicket;

            // Set Duplexing value for the document
            pt.Duplexing = Duplexing.TwoSidedLongEdge;

            if (isLandscaped)
                pt.PageOrientation = PageOrientation.Landscape;

            return pt;
        }// end:CreateFixedDocumentPrintTicket()

        #endregion // Async Event Handlers

        #region Helper Methods

		//<SnippetPrintQueueSnip>
        // -------------------- GetPrintXpsDocumentWriter() -------------------
        /// <summary>
        ///   Returns an XpsDocumentWriter for the default print queue.</summary>
        /// <returns>
        ///   An XpsDocumentWriter for the default print queue.</returns>
        private XpsDocumentWriter GetPrintXpsDocumentWriter()
        {
            // Create a local print server
            LocalPrintServer ps = new LocalPrintServer();

            // Get the default print queue
            PrintQueue pq = ps.DefaultPrintQueue;

            // Get an XpsDocumentWriter for the default print queue
            XpsDocumentWriter xpsdw = PrintQueue.CreateXpsDocumentWriter(pq);
            return xpsdw;
        }// end:GetPrintXpsDocumentWriter()
		//</SnippetPrintQueueSnip>

        // --------------- GetPrintXpsDocumentWriter(PrintQueue) --------------
        /// <summary>
        ///   Returns an XpsDocumentWriter for a given print queue.</summary>
        /// <param name="pq">
        ///   The print queue to return the XpsDocumentWriter for.</param>
        /// <returns>
        ///   An XpsDocumentWriter for the given print queue.</returns>
        private XpsDocumentWriter GetPrintXpsDocumentWriter(PrintQueue pq)
        {
            XpsDocumentWriter xpsdw = PrintQueue.CreateXpsDocumentWriter(pq);
            return xpsdw;
        }// end:GetPrintXpsDocumentWriter(PrintQueue)

        // -------------------- GetPrintXpsDocumentWriter() -------------------
        // <SnippetPageMediaSize>
        /// <summary>
        ///   Returns a scaled copy of a given visual transformed to
        ///   fit for printing to a specified print queue.</summary>
        /// <param name="v">
        ///   The visual to be printed.</param>
        /// <param name="pq">
        ///   The print queue to be output to.</param>
        /// <returns>
        ///   The root element of the transformed visual.</returns>
        private Visual PerformTransform(Visual v, PrintQueue pq)
        {
            ContainerVisual root = new ContainerVisual();
            const double inch = 96;

            // Set the margins.
            double xMargin = 1.25 * inch;
            double yMargin = 1 * inch;

            PrintTicket pt = pq.UserPrintTicket;
            Double printableWidth = pt.PageMediaSize.Width.Value;
            Double printableHeight = pt.PageMediaSize.Height.Value;

            Double xScale = (printableWidth - xMargin * 2) / printableWidth;
            Double yScale = (printableHeight - yMargin * 2) / printableHeight;

            root.Children.Add(v);
            root.Transform = new MatrixTransform(xScale, 0, 0, yScale, xMargin, yMargin);

            return root;
        }// end:PerformTransform()
        // </SnippetPageMediaSize>

        #endregion // Helper Methods

        #region Private Data
        private int                   _batchProgress = 0;
        private int                   _firstDocumentPrintTicket = 0;
        private String                _contentDir = null;
        private WPFContent            _wpfContent = null;
        private VisualsToXpsDocument  _activeVtoXPSD = null;
        private XpsDocumentWriter     _xpsdwActive = null;
        #endregion // Private Data

    }// end:class XpsPrintHelper
}// end:namespace SDKSampleHelper
