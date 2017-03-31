Imports System
Imports System.CodeDom

Public Class Class1

    Public Sub New()
    End Sub

    Public Shared Function CreateCompileUnit() As CodeCompileUnit
        Dim cu As New CodeCompileUnit()

        '<Snippet1>
        ' Creates a code expression for a CodeExpressionStatement to contain.
        Dim invokeExpression = New CodeMethodInvokeExpression( _
            New CodeTypeReferenceExpression("Console"), "Write", _
            New CodePrimitiveExpression("Example string"))

        ' Creates a statement using a code expression.
        Dim expressionStatement As CodeExpressionStatement
        expressionStatement = New CodeExpressionStatement(invokeExpression)

        ' A C# code generator produces the following source code for the preceeding example code:
        ' Console.Write( "Example string" );
        '</Snippet1>

        '<Snippet2>
        ' Creates a CodeLinePragma that references line 100 of the file "example.cs".
        Dim pragma As New CodeLinePragma("example.cs", 100)
        '</Snippet2>

        '<Snippet9>
        ' Creates a CodeSnippetExpression that represents a literal string that
        ' can be used as an expression in a CodeDOM graph.
        Dim literalExpression As New CodeSnippetExpression("Literal expression")
        '</Snippet9>

        '<Snippet10>
        ' Creates a statement using a literal string.
        Dim literalStatement As New CodeSnippetStatement( _
            "Console.Write(""Test literal statement output"")")
        '</Snippet10>

        '<Snippet11>
        ' Creates a type member using a literal string.
        Dim literalMember As New CodeSnippetTypeMember("public static void TestMethod() {}")
        '</Snippet11>

        Return cu
    End Function

    Public Shared Function CreateSnippetCompileUnit() As CodeCompileUnit
        '<Snippet8>
        ' Creates a compile unit using a literal sring.
        Dim literalCode As String
        literalCode = "using System; namespace TestLiteralCode " & _
            "{ public class TestClass { public TestClass() {} } }"
        Dim csu As New CodeSnippetCompileUnit(literalCode)
        '</Snippet8>
        Return csu
    End Function

    ' CodeNamespaceImportCollection
    Public Sub CodeNamespaceImportCollectionExample()
        '<Snippet3>
        '<Snippet4>
        ' Creates an empty CodeNamespaceImportCollection.
        Dim collection As New CodeNamespaceImportCollection()
        '</Snippet4>

        '<Snippet5>
        ' Adds a CodeNamespaceImport to the collection.
        collection.Add(New CodeNamespaceImport("System"))
        '</Snippet5>

        '<Snippet6>
        ' Adds an array of CodeNamespaceImport objects to the collection.
        Dim [Imports] As CodeNamespaceImport() = _
            {New CodeNamespaceImport("System"), _
            New CodeNamespaceImport("System.Drawing")}
        collection.AddRange([Imports])
        '</Snippet6>

        '<Snippet7>
        ' Retrieves the count of the items in the collection.
        Dim collectionCount As Integer = collection.Count
        '</Snippet7>
        '</Snippet3>
    End Sub
End Class