<!-- <Snippet1> -->
<%@ page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void PasswordRecovery1_UserLookupError(object sender, EventArgs e)
  {
    PasswordRecovery1.UserNameTitleText = "Try again";
    PasswordRecovery1.TitleTextStyle.ForeColor = System.Drawing.Color.Red;
  }
  
  void PasswordRecovery1_AnswerLookupError(object sender, EventArgs e)
  {
    PasswordRecovery1.QuestionTitleText = "Try again";
    PasswordRecovery1.TitleTextStyle.ForeColor = System.Drawing.Color.Red;
  }
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
<form id="form1" runat="server">
  <asp:passwordrecovery id="PasswordRecovery1" runat="server" 
    questiontitletext="Password Confirmation Question"
    usernametitletext="Get a new password" OnUserLookupError="PasswordRecovery1_UserLookupError" OnAnswerLookupError="PasswordRecovery1_AnswerLookupError">
    <titletextstyle 
      font-names="Arial" 
      font-bold="True" 
      forecolor="White" 
      backcolor="Gray">
    </titletextstyle>
  </asp:passwordrecovery>

</form>
</body>
</html>
<!-- </Snippet1> -->