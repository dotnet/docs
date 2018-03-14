' <Snippet1>
Imports System
Imports System.Collections
Imports System.Data
Imports System.IO
Imports System.Security.Permissions
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace Samples.AspNet.VB.Controls

' The CsvDataSource is a data source control that retrieves its
' data from a comma-separated value file.
<AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
Public Class CsvDataSource
   Inherits DataSourceControl

   Public Sub New()
   End Sub 'New

   ' The comma-separated value file to retrieve data from.
   Public Property FileName() As String
      Get
         Return CType(Me.GetView([String].Empty), CsvDataSourceView).SourceFile
      End Get
      Set
         ' Only set if it is different.
         If CType(Me.GetView([String].Empty), CsvDataSourceView).SourceFile <> value Then
            CType(Me.GetView([String].Empty), CsvDataSourceView).SourceFile = value
            RaiseDataSourceChangedEvent(EventArgs.Empty)
         End If
      End Set
   End Property

   ' Do not add the column names as a data row. Infer columns if the CSV file does
   ' not include column names.

   Public Property IncludesColumnNames() As Boolean
      Get
         Return CType(Me.GetView([String].Empty), CsvDataSourceView).IncludesColumnNames
      End Get
      Set
         ' Only set if it is different.
         If CType(Me.GetView([String].Empty), CsvDataSourceView).IncludesColumnNames <> value Then
            CType(Me.GetView([String].Empty), CsvDataSourceView).IncludesColumnNames = value
            RaiseDataSourceChangedEvent(EventArgs.Empty)
         End If
      End Set
   End Property


   ' <Snippet3>
   ' Return a strongly typed view for the current data source control.
   Private view As CsvDataSourceView = Nothing

   Protected Overrides Function GetView(viewName As String) As DataSourceView
      If view Is Nothing Then
         view = New CsvDataSourceView(Me, String.Empty)
      End If
      Return view
   End Function 'GetView
   ' </Snippet3>

   ' <Snippet4>
   ' The ListSourceHelper class calls GetList, which
   ' calls the DataSourceControl.GetViewNames method.
   ' Override the original implementation to return
   ' a collection of one element, the default view name.
   Protected Overrides Function GetViewNames() As ICollection
      Dim al As New ArrayList(1)
      al.Add(CsvDataSourceView.DefaultViewName)
      Return CType(al, ICollection)
   End Function 'GetViewNames

End Class 'CsvDataSource
' </Snippet4>


' <Snippet5>
' The CsvDataSourceView class encapsulates the
' capabilities of the CsvDataSource data source control.

Public Class CsvDataSourceView
   Inherits DataSourceView

   Public Sub New(owner As IDataSource, name As String)
       MyBase.New(owner, DefaultViewName)
   End Sub 'New

   ' The data source view is named. However, the CsvDataSource
   ' only supports one view, so the name is ignored, and the
   ' default name used instead.
   Public Shared DefaultViewName As String = "CommaSeparatedView"

   ' The location of the .csv file.
   Private aSourceFile As String = [String].Empty

   Friend Property SourceFile() As String
      Get
         Return aSourceFile
      End Get
      Set
         ' Use MapPath when the SourceFile is set, so that files local to the
         ' current directory can be easily used.
         Dim mappedFileName As String
         mappedFileName = HttpContext.Current.Server.MapPath(value)
         aSourceFile = mappedFileName
      End Set
   End Property

   ' Do not add the column names as a data row. Infer columns if the CSV file does
   ' not include column names.
   Private columns As Boolean = False

   Friend Property IncludesColumnNames() As Boolean
      Get
         Return columns
      End Get
      Set
         columns = value
      End Set
   End Property

   ' <Snippet6>
   ' Get data from the underlying data source.
   ' Build and return a DataView, regardless of mode.
   Protected Overrides Function ExecuteSelect(selectArgs As DataSourceSelectArguments) _
    As System.Collections.IEnumerable
      Dim dataList As IEnumerable = Nothing
      ' Open the .csv file.
      If File.Exists(Me.SourceFile) Then
         Dim data As New DataTable()

         ' Open the file to read from.
         Dim sr As StreamReader = File.OpenText(Me.SourceFile)

         Try
            ' Parse the line
            Dim dataValues() As String
            Dim col As DataColumn

            ' Do the following to add schema.
            dataValues = sr.ReadLine().Split(","c)
            ' For each token in the comma-delimited string, add a column
            ' to the DataTable schema.
            Dim token As String
            For Each token In dataValues
               col = New DataColumn(token, System.Type.GetType("System.String"))
               data.Columns.Add(col)
            Next token

            ' Do not add the first row as data if the CSV file includes column names.
            If Not IncludesColumnNames Then
               data.Rows.Add(CopyRowData(dataValues, data.NewRow()))
            End If

            ' Do the following to add data.
            Dim s As String
            Do
               s = sr.ReadLine()
               If Not s Is Nothing Then
                   dataValues = s.Split(","c)
                   data.Rows.Add(CopyRowData(dataValues, data.NewRow()))
               End If
            Loop Until s Is Nothing

         Finally
            sr.Close()
         End Try

         data.AcceptChanges()
         Dim dataView As New DataView(data)
' <Snippet7>
         If Not selectArgs.SortExpression Is String.Empty Then
             dataView.Sort = selectArgs.SortExpression
         End If
' </Snippet7>
         dataList = dataView
      Else
         Throw New System.Configuration.ConfigurationErrorsException("File not found, " + Me.SourceFile)
      End If

      If dataList is Nothing Then
         Throw New InvalidOperationException("No data loaded from data source.")
      End If

      Return dataList
   End Function 'ExecuteSelect


   Private Function CopyRowData([source]() As String, target As DataRow) As DataRow
      Try
         Dim i As Integer
         For i = 0 To [source].Length - 1
            target(i) = [source](i)
         Next i
      Catch iore As IndexOutOfRangeException
         ' There are more columns in this row than
         ' the original schema allows.  Stop copying
         ' and return the DataRow.
         Return target
      End Try
      Return target
   End Function 'CopyRowData
   ' </Snippet6>

   ' <Snippet8>
   ' The CsvDataSourceView does not currently
   ' permit deletion. You can modify or extend
   ' this sample to do so.
   Public Overrides ReadOnly Property CanDelete() As Boolean
      Get
         Return False
      End Get
   End Property

   Protected Overrides Function ExecuteDelete(keys As IDictionary, values As IDictionary) As Integer
      Throw New NotSupportedException()
   End Function 'ExecuteDelete
   ' </Snippet8>

   ' <Snippet9>
   ' The CsvDataSourceView does not currently
   ' permit insertion of a new record. You can
   ' modify or extend this sample to do so.
   Public Overrides ReadOnly Property CanInsert() As Boolean
      Get
         Return False
      End Get
   End Property

   Protected Overrides Function ExecuteInsert(values As IDictionary) As Integer
      Throw New NotSupportedException()
   End Function 'ExecuteInsert
   ' </Snippet9>

   ' <Snippet10>
   ' The CsvDataSourceView does not currently
   ' permit update operations. You can modify or
   ' extend this sample to do so.
   Public Overrides ReadOnly Property CanUpdate() As Boolean
      Get
         Return False
      End Get
   End Property

   Protected Overrides Function ExecuteUpdate(keys As IDictionary, _
                                              values As IDictionary, _
                                              oldValues As IDictionary) As Integer
      Throw New NotSupportedException()
   End Function 'ExecuteUpdate

End Class 'CsvDataSourceView
' </Snippet10>
' </Snippet5>
End Namespace
' </Snippet1>