SampleObject.dll: SampleObject2.dll Program.cs
   csc /t:library /out:SampleObject.dll Program.cs
   
SampleObject2.dll:  SampleObject.cs
   csc /t:library /out:SampleObject2.dll SampleObject.cs

clean:
   del *.dll *.bin