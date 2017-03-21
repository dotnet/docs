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
Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates


Namespace SDKSample
	''' <summary>
	''' Dialog for displaying Signatures and Signature Definitions associated
	''' with an XpsDocument
	''' </summary>

	Partial Public Class SignatureDialog
		Inherits Window
		#Region "Constructor"
		Public Sub New(ByVal document As XpsDocument)
			MyBase.New()
			_xpsDocument = document
			InitializeComponent()
			AddHandler SignatureDef.Click, AddressOf SignatureDefinitionCommandHandler
			AddHandler Sign.Click, AddressOf SignCommandHandler
			AddHandler Done.Click, AddressOf DoneCommandHandler
			_signatureUtilities = New SignatureUtilites()
			InitializeSignatureDisplay()

		End Sub
		#End Region
		#Region "Public Methods"
		Public Function AddSignatureItem(ByVal signatureDefintion As XpsSignatureDefinition) As SignatureDisplayItem
			Dim item As New SignatureDisplayItem()
			If signatureDefintion IsNot Nothing Then
				item.Request = signatureDefintion.RequestedSigner
				item.Intent = signatureDefintion.Intent
				item.SignBy = signatureDefintion.SignBy.ToString()
				item.Location = signatureDefintion.SigningLocale
				item.SigId = signatureDefintion.SpotId
			End If
			Me.SignatureList.Items.Add(item)
			Return item
		End Function
		#End Region
		#Region "Private Methods"
		Private Sub InitializeSignatureDisplay()
			Me.SignatureList.Items.Clear()
			Me.SignatureList.Items.Add(SignatureHeader)
			_signatureUtilities.IterateSignatureDefinitions(Me, _xpsDocument)
			_signatureUtilities.IterateSignatures(Me, _xpsDocument)
		End Sub

		Private Sub SignCommandHandler(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim item As SignatureDisplayItem = TryCast(SignatureList.SelectedItem, SignatureDisplayItem)
			If item IsNot Nothing AndAlso item.IsSigned Then
				System.Windows.MessageBox.Show("This definition is already signed.")
				Return
			End If
			Dim cert As X509Certificate = PromptForSignature()
			If cert IsNot Nothing Then
				Dim spotID? As Guid = Nothing
				If item IsNot Nothing Then
					spotID = item.SigId
				End If
				_signatureUtilities.SignXps(_xpsDocument, cert, spotID)
				InitializeSignatureDisplay()
			End If

		End Sub

		'<SnippetSignatureDefinitionCommandHandler>

		Private Sub SignatureDefinitionCommandHandler(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim sigDefDialog As New SignatureDefinition()
			If sigDefDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
				Dim signatureDefinition As New XpsSignatureDefinition()
				signatureDefinition.RequestedSigner = sigDefDialog.RequestedSigner.Text
				signatureDefinition.Intent = sigDefDialog.Intent.Text
				signatureDefinition.SigningLocale = sigDefDialog.SigningLocale.Text
				Try
					signatureDefinition.SignBy = Date.Parse(sigDefDialog.SignBy.Text)
				Catch e1 As FormatException
				End Try
				signatureDefinition.SpotId = Guid.NewGuid()
				Dim docSeq As IXpsFixedDocumentSequenceReader = _xpsDocument.FixedDocumentSequenceReader '_xpsDocument is type System.Windows.Xps.Packaging.XpsDocument
				Dim doc As IXpsFixedDocumentReader = docSeq.FixedDocuments(0)
				doc.AddSignatureDefinition(signatureDefinition)
				doc.CommitSignatureDefinition()
				InitializeSignatureDisplay()
			End If
		End Sub

		'</SnippetSignatureDefinitionCommandHandler>

		Private Sub DoneCommandHandler(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Close()
		End Sub

		Private Shared Function PromptForSignature() As X509Certificate
			Dim x509cert As X509Certificate2 = Nothing

			' look for appropriate certificates
			Dim store As New X509Store(StoreLocation.CurrentUser)
			Dim collection As X509Certificate2Collection = Nothing

			store.Open(OpenFlags.OpenExistingOnly Or OpenFlags.ReadOnly)
			collection = CType(store.Certificates, X509Certificate2Collection)

			' narrow down the choices
			' timevalid
			collection = collection.Find(X509FindType.FindByTimeValid, Date.Now, True) 'validOnly

			' intended for signing (or no intent specified)
			collection = collection.Find(X509FindType.FindByKeyUsage, X509KeyUsageFlags.DigitalSignature, False) 'validOnly

			' remove certs that don't have private key
			' work backward so we don't disturb the enumeration
			For i As Integer = collection.Count - 1 To 0 Step -1
				If Not collection(i).HasPrivateKey Then
					collection.RemoveAt(i)
				End If
			Next i

			' any suitable certificates available?
			If collection.Count > 0 Then
				' ask user to select
				collection = X509Certificate2UI.SelectFromCollection(collection, "Select Certificate", "Select Certificate", X509SelectionFlag.SingleSelection)
				If collection.Count > 0 Then
					x509cert = collection(0) ' return the first one
				End If
			End If
			Return x509cert
		End Function
		#End Region ' Private Methods
		#Region "Private Members"
		Private _signatureUtilities As SignatureUtilites
		Private _xpsDocument As XpsDocument
		#End Region

	End Class
	''' <summary>
	''' A control that diplays information on a Signature Definition and associated signature
	''' </summary>
	Public Class SignatureDisplayItem
		Inherits StackPanel

		#Region "Constructor"
		Public Sub New()
			MyBase.New()
			Me.Orientation = System.Windows.Controls.Orientation.Horizontal
            _requestBlock = New TextBlock()
            _requestBlock.Width = 100
            Me.Children.Add(_requestBlock)

            _signerBlock = New TextBlock()
            _signerBlock.Width = 100
            Me.Children.Add(_signerBlock)

            _intentBlock = New TextBlock()
            _intentBlock.Width = 100
            Me.Children.Add(_intentBlock)

            _locationBlock = New TextBlock()
            _locationBlock.Width = 100
            Me.Children.Add(_locationBlock)

            _signByBlock = New TextBlock()
            _signByBlock.Width = 50
            Me.Children.Add(_signByBlock)
        End Sub
#End Region
#Region "Public Properties"
        Public Property Request() As String
            Get
                Return _requestBlock.Text
            End Get
            Set(ByVal value As String)
                _requestBlock.Text = value
            End Set
        End Property

        Public Property Signer() As String
            Get
                Return _signerBlock.Text
            End Get
            Set(ByVal value As String)
                _signerBlock.Text = value
            End Set
        End Property

        Public Property Intent() As String
            Get
                Return _intentBlock.Text
            End Get
            Set(ByVal value As String)
                _intentBlock.Text = value
            End Set
        End Property

        Public Property Location() As String
            Get
                Return _locationBlock.Text
            End Get
            Set(ByVal value As String)
                _locationBlock.Text = value
            End Set
        End Property
        Public Property SignBy() As String
            Get
                Return _signByBlock.Text
            End Get
            Set(ByVal value As String)
                _signByBlock.Text = value
            End Set
        End Property

        Public Property SigId() As Guid?
            Get
                Return _sigId
            End Get
            Set(ByVal value? As Guid)
                _sigId = value
            End Set
        End Property

        Public Property IsSigned() As Boolean
            Get
                Return _isSigned
            End Get
            Set(ByVal value As Boolean)
                _isSigned = value
            End Set
        End Property

#End Region ' Public Properties
#Region "Private Members"
        Private _sigId As Guid?
        Private _requestBlock As TextBlock
        Private _signerBlock As TextBlock
        Private _intentBlock As TextBlock
        Private _locationBlock As TextBlock
        Private _signByBlock As TextBlock
        Private _isSigned As Boolean
#End Region ' PrivateMembers
	End Class

End Namespace