'<Snippet1>

Imports System
Imports System.Text
Imports System.Security.Cryptography

Class Program

	Public Shared Sub Main()
		Dim rnd As RandomNumberGenerator = RandomNumberGenerator.Create
		Dim input() As Byte = New Byte((20) - 1) {}
		rnd.GetBytes(input)
		Console.WriteLine("Input        : {0}"& vbLf, BytesToStr(input))
		PrintHash(input)
		PrintHashOneBlock(input)
		PrintHashMultiBlock(input, 1)
		PrintHashMultiBlock(input, 2)
		PrintHashMultiBlock(input, 3)
		PrintHashMultiBlock(input, 5)
		PrintHashMultiBlock(input, 10)
		PrintHashMultiBlock(input, 11)
		PrintHashMultiBlock(input, 19)
		PrintHashMultiBlock(input, 20)
		PrintHashMultiBlock(input, 21)
	End Sub

	Public Shared Function BytesToStr(ByVal bytes() As Byte) As String
		Dim str As StringBuilder = New StringBuilder
		Dim i As Integer = 0
		Do While (i < bytes.Length)
		str.AppendFormat("{0:X2}", bytes(i))
		i = (i + 1)
		Loop
		Return str.ToString
	End Function

	Public Shared Sub PrintHash(ByVal input() As Byte)
		Dim sha As SHA256Managed = New SHA256Managed
		Console.WriteLine("ComputeHash  : {0}", BytesToStr(sha.ComputeHash(input)))
	End Sub

	Public Shared Sub PrintHashOneBlock(ByVal input() As Byte)
		Dim sha As SHA256Managed = New SHA256Managed
		sha.TransformFinalBlock(input, 0, input.Length)
		Console.WriteLine("FinalBlock   : {0}", BytesToStr(sha.Hash))
	End Sub

	Public Shared Sub PrintHashMultiBlock(ByVal input() As Byte, ByVal size As Integer)
		Dim sha As SHA256Managed = New SHA256Managed
		Dim offset As Integer = 0

		While ((input.Length - offset)  _
			>= size)
		offset = (offset + sha.TransformBlock(input, offset, size, input, offset))

		End While
		sha.TransformFinalBlock(input, offset, (input.Length - offset))
		Console.WriteLine("MultiBlock {0:00}: {1}", size, BytesToStr(sha.Hash))
	End Sub
End Class
' </Snippet1>
