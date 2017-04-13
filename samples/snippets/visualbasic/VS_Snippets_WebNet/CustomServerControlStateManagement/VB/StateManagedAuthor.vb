' <Snippet3>
' StateManagedAuthor.vb
Option Strict On
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Globalization
Imports System.Web.UI

Namespace Samples.AspNet.VB.Controls
    < _
    TypeConverter(GetType(StateManagedAuthorConverter)) _
    > _
    Public Class StateManagedAuthor
        Implements IStateManager
        Private isTrackingViewStateValue As Boolean
        Private viewStateValue As StateBag

        Public Sub New()
            Me.New(String.Empty, String.Empty, String.Empty)
        End Sub

        Public Sub New(ByVal first As String, ByVal last As String)
            Me.New(first, String.Empty, last)
        End Sub

        Public Sub New(ByVal first As String, ByVal middle As String, _
            ByVal last As String)
            FirstName = first
            MiddleName = middle
            LastName = last
        End Sub

        < _
        Category("Behavior"), _
        DefaultValue(""), _
        Description("First name of author"), _
        NotifyParentProperty(True) _
        > _
        Public Overridable Property FirstName() As String
            Get
                Dim s As String = CStr(ViewState("FirstName"))
                If s Is Nothing Then s = String.Empty
                Return s
            End Get
            Set(ByVal value As String)
                ViewState("FirstName") = value
            End Set
        End Property

        < _
        Category("Behavior"), _
        DefaultValue(""), _
        Description("Last name of author"), _
        NotifyParentProperty(True) _
        > _
        Public Overridable Property LastName() As String
            Get
                Dim s As String = CStr(ViewState("LastName"))
                If s Is Nothing Then s = String.Empty
                Return s
            End Get
            Set(ByVal value As String)
                ViewState("LastName") = value
            End Set
        End Property

        < _
        Category("Behavior"), _
        DefaultValue(""), _
        Description("Middle name of author"), _
        NotifyParentProperty(True) _
        > _
        Public Overridable Property MiddleName() As String
            Get
                Dim s As String = CStr(ViewState("MiddleName"))
                If s Is Nothing Then s = String.Empty
                Return s
            End Get
            Set(ByVal value As String)
                ViewState("MiddleName") = value
            End Set
        End Property

        Protected Overridable ReadOnly Property ViewState() _
            As StateBag
            Get
                If viewStateValue Is Nothing Then
                    viewStateValue = New StateBag(False)

                    If isTrackingViewStateValue Then
                        CType(viewStateValue, _
                        IStateManager).TrackViewState()
                    End If
                End If
                Return viewStateValue
            End Get
        End Property

        Public Overrides Function ToString() As String
            Return ToString(CultureInfo.InvariantCulture)
        End Function


        Public Overloads Function ToString( _
        ByVal culture As CultureInfo) As String
            Return TypeDescriptor.GetConverter( _
                Me.GetType()).ConvertToString(Nothing, culture, Me)
        End Function

#Region "IStateManager implementation"
        Public ReadOnly Property IsTrackingViewState() As Boolean _
            Implements IStateManager.IsTrackingViewState
            Get
                Return isTrackingViewStateValue
            End Get
        End Property

        Public Sub LoadViewState(ByVal savedState As Object) _
            Implements IStateManager.LoadViewState
            If savedState IsNot Nothing Then
                CType(ViewState, _
                    IStateManager).LoadViewState(savedState)
            End If
        End Sub

        Public Function SaveViewState() As Object _
            Implements IStateManager.SaveViewState
            Dim savedState As Object = Nothing
            If viewStateValue IsNot Nothing Then
                savedState = CType(viewStateValue, _
                    IStateManager).SaveViewState
            End If
            Return savedState
        End Function

        Public Sub TrackViewState() _
            Implements IStateManager.TrackViewState
            isTrackingViewStateValue = True
            If viewStateValue IsNot Nothing Then
                CType(viewStateValue, IStateManager).TrackViewState()
            End If
        End Sub
#End Region

        Protected Sub SetDirty()
            viewStateValue.SetDirty(True)
        End Sub
    End Class
End Namespace
' </Snippet3>
