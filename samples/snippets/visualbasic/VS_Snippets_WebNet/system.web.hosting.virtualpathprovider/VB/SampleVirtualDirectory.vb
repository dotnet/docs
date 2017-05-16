' <Snippet30>
Imports Microsoft.VisualBasic

Imports System
Imports System.Data
Imports System.Collections
Imports System.Security.Permissions
Imports System.Web
Imports System.Web.Hosting


Namespace Samples.AspNet.VB
  <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal), _
   AspNetHostingPermission(SecurityAction.InheritanceDemand, level:=AspNetHostingPermissionLevel.Minimal)> _
  Public Class SampleVirtualDirectory
    Inherits VirtualDirectory

    Private spp As SamplePathProvider

    ' Declare the variable the property uses.
    Private existsValue As Boolean

    Public ReadOnly Property exists() As Boolean
      Get
        Return existsValue
      End Get
    End Property

    ' <Snippet31>
    Public Sub New(ByVal virtualDir As String, ByVal provider As SamplePathProvider)
      MyBase.New(virtualDir)
      spp = provider
      GetData()
    End Sub

    Protected Sub GetData()
      ' Get the data from the SamplePathProvider.
      Dim spp As SamplePathProvider
      spp = CType(HostingEnvironment.VirtualPathProvider, SamplePathProvider)

      Dim ds As DataSet
      ds = spp.GetVirtualData

      ' Clean up the path to match data in resource file.
      Dim path As String
      path = VirtualPath.Replace(HostingEnvironment.ApplicationVirtualPath, "")
      Dim trimChars() As Char = {"/"c}
      path = path.TrimEnd(trimChars)

      ' Get the virtual directory from the resource table.
      Dim dirs As DataTable
      dirs = ds.Tables("resource")
      Dim rows As DataRow()
      rows = dirs.Select( _
        String.Format("(name = '{0}') AND (type='dir')", path))

      ' If the select returned a row, the directory exits.
      If (rows.Length > 0) Then
        existsValue = True

        ' Get the children from the resource table.
        ' This technique works for small numbers of virtual resources.
        '  Sites with moderate to large numbers of virtual
        '  resources should choose a method that consumes fewer
        '  computer resources.
        Dim childRows As DataRow()
        childRows = dirs.Select( _
          String.Format("parentPath = '{0}'", path))

        For Each childRow As DataRow In childRows
          Dim childPath As String
          childPath = CType(childRow("path"), String)

          If (childRow("type").ToString = "dir") Then
            Dim svd As New SampleVirtualDirectory(childPath, spp)
            childrenValue.Add(svd)
            directoriesValue.Add(svd)
          Else
            Dim svf As New SampleVirtualFile(childPath, spp)
            childrenValue.Add(svf)
            directoriesValue.Add(svf)
          End If
        Next

      End If
    End Sub
    ' </Snippet31>

    Private childrenValue As ArrayList
    Public Overrides ReadOnly Property Children() As System.Collections.IEnumerable
      Get
        Return childrenValue
      End Get
    End Property

    Private directoriesValue As ArrayList
    Public Overrides ReadOnly Property Directories() As System.Collections.IEnumerable
      Get
        Return directoriesValue
      End Get
    End Property

    Private filesValue As ArrayList
    Public Overrides ReadOnly Property Files() As System.Collections.IEnumerable
      Get
        Return filesValue
      End Get
    End Property
  End Class

End Namespace
' </Snippet30>