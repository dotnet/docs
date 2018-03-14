Imports Microsoft.VisualBasic
Imports System.Collections.Generic

'<Snippet3>
Public Class CustomerLogic
    Public Function GetSubsetOfEmployees(ByVal startRows As Integer, ByVal maxRows As Integer) As List(Of Customer)

        Dim ndc As New NorthwindDataContext()
        Dim customerQuery = _
        From c In ndc.Customers _
            Select c

        Return customerQuery.Skip(startRows).Take(maxRows).ToList()
    End Function

    Public Function GetEmployeeCount() As Integer

        Dim cachedCount = HttpRuntime.Cache("TotalEmployeeCount")
        If cachedCount IsNot Nothing Then
            Return Integer.Parse(cachedCount.ToString())
        Else
            Dim ndc As New NorthwindDataContext()
            Dim totalNumberQuery = _
            From c In ndc.Customers _
                Select c

            Dim employeeCount = totalNumberQuery.Count()
            HttpRuntime.Cache.Add("TotalEmployeeCount", employeeCount, Nothing, DateTime.Now.AddMinutes(5), Cache.NoSlidingExpiration, CacheItemPriority.Normal, Nothing)
            Return employeeCount
        End If
    End Function
End Class
'</Snippet3>
