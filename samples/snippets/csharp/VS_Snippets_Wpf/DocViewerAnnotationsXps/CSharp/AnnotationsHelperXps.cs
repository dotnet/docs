// DocViewerAnnotationsXps SDK Sample - AnnotationsHelperXps.cs
// Copyright (c) Microsoft Corporation. All rights reserved.

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Annotations.Storage;
using System.IO;
using System.Windows.Annotations;
using System.IO.Packaging;
using System.Windows.Controls;
using System.Windows.Documents;

namespace SDKSample
{
    // ====================== class AnnotationsHelperXps ======================
    /// <summary>
    ///   Provides helper methods for creating and storing user annotations
    ///   within an XML file stored in an XPS document container.</summary>
    public class AnnotationsHelperXps
    {

        // ------------- AnnotationsHelperXps default constructor -------------
        /// <summary>
        ///   Initializes a new instance of the class.</summary>
        public AnnotationsHelperXps()
        {
        }


        // --------- AnnotationsHelperXps DocumentViewer constructor ----------
        /// <summary>
        ///   Initializes a new instance of the AnnotationsHelperXps
        ///   class with a given target DocumentViewer.</summary>
        public AnnotationsHelperXps(DocumentViewer dv)
        {
            _docViewer = dv;
        }


        // --------------------- DocViewer Getter/Setter ----------------------
        /// <summary>
        ///   Sets and gets the DocumentViewer control that
        ///   contains the content to be annotated.</summary>
        public DocumentViewer DocViewer
        {
            set
                { _docViewer = value; }
            get
                { return _docViewer; }
        }


        // ---------------------------- SetSource -----------------------------
        /// <summary>
        ///   Sets the source document packageURI
        ///   and FixedDocumentSequence URI.</summary>
        /// <param name="packageUri">
        ///   The URI path and filename of the XPS document container.</param>
        /// <param name="rootUri">
        ///   The URI of the root FixedDocumentSequence in the package.</param>
        /// <remarks>
        ///     SetSource must be called first before
        ///     calling StartAnnotations().</remarks>
        public void SetSource(Uri packageUri, Uri rootUri)
        {
            _packageUri = packageUri;
            _rootUri = rootUri;
        }


        //<SnippetStartStopAnnotations>
        //<SnippetStartAnnotations>
        // ------------------------- StartAnnotations -------------------------
        /// <summary>
        ///   Enables annotations processing and
        ///   displays viewable annotations.</summary>
        /// <remarks>
        ///     SetSource must be called first before
        ///     calling StartAnnotations().</remarks>
        public void StartAnnotations()
        {
            if (_docViewer==null)
                throw new InvalidOperationException(
                    "Required DocumentViewer control has not been specified.");

            if ((_packageUri==null) || (_rootUri==null))
                throw new InvalidOperationException(
                    "Required SetSource() has not been called.");

            // If there is no AnnotationService yet, create one.
            if (_annotService == null)
            {
                // Get the annotations data stream from the XPS container.
                _annotStream  = GetAnnotationPart(_rootUri).GetStream();

                // Create the AnnotationService.
                _annotService = new AnnotationService(_docViewer);

                // Enable the service with the annotation data stream.
                _annotService.Enable(new XmlStreamStore(_annotStream));
            }

            // Else if the annotationService exists but is not enabled, enable it.
            else if (!_annotService.IsEnabled)
                _annotService.Enable(_annotService.Store);

        }// end:StartAnnotations()
        //</SnippetStartAnnotations>


        //<SnippetStopAnnotations>
        // -------------------------- StopAnnotations -------------------------
        /// <summary>
        ///   Disables annotations processing and hides annotations.</summary>
        public void StopAnnotations()
        {
            // If the AnnotationStore is active, flush and close it.
            if ( (_annotService != null) && _annotService.IsEnabled )
            {
                _annotService.Store.Flush();
                _annotStream.Flush();
                _annotStream.Close();
            }

            // If the AnnotationService is active, shut it down.
            if (_annotService != null)
            {
                if (_annotService.IsEnabled)
                    _annotService.Disable();
                _annotService = null;
            }
        }// end:StopAnnotations()
        //</SnippetStopAnnotations>
        //</SnippetStartStopAnnotations>


        //<SnippetDocViewAnnXpsDocPaginator>
        // ------------------ GetAnnotationDocumentPaginator ------------------
        /// <summary>
        ///   Returns a paginator for printing annotations.</summary>
        /// <param name="fds">
        ///   The FixedDocumentSequence containing
        ///   the annotations to print.</param>
        /// <returns>
        ///   An paginator for printing the document's annotations.</returns>
        public AnnotationDocumentPaginator GetAnnotationDocumentPaginator(
                                                    FixedDocumentSequence fds)
        {
            return new AnnotationDocumentPaginator(
                           fds.DocumentPaginator, _annotService.Store);
        }
        //</SnippetDocViewAnnXpsDocPaginator>


        // ------------------------ GetAnnotationsPart ------------------------
        /// <summary>
        ///   Returns the part within an XPS document
        ///   for storing user annotations.</summary>
        /// <param name="documentUri">
        ///   The URI of the FixedDocumentSequence
        ///   within the package to annotate.</param>
        /// <returns>
        ///   The package part containing existing user annotations
        ///   and for storing new annotations.</returns>
        /// <remarks>
        ///   If the document package does not as yet contain an annotations
        ///   part, a new empty one is created and returned.</remarks>
        private PackagePart GetAnnotationPart(Uri documentUri)
        {
            // Open the document package.
            Package package = PackageStore.GetPackage(_packageUri);
            if (package == null)
            {
                throw new InvalidOperationException(
                    "The document package '" + _packageUri + "' does not exist.");
            }

            // Get the FixedDocumentSequence part from the package.
            PackagePart docPart = package.GetPart(documentUri);

            // Search through all the document relationships to find the
            // annotations relationship part (or null, of there is none).
            PackageRelationship annotRel = null;
            foreach ( PackageRelationship rel in
                docPart.GetRelationshipsByType(_annotRelsType) )
            {
                annotRel = rel;
            }

            // If annotations relationship does not exist, create a new
            // annotations part along with a relationship part for it.
            PackagePart annotPart = null;
            if (annotRel == null)
            {
                // Create a new Annotations part.
                annotPart = package.CreatePart(PackUriHelper.CreatePartUri(
                    new Uri(_annotFile, UriKind.Relative)), _annotContentType);
                // Create a new relationship that points to the Annotations part.
                docPart.CreateRelationship(
                    annotPart.Uri, TargetMode.Internal, _annotRelsType);
            }

            // If an annotations relationship exists,
            // get the annotations part that it references.
            else // if (annotRel != null)
            {   // Get the Annotations part specified by the relationship.
                annotPart = package.GetPart(annotRel.TargetUri);
                if (annotPart == null)
                {
                    throw new InvalidOperationException(
                        "The Annotations part referenced by the Annotations " +
                        "Relationship TargetURI '" + annotRel.TargetUri +
                        "' could not be found.");
                }
            }

            return annotPart;
        }// end:GetAnnotationPart()


        #region private variables

        // Application's DocumentViewer control.
        private DocumentViewer _docViewer = null;

        // URI path and filename of the document container.
        private Uri _packageUri = null;

        // URI of the document's FixedDocumentSequence part within the package.
        private Uri _rootUri = null;

        // URI of the annotations XML filestore part within the package.
        private string _annotFile = "/Annotations.xml";

        private AnnotationService _annotService = null; // AnnotationService
        private Stream _annotStream = null;             // Annotation IO stream

        // Annotations Relationship part type
        private readonly string _annotRelsType =
            "http://schemas.microsoft.com/xps/2005/06/annotations";

        // Annotations Content part type
        private readonly string _annotContentType =
            "application/vnd.ms-package.annotations+xml";

        #endregion // private variables

    }// end:class AnnotationsHelperXps

}// end:namespace SDKSample
