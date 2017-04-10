// XpsSave SDK Sample - XpsSaveHelper.cs
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
using SDKSample;


namespace SDKSampleHelper
{
    // ------------------------- AsyncSaveEventArgs ------------------------
    /// <summary>
    ///   Event arg class for asynchronous save events.</summary>
    public class AsyncSaveEventArgs : EventArgs
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

        public AsyncSaveEventArgs(String status, bool completed)
        {
            _completed = completed;
            _status = status;
        }
    }// end:class AsyncSaveEventArgs



    public class SaveHelper
    {
        internal delegate void AsyncSaveChangeHandler(
            object saveHelper, AsyncSaveEventArgs asycnInformation);

        internal event AsyncSaveChangeHandler OnAsyncSaveChange;


        #region Constructors
        public SaveHelper(String contentPath)
        {
            _xpfContent = new XPFContent(contentPath);
        }
        #endregion Constructors


        #region Save Interface
        public void SaveSingleVisual(String containerName, bool async)
        {
            // Create Visual
            Visual v = _xpfContent.CreateFirstVisual(true);

            // Create an saving XPSDocumentWriter.
            XpsDocumentWriter xdwSave = GetSaveXpsDocumentWriter(containerName);

            // Save content using helper function
            if (async)
            {
                SaveVisualAsync(xdwSave, v);
            }
            else
            {
                SaveVisual(xdwSave, v);
                // Close the pakcage
                _xpsDocument.Close();
            }
        }


        public void SaveMultipleVisuals(string containerName, bool async)
        {
            // Create a collection of visuals
            List<Visual> vc = new List<Visual>();

            //Create Visuals
            vc.Add(_xpfContent.CreateFirstVisual(true));
            vc.Add(_xpfContent.CreateSecondVisual(true));
            vc.Add(_xpfContent.CreateThirdVisual(true));

            // Create a saving XPSDocumentWriter
            XpsDocumentWriter xdwSave = GetSaveXpsDocumentWriter(containerName);

            if (async)
            {
                SaveVisualsAsync(xdwSave, vc);
            }
            else // if (!async)
            {
                // Save content using helper function
                SaveVisuals(xdwSave, vc);
                _xpsDocument.Close();   // Close the pakcage
            }
        }


        public void SaveSingleFlowContentDocument(
                    string containerName, bool async)
        {
            // Create flow content
            DocumentPaginator idp =
                _xpfContent.CreateFlowDocument().DocumentPaginator;

            // Create a saving XPSDocumentWriter
            // (temp file in current working directory).
            XpsDocumentWriter xdwSave = GetSaveXpsDocumentWriter(containerName);

            // Save content using helper function
            if (async)
            {
                SaveSingleFlowContentDocumentAsync(xdwSave, idp);
            }
            else
            {
                SaveSingleFlowContentDocument(xdwSave, idp);
                _xpsDocument.Close();   // Close the pakcage
            }
        }


        public void SaveSingleFixedContentDocument(
                    string containerName, bool async)
        {
            // Create FixedDocument with associated PrintTicket
            FixedDocument fd = _xpfContent.CreateFixedDocumentWithPages();

            // Create a saving XPSDocumentWriter
            // (temp file in current working directory).
            XpsDocumentWriter xdwSave =
                GetSaveXpsDocumentWriter(containerName);

            if (async)
            {
                SaveSingleFixedContentDocumentAsync(xdwSave, fd);
            }
            else
            {
                SaveSingleFixedContentDocument(xdwSave, fd);
                _xpsDocument.Close();  // Close the package
            }
        }


        public void SaveMultipleFixedContentDocuments(
                    string containerName, bool async)
        {
            // Create FixedDocumentSequence
            FixedDocumentSequence fds =
                _xpfContent.LoadFixedDocumentSequenceFromDocument();

            // Create a saving XPSDocumentWriter
            // (temp file in current working directory).
            XpsDocumentWriter xdwSave = GetSaveXpsDocumentWriter(containerName);

            if (async)
            {
                SaveMultipleFixedContentDocumentsAsync(xdwSave, fds);
            }
            else
            {
                // Save content using helper function
                SaveMultipleFixedContentDocuments(xdwSave, fds);
                // Close the pakcage
                _xpsDocument.Close();
            }
        }// end:SaveMultipleFixedContentDocuments()

        // Save content displayed in a DocumentViewer Control
        public void SaveDocumentViewerContent(
                    DocumentViewer dv, string containerName, bool async )
        {
            if (dv == null)
                return;

            // Create an saving XPSDocumentWriter
            // (temp file in current working directory).
            XpsDocumentWriter xdwSave = GetSaveXpsDocumentWriter(containerName);

            if (async)
            {
                SaveSingleFlowContentDocumentAsync(
                    xdwSave, dv.Document.DocumentPaginator);
            }
            else
            {
                // Access and Save DocumentViewer data
                SaveSingleFlowContentDocument(
                    xdwSave, dv.Document.DocumentPaginator);
                _xpsDocument.Close();   // Close the package
            }
        }// end:SaveDocumentViewerContent()

        #endregion

        #region Synchronous Save Methods

        //<SnippetWriteToXpsWithVisual>
        private void SaveVisual(XpsDocumentWriter xpsdw, Visual v)
        {
            xpsdw.Write(v); // Write visual to single page
        }
        //</SnippetWriteToXpsWithVisual>


        //<SnippetCreateAndWriteToVisualsCollator>
        private void SaveVisuals(XpsDocumentWriter xpsdw, List<Visual> vc)
        {
            // Setup for writing multiple visuals
            VisualsToXpsDocument vToXpsD = (VisualsToXpsDocument)xpsdw.CreateVisualsCollator();

            // Iterate through all visuals in the collection
            foreach (Visual v in vc)
            {
                vToXpsD.Write(v);   //Write each visual to single page
            }

            // End writing multiple visuals
            vToXpsD.EndBatchWrite();
        }
        //</SnippetCreateAndWriteToVisualsCollator>


        //<SnippetWriteToXpsWithDocumentPaginator>
        private void SaveSingleFlowContentDocument(
                     XpsDocumentWriter xpsdw, DocumentPaginator docPaginator)
        {
            xpsdw.Write(docPaginator); // Write the DocPaginator as a document.
        }
        //</SnippetWriteToXpsWithDocumentPaginator>


        //<SnippetWriteToXpsWithFixedDocument>
        private void SaveSingleFixedContentDocument(
                     XpsDocumentWriter xpsdw, FixedDocument fd)
        {
            xpsdw.Write(fd);        // Write the FixedDocument as a document.
        }
        //</SnippetWriteToXpsWithFixedDocument>


        //<SnippetWriteToXpsWithFixedDocumentSequence>
        private void SaveMultipleFixedContentDocuments(
                     XpsDocumentWriter xpsdw, FixedDocumentSequence fds)
        {
            // Write the FixedDocumentSequence as a collection of documents
            xpsdw.Write(fds);
        }
        //</SnippetWriteToXpsWithFixedDocumentSequence>
        #endregion // Synchronous Save Methods


        #region Asynchronous Save Methods
        //<SnippetWriteAsyncToXpsWithVisual>
        private void SaveVisualAsync(XpsDocumentWriter xpsdw, Visual v)
        {
            _xpsdwActive = xpsdw;

            xpsdw.WritingCompleted +=
                new WritingCompletedEventHandler(AsyncSaveCompleted);

            xpsdw.WriteAsync(v);    // Write visual to single page.
        }
        //</SnippetWriteAsyncToXpsWithVisual>


        private void SaveVisualsAsync(XpsDocumentWriter xpsdw, List<Visual> vc)
        {
            _xpsdwActive = xpsdw;

            xpsdw.WritingCompleted +=
                new WritingCompletedEventHandler(AsyncSaveCompleted);

            xpsdw.WritingProgressChanged +=
                new WritingProgressChangedEventHandler(AsyncSavingProgress);

            // Setup for writing multiple visuals
            VisualsToXpsDocument vToXpsD = (VisualsToXpsDocument)xpsdw.CreateVisualsCollator();

            _batchProgress = 0;
            _activeVtoXPSD = vToXpsD;

            // Iterate through all visuals in the collection
            foreach (Visual v in vc)
            {
                vToXpsD.WriteAsync(v);  // Write each visual to single page.
            }
        }// end:SaveVisualsAsync()


        //<SnippetWriteAsyncToXpsWithDocumentPaginator>
        private void SaveSingleFlowContentDocumentAsync(
                     XpsDocumentWriter xpsdw, DocumentPaginator idp)
        {
            _xpsdwActive = xpsdw;

            xpsdw.WritingCompleted +=
                new WritingCompletedEventHandler(AsyncSaveCompleted);

            // Write the IDP as a document.
            xpsdw.WriteAsync(idp);
        }
        //</SnippetWriteAsyncToXpsWithDocumentPaginator>


        //<SnippetWriteAsyncToXpsWithFixedDocument>
        private void SaveSingleFixedContentDocumentAsync(
                     XpsDocumentWriter xpsdw, FixedDocument fd)
        {
            _xpsdwActive = xpsdw;

            xpsdw.WritingCompleted +=
                new WritingCompletedEventHandler(AsyncSaveCompleted);

            // Write the FixedDocument as a document.
            xpsdw.WriteAsync(fd);
        }
        //</SnippetWriteAsyncToXpsWithFixedDocument>


        //<SnippetWritingEvents>
        //<SnippetWriteAsyncToXpsWithFixedDocumentSequence>
        private void SaveMultipleFixedContentDocumentsAsync(
                     XpsDocumentWriter xpsdw, FixedDocumentSequence fds)
        {
            _xpsdwActive = xpsdw;

            xpsdw.WritingCompleted +=
                new WritingCompletedEventHandler(AsyncSaveCompleted);

            xpsdw.WritingProgressChanged +=
                new WritingProgressChangedEventHandler(AsyncSavingProgress);

            // Write the FixedDocumentSequence as a
            // collection of documents asynchronously.
            xpsdw.WriteAsync(fds);
        }
        //</SnippetWriteAsyncToXpsWithFixedDocumentSequence>


        // Cancel an async operation
        public void CancelAsync()
        {
            _xpsdwActive.CancelAsync();
        }
        #endregion // Asynchronous Save Methods


        #region Async Event Handlers
        //
        // Create an "async operation complete" event handler
        // for saving a FixedDocumentSequence
        //
        private void AsyncSaveCompleted(
                     object sender, WritingCompletedEventArgs e)
        {
            string result;
            if (e.Cancelled)          result = "Canceled";
            else if (e.Error != null) result = "Error";
            else                      result = "Asynchronous operation Completed";

            // Close the pakcage
            _xpsDocument.Close();

            if (OnAsyncSaveChange != null)
            {
                AsyncSaveEventArgs asyncInfo =
                    new AsyncSaveEventArgs(result, true);
                OnAsyncSaveChange(this, asyncInfo);
            }
        }

        //
        // Create an "async operation progress" event handler for
        // monitoring the progress of saving a FixedDocumentSequence.
        //
        private void AsyncSavingProgress(
                        object sender, WritingProgressChangedEventArgs e)
        {
            _batchProgress++;

            if (OnAsyncSaveChange != null)
            {
                String progress =
                    String.Format("{0} - {1}", e.WritingLevel.ToString(),
                                  e.Number.ToString());
                AsyncSaveEventArgs asyncInfo =
                    new AsyncSaveEventArgs(progress, false);
                OnAsyncSaveChange(this, asyncInfo);
            }

            // Call EndBatchWrite when serializing multiple visuals.
            if ( (_activeVtoXPSD != null) && (_batchProgress == 3) )
                _activeVtoXPSD.EndBatchWrite();
        }
        //</SnippetWritingEvents>
        #endregion // Async Event Handlers


        private XpsDocumentWriter GetSaveXpsDocumentWriter(string containerName)
        {
            // Delete the file if it already exists
            File.Delete(containerName);

            // Create an XPS Document for saving

            //<SnippetCreateXpsDocumentWriter>

            _xpsDocument = new XpsDocument(containerName,FileAccess.ReadWrite);

            XpsDocumentWriter xpsdw = XpsDocument.CreateXpsDocumentWriter(_xpsDocument);

            //</SnippetCreateXpsDocumentWriter>

            return xpsdw;
        }

        #region Private Data
        private int                     _batchProgress;
        private XPFContent              _xpfContent;
        private VisualsToXpsDocument    _activeVtoXPSD;
        private XpsDocument             _xpsDocument;
        private XpsDocumentWriter       _xpsdwActive;
        #endregion // Private Data

    }// end:class SaveHelper

}// end:namespace SDKSampleHelper

