using System;
using System.IO;
using System.Threading.Tasks;

public static class Wrapper
{
    // <Snippet4>
    public static Task<int> ReadAsync(this Stream stream, 
                                      byte[] buffer, int offset, 
                                      int count)
    {
        if (stream == null) 
           throw new ArgumentNullException("stream");
        
        return Task<int>.Factory.FromAsync(stream.BeginRead, 
                                           stream.EndRead, buffer, 
                                           offset, count, null);
    }
    // </Snippet4>
}
