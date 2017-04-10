' The following code example creates instances of the UTF32Encoding class using different parameter values and then checks them for equality.

' <Snippet1>
Imports System
Imports System.Text

Public Class SamplesUTF32Encoding   

   Public Shared Sub Main()

      ' Create different instances of UTF32Encoding.
      Dim u32 As New UTF32Encoding()
      Dim u32tt As New UTF32Encoding(True, True)
      Dim u32tf As New UTF32Encoding(True, False)
      Dim u32ft As New UTF32Encoding(False, True)
      Dim u32ff As New UTF32Encoding(False, False)

      ' Compare these instances with instances created using the ctor with three parameters.
      CompareEncodings(u32, "u32  ")
      CompareEncodings(u32tt, "u32tt")
      CompareEncodings(u32tf, "u32tf")
      CompareEncodings(u32ft, "u32ft")
      CompareEncodings(u32ff, "u32ff")

   End Sub 'Main


   Public Shared Sub CompareEncodings(a As UTF32Encoding, name As String)

      ' Create different instances of UTF32Encoding using the ctor with three parameters.
      Dim u32ttt As New UTF32Encoding(True, True, True)
      Dim u32ttf As New UTF32Encoding(True, True, False)
      Dim u32tft As New UTF32Encoding(True, False, True)
      Dim u32tff As New UTF32Encoding(True, False, False)
      Dim u32ftt As New UTF32Encoding(False, True, True)
      Dim u32ftf As New UTF32Encoding(False, True, False)
      Dim u32fft As New UTF32Encoding(False, False, True)
      Dim u32fff As New UTF32Encoding(False, False, False)

      ' Compare the specified instance with each of the instances that were just created.
      Console.WriteLine("{0} and u32ttt : {1}", name, a.Equals(u32ttt))
      Console.WriteLine("{0} and u32ttf : {1}", name, a.Equals(u32ttf))
      Console.WriteLine("{0} and u32tft : {1}", name, a.Equals(u32tft))
      Console.WriteLine("{0} and u32tff : {1}", name, a.Equals(u32tff))
      Console.WriteLine("{0} and u32ftt : {1}", name, a.Equals(u32ftt))
      Console.WriteLine("{0} and u32ftf : {1}", name, a.Equals(u32ftf))
      Console.WriteLine("{0} and u32fft : {1}", name, a.Equals(u32fft))
      Console.WriteLine("{0} and u32fff : {1}", name, a.Equals(u32fff))

   End Sub 'CompareEncodings 

End Class 'SamplesUTF32Encoding


'This code produces the following output.
'
'u32   vs u32ttt : False
'u32   vs u32ttf : False
'u32   vs u32tft : False
'u32   vs u32tff : False
'u32   vs u32ftt : False
'u32   vs u32ftf : False
'u32   vs u32fft : False
'u32   vs u32fff : True
'u32tt vs u32ttt : False
'u32tt vs u32ttf : True
'u32tt vs u32tft : False
'u32tt vs u32tff : False
'u32tt vs u32ftt : False
'u32tt vs u32ftf : False
'u32tt vs u32fft : False
'u32tt vs u32fff : False
'u32tf vs u32ttt : False
'u32tf vs u32ttf : False
'u32tf vs u32tft : False
'u32tf vs u32tff : True
'u32tf vs u32ftt : False
'u32tf vs u32ftf : False
'u32tf vs u32fft : False
'u32tf vs u32fff : False
'u32ft vs u32ttt : False
'u32ft vs u32ttf : False
'u32ft vs u32tft : False
'u32ft vs u32tff : False
'u32ft vs u32ftt : False
'u32ft vs u32ftf : True
'u32ft vs u32fft : False
'u32ft vs u32fff : False
'u32ff vs u32ttt : False
'u32ff vs u32ttf : False
'u32ff vs u32tft : False
'u32ff vs u32tff : False
'u32ff vs u32ftt : False
'u32ff vs u32ftf : False
'u32ff vs u32fft : False
'u32ff vs u32fff : True

' </Snippet1>
