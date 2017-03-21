[SqlTrigger(Name = @"SalesAudit", Target = "[dbo].[SalesInfo]", Event = "FOR INSERT")]
public static void SalesAudit()
{
   // Get the trigger context.
   SqlTriggerContext triggContext = SqlContext.TriggerContext;
   
   switch (triggContext.TriggerAction)
   {
      case TriggerAction.Insert:

      // Do something in response to the INSERT.
         
      break;
   }
}