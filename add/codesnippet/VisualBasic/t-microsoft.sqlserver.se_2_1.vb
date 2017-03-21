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