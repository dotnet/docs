' Visual Basic .NET Document
Option Strict On

' <Snippet8>
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
' </Snippet8>

<Serializable> Public Structure PersonTable
   Public ReadOnly nColumns As Integer
   Public Readonly column1 As String
   Public ReadOnly column2 As String
   Public ReadOnly column3 As String
   Public ReadOnly width1 As Integer
   Public ReadOnly width2 As Integer
   Public ReadOnly width3 As Integer
   
   Public Sub New(column1 As String, column2 As String, column3 As String,
                  width1 As Integer, width2 As Integer, width3 As Integer)
      Me.column1 = column1
      Me.column2 = column2
      Me.column3 = column3
      Me.width1 = width1
      Me.width2 = width2
      Me.width3 = width3
      Me.nColumns = Me.GetType().GetFields().Count \ 2 
   End Sub
End Structure

