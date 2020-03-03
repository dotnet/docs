<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void SubmitBtn_Click(Object sender, EventArgs e)
  {
    TextArea1.Cols = Convert.ToInt32(Select1.Value);
    Span1.InnerHtml = "You wrote: <br />" + TextArea1.Value;
  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
   <title>HtmlTextArea Example</title>
</head>

<body>

   <form id="form1" runat="server">

      <h3>HtmlTextArea Example</h3>

      Enter your comments: <br />

      <textarea rows="2" cols="20" id="TextArea1" 
                runat="server"/>

      <br />
      Select column width: <br />

      <select id="Select1"
              runat="server">

         <option value="10" selected="selected"> 10 </option>
         <option value="20"> 20 </option>
         <option value="30"> 30 </option>
         <option value="40"> 40 </option>
         <option value="50"> 50 </option>
         <option value="60"> 60 </option>

      </select>

      <br /><br />

      <input type="submit"  
             value="Submit" 
             onserverclick="SubmitBtn_Click" 
             runat="server"/>

      <br />

      <span id="Span1" 
            runat="server" />

   </form>

</body>
</html>
<!--</Snippet1>-->