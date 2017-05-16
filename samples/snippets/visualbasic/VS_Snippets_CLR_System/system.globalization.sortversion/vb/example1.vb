' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Collections
Imports System.Collections.Generic
Imports System.Globalization
Imports System.IO
Imports System.Text

Public Class Example : Implements IComparer
   Private Const FILENAME As String = ".\Regions.dat"
   
   Private Structure Region
      Friend Sub New(id As String, name As String)
         Me.Id = id
         Me.NativeName = name
      End Sub
      
      Dim Id As String
      Dim NativeName As String
      
      Public Overrides Function ToString() As String
         Return Me.NativeName
      End Function
   End Structure
   
   Public Shared Sub Main()
      Dim reindex As Boolean = False
      
      Dim regions() As Region
      Dim ver As SortVersion = Nothing

      ' If the data has not been saved, create it.
      If Not File.Exists(FILENAME) Then 
         regions = GenerateData()
         ver = CultureInfo.CurrentCulture.CompareInfo.Version  
         reindex = True
      ' Retrieve the existing data.
      Else
         regions = RestoreData(ver)
      End If

      ' Determine whether the current ordering is valid; if not, reorder.
      If reindex OrElse ver <> CultureInfo.CurrentCulture.CompareInfo.Version Then 
         Array.Sort(regions, New Example())      
         ' Save newly reordered data.
         SaveData(regions)
      End If
      
      ' Continue with application...
   End Sub

   Private Shared Function GenerateData() As Region()
      Dim regions As New List(Of Region)()

      For Each culture In CultureInfo.GetCultures(CultureTypes.AllCultures)
         If culture.IsNeutralCulture Or culture.Equals(CultureInfo.InvariantCulture) Then Continue For
            
         Dim region As New RegionInfo(culture.Name)
         regions.Add(New Region(region.Name, region.NativeName))
      Next
      Return regions.ToArray()
   End Function
   
   Private Shared Function RestoreData(ByRef ver As SortVersion) As Region()
      Dim regions As New List(Of Region)
      
      Dim rdr As New BinaryReader(File.Open(FILENAME, FileMode.Open))
      
      Dim sortVer As Integer = rdr.ReadInt32
      Dim sortId As Guid = Guid.Parse(rdr.ReadString())
      ver = New SortVersion(sortVer, sortId)
      
      Dim id As String, name As String
      Do While rdr.PeekChar <> -1
         id = rdr.ReadString()
         name = rdr.ReadString()
         regions.Add(New Region(id, name))      
      Loop
      Return regions.ToArray()
   End Function
   
   Private Shared Sub SaveData(regions As Region())
      Dim ver As SortVersion = CultureInfo.CurrentCulture.CompareInfo.Version

      Dim wrtr As New BinaryWriter(File.Open(FILENAME, FileMode.Create))
      wrtr.Write(ver.FullVersion) 
      wrtr.Write(ver.SortId.ToString()) 
      
      For Each region In regions
         wrtr.Write(region.Id)
         wrtr.Write(region.NativeName)
      Next
      wrtr.Close()
   End Sub

   Private Function SortByNativeName(o1 As Object, o2 As Object) As Integer _
           Implements IComparer.Compare
        ' Assume that all conversions succeed.
        Dim r1 As Region = CType(o1, Region)
        Dim r2 As Region = CType(o2, Region)
        
        Return String.Compare(r1.NativeName, r2.NativeName, 
                              StringComparison.CurrentCulture)         
   End Function
End Class
' </Snippet1>   
      


