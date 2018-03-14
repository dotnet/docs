<!--<Snippet1>-->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >  
<head runat="server">
    <title>Table of Contents</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

         <a id="TOC"/>
         <h2>Table of Contents</h2>
         <a href="#Topic1">Topic 1</a><br />
         <a href="#Topic2">Topic 2</a><br />
         <a href="#Topic3">Topic 3</a><br />
 
         <br /><br />
 
         <a id="Topic1"/>
            <h3>Topic 1</h3>
            <br /><br />
            Contents for first topic...
            <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
            <a href="#TOC">Top</a><br />
        
         <a id="Topic2"/>
            <h3>Topic 2</h3>
            <br /><br />
            Contents for second topic...
            <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
            <a href="#TOC">Top</a><br />
            <br />
         
 
         <a id="Topic3"/>
            <h3>Topic 3</h3>
            <br /><br />
            Contents for third topic...
            <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
            <a href="#TOC">Top</a><br />
            <br /><br />

    <div>
    </form>
</body>
</html>
<!--</Snippet1>-->
