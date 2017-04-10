using System;
using System.CodeDom;

namespace CodeDomSampleBatch
{
	public class Class1
	{
		public Class1()
		{
		}

        public static CodeCompileUnit CreateCompileUnit()
        {
            CodeCompileUnit cu = new CodeCompileUnit();

            //<Snippet1>
            // Creates a code expression for a CodeExpressionStatement to contain.
            CodeExpression invokeExpression = new CodeMethodInvokeExpression( 
                new CodeTypeReferenceExpression("Console"), 
                "Write", new CodePrimitiveExpression("Example string") );

            // Creates a statement using a code expression.
            CodeExpressionStatement expressionStatement;
            expressionStatement = new CodeExpressionStatement( invokeExpression );                        

            // A C# code generator produces the following source code for the preceeding example code:

            // Console.Write( "Example string" );
            //</Snippet1>

            //<Snippet2>
            // Creates a CodeLinePragma that references line 100 of the file "example.cs".
            CodeLinePragma pragma = new CodeLinePragma("example.cs", 100);
            //</Snippet2>

            //<Snippet9>
            // Creates a CodeSnippetExpression that represents a literal string that
            // can be used as an expression in a CodeDOM graph.
            CodeSnippetExpression literalExpression = 
                new CodeSnippetExpression("Literal expression");
            //</Snippet9>

            //<Snippet10>
            // Creates a statement using a literal string.
            CodeSnippetStatement literalStatement = 
                new CodeSnippetStatement("Console.Write(\"Test literal statement output\")");            
            //</Snippet10>

            //<Snippet11>
            // Creates a type member using a literal string.
            CodeSnippetTypeMember literalMember = 
                new CodeSnippetTypeMember("public static void TestMethod() {}");
            //</Snippet11>

            return cu;
        }

        public static CodeCompileUnit CreateSnippetCompileUnit()
        {
            //<Snippet8>
            // Creates a compile unit using a literal sring;
            string literalCode;
            literalCode = "using System; namespace TestLiteralCode " + 
                "{ public class TestClass { public TestClass() {} } }";
            CodeSnippetCompileUnit csu = new CodeSnippetCompileUnit( literalCode );            
            //</Snippet8>
            return csu;
        }

        // CodeNamespaceImportCollection
        public void CodeNamespaceImportCollectionExample()
        {
            //<Snippet3>
            //<Snippet4>
            // Creates an empty CodeNamespaceImportCollection.
            CodeNamespaceImportCollection collection = 
                new CodeNamespaceImportCollection();            			
            //</Snippet4>

            //<Snippet5>
            // Adds a CodeNamespaceImport to the collection.
            collection.Add( new CodeNamespaceImport("System") );
            //</Snippet5>

            //<Snippet6>
            // Adds an array of CodeNamespaceImport objects to the collection.
            CodeNamespaceImport[] Imports = { 
                    new CodeNamespaceImport("System"),
                    new CodeNamespaceImport("System.Drawing") };
            collection.AddRange( Imports );
            //</Snippet6>
            
            //<Snippet7>
            // Retrieves the count of the items in the collection.
            int collectionCount = collection.Count;
            //</Snippet7>            
            //</Snippet3>
        }
	}
}