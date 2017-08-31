//-----------------------------------------------------------------------------
//<Snippet3>
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Microsoft.SqlServer.Server;

public partial class Triggers
{
    [SqlTrigger(Name="UserNameAudit", Target="Users", Event="FOR INSERT")]
    public static void UserNameAudit()
    {
        SqlTriggerContext triggContext = SqlContext.TriggerContext;
        SqlParameter userName = new SqlParameter("@username", System.Data.SqlDbType.NVarChar);

        if (triggContext.TriggerAction == TriggerAction.Insert)
        {
            using (SqlConnection conn = new SqlConnection("context connection=true"))
            {
                conn.Open();
                SqlCommand sqlComm = new SqlCommand();
                SqlPipe sqlP = SqlContext.Pipe;

                sqlComm.Connection = conn;
                sqlComm.CommandText = "SELECT UserName from INSERTED";

                userName.Value = sqlComm.ExecuteScalar().ToString();

                if (IsEMailAddress(userName.ToString()))
                {
                    sqlComm.CommandText = "INSERT UsersAudit(UserName) VALUES(userName)";
                    sqlP.Send(sqlComm.CommandText);
                    sqlP.ExecuteAndSend(sqlComm);
                }
            }
        }
    }


    public static bool IsEMailAddress(string s)
    {
        return Regex.IsMatch(s, "^([\\w-]+\\.)*?[\\w-]+@[\\w-]+\\.([\\w-]+\\.)*?[\\w]+$");
    }
}
//</Snippet3>


//-----------------------------------------------------------------------------
//<Snippet8>
public partial class Triggers
{
    [SqlTrigger(Target="authors", Event="FOR UPDATE")]
    public static void AuthorsUpdateTrigger()
    {
        //...
    }
}
//</Snippet8>


//-----------------------------------------------------------------------------
//<Snippet9>
public partial class Triggers
{
    [SqlTrigger(Name="trig_onpubinsert", Target="publishers", Event="FOR INSERT")]
    public static void PublishersInsertTrigger()
    {
        //...
    }
}
//</Snippet9>
