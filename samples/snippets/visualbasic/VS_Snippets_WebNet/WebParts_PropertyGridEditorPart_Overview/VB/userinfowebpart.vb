' <snippet5>
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Security.Permissions
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts

Namespace Samples.AspNet.VB.Controls

  <AspNetHostingPermission(SecurityAction.Demand, _
    Level:=AspNetHostingPermissionLevel.Minimal)> _
  <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
    Level:=AspNetHostingPermissionLevel.Minimal)> _
  Public Class UserInfoWebPart
    Inherits WebPart
    Private server As HttpServerUtility = HttpContext.Current.Server
    Private _userNickName As String = "Add a nickname."
    Private _userPetName As String = "Add a pet name."
    Private _userSpecialDate As DateTime = DateTime.Now
    Private _userIsCurrent As [Boolean] = True
    Private _userJobType As JobTypeName = JobTypeName.Unselected

    Public Enum JobTypeName
      Unselected = 0
      Support = 1
      Service = 2
      Professional = 3
      Technical = 4
      Manager = 5
      Executive = 6
    End Enum

    Private NickNameLabel As Label
    Private PetNickNameLabel As Label
    Private SpecialDateLabel As Label
    Private IsCurrentCheckBox As CheckBox
    Private JobTypeLabel As Label

    ' Add the Personalizable and WebBrowsable attributes to the  
    ' public properties, so that users can save property values  
    ' and edit them with a PropertyGridEditorPart control.

    <Personalizable(), WebBrowsable(), WebDisplayName("Nickname")> _
    Public Property NickName() As String
      Get
        Dim o As Object = ViewState("NickName")
        If Not (o Is Nothing) Then
          Return CStr(o)
        Else
          Return _userNickName
        End If
      End Get
      Set(ByVal value As String)
        _userNickName = server.HtmlEncode(value)
      End Set
    End Property

    <Personalizable(), WebBrowsable(), WebDisplayName("Pet Name")> _
    Public Property PetName() As String
      Get
        Dim o As Object = ViewState("PetName")
        If Not (o Is Nothing) Then
          Return CStr(o)
        Else
          Return _userPetName
        End If
      End Get
      Set(ByVal value As String)
        _userPetName = server.HtmlEncode(value)
      End Set
    End Property

    <Personalizable(), WebBrowsable(), WebDisplayName("Special Day")> _
    Public Property SpecialDay() As DateTime
      Get
        Dim o As Object = ViewState("SpecialDay")
        If Not (o Is Nothing) Then
          Return CType(o, DateTime)
        Else
          Return _userSpecialDate
        End If
      End Get

      Set(ByVal value As DateTime)
        _userSpecialDate = value
      End Set
    End Property

    ' <snippet6>
    <Personalizable(), WebBrowsable(), WebDisplayName("Job Type"), _
      WebDescription("Select the category that corresponds to your job.")> _
    Public Property UserJobType() As JobTypeName
      Get
        Dim o As Object = ViewState("UserJobType")
        If Not (o Is Nothing) Then
          Return CType(o, JobTypeName)
        Else
          Return _userJobType
        End If
      End Get
      Set(ByVal value As JobTypeName)
        _userJobType = CType(value, JobTypeName)
      End Set
    End Property
    ' </snippet6>

    <Personalizable(), WebBrowsable(), WebDisplayName("Is Current")> _
    Public Property IsCurrent() As [Boolean]
      Get
        Dim o As Object = ViewState("IsCurrent")
        If Not (o Is Nothing) Then
          Return CType(o, [Boolean])
        Else
          Return _userIsCurrent
        End If
      End Get
      Set(ByVal value As [Boolean])
        _userIsCurrent = value
      End Set
    End Property

    Protected Overrides Sub CreateChildControls()
      Controls.Clear()

      NickNameLabel = New Label()
      NickNameLabel.Text = Me.NickName
      SetControlAttributes(NickNameLabel)

      PetNickNameLabel = New Label()
      PetNickNameLabel.Text = Me.PetName
      SetControlAttributes(PetNickNameLabel)

      SpecialDateLabel = New Label()
      SpecialDateLabel.Text = Me.SpecialDay.ToShortDateString()
      SetControlAttributes(SpecialDateLabel)

      IsCurrentCheckBox = New CheckBox()
      IsCurrentCheckBox.Checked = Me.IsCurrent
      SetControlAttributes(IsCurrentCheckBox)

      JobTypeLabel = New Label()
      JobTypeLabel.Text = Me.UserJobType.ToString()
      SetControlAttributes(JobTypeLabel)

      ChildControlsCreated = True

    End Sub

    Private Sub SetControlAttributes(ByVal ctl As WebControl)
      ctl.BackColor = Color.White
      ctl.BorderWidth = 1
      ctl.Width = 200
      Me.Controls.Add(ctl)
    End Sub

    Protected Overrides Sub RenderContents(ByVal writer As HtmlTextWriter)
      writer.Write("Nickname:")
      writer.WriteBreak()
      NickNameLabel.RenderControl(writer)
      writer.WriteBreak()
      writer.Write("Pet Name:")
      writer.WriteBreak()
      PetNickNameLabel.RenderControl(writer)
      writer.WriteBreak()
      writer.Write("Special Date:")
      writer.WriteBreak()
      SpecialDateLabel.RenderControl(writer)
      writer.WriteBreak()
      writer.Write("Job Type:")
      writer.WriteBreak()
      JobTypeLabel.RenderControl(writer)
      writer.WriteBreak()
      writer.Write("Current:")
      writer.WriteBreak()
      IsCurrentCheckBox.RenderControl(writer)

    End Sub

  End Class

End Namespace
' </snippet5>