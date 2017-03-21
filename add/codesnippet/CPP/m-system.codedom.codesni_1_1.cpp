         // Creates a compile unit using a literal sring;
         String^ literalCode;
         literalCode = "using System; namespace TestLiteralCode " +
            "{ public class TestClass { public TestClass() {} } }";
         CodeSnippetCompileUnit^ csu = gcnew CodeSnippetCompileUnit( literalCode );