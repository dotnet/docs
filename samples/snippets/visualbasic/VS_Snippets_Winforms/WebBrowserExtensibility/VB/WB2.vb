'<snippet00>
Imports System
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports System.Security.Permissions

Namespace WebBrowserExtensibility

    <PermissionSetAttribute(SecurityAction.Demand, Name:="FullTrust")> _
    Public Class Form1
        Inherits Form

        <STAThreadAttribute()> Public Shared Sub Main()
            Application.Run(New Form1())
        End Sub

        Private WithEvents wb As New WebBrowser2()

        Public Sub New()

            wb.Dock = DockStyle.Fill
            Controls.Add(wb)

            ' Attempt to navigate to an invalid address.
            wb.Navigate("www.widgets.microsoft.com")

        End Sub

        Private Sub wb_NavigateError( _
            ByVal sender As Object, _
            ByVal e As WebBrowserNavigateErrorEventArgs) _
            Handles wb.NavigateError

            ' Display an error message to the user.
            MessageBox.Show("Cannot navigate to " + e.Url)

        End Sub

    End Class

    Public Class WebBrowser2
        Inherits WebBrowser

        '<snippet10>
        Private cookie As AxHost.ConnectionPointCookie
        Private helper As WebBrowser2EventHelper

        <PermissionSetAttribute(SecurityAction.LinkDemand, _
        Name := "FullTrust")> Protected Overrides Sub CreateSink()

            MyBase.CreateSink()

            ' Create an instance of the client that will handle the event
            ' and associate it with the underlying ActiveX control.
            helper = New WebBrowser2EventHelper(Me)
            cookie = New AxHost.ConnectionPointCookie( _
                Me.ActiveXInstance, helper, GetType(DWebBrowserEvents2))
        End Sub

        <PermissionSetAttribute(SecurityAction.LinkDemand, _
        Name := "FullTrust")> Protected Overrides Sub DetachSink()

            ' Disconnect the client that handles the event
            ' from the underlying ActiveX control.
            If cookie IsNot Nothing Then
                cookie.Disconnect()
                cookie = Nothing
            End If
            MyBase.DetachSink()

        End Sub
        '</snippet10>

        Public Event NavigateError As WebBrowserNavigateErrorEventHandler

        ' Raises the NavigateError event.
        Protected Overridable Sub OnNavigateError( _
            ByVal e As WebBrowserNavigateErrorEventArgs)

            RaiseEvent NavigateError(Me, e)

        End Sub

        ' Handles the NavigateError event from the underlying ActiveX 
        ' control by raising the NavigateError event defined in this class.
        Private Class WebBrowser2EventHelper
            Inherits StandardOleMarshalObject
            Implements DWebBrowserEvents2

            Private parent As WebBrowser2

            Public Sub New(ByVal parent As WebBrowser2)
                Me.parent = parent
            End Sub

            Public Sub NavigateError(ByVal pDisp As Object, _
                ByRef URL As Object, ByRef frame As Object, _
                ByRef statusCode As Object, ByRef cancel As Boolean) _
                Implements DWebBrowserEvents2.NavigateError

                ' Raise the NavigateError event.
                Me.parent.OnNavigateError( _
                    New WebBrowserNavigateErrorEventArgs( _
                    CStr(URL), CStr(frame), CInt(statusCode), cancel))

            End Sub

        End Class

    End Class

    ' Represents the method that will handle the WebBrowser2.NavigateError event.
    Public Delegate Sub WebBrowserNavigateErrorEventHandler(ByVal sender As Object, _
        ByVal e As WebBrowserNavigateErrorEventArgs)

    ' Provides data for the WebBrowser2.NavigateError event.
    Public Class WebBrowserNavigateErrorEventArgs
        Inherits EventArgs

        Private urlValue As String
        Private frameValue As String
        Private statusCodeValue As Int32
        Private cancelValue As Boolean

        Public Sub New( _
            ByVal url As String, ByVal frame As String, _
            ByVal statusCode As Int32, ByVal cancel As Boolean)

            Me.urlValue = url
            Me.frameValue = frame
            Me.statusCodeValue = statusCode
            Me.cancelValue = cancel

        End Sub

        Public Property Url() As String
            Get
                Return urlValue
            End Get
            Set(ByVal value As String)
                urlValue = value
            End Set
        End Property

        Public Property Frame() As String
            Get
                Return frameValue
            End Get
            Set(ByVal value As String)
                frameValue = value
            End Set
        End Property

        Public Property StatusCode() As Int32
            Get
                Return statusCodeValue
            End Get
            Set(ByVal value As Int32)
                statusCodeValue = value
            End Set
        End Property

        Public Property Cancel() As Boolean
            Get
                Return cancelValue
            End Get
            Set(ByVal value As Boolean)
                cancelValue = value
            End Set
        End Property

    End Class

    ' Imports the NavigateError method from the OLE DWebBrowserEvents2 
    ' interface. 
    <ComImport(), Guid("34A715A0-6587-11D0-924A-0020AFC7AC4D"), _
    InterfaceType(ComInterfaceType.InterfaceIsIDispatch), _
    TypeLibType(TypeLibTypeFlags.FHidden)> _
    Public Interface DWebBrowserEvents2

        <DispId(271)> Sub NavigateError( _
            <InAttribute(), MarshalAs(UnmanagedType.IDispatch)> _
            ByVal pDisp As Object, _
            <InAttribute()> ByRef URL As Object, _
            <InAttribute()> ByRef frame As Object, _
            <InAttribute()> ByRef statusCode As Object, _
            <InAttribute(), OutAttribute()> ByRef cancel As Boolean)

    End Interface

End Namespace
'</snippet00>