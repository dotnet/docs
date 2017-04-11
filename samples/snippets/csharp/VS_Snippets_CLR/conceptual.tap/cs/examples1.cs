using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

public class Example
{
   public static void Main()
   {


   }

   // <Snippet1>
   public Task ReadAsync(byte [] buffer, int offset, int count, 
                         CancellationToken cancellationToken)
   // </Snippet1>
   {
      return Task.Factory.StartNew( () => Thread.Sleep(100));
   }                      

   // <Snippet2>
   public Task ReadAsync(byte[] buffer, int offset, int count, 
                         IProgress<long> progress)
   // </Snippet2>
   {
      return Task.Factory.StartNew( () => Thread.Sleep(100));
   }                      


   // <Snippet3>
   public Task<ReadOnlyCollection<FileInfo>> FindFilesAsync(
               string pattern, 
               IProgress<Tuple<double, 
               ReadOnlyCollection<List<FileInfo>>>> progress)
   // </Snippet3>
   {
      return Task.Factory.StartNew( () => { FileInfo[] fi = new FileInfo[10]; 
                                          return new ReadOnlyCollection<FileInfo>(fi); } );
   }               

   // <Snippet4>
   public Task<ReadOnlyCollection<FileInfo>> FindFilesAsync(
       string pattern, 
       IProgress<FindFilesProgressInfo> progress)
   // </Snippet4>
   {
      return Task.Factory.StartNew( () => { FileInfo[] fi = new FileInfo[10]; 
                                          return new ReadOnlyCollection<FileInfo>(fi); } );
   }
}

public class FindFilesProgressInfo
{}


public class Progress<T> : IProgress<T>
{
    public Progress();
    public Progress(Action<T> handler);
    protected virtual void OnReport(T value);
    public event EventHandler<T> ProgressChanged;
}
