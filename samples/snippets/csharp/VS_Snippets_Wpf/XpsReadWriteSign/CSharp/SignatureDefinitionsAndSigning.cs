using System;
using System.Windows;
using System.Windows.Xps.Packaging;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;


namespace SDKSample
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public class SignatureUtilites
    {

		//<SnippetIterateSignatureDefinitions>

        // -------------------- IterateSignatureDefinitions --------------------
        /// <summary>
        ///   Interates through the SignatureDefinition contained in a given
        ///   XPS document displaying and updating the signature properties
        ///   through a user dialog.</summary>
        /// <param name="signatureDialog">
        ///   The user dialog to use in displaying and
        ///   updating the signature information.</param>
        /// <param name="xpsDocument">
        ///   The XPS document containing the signature information.</param>
        public void IterateSignatureDefinitions(
            SignatureDialog signatureDialog, XpsDocument xpsDocument )
        {
            IXpsFixedDocumentSequenceReader docSeq =
                xpsDocument.FixedDocumentSequenceReader;

            // For every FixedDocument in the XPS document.
            foreach (IXpsFixedDocumentReader doc in docSeq.FixedDocuments)
            {
                // For every SignatureDefinition in each FixedDocument.
                foreach (XpsSignatureDefinition signature in
                         doc.SignatureDefinitions)
                {
                    SignatureDisplayItem item =
                        signatureDialog.AddSignatureItem(signature);

                    // Signatures are bound to signature definitions by GUID.
                    // If the SignatureDefintion SpotId is the same as the
                    // SignatureId, the signature is signing that definition.

                    // For every signature in the XPS document.
                    foreach (XpsDigitalSignature sig in xpsDocument.Signatures)
                    {
                        if (sig.Id != null && sig.Id == signature.SpotId)
                        {
                            X509Certificate2 cert =
                                sig.SignerCertificate as X509Certificate2;
                            item.Signer =
                                cert.GetNameInfo(X509NameType.SimpleName, false);
                            item.IsSigned = true;
                        }
                    }// end:foreach (XpsDigitalSignature

                }// end:foreach (XpsSignatureDefinition

            }// end:foreach (IXpsFixedDocumentReader

        }// end:IterateSignatureDefinitions()

		//</SnippetIterateSignatureDefinitions>

        // ------------------------- IterateSignatures ------------------------
        /// <summary>
        ///   Interates through signatures that are not associated with
        ///   a SignatureDefinition.</summary>
        /// <param name="signatureDialog">
        ///   The user dialog to use in displaying and
        ///   updating the signature information.</param>
        /// <param name="xpsDocument">
        ///   The XPS document containing the signature information.</param>
        public void IterateSignatures(
            SignatureDialog signatureDialog, XpsDocument xpsDocument)
        {
            bool found = false;
            IXpsFixedDocumentSequenceReader docSeq =
                xpsDocument.FixedDocumentSequenceReader;

            // For every signature in the XPS document.
            foreach (XpsDigitalSignature sig in xpsDocument.Signatures)
            {
                found = false;

                // For every FixedDocument in the XPS document.
                foreach (IXpsFixedDocumentReader doc in docSeq.FixedDocuments)
                {
                    // For every SignatureDefinition in each FixedDocument.
                    foreach (XpsSignatureDefinition signature in
                        doc.SignatureDefinitions)
                    {
                        if (sig.Id!= null && sig.Id == signature.SpotId)
                        {
                            found = true;
                            break;
                        }
                    }//end:foreach (XpsSignatureDefinition

                    if (found)
                        break;
                }// end:foreach (IXpsFixedDocument

                if (!found)
                {
                    SignatureDisplayItem item =
                        signatureDialog.AddSignatureItem(null);
                    X509Certificate2 cert =
                        sig.SignerCertificate as X509Certificate2;
                    item.Signer =
                        cert.GetNameInfo(X509NameType.SimpleName, false);
                    item.IsSigned = true;
                }
            }// end:foreach (XpsDigitalSignature

        }// end:IterateSignatures()


        //<SnippetSignXpsDocument>

        // ------------------------------ SignXps -----------------------------
        /// <summary>
        ///   Signs an XPS document with a given X509 certificate, and if one
        ///   exists, associates the signature with a given SignatureDefintion
        ///   spotId GUID.</summary>
        /// <param name="xpsDocument">
        ///   The XPS document to sign.</param>
        /// <param name="cert">
        ///   The X509 certificate to use for signing.</param>
        /// <param name="spotId">
        ///   The nullable spotId GUID of the signature definition.</param>
        public void SignXps(
            XpsDocument xpsDocument, X509Certificate cert, Guid? spotId )
        {
            // If there's a SignatureDefinition spotId,
            // associate it with the signature.
            if (spotId != null)
            {
                xpsDocument.SignDigitally(
                    cert, true, XpsDigSigPartAlteringRestrictions.None,
                    spotId.Value);
            }
            else
            {
                xpsDocument.SignDigitally(
                    cert, true, XpsDigSigPartAlteringRestrictions.None);
            }

        }// end:SignXps()

        //</SnippetSignXpsDocument>

    }// end:class SignatureUtilites

}// end:namespace
