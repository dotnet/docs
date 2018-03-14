Imports System
Imports System.Windows
Imports System.Windows.Forms
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Shapes
Imports System.Windows.Input
Imports System.Windows.Xps.Packaging
Imports System.Security.Cryptography.X509Certificates
Imports System.Xml
Imports System.IO
Imports System.Collections.Generic


Namespace SDKSample
	' ----------------------------- Class Window1 ----------------------------
	''' <summary>
	'''   Demonstrates the use of the XPS Packaging APIs.</summary>
	''' <remarks>
	'''   <rem>File|New - demonstrates how to create an XPS document
	'''     from scratch.</rem>
	'''   <rem>File|Open - Demonstrates opening an XPS document
	'''     with a DocumentViewer.</rem>
	'''   <rem>File|Outline - Demonstrates interating through the parts of
	'''     of an XpsDocument.</rem>
	'''   <rem>File|Properties - Demonstrates viewing and editing the
	'''     properties of an XpsDocument.</rem>
	'''   <rem>File|Sign - Demonstrates viewing XPS document digital signature
	'''     definitions and how to digitally sign an XpsDocument.</rem>
	''' </remarks>
	Partial Public Class Window1
		Inherits Window
		#Region "Constructors"
		Public Sub New()
			MyBase.New()

			InitializeComponent()

			'
			'This utility has helper methods that demonstrate creating the XpsDocument
			'and iterating its parts
			'
			_xpsReadWriteUtility = New XpsReadWriteUtility(Directory.GetCurrentDirectory())

			'
			'The following commands are manually created and bound to menu items
			'New, Open and Properties are predefined command types
			'

			'Create Sign Command
			SignCommand = New RoutedCommand("Sign",GetType(Window1))
			SigMenuItem.Command = SignCommand

			'Create Outline Command
			OutlineCommand = New RoutedCommand("Outline", GetType(Window1))
			OutlineMenuItem.Command = OutlineCommand

			'Create Outline Command
			ThumbnailCommand = New RoutedCommand("Thumbnail", GetType(Window1))
			ThumbnailItem.Command = ThumbnailCommand

			' Add the New Command
            AddCommandBindings(ApplicationCommands.[New], AddressOf NewCommandHandler)
			' Add the Open Command
			AddCommandBindings(ApplicationCommands.Open, AddressOf OpenCommandHandler)
			' Add the Outline Command
			AddCommandBindings(OutlineCommand, AddressOf OutlineCommandHandler)
			' Add the Properties Command
			AddCommandBindings(ApplicationCommands.Properties, AddressOf ProportiesCommandHandler)
			' Add the Signatures Command
			AddCommandBindings(SignCommand, AddressOf SignatureCommandHandler)
			' Add the Thumbnail Command
			AddCommandBindings(ThumbnailCommand, AddressOf ThumbnailCommandHandler)
			' Add the Close Command
			AddCommandBindings(ApplicationCommands.Close, AddressOf CloseCommandHandler)


		End Sub
		#End Region

		#Region "Private Methods"
		' ----------------------- OpenCommandHandler -------------------------
		''' <summary>
		'''   Opens an existing XPS document and displays
		'''   it with a DocumentViewer./// </summary>
		''' <param name="sender"></param>
		''' <param name="e"></param>
		Private Sub OpenCommandHandler(ByVal sender As Object, ByVal e As ExecutedRoutedEventArgs)
			'Display a file open dialog to find and existing document
			Dim dlg As New OpenFileDialog()
			dlg.Filter = "Xps Documents (*.xps)|*.xps"
			dlg.FilterIndex = 1
			If dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
				If _xpsDocument IsNot Nothing Then
					_xpsDocument.Close()
				End If
				Try
					_xpsDocument = New XpsDocument(dlg.FileName, System.IO.FileAccess.ReadWrite)
				Catch e1 As UnauthorizedAccessException
					System.Windows.MessageBox.Show(String.Format("Unable to access {0}", dlg.FileName))
					Return
				End Try
				' For optimal performance the XPS document should be remain
				' open while its FixedDocumentSequence is active in the
				' DocumentViewer control.  When the XPS document is opened
				' with the XpsDocument constructor ("new" above) a reference
				' to it is automatically added to the PackageStore.  The
				' PackStore is a static application collection that contains a
				' reference to each open package along the package's URI as a
				' key.  Adding a reference of the XPS package to the
				' PackageStore keeps the package open and avoids repeated opens
				' and closes while the document content is actively being
				' processed by the DocumentViewer control.  The XpsDocument
				' Dispose() method automatically removes the package from the
				' PackageStore after the document is removed from the
				' DocumentViewer control and is no longer in use.
				docViewer.Document = _xpsDocument.GetFixedDocumentSequence()
				_fileName = dlg.FileName
			End If
			EnableMenuItems()
		End Sub ' end:OpenCommandHandler()


		' ----------------------- OutlineCommandHandler ----------------------
		''' <summary>
		'''   Iterates through the parts of an XpsDocument initializing
		'''   a tree view control with the names of its parts.</summary>
		''' <param name="sender"></param>
		''' <param name="e"></param>
		Private Sub OutlineCommandHandler(ByVal sender As Object, ByVal e As ExecutedRoutedEventArgs)
			If _xpsDocument IsNot Nothing Then
				_xpsReadWriteUtility.IterateXpsPackageParts(_xpsDocument, treeView, _fileName)
			End If
		End Sub ' end:OutlineCommandHandler()


		' ---------------------- SignatureCommandHandler ---------------------
		''' <summary>
		'''   Displays a dialog showing the current digital signatures and
		'''   signature definitions.  A button on the dialog allows additional
		'''   signatures to be added.</summary>
		''' <param name="sender"></param>
		''' <param name="e"></param>
		Private Sub SignatureCommandHandler(ByVal sender As Object, ByVal e As ExecutedRoutedEventArgs)
			If _fileName IsNot Nothing Then
				Dim signatureDialog As New SignatureDialog(_xpsDocument)
				signatureDialog.ShowDialog()

				' Close to flush the new signature definition, then reopen.
				_xpsDocument.Close()
				_xpsDocument = New XpsDocument(_fileName, FileAccess.ReadWrite)
			End If
		End Sub ' end:SignatureCommandHandler()

		' ---------------------- ThumbnailCommandHandler ---------------------
		''' <summary>
		'''   Displays a dialog showing the current thumbnail.  A button on the dialog creates a
		'''   thumbnail add adds it.</summary>
		''' <param name="sender"></param>
		''' <param name="e"></param>
		Private Sub ThumbnailCommandHandler(ByVal sender As Object, ByVal e As ExecutedRoutedEventArgs)
			If _fileName IsNot Nothing Then
				Dim thumnailDialog As New ThumnailDialog(_xpsDocument)
				thumnailDialog.ShowDialog()

				' Close and re-open the document in case a new thumbnail was added.
				_xpsDocument.Close()
				_xpsDocument = New XpsDocument(_fileName, FileAccess.ReadWrite)
			End If
		End Sub ' end:ThumbnailCommandHandler()

		' ------------------------- NewCommandHandler ------------------------
		''' <summary>
		'''   Prompts the user for a new XPS document file name, creates the
		'''   new document, fills the document with a preset block of content,
		'''   and then sets the new document as the current document.</summary>
		''' <param name="sender"></param>
		''' <param name="e"></param>
		Private Sub NewCommandHandler(ByVal sender As Object, ByVal e As ExecutedRoutedEventArgs)
			' Prompt the user for new file to be saved
			Dim saveDlg As New SaveFileDialog()
			saveDlg.Title = "New Xps Document"
			saveDlg.Filter = "Xps Documents (*.xps)|*.xps"
			saveDlg.FilterIndex = 1
			saveDlg.DefaultExt = "*.xps"
			If saveDlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
				If _xpsDocument IsNot Nothing Then
					_xpsDocument.Close()
				End If
				Try
					' Open a "Save As" dialog to query the user
					' for where to create the new XPS document.
					If File.Exists(saveDlg.FileName) Then
						File.Delete(saveDlg.FileName)
					End If
					_xpsDocument = New XpsDocument(saveDlg.FileName, System.IO.FileAccess.ReadWrite)
				Catch e1 As UnauthorizedAccessException
					System.Windows.MessageBox.Show(String.Format("Unable to access {0}", saveDlg.FileName))
					Return
				End Try

				' Fill the newly created document.
				_xpsReadWriteUtility.Create(_xpsDocument)

				' Close it to flush the values.
				_xpsDocument.Close()

				' Re-open the document and set as the current document.
				_xpsDocument = New XpsDocument(saveDlg.FileName, System.IO.FileAccess.ReadWrite)
				docViewer.Document = _xpsDocument.GetFixedDocumentSequence()
				 _fileName = saveDlg.FileName
			End If ' end:if (saveDlg.ShowDialog() == DialogResult.OK)

			EnableMenuItems()
		End Sub ' end:NewCommandHandler()


		' ---------------------- ProportiesCommandHandler --------------------
		''' <summary>
		'''   File|Properties handler - Opens a dialog to display the
		'''   document properties and allows them to be edited.</summary>
		''' <param name="sender"></param>
		''' <param name="e"></param>
		Private Sub ProportiesCommandHandler(ByVal sender As Object, ByVal e As ExecutedRoutedEventArgs)
			Dim properties As New PropertiesDialog(_xpsDocument)
			properties.ShowDialog()
		End Sub ' end:ProportiesCommandHandler()


		' ------------------------ CloseCommandHandler -----------------------
		''' <summary>
		'''   File|Close handler - Closes current XPS document.</summary>
		''' <param name="sender"></param>
		''' <param name="e"></param>
		Private Sub CloseCommandHandler(ByVal sender As Object, ByVal e As ExecutedRoutedEventArgs)
			Me.Close()
			EnableMenuItems()
		End Sub ' end:CloseCommandHandler()


		' ------------------------ AddCommandBindings ------------------------
		''' <summary>
		'''     Registers menu commands (helper method).</summary>
		''' <param name="command"></param>
		''' <param name="handler"></param>
		Private Sub AddCommandBindings(ByVal command As ICommand, ByVal handler As ExecutedRoutedEventHandler)
			Dim cmdBindings As New CommandBinding(command)
			AddHandler cmdBindings.Executed, handler
			CommandBindings.Add(cmdBindings)
		End Sub ' end:AddCommandBindings()


		' -------------------------- EnableMenuItems -------------------------
		''' <summary>
		'''   Evaluates and sets the menu state.</summary>
		Private Sub EnableMenuItems()
			If _fileName IsNot Nothing Then
				SigMenuItem.IsEnabled = True
				PropMenuItem.IsEnabled = True
				OutlineMenuItem.IsEnabled = True
				ThumbnailItem.IsEnabled = True
			Else
				SigMenuItem.IsEnabled = False
				PropMenuItem.IsEnabled = False
				OutlineMenuItem.IsEnabled = False
				ThumbnailItem.IsEnabled = False
			End If
		End Sub ' end:EnableMenuItems()
		#End Region ' Private Methods

		#Region "Private Members"
		Private _xpsDocument As XpsDocument
		Private _xpsReadWriteUtility As XpsReadWriteUtility
		Private _fileName As String
		Private Shared OutlineCommand As RoutedCommand
		Private Shared SignCommand As RoutedCommand
		Private Shared ThumbnailCommand As RoutedCommand
		#End Region '  Private Members

	End Class ' end:partial class Window1

End Namespace ' end:namespace