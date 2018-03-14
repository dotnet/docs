' DataboundDesigner.vb
'

' Create a custom designer, named TemplatedListDesigner, that
' derives from the TemplatedControlDesigner class and implements
' the IDataSourceProvider interface.
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Data
Imports System.Diagnostics
Imports System.Web.UI
Imports System.Web.UI.Design
Imports System.Web.UI.WebControls
Imports Examples.AspNet

Namespace Examples.AspNet.Design
   <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.InheritanceDemand, Name:="FullTrust" ), _
   System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust" )> _
   Public Class TemplatedListDesigner
      Inherits TemplatedControlDesigner
      Implements IDataSourceProvider
      
      ' Declare variables.
      Private dummyDataTable As DataTable
      Private designTimeDataTable As DataTable
      Private templateVerbs() As TemplateEditingVerb
      Private templateVerbsDirty As Boolean
      
      ' When an instance of this class is created,
      ' a Boolean property, named templateVerbsDirty, 
      ' is set to True.
      Public Sub New()
         templateVerbsDirty = True
      End Sub
     
      Public Overrides ReadOnly Property AllowResize() As Boolean
         Get
            ' When templates are not defined, render a read-only,
            ' fixed-size block. Once templates are defined or
            ' are being edited, the control allows resizing.
            Return TemplatesExist Or InTemplateMode
         End Get
      End Property



      ' Create a design-time DataSource property that 
      ' tracks to a key with the same name in the control's
      ' DataBindingCollection.      
      Public Property DataSource() As String
         Get
            Dim binding As DataBinding = DataBindings("DataSource")
            
            If Not (binding Is Nothing) Then
               Return binding.Expression
            End If
            Return [String].Empty
         End Get
         Set
            If value Is Nothing Or value.Length = 0 Then
               DataBindings.Remove("DataSource")
            Else
               Dim binding As DataBinding = DataBindings("DataSource")
               
               If binding Is Nothing Then
                  binding = New DataBinding("DataSource", GetType(IEnumerable), value)
               Else
                  binding.Expression = value
               End If
               DataBindings.Add(binding)
            End If
            
            OnDataSourceChanged()
            OnBindingsCollectionChanged("DataSource")
         End Set
      End Property



      ' Override the DesignTimeHtmlRequiresLoadComplete property.      
      Public Overrides ReadOnly Property DesignTimeHtmlRequiresLoadComplete() As Boolean
         Get
            ' If there is a data source, look it up in the container
            ' and require the document to be loaded completely.
            Return DataSource.Length <> 0
         End Get
      End Property



      ' Create a read-only property that determines whether the control
      ' is using templates at design time.      
      Protected ReadOnly Property TemplatesExist() As Boolean
         Get
            Return Not (CType(Component, TemplatedList).ItemTemplate Is Nothing)
         End Get
      End Property

    

      ' Override the CreateTemplateEditingFrame method to 
      ' provide a frame in which to manipulate
      ' templates at design time. 
      Protected Overrides Function CreateTemplateEditingFrame( _
        verb As TemplateEditingVerb) As ITemplateEditingFrame
         Dim teService As ITemplateEditingService = _
          CType(GetService(GetType(ITemplateEditingService)), ITemplateEditingService)
         Debug.Assert( Not (teService Is Nothing), _
          "How did we get this far without an ITemplateEditingService?")
         Debug.Assert((verb.Index = 0))
         
         Dim templateNames() As String = {"ItemTemplate"}
         Dim templateStyles() As Style = {CType(Component, TemplatedList).ItemStyle}
         
         Dim editingFrame As ITemplateEditingFrame = _
          teService.CreateFrame( _
           Me, verb.Text, templateNames, CType(Component, TemplatedList).ControlStyle, templateStyles)
         Return editingFrame
      End Function



      ' Override the Dispose method to release resources associated
      ' with this designer.
      Protected  Overloads Overrides Sub Dispose(disposing As Boolean)
        If disposing
         DisposeTemplateVerbs()
        End If
         MyBase.Dispose(disposing)
      End Sub
      
      ' Create a method that releases resources used by the
      ' designer verbs associated with design-time templates.
      Private Sub DisposeTemplateVerbs()
         If Not (templateVerbs Is Nothing) Then
            templateVerbs(0).Dispose()
            
            templateVerbs = Nothing
            templateVerbsDirty = True
         End If
      End Sub
   
   

      ' Override the GetCachedTemplateEditingVerbs method to check
      ' whether the verbs have been changed. If they have, a new
      ' collection of verbs is created for use with this designer.     
      Protected Overrides Function GetCachedTemplateEditingVerbs() As TemplateEditingVerb()
         If templateVerbsDirty = True Then
            DisposeTemplateVerbs()
            
            templateVerbs = New TemplateEditingVerb(1) {}
            templateVerbs(0) = New TemplateEditingVerb("Item Template", 0, Me)
            
            templateVerbsDirty = False
         End If
         
         Return templateVerbs
      End Function

      
      Protected Function GetDesignTimeDataSource(minimumRows As Integer, ByRef dummyDataSource As Boolean) As IEnumerable
         dummyDataSource = False
         
         Dim selectedDataSource As IEnumerable = CType(Me, IDataSourceProvider).GetResolvedSelectedDataSource()
         Dim dataTable As DataTable = designTimeDataTable
         
         ' Use the data table corresponding to the selected data source 
         ' if possible.
         If dataTable Is Nothing Then
            If Not (selectedDataSource Is Nothing) Then
               designTimeDataTable = DesignTimeData.CreateSampleDataTable(selectedDataSource)
               dataTable = designTimeDataTable
            End If
            
            If dataTable Is Nothing Then
               ' Fall back on a dummy data source if a sample data-table cannot be created.
               If dummyDataTable Is Nothing Then
                  dummyDataTable = DesignTimeData.CreateDummyDataTable()
               End If
               
               dataTable = dummyDataTable
               dummyDataSource = True
            End If
         End If
         
         Dim liveDataSource As IEnumerable = DesignTimeData.GetDesignTimeDataSource(dataTable, minimumRows)
         Return liveDataSource
      End Function
      
      
      ' Override the GetDesignTimeHtml method to display templates
      ' in the designer if they exist.
      Public Overrides Function GetDesignTimeHtml() As String
         Dim control As TemplatedList = CType(Component, TemplatedList)
         Dim designTimeHtml As String = Nothing
         Dim hasATemplate As Boolean = Me.TemplatesExist
         
         If hasATemplate Then
            Dim dummyDataSource As Boolean
            Dim designTimeDataSource As IEnumerable = GetDesignTimeDataSource(5, dummyDataSource)
            
            Try
               control.DataSource = designTimeDataSource
               control.DataBind()
               
               designTimeHtml = MyBase.GetDesignTimeHtml()
            Finally
               control.DataSource = Nothing
            End Try
         Else
            designTimeHtml = GetEmptyDesignTimeHtml()
         End If
         
         Return designTimeHtml
      End Function

      

      ' Override the GetEmptyDesignTimeHtml to check whether 
      ' template mode can be used from the designer, and provide
      ' display messages for both cases.      
      Protected Overrides Function GetEmptyDesignTimeHtml() As String
         Dim textValue As String
         
         If CanEnterTemplateMode Then
            textValue = "Right click and choose a set of templates to edit their content.<br>The ItemTemplate is required."
         Else
            textValue = "Switch to HTML view to edit the control's templates.<br>The ItemTemplate is required."
         End If
         Return CreatePlaceHolderDesignTimeHtml(textValue)
      End Function



      ' Override the GetErrorDesignTimeHtml to display an
      ' error message if an error occurs in design-time rendering of
      ' the control.      
      Protected Overrides Function GetErrorDesignTimeHtml(e As Exception) As String
         Debug.Fail(e.ToString())
         Return CreatePlaceHolderDesignTimeHtml("There was an error rendering the control.<br>Make sure all properties are valid.")
      End Function

 

      ' Override the GetTemplateContainerDataSource to return the 
      ' data source to be used by the templated control.    
      Public Overrides Function GetTemplateContainerDataSource(templateName As String) As IEnumerable
         Return CType(Me, IDataSourceProvider).GetResolvedSelectedDataSource()
      End Function
      
      Public Overrides Function GetTemplateContainerDataItemProperty(templateName As String) As String
         Return "DataItem"
      End Function

  
     
      ' Override the GetTemplateContent method to return the content
      ' contained in the template.
      Public Overrides Function GetTemplateContent(editingFrame As ITemplateEditingFrame, templateName As String, ByRef allowEditing As Boolean) As String
         ' Ensure that the designer verb is first in the collection
         ' and that the name of the template is ItemTemplate.
         Debug.Assert((editingFrame.Verb.Index = 0))
         Debug.Assert(templateName.Equals("ItemTemplate"))
         allowEditing = True
         
         Dim template As ITemplate = CType(Component, TemplatedList).ItemTemplate
         Dim templateContent As String = [String].Empty
         
         ' If the template is already created, use the text
         ' already created for it.
         If Not (template Is Nothing) Then
            templateContent = GetTextFromTemplate(template)
         End If
         
         Return templateContent
      End Function


      ' Override the OnComponentChanged method to change
      ' the control's DataSource or styles in the designer.
      Public Overrides Sub OnComponentChanged(sender As Object, e As ComponentChangedEventArgs)
         If Not (e.Member Is Nothing) Then
            Dim memberName As String = e.Member.Name
            If memberName.Equals("DataSource") Or memberName.Equals("DataMember") Then
               OnDataSourceChanged()
            Else
               If memberName.Equals("ItemStyle") Then
                  OnStylesChanged()
               End If
            End If
         End If 
         MyBase.OnComponentChanged(sender, e)
      End Sub
      
      ' Create a method that sets the data table 
      ' associated with the templates to nothing.
      Protected Overridable Sub OnDataSourceChanged()
         designTimeDataTable = Nothing
      End Sub
      
      ' Create a method that determines whether the designer
      ' verbs associated with the control's templates have
      ' changed.
      Protected Sub OnStylesChanged()
         OnTemplateEditingVerbsChanged()
      End Sub
      
      ' Create a method that notifies all callers
      ' that the designer verbs collection has changed.
      Protected Sub OnTemplateEditingVerbsChanged()
         templateVerbsDirty = True
      End Sub

      
     
      ' Override the PreFilterProperties method to allow the DataSource
      ' associated with the control to be described in the designer.
      Protected Overrides Sub PreFilterProperties(properties As IDictionary)
         MyBase.PreFilterProperties(properties)
         
         Dim prop As PropertyDescriptor
         
         prop = CType(properties("DataSource"), PropertyDescriptor)
         Debug.Assert(( Not (prop Is Nothing)))
         prop = TypeDescriptor.CreateProperty( _
           Me.GetType(), prop, New Attribute() {New TypeConverterAttribute(GetType(DataSourceConverter))})
         properties("DataSource") = prop
      End Sub
     
     
      ' Override the SetTemplateContent method to check whether the template
      ' exists. If it does, set its content to the value already created for it.
      ' 
      Public Overrides Sub SetTemplateContent( _
        editingFrame As ITemplateEditingFrame, _
        templateName As String, _
        templateContent As String)
         Debug.Assert((editingFrame.Verb.Index = 0))
         Debug.Assert(templateName.Equals("ItemTemplate"))
         
         Dim template As ITemplate = Nothing
         
         If Not (templateContent Is Nothing) And templateContent.Length <> 0 Then
            template = GetTemplateFromText(templateContent)
         End If
         
         CType(Component, TemplatedList).ItemTemplate = template
      End Sub
 

     
      ' Create a method that implements the 
      ' IDataSourceProvider.GetResolvedSelectedDataSource method.
      ' It converts the object returned from the GetSelectedDataSource
      ' method into an IEnumberable object to allow iteration over
      ' the returned object.
      Function GetResolvedSelectedDataSource() As IEnumerable _
       Implements IDataSourceProvider.GetResolvedSelectedDataSource
         Return CType(CType(Me, IDataSourceProvider).GetSelectedDataSource(), IEnumerable)
      End Function
 
      ' Create a method that implements the 
      ' IDataSourceProvider.GetSelectedDataSource method. 
      ' Return the data source as an IEnumerable object,
      ' if possible.     
      Function GetSelectedDataSource() As Object _
       Implements IDataSourceProvider.GetSelectedDataSource
         Dim selectedDataSource As Object = Nothing
         Dim dataSource As String = Nothing
         
         Dim binding As DataBinding = DataBindings("DataSource")
         If Not (binding Is Nothing) Then
            dataSource = binding.Expression
         End If
          
         If Not (dataSource Is Nothing) Then
            Dim componentSite As ISite = Component.Site
            If Not (componentSite Is Nothing) Then
               Dim container As IContainer = CType(componentSite.GetService(GetType(IContainer)), IContainer)
               
               If Not (container Is Nothing) Then
                  Dim comp As IComponent = container.Components(dataSource)
                  If TypeOf comp Is IEnumerable Then
                     selectedDataSource = comp
                  End If
               End If
            End If
         End If
         
         Return selectedDataSource
      End Function
    
   End Class
End Namespace

