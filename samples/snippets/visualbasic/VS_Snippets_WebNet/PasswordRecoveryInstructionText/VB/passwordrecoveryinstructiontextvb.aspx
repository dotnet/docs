<!-- <Snippet1> -->
<%@ page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  ' <Snippet2>
  Sub PasswordRecovery1_UserLookupError(ByVal sender As Object, ByVal e As System.EventArgs)
    PasswordRecovery1.UserNameInstructionText = "Enter the correct Web site user name."
    PasswordRecovery1.InstructionTextStyle.ForeColor = System.Drawing.Color.Red
  End Sub
  ' </Snippet2>
  
  ' <Snippet4>
  Sub PasswordRecovery1_AnswerLookupError(ByVal sender As Object, ByVal e As System.EventArgs)
    PasswordRecovery1.QuestionInstructionText = "Enter the correct answer to this question."
    PasswordRecovery1.InstructionTextStyle.ForeColor = System.Drawing.Color.Red
  End Sub
  ' </Snippet4>
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
<form id="form1" runat="server">
<!-- <Snippet3> -->
  <asp:passwordrecovery id="PasswordRecovery1" runat="server" 
    questioninstructiontext="Enter the answer to the password confirmation question."
    usernameinstructiontext="Enter your Web site user name." 
    OnUserLookupError="PasswordRecovery1_UserLookupError" OnAnswerLookupError="PasswordRecovery1_AnswerLookupError">
    <instructiontextstyle 
      font-size="Smaller" 
      font-names="Comic Sans MS" 
      font-italic="True" 
      forecolor="Blue">
    </instructiontextstyle>
  </asp:passwordrecovery>
<!-- </Snippet3> -->
</form>
</body>
</html>
<!-- </Snippet1> -->
