Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Security.Permissions


Namespace ASPNET.Samples.VB

    ' <snippet1>
    ' Create a custom ControlCollection that writes
    ' information to the Trace log when an instance
    ' of the collection is created.
    <AspNetHostingPermission(SecurityAction.Demand, _
       Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomControlCollection
        Inherits ControlCollection

        Private context As HttpContext

        Public Sub New(ByVal owner As Control)
            MyBase.New(owner)
            HttpContext.Current.Trace.Write("The control collection is created.")
            ' Display the Name of the control
            ' that uses this collection when tracing is enabled.
            HttpContext.Current.Trace.Write("The owner is: " _
          & Me.Owner.ToString())
        End Sub


    End Class

    ' </snippet1>


    <AspNetHostingPermission(SecurityAction.Demand, _
       Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class ChildControl
        Inherits Control

        Private messageValue As String

        Public Property Message() As String
            Get
                Return messageValue
            End Get
            Set(ByVal value As String)
                messageValue = value
            End Set
        End Property

    End Class

    <AspNetHostingPermission(SecurityAction.Demand, _
       Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class ParentControl
        Inherits Control
        Public Sub New()

        End Sub

        ' <snippet2>       
        ' Override the CreateControlCollection method to 
        ' write to the Trace object when tracing is enabled
        ' for the page or application in which this control
        ' is included.   
        Protected Overrides Function CreateControlCollection() As ControlCollection
            Return New CustomControlCollection(Me)
        End Function

        ' </snippet2>
        Protected Overrides Sub CreateChildControls()
            ' Create a new ControlCollection. 
            Me.CreateControlCollection()

            ' Create child controls.
            Dim firstControl As New ChildControl()
            firstControl.Message = "FirstChildControl"

            Dim secondControl As New ChildControl()
            secondControl.Message = "SecondChildControl"

            Dim thirdControl As New ChildControl()
            thirdControl.Message = "ThirdChildControl"

            Dim fourthControl As New ChildControl()
            fourthControl.Message = "FourthChildControl"

            Controls.Add(firstControl)
            Controls.Add(secondControl)
            Controls.Add(thirdControl)
            Controls.Add(fourthControl)

            ' Prevent child controls from being created again.
            ChildControlsCreated = True
        End Sub 'CreateChildControls


    End Class
End Namespace
