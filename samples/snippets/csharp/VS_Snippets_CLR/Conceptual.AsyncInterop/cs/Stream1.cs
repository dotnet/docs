using System;

public class Stream
{
    // <Snippet1>
    public int Read(byte[] buffer, int offset, int count)
    // </Snippet1>
    { return 0; }

    // <Snippet2>
    public IAsyncResult BeginRead(byte[] buffer, int offset, 
                                  int count, AsyncCallback callback, 
                                  object state)
    // </Snippet2>
    { return null;  }
   
    // <Snippet3>
    public int EndRead(IAsyncResult asyncResult)
    // </Snippet3>
    { return 0; }
}
