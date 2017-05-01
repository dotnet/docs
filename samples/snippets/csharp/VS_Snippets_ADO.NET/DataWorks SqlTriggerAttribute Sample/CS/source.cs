using System;
using System.Data;
using System.Data.Sql;
using Microsoft.SqlServer.Server;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Xml;
using System.Text.RegularExpressions;

public class CLRTriggers
{

// <Snippet1>
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
//</Snippet1>

}
