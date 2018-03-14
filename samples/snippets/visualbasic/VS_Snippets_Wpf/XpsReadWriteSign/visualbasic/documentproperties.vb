Imports System
Imports System.Windows.Xps.Packaging
Imports System.Windows.Forms

Namespace SDKSample
	''' <summary>
	'''   Provides utility functions for copying property values to
	'''   and from a properties dialog and an XPS document.</summary>
	Public Class PropertiesUtility
		' -------------------------- WriteProperties -------------------------
		''' <summary>
		'''   Copies the text values from a given properties
		'''   dialog to a specified document's properties.</summary>
		''' <param name="xpsDocument">
		'''   The document to copy the property values to.</param>
		''' <param name="propertiesDialog">
		'''   The dialog to copy the property values from.</param>
		Public Sub WriteProperties(ByVal xpsDocument As XpsDocument, ByVal propertiesDialog As PropertiesDialog)
			xpsDocument.CoreDocumentProperties.Creator = propertiesDialog.Creator.Text

			xpsDocument.CoreDocumentProperties.Description = propertiesDialog.Description.Text

			xpsDocument.CoreDocumentProperties.Identifier = propertiesDialog.Identifier.Text

			xpsDocument.CoreDocumentProperties.Keywords = propertiesDialog.Keywords.Text

			xpsDocument.CoreDocumentProperties.Title = propertiesDialog.Title.Text

			xpsDocument.CoreDocumentProperties.Subject = propertiesDialog.Subject.Text

			xpsDocument.CoreDocumentProperties.Language = propertiesDialog.Language.Text

			xpsDocument.CoreDocumentProperties.ContentType = propertiesDialog.ContentType.Text

			xpsDocument.CoreDocumentProperties.Category = propertiesDialog.Category.Text

		End Sub ' end:WriteProperties()

		' -------------------------- ReadProperties --------------------------
		''' <summary>
		'''   Copies the text properties of a given
		'''   document to a properties dialog.
		''' </summary>
		''' <param name="xpsDocument">
		'''   The document to copy the properties from.</param>
		''' <param name="propertiesDialog">
		'''   The dialog to copy the properties to.</param>
		Public Sub ReadProperties(ByVal xpsDocument As XpsDocument, ByVal propertiesDialog As PropertiesDialog)
			propertiesDialog.Creator.Text = xpsDocument.CoreDocumentProperties.Creator

			propertiesDialog.Description.Text = xpsDocument.CoreDocumentProperties.Description

			propertiesDialog.Identifier.Text = xpsDocument.CoreDocumentProperties.Identifier

			propertiesDialog.Keywords.Text = xpsDocument.CoreDocumentProperties.Keywords

			propertiesDialog.Title.Text = xpsDocument.CoreDocumentProperties.Title

			propertiesDialog.Subject.Text = xpsDocument.CoreDocumentProperties.Subject

			propertiesDialog.Language.Text = xpsDocument.CoreDocumentProperties.Language

			propertiesDialog.ContentType.Text = xpsDocument.CoreDocumentProperties.ContentType
			propertiesDialog.Category.Text = xpsDocument.CoreDocumentProperties.Category
		End Sub ' end:ReadProperties()

	End Class ' end:class PropertiesUtility

End Namespace ' end:namespace
