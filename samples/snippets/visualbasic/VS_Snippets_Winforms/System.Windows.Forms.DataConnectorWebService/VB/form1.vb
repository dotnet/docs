'<snippet1>
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Namespace BindToWebService
    Class Form1
        Inherits Form

        <STAThread()> _
        Shared Sub Main()
            Application.EnableVisualStyles()
            Application.Run(New Form1())
        End Sub

        Private BindingSource1 As New BindingSource()
        Private textBox1 As New TextBox()
        Private textBox2 As New TextBox()
        Private WithEvents button1 As New Button()

        Public Sub New()

            textBox1.Location = New System.Drawing.Point(118, 131)
            textBox1.ReadOnly = True
            button1.Location = New System.Drawing.Point(133, 60)
            button1.Text = "Get zipcode"
            ClientSize = New System.Drawing.Size(292, 266)
            Controls.Add(Me.button1)
            Controls.Add(Me.textBox1)
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) _
            Handles button1.Click

            textBox1.Text = "Calling Web service.."
            Dim resolver As New ZipCodeResolver()
            BindingSource1.Add(resolver.CorrectedAddressXml("0", "One Microsoft Way", "Redmond", "WA"))

        End Sub


        Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            '<snippet2>
            BindingSource1.DataSource = GetType(USPSAddress)
            '</snippet2>
            '<snippet3>
            textBox1.DataBindings.Add("Text", Me.BindingSource1, "FullZIP", True)
            '</snippet3>
        End Sub

    End Class

    <System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Web.Services.WebServiceBindingAttribute(Name:="ZipCodeResolverSoap", _
        [Namespace]:="http://webservices.eraserver.net/")> _
    Public Class ZipCodeResolver
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol

        Private CorrectedAddressXmlOperationCompleted As _
            System.Threading.SendOrPostCallback


        Public Sub New()
            MyBase.New()
            Me.Url = _
                "http://webservices.eraserver.net/zipcoderesolver/zipcoderesolver.asmx"
        End Sub


        Public Event CorrectedAddressXmlCompleted As _
            CorrectedAddressXmlCompletedEventHandler

        <System.Web.Services.Protocols.SoapDocumentMethodAttribute( _
            "http://webservices.eraserver.net/CorrectedAddressXml", _
            RequestNamespace:="http://webservices.eraserver.net/", _
            ResponseNamespace:="http://webservices.eraserver.net/", _
            Use:=System.Web.Services.Description.SoapBindingUse.Literal, _
            ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)> _
        Public Function CorrectedAddressXml(ByVal accessCode As String, _
            ByVal address As String, ByVal city As String, ByVal state As String) _
            As USPSAddress
            Dim results() As Object = Me.Invoke("CorrectedAddressXml", _
                New Object() {accessCode, address, city, state})
            Return CType(results(0), USPSAddress)
        End Function

        '''<remarks/>
        Public Function BeginCorrectedAddressXml(ByVal accessCode As String, _
            ByVal address As String, ByVal city As String, ByVal state As String, _
            ByVal callback As System.AsyncCallback, ByVal asyncState As Object) _
            As System.IAsyncResult

            Return Me.BeginInvoke("CorrectedAddressXml", _
                New Object() {accessCode, address, city, state}, callback, asyncState)
        End Function

        Public Function EndCorrectedAddressXml(ByVal asyncResult _
            As System.IAsyncResult) As USPSAddress
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0), USPSAddress)
        End Function
    End Class

    '<snippet4>
    <System.SerializableAttribute(), _
     System.Xml.Serialization.XmlTypeAttribute( _
        [Namespace]:="http://webservices.eraserver.net/")> _
    Public Class USPSAddress

        Private streetField As String

        Private cityField As String

        Private stateField As String

        Private shortZIPField As String

        Private fullZIPField As String


        Public Property Street() As String
            Get
                Return Me.streetField
            End Get
            Set(ByVal value As String)
                Me.streetField = value
            End Set
        End Property


        Public Property City() As String
            Get
                Return Me.cityField
            End Get
            Set(ByVal value As String)
                Me.cityField = value
            End Set
        End Property

        Public Property State() As String
            Get
                Return Me.stateField
            End Get
            Set(ByVal value As String)
                Me.stateField = value
            End Set
        End Property


        Public Property ShortZIP() As String
            Get
                Return Me.shortZIPField
            End Get
            Set(ByVal value As String)
                Me.shortZIPField = value
            End Set
        End Property


        Public Property FullZIP() As String
            Get
                Return Me.fullZIPField
            End Get
            Set(ByVal value As String)
                Me.fullZIPField = value
            End Set
        End Property
    End Class
    '</snippet4>

    Public Delegate Sub CorrectedAddressXmlCompletedEventHandler(ByVal sender As Object, _
         ByVal args As CorrectedAddressXmlCompletedEventArgs)

    Public Class CorrectedAddressXmlCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs

        Private results() As Object

        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, _
            ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub

        Public ReadOnly Property Result() As USPSAddress
            Get
                Me.RaiseExceptionIfNecessary()
                Return CType(Me.results(0), USPSAddress)
            End Get
        End Property
    End Class

End Namespace
'</snippet1>
