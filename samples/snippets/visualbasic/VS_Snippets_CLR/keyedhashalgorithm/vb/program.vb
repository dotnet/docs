'<Snippet1>
Imports System
Imports System.Security.Cryptography
 _

Public Class TestHMACMD5

    Private Shared Sub PrintByteArray(ByVal arr() As [Byte])
        Dim i As Integer
        Console.WriteLine(("Length: " + arr.Length.ToString()))
        For i = 0 To arr.Length - 1
            Console.Write("{0:X}", arr(i))
            Console.Write("    ")
            If (i + 9) Mod 8 = 0 Then
                Console.WriteLine()
            End If
        Next i
        If i Mod 8 <> 0 Then
            Console.WriteLine()
        End If
    End Sub

    Public Shared Sub Main()
        ' Create a key.
        Dim key1 As Byte() = {&HB, &HB, &HB, &HB, &HB, &HB, &HB, &HB, &HB, &HB, &HB, &HB, &HB, &HB, &HB, &HB}
        ' Pass the key to the constructor of the HMACMD5 class.  
        Dim hmac1 As New HMACMD5(key1)

        ' Create another key.
        Dim key2 As Byte() = System.Text.Encoding.ASCII.GetBytes("KeyString")
        ' Pass the key to the constructor of the HMACMD5 class.  
        Dim hmac2 As New HMACMD5(key2)

        ' Encode a string into a byte array, create a hash of the array,
        ' and print the hash to the screen.
        Dim data1 As Byte() = System.Text.Encoding.ASCII.GetBytes("Hi There")
        PrintByteArray(hmac1.ComputeHash(data1))

        ' Encode a string into a byte array, create a hash of the array,
        ' and print the hash to the screen.
        Dim data2 As Byte() = System.Text.Encoding.ASCII.GetBytes("This data will be hashed.")
        PrintByteArray(hmac2.ComputeHash(data2))
    End Sub
End Class
 _

Public Class HMACMD5
    Inherits KeyedHashAlgorithm
    Private hash1 As MD5
    Private hash2 As MD5
    Private bHashing As Boolean = False

    Private rgbInner(64) As Byte
    Private rgbOuter(64) As Byte


    Public Sub New(ByVal rgbKey() As Byte)
        HashSizeValue = 128
        ' Create the hash algorithms.
        hash1 = MD5.Create()
        hash2 = MD5.Create()
        ' Get the key.
        If rgbKey.Length > 64 Then
            KeyValue = hash1.ComputeHash(rgbKey)
            ' No need to call Initialize; ComputeHash does it automatically.
        Else
            KeyValue = CType(rgbKey.Clone(), Byte())
        End If
        ' Compute rgbInner and rgbOuter.
        Dim i As Integer = 0
        For i = 0 To 63
            rgbInner(i) = &H36
            rgbOuter(i) = &H5C
        Next i
        i = 0
        For i = 0 To KeyValue.Length - 1
            rgbInner(i) = rgbInner(i) Xor KeyValue(i)
            rgbOuter(i) = rgbOuter(i) Xor KeyValue(i)
        Next i
    End Sub


    Public Overrides Property Key() As Byte()
        Get
            Return CType(KeyValue.Clone(), Byte())
        End Get
        Set(ByVal Value As Byte())
            If bHashing Then
                Throw New Exception("Cannot change key during hash operation")
            End If
            If value.Length > 64 Then
                KeyValue = hash1.ComputeHash(value)
                ' No need to call Initialize; ComputeHash does it automatically.
            Else
                KeyValue = CType(value.Clone(), Byte())
            End If
            ' Compute rgbInner and rgbOuter.
            Dim i As Integer = 0
            For i = 0 To 63
                rgbInner(i) = &H36
                rgbOuter(i) = &H5C
            Next i
            For i = 0 To KeyValue.Length - 1
                rgbInner(i) ^= KeyValue(i)
                rgbOuter(i) ^= KeyValue(i)
            Next i
        End Set
    End Property


    Public Overrides Sub Initialize()
        hash1.Initialize()
        hash2.Initialize()
        bHashing = False
    End Sub


    Protected Overrides Sub HashCore(ByVal rgb() As Byte, ByVal ib As Integer, ByVal cb As Integer)
        If bHashing = False Then
            hash1.TransformBlock(rgbInner, 0, 64, rgbInner, 0)
            bHashing = True
        End If
        hash1.TransformBlock(rgb, ib, cb, rgb, ib)
    End Sub


    Protected Overrides Function HashFinal() As Byte()
        If bHashing = False Then
            hash1.TransformBlock(rgbInner, 0, 64, rgbInner, 0)
            bHashing = True
        End If
        ' Finalize the original hash.
        hash1.TransformFinalBlock(New Byte(0) {}, 0, 0)
        ' Write the outer array.
        hash2.TransformBlock(rgbOuter, 0, 64, rgbOuter, 0)
        ' Write the inner hash and finalize the hash.
        hash2.TransformFinalBlock(hash1.Hash, 0, hash1.Hash.Length)
        bHashing = False
        Return hash2.Hash
    End Function
End Class
'</Snippet1>

