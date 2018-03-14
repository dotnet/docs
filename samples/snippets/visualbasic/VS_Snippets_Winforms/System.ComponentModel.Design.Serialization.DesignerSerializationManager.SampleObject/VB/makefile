SampleObject.dll: SampleObject2.dll Program.vb
   vbc /t:library /out:SampleObject.dll Program.vb
   
SampleObject2.dll:  SampleObject.vb
   vbc /t:library /out:SampleObject2.dll SampleObject.vb

clean:
   del *.dll *.bin