' <Snippet1>
Imports System
Imports System.Text
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.Strings

Class EncoderTest
    
    Public Shared Sub Main()
        ' Unicode characters.
        ' ChrW(35)  = #
        ' ChrW(37)  = %
        ' ChrW(928) = Pi
        ' ChrW(931) = Sigma
        Dim chars() As Char = {ChrW(35), ChrW(37), ChrW(928), ChrW(931)}
        
        ' Encode characters using an Encoding object.
        Dim encoding As Encoding = Encoding.UTF7
        Console.WriteLine( _
            "Using Encoding" & _
            ControlChars.NewLine & _
            "--------------" _
        )
        
        ' Encode complete array for comparison.
        Dim allCharactersFromEncoding As Byte() = encoding.GetBytes(chars)
        Console.WriteLine("All characters encoded:")
        ShowArray(allCharactersFromEncoding)
        
        ' Encode characters, one-by-one.
        ' The Encoding object will NOT maintain state between calls.
        Dim firstchar As Byte() = encoding.GetBytes(chars, 0, 1)
        Console.WriteLine("First character:")
        ShowArray(firstchar)
        
        Dim secondchar As Byte() = encoding.GetBytes(chars, 1, 1)
        Console.WriteLine("Second character:")
        ShowArray(secondchar)
        
        Dim thirdchar As Byte() = encoding.GetBytes(chars, 2, 1)
        Console.WriteLine("Third character:")
        ShowArray(thirdchar)
        
        Dim fourthchar As Byte() = encoding.GetBytes(chars, 3, 1)
        Console.WriteLine("Fourth character:")
        ShowArray(fourthchar)
        
        
        ' Now, encode characters using an Encoder object.
        Dim encoder As Encoder = encoding.GetEncoder()
        Console.WriteLine( _
            "Using Encoder" & _
            ControlChars.NewLine & _
            "-------------" _
        )
        
        ' Encode complete array for comparison.
        Dim allCharactersFromEncoder( _
            encoder.GetByteCount(chars, 0, chars.Length, True) _
        ) As Byte
        encoder.GetBytes(chars, 0, chars.Length, allCharactersFromEncoder, 0, True)
        Console.WriteLine("All characters encoded:")
        ShowArray(allCharactersFromEncoder)
        
        ' Do not flush state; i.e. maintain state between calls.
        Dim bFlushState As Boolean = False
        
        ' Encode characters one-by-one.
        ' By maintaining state, the Encoder will not store extra bytes in the output.
        Dim firstcharNoFlush( _
            encoder.GetByteCount(chars, 0, 1, bFlushState) _
        ) As Byte
        encoder.GetBytes(chars, 0, 1, firstcharNoFlush, 0, bFlushState)
        Console.WriteLine("First character:")
        ShowArray(firstcharNoFlush)
        
        Dim secondcharNoFlush( _
            encoder.GetByteCount(chars, 1, 1, bFlushState) _
        ) As Byte
        encoder.GetBytes(chars, 1, 1, secondcharNoFlush, 0, bFlushState)
        Console.WriteLine("Second character:")
        ShowArray(secondcharNoFlush)
        
        Dim thirdcharNoFlush( _
            encoder.GetByteCount(chars, 2, 1, bFlushState) _
        ) As Byte
        encoder.GetBytes(chars, 2, 1, thirdcharNoFlush, 0, bFlushState)
        Console.WriteLine("Third character:")
        ShowArray(thirdcharNoFlush)
        
        ' Must flush state on last call to GetBytes().
        bFlushState = True
        
        Dim fourthcharNoFlush( _
            encoder.GetByteCount(chars, 3, 1, bFlushState) _
        ) As Byte
        encoder.GetBytes(chars, 3, 1, fourthcharNoFlush, 0, bFlushState)
        Console.WriteLine("Fourth character:")
        ShowArray(fourthcharNoFlush)
    End Sub 'Main
    
    
    Public Shared Sub ShowArray(theArray As Array)
        Dim o As Object
        For Each o In  theArray
            Console.Write("[{0}]", o)
        Next o
        Console.WriteLine(ControlChars.NewLine)
    End Sub 'ShowArray
End Class 'EncoderTest

'This code example produces the following output.
'
'Using Encoding
'--------------
'All characters encoded:
'[43][65][67][77][65][74][81][79][103][65][54][77][45]
'
'First character:
'[43][65][67][77][45]
'
'Second character:
'[43][65][67][85][45]
'
'Third character:
'[43][65][54][65][45]
'
'Fourth character:
'[43][65][54][77][45]
'
'Using Encoder
'-------------
'All characters encoded:
'[43][65][67][77][65][74][81][79][103][65][54][77][45][0]
'
'First character:
'[43][65][67][0]
'
'Second character:
'[77][65][74][0]
'
'Third character:
'[81][79][103][0]
'
'Fourth character:
'[65][54][77][45][0]
'
' </Snippet1>
