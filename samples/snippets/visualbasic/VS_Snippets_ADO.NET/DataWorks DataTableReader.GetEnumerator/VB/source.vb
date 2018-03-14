Option Explicit
Option Strict

Imports System
Imports System.Collections
Imports System.Data
Imports System.Data.Common


    
Module Module1
' <Snippet1>
   Sub Main()
      Try
         Dim userTable As New DataTable("peopleTable")
         userTable.Columns.Add("Id", GetType(Integer))
         userTable.Columns.Add("Name", GetType(String))

         ' Note that even if you create the DataTableReader
         ' before adding the rows, the enumerator can still
         ' visit all the rows.
         Dim reader As DataTableReader = userTable.CreateDataReader()
         userTable.Rows.Add(1, "Peter")
         userTable.Rows.Add(2, "Mary")
         userTable.Rows.Add(3, "Andy")
         userTable.Rows.Add(4, "Russ")

         Dim enumerator As IEnumerator = reader.GetEnumerator()
         ' Keep track of whether the row to be deleted
         ' has actually been deleted yet. This allows
         ' this sample to demonstrate that the enumerator
         ' is able to survive row deletion.
         Dim isRowDeleted As Boolean = False
         While (enumerator.MoveNext())

            Dim dataRecord As DbDataRecord = CType(enumerator.Current, _
                DbDataRecord)

            ' While the enumerator is active, delete a row.
            ' This doesn't affect the behavior of the enumerator.
            If Not isRowDeleted Then
               isRowDeleted = True
               userTable.Rows(2).Delete()
            End If
            Console.WriteLine(dataRecord.GetString(1))
         End While
      Catch ex As Exception

         Console.WriteLine(ex)
      End Try
      Console.ReadLine()
   End Sub
' </Snippet1>
End Module

