' Visual Basic .NET Document
Option Strict On

Module Example
   Public Sub Main()
      AppendInt16()
      Console.WriteLine("---")
      AppendInt32()
      Console.WriteLine("---")
      AppendInt64()
      Console.WriteLine("---")
      AppendSByte()
      Console.WriteLine("---")
      AppendSingle()
      Console.WriteLine("---")
      AppendUInt16()
      Console.WriteLine("---")
      AppendUInt32()
      Console.WriteLine("---")
      AppendUInt64()
      Console.WriteLine("---")
      AppendString()
      Console.WriteLine("---")
   End Sub
   
   Private Sub AppendInt16()
      ' <Snippet10> 
      Dim sb As New System.Text.StringBuilder("The range of a 16-bit integer: ")
      sb.Append(Int16.MinValue).Append(" to ").Append(Int16.MaxValue)
      Console.WriteLine(sb)
      ' The example displays the following output:
      '       The range of a 16-bit integer: -32768 to 32767
      ' </Snippet10>
   End Sub
   
   Private Sub AppendInt32()
      ' <Snippet11> 
      Dim sb As New System.Text.StringBuilder("The range of a 32-bit integer: ")
      sb.Append(Int32.MinValue).Append(" to ").Append(Int32.MaxValue)
      Console.WriteLine(sb)
      ' The example displays the following output:
      '       The range of a 32-bit integer: -2147483648 to 2147483647
      ' </Snippet11>
   End Sub
   
   Private Sub AppendInt64()
      ' <Snippet12> 
      Dim sb As New System.Text.StringBuilder("The range of a 64-bit integer: ")
      sb.Append(Int64.MinValue).Append(" to ").Append(Int64.MaxValue)
      Console.WriteLine(sb)
      ' The example displays the following output:
      '       The range of a 64-bit integer:  -9223372036854775808 to 9223372036854775807
      ' </Snippet12>
   End Sub
   
   Private Sub AppendSByte()
      ' <Snippet13> 
      Dim sb As New System.Text.StringBuilder("The range of an 8-bit signed integer: ")
      sb.Append(SByte.MinValue).Append(" to ").Append(SByte.MaxValue)
      Console.WriteLine(sb)
      ' The example displays the following output:
      '       The range of an 8-bit unsigned integer: -128 to 127 
      ' </Snippet13>
   End Sub
   
   Private Sub AppendSingle()
      ' <Snippet14> 
      Dim value As Single = 1034769.47
      Dim sb As New System.Text.StringBuilder()
      sb.Append("*"c, 5).Append(value).Append("*"c, 5)
      Console.WriteLine(sb)
      ' The example displays the following output:
      '       *****1034769.47*****
      ' </Snippet14>
   End Sub
   
   Private Sub AppendUInt16()
      ' <Snippet15> 
      Dim sb As New System.Text.StringBuilder("The range of a 16-bit unsigned integer: ")
      sb.Append(UInt16.MinValue).Append(" to ").Append(UInt16.MaxValue)
      Console.WriteLine(sb)
      ' The example displays the following output:
      '       The range of a 16-bit unsigned integer: 0 to 65535
      ' </Snippet15>
   End Sub
   
   Private Sub AppendUInt32()
      ' <Snippet16> 
      Dim sb As New System.Text.StringBuilder("The range of a 32-bit unsigned integer: ")
      sb.Append(UInt32.MinValue).Append(" to ").Append(UInt32.MaxValue)
      Console.WriteLine(sb)
      ' The example displays the following output:
      '       The range of a 32-bit unsigned integer: 0 to 4294967295
      ' </Snippet16>
   End Sub
   
   Private Sub AppendUInt64()
      ' <Snippet17> 
      Dim sb As New System.Text.StringBuilder("The range of a 64-bit unsigned integer: ")
      sb.Append(UInt64.MinValue).Append(" to ").Append(UInt64.MaxValue)
      Console.WriteLine(sb)
      ' The example displays the following output:
      '       The range of a 64-bit unsigned integer: 0 to 18446744073709551615
      ' </Snippet17>
   End Sub

   Private Sub AppendString()
      ' <Snippet19>
      Dim str As String = "First;George Washington;1789;1797"
      Dim index As Integer = 0
      Dim sb As New System.Text.StringBuilder()
      Dim length As Integer = str.IndexOf(";"c, index)      
      sb.Append(str, index, length).Append(" President of the United States: ")
      index += length + 1
      length = str.IndexOf(";"c, index) - index
      sb.Append(str, index, length).Append(", from ")
      index += length + 1
      length = str.IndexOf(";"c, index) - index
      sb.Append(str, index, length).Append(" to ")
      index += length + 1
      sb.Append(str, index, str.Length - index)
      Console.WriteLine(sb)
      ' The example displays the following output:
      '    First President of the United States: George Washington, from 1789 to 1797      
      ' </Snippet19>
   End Sub
End Module

