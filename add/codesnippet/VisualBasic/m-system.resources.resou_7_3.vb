Imports System.Resources

<Assembly: NeutralResourcesLanguageAttribute("en")>

Module Example
   Public Sub Main()
      Dim fmtString As String = String.Empty
      Dim rm As New ResourceManager("UIResources", GetType(Example).Assembly)       
      Dim title As String = rm.GetString("TableName")
      Dim tableInfo As PersonTable = DirectCast(rm.GetObject("Employees"), PersonTable)

      If Not String.IsNullOrEmpty(title) Then
         fmtString = "{0," + ((Console.WindowWidth + title.Length) \ 2).ToString() + "}" 
         Console.WriteLine(fmtString, title)      
         Console.WriteLine()
      End If

      For ctr As Integer = 1 To tableInfo.nColumns
         Dim columnName As String = "column"  + ctr.ToString()
         Dim widthName As String = "width" + ctr.ToString()
         Dim value As String = CStr(tableInfo.GetType().GetField(columnName).GetValue(tableInfo))
         Dim width As Integer = CInt(tableInfo.GetType().GetField(widthName).GetValue(tableInfo))
         fmtString = "{0,-" + width.ToString() + "}"
         Console.Write(fmtString, value)
      Next      
      Console.WriteLine()
   End Sub
End Module