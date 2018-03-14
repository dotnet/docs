' <Snippet11>
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Text
Imports System.Web.UI
Imports System.Web.UI.Design
Imports System.Web.UI.Design.WebControls
Imports System.Web.UI.WebControls
Imports System.Reflection
Imports System.Xml
Imports System.Configuration

Namespace Samples.AspNet.VB.Controls

    ' This region-based control renders the content of an XML file.
    <Designer(GetType(ControlWithStyleTasksDesigner))> _
    <ToolboxData("<{0}:ControlWithStyleTasks runat=server>" _
                 & "</{0}:ControlWithStyleTasks>")> _
    Public Class ControlWithStyleTasks
        Inherits Panel
    End Class

    <Designer(GetType(ControlWithConfigurationSettingDesigner))> _
    <ToolboxData("<{0}:ControlWithConfigurationSetting runat=server " _
                 & "width=100%></{0}:ControlWithConfigurationSetting>")> _
    Public Class ControlWithConfigurationSetting
        Inherits Panel
    End Class

    <Designer(GetType(ControlWithButtonTasksDesigner))> _
    <ToolboxData("<{0}:ControlWithButtonTasks runat=server " _
                 & "width=100%></{0}:ControlWithButtonTasks>")> _
    Public Class ControlWithButtonTasks
        Inherits Panel
    End Class

    ' Declare a custom button to add dynamically at design time.
    Public Class NewButton
        Inherits Button

        Public Sub New()
            [Text] = "NewButton"
        End Sub
    End Class

    ' This control designer is used to read xml files from the project.
	<System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
    Public Class ControlWithStyleTasksDesigner
        Inherits PanelContainerDesigner
        Private _style As Style = Nothing

        ' Add the caption by default. Note that the caption will 
        ' only appear if the Web server control allows 
        ' child controls rather than properties. 
        Public Overrides ReadOnly Property FrameCaption() _
          As String

            Get
                Return "Container getting styles from the project item."
            End Get
        End Property

        Public Overrides ReadOnly Property FrameStyle() As Style
            Get
                If _style Is Nothing Then
                    _style = New Style()
                    _style.Font.Name = "Verdana"
                    _style.Font.Size = New FontUnit("XSmall")
                    _style.BackColor = Color.LightGreen
                    _style.ForeColor = Color.Black
                End If

                Return _style
            End Get
        End Property

        ' Create a convenience field for the control.
        Private myControl As ControlWithStyleTasks

        Public Overrides Sub Initialize(ByVal component _
          As IComponent)
            ' Create the convenience control.
            MyBase.Initialize(component)
            myControl = CType(component, ControlWithStyleTasks)
        End Sub

        ' The following section creates a designer action list.
        ' Add the specific action list for this control. The 
        ' procedure here depends upon the specific order for 
        ' the list to be added, but always add the base.
        Public Overrides ReadOnly Property ActionLists() _
          As DesignerActionListCollection

            Get
                Dim newActionLists As New DesignerActionListCollection()
                newActionLists.AddRange(MyBase.ActionLists)
                newActionLists.Add(New MyList(Me))
                Return newActionLists
            End Get
        End Property

        Private _styleConfigPhysicalFile As String = ""

        Protected Property StyleConfigurationFile() As String
            Get
                Return _styleConfigPhysicalFile
            End Get
            Set(ByVal value As String)
                Dim styleConfigPhysicalFilePath As String = String.Empty
                If value.Length > 0 Then
                    ' Access the folder and look for the Control.xml file; 
                    ' then obtain its physical path to use to set styles 
                    ' for this control and control designer.  Obtain the 
                    ' actual file and its physical path from WebApplication.
                    Dim webApp As IWebApplication = _
                      CType(Component.Site. _
                        GetService(GetType(IWebApplication)), IWebApplication)
                    If Not (webApp Is Nothing) Then
                        ' Look for the project items from the root.
                        Dim dataFileProjectItem As IProjectItem = _
                          webApp.GetProjectItemFromUrl(("~/" + value))
                        If Not (dataFileProjectItem Is Nothing) Then
                            _styleConfigPhysicalFile = value
                            styleConfigPhysicalFilePath = _
                              dataFileProjectItem.PhysicalPath
                        End If
                    End If
                End If

                ' Get the styles from the XML file.
                SetControlStyleFromConfiguration( _
                  styleConfigPhysicalFilePath)
            End Set
        End Property

        ' Open the xml document and set control properties directly.
        Private Sub SetControlStyleFromConfiguration(ByVal _
          path As String)

            If path Is Nothing OrElse path = String.Empty Then
                Return
            End If

            Dim wc As WebControl = CType(Component, WebControl)
            If wc Is Nothing Then
                Return
            End If

            Dim xmlDoc As New XmlDocument()
            xmlDoc.Load(path)

            Dim stylesList As XmlNodeList = _
              xmlDoc.GetElementsByTagName("style")
            Dim i As Integer
            For i = 0 To stylesList.Count - 1
                If stylesList(i).Attributes("name").Value = _
                  "BackColor" Then

                    Dim pd As PropertyDescriptor = _
                      TypeDescriptor.GetProperties(wc)("BackColor")
                    If Not (pd Is Nothing) Then
                        pd.SetValue(wc, Color.FromName(stylesList(i). _
                          Attributes("value").Value))
                    End If
                End If
                If stylesList(i).Attributes("name").Value = _
                  "ForeColor" Then

                    Dim pd As PropertyDescriptor = _
                      TypeDescriptor.GetProperties(wc)("ForeColor")
                    If Not (pd Is Nothing) Then
                        pd.SetValue(wc, Color.FromName(stylesList(i). _
                          Attributes("value").Value))
                    End If
                End If
            Next i
        End Sub

        ' Create the action list for this control.
        Private Class MyList
            Inherits DesignerActionList
            Private _parent As ControlWithStyleTasksDesigner

            Public Sub New(ByVal parent As ControlWithStyleTasksDesigner)
                MyBase.New(parent.Component)
                _parent = parent
            End Sub

            <TypeConverter(GetType(FileListTypeConverter))> _
            Public Property ConfigureControlStyle() As String
                Get
                    Return _parent.StyleConfigurationFile
                End Get
                Set(ByVal value As String)
                    _parent.StyleConfigurationFile = value
                End Set
            End Property

            ' Provide the list of sorted action items for the host.
            ' Note that you can define the items through constructors 
            ' or through metadata on the method or property items.
            Public Overrides Function GetSortedActionItems() _
              As DesignerActionItemCollection

                Dim items As New DesignerActionItemCollection()

                items.Add(New DesignerActionTextItem("Configuration", "Select"))
                items.Add(New DesignerActionPropertyItem("ConfigureControlStyle", _
                                                 "Configure XML", _
                                                 "Select", _
                                                 String.Empty))
                Return items
            End Function

            ' The type converter needs to be generated with a standard 
            ' collection of items from the project.
            Private Class FileListTypeConverter
                Inherits TypeConverter

                Public Overrides Function GetStandardValues(ByVal context _
                  As ITypeDescriptorContext) As StandardValuesCollection

                    Dim myList As MyList = CType(context.Instance, MyList)
                    Dim webApp As IWebApplication = CType(myList._parent. _
                      Component.Site.GetService(GetType(IWebApplication)), _
                                                IWebApplication)

                    Dim xmlFiles As New ArrayList()
                    Dim rootItem As IFolderProjectItem = _
                      CType(webApp.RootProjectItem, IFolderProjectItem)
                    Dim item As IProjectItem
                    For Each item In rootItem.Children
                        If String.Equals( _
                          Path.GetExtension(item.Name), ".xml", _
                          StringComparison.CurrentCultureIgnoreCase) Then

                            xmlFiles.Add(item.Name)
                        End If
                    Next item

                    Return New StandardValuesCollection(xmlFiles)
                End Function

                Public Overrides Function GetStandardValuesExclusive( _
                  ByVal context As ITypeDescriptorContext) As Boolean

                    Return False
                End Function

                Public Overrides Function GetStandardValuesSupported( _
                  ByVal context As ITypeDescriptorContext) As Boolean

                    Return True
                End Function
            End Class
        End Class
    End Class

    ' This control designer is used to obtain the 
    ' configuration setting for the title.
    Public Class ControlWithConfigurationSettingDesigner
        Inherits PanelContainerDesigner

        Public Sub New()
        End Sub

        Private _style As Style = Nothing

        Public Overrides ReadOnly Property FrameCaption() _
          As String

            Get
                Dim title As String = String.Empty
                Dim webApp As IWebApplication
                webApp = CType(Component.Site.GetService( _
                                  GetType(IWebApplication)), IWebApplication)
                If Not (webApp Is Nothing) Then
                    ' Get the Configuration API.
                    Dim config As System.Configuration.Configuration
                    config = webApp.OpenWebConfiguration(True)

                    If Not (config Is Nothing) Then
                        Dim settingsSection As AppSettingsSection
                        settingsSection = config.AppSettings

                        If Not (settingsSection Is Nothing) Then
                            title = " .... " & _
                                settingsSection.Settings("ContainerControlTitle").ToString() _
                                & " ..... "
                        End If
                    End If
                End If
                Return title
            End Get
        End Property

        Public Overrides ReadOnly Property FrameStyle() As Style
            Get
                If _style Is Nothing Then
                    _style = New Style()
                    _style.Font.Name = "Verdana"
                    _style.Font.Size = New FontUnit("XSmall")
                    _style.BackColor = Color.LightGreen
                    _style.ForeColor = Color.Black
                End If

                Return _style
            End Get
        End Property
    End Class

    ' This control designer reads from the project file.
	<System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
    Public Class ControlWithButtonTasksDesigner
        Inherits PanelContainerDesigner

        Public Sub New()
        End Sub
        Private _style As Style = Nothing

        ' Add the caption by default. Note that the caption 
        ' will only appear if the Web server control 
        ' allows child controls rather than properties. 
        Public Overrides ReadOnly Property FrameCaption() _
          As String

            Get
                Return "Container adding controls to the document."
            End Get
        End Property

        Public Overrides ReadOnly Property FrameStyle() _
          As Style

            Get
                If _style Is Nothing Then
                    _style = New Style()
                    _style.Font.Name = "Verdana"
                    _style.Font.Size = New FontUnit("XSmall")
                    _style.BackColor = Color.LightGreen
                    _style.ForeColor = Color.Black
                End If

                Return _style
            End Get
        End Property

        ' The following section creates a designer action list.
        ' Add the specific action list for this control. The 
        ' procedure here depends upon the specific order for the 
        ' list to be added, but always add the base.
        Public Overrides ReadOnly Property ActionLists() _
          As DesignerActionListCollection

            Get
                Dim newActionLists As New DesignerActionListCollection()
                newActionLists.AddRange(MyBase.ActionLists)
                newActionLists.Add(New ControlWithButtonTasksList(Me))
                Return newActionLists
            End Get
        End Property


        Public Sub AddButton()
            ' Add a standard button.
            Dim b As New Button()
            b.Text = "New Button"
            RootDesigner.AddControlToDocument(b, Nothing, ControlLocation.Last)
        End Sub 'AddButton

        Public Sub AddNewButton()
            ' Add your custom button.
            Dim b As New NewButton()
            b.Text = "New custom button"

            ' For buttons defined in a different assembly, add the  
            ' register directive for the referenced assembly. 
            ' By default, this goes to the document, unless 
            ' already defined in the document or in configuration.
            Dim wfrm As WebFormsReferenceManager = RootDesigner.ReferenceManager
            wfrm.RegisterTagPrefix(b.GetType())

            RootDesigner.AddControlToDocument(b, Nothing, ControlLocation.First)
        End Sub
        

        ' Create the action list for this control.
        Private Class ControlWithButtonTasksList
            Inherits DesignerActionList
            Private _parent As ControlWithButtonTasksDesigner

            Public Sub New(ByVal parent As ControlWithButtonTasksDesigner)
                MyBase.New(parent.Component)
                _parent = parent
            End Sub

            Public Sub AddButton()
                _parent.AddButton()
            End Sub

            Public Sub AddNewButton()
                _parent.AddNewButton()
            End Sub

            ' Provide the list of sorted action items for the host.
            Public Overrides Function GetSortedActionItems() _
              As DesignerActionItemCollection

                Dim items As New DesignerActionItemCollection()

                items.Add(New DesignerActionTextItem("Add Control", "Add"))
                items.Add(New DesignerActionMethodItem(Me, _
                                               "AddButton", _
                                               "Add a Button", _
                                               "Add", _
                                               String.Empty, _
                                               False))
                items.Add(New DesignerActionMethodItem(Me, _
                                               "AddNewButton", _
                                               "Add a custom Button", _
                                               "Add", _
                                               String.Empty, _
                                               False))

                Return items
            End Function
        End Class
    End Class

End Namespace
' </Snippet11>
