Imports System
Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlTypes
Imports Microsoft.SqlServer.Server
Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

'The Partial modifier is only required on one class definition per project.
Partial Public Class CLRTriggers 
 
' <Snippet1>   
<SqlTrigger(Name:="SalesAudit", Target:="[dbo].[SalesInfo]", Event:="FOR INSERT")> _
Public Shared Sub SalesAudit()
        
   Dim triggContext As SqlTriggerContext
         
   ' Get the trigger context.
   triggContext = SqlContext.TriggerContext        

   Select Case triggContext.TriggerAction
      Case TriggerAction.Insert
      
      ' Do something in response to the INSERT.
         
   End Select

End Sub
'</Snippet1>

End Class
