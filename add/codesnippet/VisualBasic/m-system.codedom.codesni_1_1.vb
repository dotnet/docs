        ' Creates a compile unit using a literal sring.
        Dim literalCode As String
        literalCode = "using System; namespace TestLiteralCode " & _
            "{ public class TestClass { public TestClass() {} } }"
        Dim csu As New CodeSnippetCompileUnit(literalCode)