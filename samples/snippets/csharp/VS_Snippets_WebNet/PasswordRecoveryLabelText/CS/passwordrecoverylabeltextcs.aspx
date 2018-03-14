<!-- <Snippet1> -->
<%@ Page Language="C#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>ASP.NET Example</title>
</head>
<body>
  <form id="form1" runat="server">
    <asp:PasswordRecovery id="PasswordRecovery1" runat="server" 
      AnswerLabelText="Your answer:" 
      QuestionLabelText="Answer this question:" 
      UserNameLabelText="Your user name:">
      <LabelStyle 
        font-bold="True" 
        forecolor="White"
        backcolor="Navy">
      </LabelStyle>
    </asp:PasswordRecovery>
  </form>
</body>
</html>
<!-- </Snippet1> -->

