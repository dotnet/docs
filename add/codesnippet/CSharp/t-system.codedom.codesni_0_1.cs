            // Creates a compile unit using a literal sring;
            string literalCode;
            literalCode = "using System; namespace TestLiteralCode " + 
                "{ public class TestClass { public TestClass() {} } }";
            CodeSnippetCompileUnit csu = new CodeSnippetCompileUnit( literalCode );            