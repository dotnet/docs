using System;
using System.Windows.Xps.Packaging;
using System.Windows.Forms;

namespace SDKSample
{
    /// <summary>
    ///   Provides utility functions for copying property values to
    ///   and from a properties dialog and an XPS document.</summary>
    public class PropertiesUtility
    {
        // -------------------------- WriteProperties -------------------------
        /// <summary>
        ///   Copies the text values from a given properties
        ///   dialog to a specified document's properties.</summary>
        /// <param name="xpsDocument">
        ///   The document to copy the property values to.</param>
        /// <param name="propertiesDialog">
        ///   The dialog to copy the property values from.</param>
        public void WriteProperties(
            XpsDocument xpsDocument, PropertiesDialog propertiesDialog)
        {
            xpsDocument.CoreDocumentProperties.Creator     = 
                propertiesDialog.Creator.Text;

            xpsDocument.CoreDocumentProperties.Description = 
                propertiesDialog.Description.Text;

            xpsDocument.CoreDocumentProperties.Identifier  = 
                propertiesDialog.Identifier.Text;

            xpsDocument.CoreDocumentProperties.Keywords    = 
                propertiesDialog.Keywords.Text;

            xpsDocument.CoreDocumentProperties.Title       = 
                propertiesDialog.Title.Text;

            xpsDocument.CoreDocumentProperties.Subject     = 
                propertiesDialog.Subject.Text;

            xpsDocument.CoreDocumentProperties.Language    = 
                propertiesDialog.Language.Text;

            xpsDocument.CoreDocumentProperties.ContentType = 
                propertiesDialog.ContentType.Text;

            xpsDocument.CoreDocumentProperties.Category =
                propertiesDialog.Category.Text;

        }// end:WriteProperties()

        // -------------------------- ReadProperties --------------------------
        /// <summary>
        ///   Copies the text properties of a given
        ///   document to a properties dialog.
        /// </summary>
        /// <param name="xpsDocument">
        ///   The document to copy the properties from.</param>
        /// <param name="propertiesDialog">
        ///   The dialog to copy the properties to.</param>
        public void ReadProperties(
            XpsDocument xpsDocument, PropertiesDialog propertiesDialog)
        {
            propertiesDialog.Creator.Text     =
                xpsDocument.CoreDocumentProperties.Creator;

            propertiesDialog.Description.Text =
                xpsDocument.CoreDocumentProperties.Description;

            propertiesDialog.Identifier.Text  =
                xpsDocument.CoreDocumentProperties.Identifier;

            propertiesDialog.Keywords.Text    =
                xpsDocument.CoreDocumentProperties.Keywords;

            propertiesDialog.Title.Text       =
                xpsDocument.CoreDocumentProperties.Title;

            propertiesDialog.Subject.Text     =
                xpsDocument.CoreDocumentProperties.Subject;
            
            propertiesDialog.Language.Text    =
                xpsDocument.CoreDocumentProperties.Language;
            
            propertiesDialog.ContentType.Text =
                xpsDocument.CoreDocumentProperties.ContentType;
            propertiesDialog.Category.Text =
                xpsDocument.CoreDocumentProperties.Category;
        }// end:ReadProperties()

    }// end:class PropertiesUtility

}// end:namespace
