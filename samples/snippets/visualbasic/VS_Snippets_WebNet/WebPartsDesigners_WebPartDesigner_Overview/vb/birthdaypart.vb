' <Snippet1>
' <Snippet2>
Imports System.Security.Permissions
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.Design.WebControls.WebParts
Imports System.ComponentModel

' <summary>
' BirthdayPart demonstrates some of the most
' common overrides of members of the WebPart
' class. BirthdayPartDesigner shows how to 
' customize the rendering of a custom WebPart
' control.
' </summary>
Namespace Samples.AspNet.VB.Controls
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    <AspNetHostingPermission(SecurityAction.InheritanceDemand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    <Designer(GetType(BirthdayPartDesigner))> _
    Public Class BirthdayPart
        Inherits WebPart
        Private m_birthDate As DateTime
        Private input As Calendar
        Private displayContent As Label

        Public Sub New()
            Me.AllowClose = False
            Me.Title = "Enter your birthday"
        End Sub

        <Personalizable(PersonalizationScope.User, True), WebBrowsable()> _
        Public Property BirthDate() As DateTime
            Get
                Return m_birthDate
            End Get
            Set(value As DateTime)
                m_birthDate = value
            End Set
        End Property

        ' Set the appearance of the control at run time.
        Protected Overrides Sub CreateChildControls()
            Controls.Clear()
            input = New Calendar()
            Me.Controls.Add(input)
            Dim update As New Button()
            update.Text = "Submit"
            AddHandler update.Click, New EventHandler(AddressOf Me.submit_Click)
            Me.Controls.Add(update)
            displayContent = New Label()
            displayContent.BackColor = System.Drawing.Color.LightBlue
            Dim br As New Literal()
            br.Text = "<br />"
            If (Me.m_birthDate.Day = DateTime.Now.Day) AndAlso (Me.m_birthDate.Month = DateTime.Now.Month) Then
                displayContent.Text = "Happy Birthday!"
                Me.Controls.Add(br)
                Me.Controls.Add(displayContent)
            End If
        End Sub

        Private Sub submit_Click(sender As Object, e As EventArgs)
            Me.m_birthDate = input.SelectedDate
        End Sub
    End Class

    ' </Snippet2>
    ' <Snippet3>
    Public Class BirthdayPartDesigner
        Inherits WebPartDesigner
        Public Overrides Sub Initialize(component As IComponent)
            ' Verify that the associated control is a BirthdayPart.
            If Not GetType(BirthdayPart).IsInstanceOfType(component) Then
                Throw New ArgumentException("The specified control is not of type 'BirthdayPart'", "component")
            End If
            MyBase.Initialize(component)
        End Sub

        ' Here is where you make customizations
        ' to design time appearance that will not
        ' be visible to the end user.
        Public Overrides Function GetDesignTimeHtml() As String
            Dim designTimeHtml As String = Nothing
            Try
                designTimeHtml = MyBase.GetDesignTimeHtml()
                Dim s As String = "<hr /><hr />I just added these lines to the" & " bottom of the control.<hr /><hr /></div>"
                designTimeHtml = designTimeHtml.Replace("</div>", s)
            Catch ex As Exception
                designTimeHtml = GetErrorDesignTimeHtml(ex)
                ' undo any changes in the try block
            Finally
            End Try

            If (designTimeHtml Is Nothing) OrElse (designTimeHtml.Length = 0) Then
                designTimeHtml = GetEmptyDesignTimeHtml()
            End If
            Return designTimeHtml
        End Function

        ' This method normally returns a blank string.
        ' Override to return a meaningful message.
        Protected Overrides Function GetEmptyDesignTimeHtml() As String
            Return CreatePlaceHolderDesignTimeHtml("<hr />If the page developer forgot to fill in a " & "required property you could tell them here.<hr />")
        End Function

        ' Add specific text to the generic error message.
        Protected Overrides Function GetErrorDesignTimeHtml(e As Exception) As String
            Dim s As String = "<hr />The control failed to render."
            Return (s & e.Message & "<hr />")
        End Function
    End Class
End Namespace
' </Snippet3>
' </Snippet1>
