<!--<Snippet1>-->

<%@ Page language="c#" %>
<%@ Import namespace="System.Text" %>
<%@ Import namespace="System.IO" %>

<script runat="server">

// This code is to be added to a Global.asax file.

public void Application_BeginRequest() 
{
   Request.Filter = new QQQ1(Request.Filter);
   Request.Filter = new QQQ2(Request.Filter);
}

class QQQ1 : Stream
{
    private Stream _sink;

    public QQQ1(Stream sink)
    {
        _sink = sink;
    }

    public override bool CanRead
    {
        get { return true; }
    }

    public override bool CanSeek
    {
        get { return false; }
    }

    public override bool CanWrite
    {
        get { return false; }
    }

    public override long Length
    {
        get { return _sink.Length; }
    }

    public override long Position
    {
        get { return _sink.Position; }
        set { throw new NotSupportedException(); }
    }

    public override int Read(byte[] buffer, int offset, int count)
    {
	int c = _sink.Read(buffer, offset, count);

        for (int i = 0; i < count; i++)
        {
            if (buffer[offset+i] >= 'a' && buffer[offset+i] <= 'z')
                buffer[offset+i] -= ('a'-'A');
        }

        return c;
    }

    public override long Seek(long offset, System.IO.SeekOrigin direction)
    {
        throw new NotSupportedException();
    }

    public override void SetLength(long length)
    {
        throw new NotSupportedException();
    }

    public override void Close()
    {
        _sink.Close();
    }

    public override void Flush()
    {
        _sink.Flush();
    }

    public override void Write(byte[] buffer, int offset, int count)
    {
	throw new NotSupportedException();
    }
}

class QQQ2 : Stream
{
    private Stream _sink;

    public QQQ2(Stream sink)
    {
        _sink = sink;
    }

    public override bool CanRead
    {
        get { return true; }
    }

    public override bool CanSeek
    {
        get { return false; }
    }

    public override bool CanWrite
    {
        get { return false; }
    }

    public override long Length
    {
        get { return _sink.Length; }
    }

    public override long Position
    {
        get { return _sink.Position; }
        set { throw new NotSupportedException(); }
    }

    public override int Read(byte[] buffer, int offset, int count)
    {
	int c = _sink.Read(buffer, offset, count);

        for (int i = 0; i < count; i++)
        {
            if (buffer[i] == 'E')
                buffer[i] = (byte)'*';
            else if (buffer[i] == 'e')
                buffer[i] = (byte)'#';
        }
        return c;
    }

    public override long Seek(long offset, System.IO.SeekOrigin direction)
    {
        throw new NotSupportedException();
    }

    public override void SetLength(long length)
    {
        throw new NotSupportedException();
    }

    public override void Close()
    {
        _sink.Close();
    }

    public override void Flush()
    {
        _sink.Flush();
    }

    public override void Write(byte[] buffer, int offset, int count)
    {
	throw new NotSupportedException();
    }
}


/*____________________________________________________________________

This ASP.NET page uses the request filter to modify all text sent by the 
browser in Request.InputStream. To test the filter, use this page to take
the POSTed output from a data entry page using a tag such as: 
<form method="POST" action="ThisTestPage.aspx">


<%@ PAGE LANGUAGE = C# %>
<%@ IMPORT namespace="System.IO" %>

<html>
<Script runat=server>
   void Page_Load()
   {
 
      // Create a Stream object to capture entire InputStream from browser.
      Stream str = Request.InputStream;
   
      // Find number of bytes in stream.
      int strLen = (int)str.Length;

      // Create a byte array to hold stream.
      byte[] bArr = new byte[strLen];

      // Read stream into byte array.
      str.Read(bArr,0,strLen);
 
      // Convert byte array to a text string.
      String strmContents="";
      for(int i = 0; i < strLen; i++)
         strmContents = strmContents + (Char)bArr[i];
     
      // Display filtered stream in browser.
      Response.Write("Contents of Filtered InputStream: <br>" + strmContents);
   }
______________________________________________________________________*/

</script>
<!--</Snippet1>-->
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
</body>
</html>
