#If _MyType <> "Empty" Then

Namespace My
    ''' <summary>
    ''' Module used to define the properties that are available in the My Namespace for Web projects.
    ''' </summary>
    ''' <remarks></remarks>
    <Global.Microsoft.VisualBasic.HideModuleName()> _
    Module MyWebExtension
        Private s_Computer As New ThreadSafeObjectProvider(Of Global.Microsoft.VisualBasic.Devices.ServerComputer)
        Private s_User As New ThreadSafeObjectProvider(Of Global.Microsoft.VisualBasic.ApplicationServices.WebUser)
        Private s_Log As New ThreadSafeObjectProvider(Of Global.Microsoft.VisualBasic.Logging.AspLog)
        Private s_Application As New ThreadSafeObjectProvider(Of MyApplication)

        ''' <summary>
        ''' Returns information about the current application.
        ''' </summary>
        <Global.System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")> _
        Friend ReadOnly Property Application() As MyApplication
            Get
                Return s_Application.GetInstance()
            End Get
        End Property

        ''' <summary>
        ''' Returns information about the host computer.
        ''' </summary>
        <Global.System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")> _
        Friend ReadOnly Property Computer() As Global.Microsoft.VisualBasic.Devices.ServerComputer
            Get
                Return s_Computer.GetInstance()
            End Get
        End Property
        ''' <summary>
        ''' Returns information for the current Web user.
        ''' </summary>
        <Global.System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")> _
        Friend ReadOnly Property User() As Global.Microsoft.VisualBasic.ApplicationServices.WebUser
            Get
                Return s_User.GetInstance()
            End Get
        End Property
        ''' <summary>
        ''' Returns Request object.
        ''' </summary>
        <Global.System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")> _
        <Global.System.ComponentModel.Design.HelpKeyword("My.Request")> _
        Friend ReadOnly Property Request() As Global.System.Web.HttpRequest
            <Global.System.Diagnostics.DebuggerHidden()> _
            Get
                Dim CurrentContext As Global.System.Web.HttpContext = Global.System.Web.HttpContext.Current
                If CurrentContext IsNot Nothing Then
                    Return CurrentContext.Request
                End If
                Return Nothing
            End Get
        End Property
        ''' <summary>
        ''' Returns Response object.
        ''' </summary>
        <Global.System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")> _
         <Global.System.ComponentModel.Design.HelpKeyword("My.Response")> _
         Friend ReadOnly Property Response() As Global.System.Web.HttpResponse
            <Global.System.Diagnostics.DebuggerHidden()> _
            Get
                Dim CurrentContext As Global.System.Web.HttpContext = Global.System.Web.HttpContext.Current
                If CurrentContext IsNot Nothing Then
                    Return CurrentContext.Response
                End If
                Return Nothing
            End Get
        End Property
        ''' <summary>
        ''' Returns the Asp log object.
        ''' </summary>
        <Global.System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")> _
        Friend ReadOnly Property Log() As Global.Microsoft.VisualBasic.Logging.AspLog
            <Global.System.Diagnostics.DebuggerHidden()> _
            Get
                Return s_Log.GetInstance()
            End Get
        End Property

        ''' <summary>
        ''' Provides access to WebServices added to this project.
        ''' </summary>
        <Global.System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")> _
        <Global.System.ComponentModel.Design.HelpKeyword("My.WebServices")> _
        Friend ReadOnly Property WebServices() As MyWebServices
            <Global.System.Diagnostics.DebuggerHidden()> _
            Get
                Return m_MyWebServicesObjectProvider.GetInstance()
            End Get
        End Property

        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Never)> _
        <Global.Microsoft.VisualBasic.MyGroupCollection("System.Web.Services.Protocols.SoapHttpClientProtocol", "Create__Instance__", "Dispose__Instance__", "")> _
        <Global.System.Runtime.CompilerServices.CompilerGenerated()> _
        Friend NotInheritable Class MyWebServices

            <Global.System.ComponentModel.EditorBrowsable(Global.System.ComponentModel.EditorBrowsableState.Never), Global.System.Diagnostics.DebuggerHidden()> _
            Public Overrides Function Equals(ByVal o As Object) As Boolean
                Return MyBase.Equals(o)
            End Function
            <Global.System.ComponentModel.EditorBrowsable(Global.System.ComponentModel.EditorBrowsableState.Never), Global.System.Diagnostics.DebuggerHidden()> _
            Public Overrides Function GetHashCode() As Integer
                Return MyBase.GetHashCode
            End Function
            <Global.System.ComponentModel.EditorBrowsable(Global.System.ComponentModel.EditorBrowsableState.Never), Global.System.Diagnostics.DebuggerHidden()> _
            Friend Overloads Function [GetType]() As Global.System.Type
                Return GetType(MyWebServices)
            End Function
            <Global.System.ComponentModel.EditorBrowsable(Global.System.ComponentModel.EditorBrowsableState.Never), Global.System.Diagnostics.DebuggerHidden()> _
            Public Overrides Function ToString() As String
                Return MyBase.ToString
            End Function

            <Global.System.Diagnostics.DebuggerHidden()> _
            Private Shared Function Create__Instance__(Of T As {New})(ByVal instance As T) As T
                If instance Is Nothing Then
                    Return New T()
                Else
                    Return instance
                End If
            End Function

            <Global.System.Diagnostics.DebuggerHidden()> _
            Private Sub Dispose__Instance__(Of T)(ByRef instance As T)
                instance = Nothing
            End Sub

            <Global.System.Diagnostics.DebuggerHidden()> _
            <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Never)> _
            Public Sub New()
                MyBase.New()
            End Sub
        End Class

        <Global.System.Runtime.CompilerServices.CompilerGenerated()> Private ReadOnly m_MyWebServicesObjectProvider As New ThreadSafeObjectProvider(Of MyWebServices)
    End Module

    <Global.System.Runtime.CompilerServices.CompilerGenerated(), Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Never)> Partial Friend Class MyApplication
        Inherits Global.Microsoft.VisualBasic.ApplicationServices.ApplicationBase
    End Class

End Namespace

#End If