      array<CodeExpression^>^temp0 = gcnew array<CodeExpression^>(0);
      CodeObjectCreateExpression^ objectCreate1 = gcnew CodeObjectCreateExpression( "System.DateTime",temp0 );
      
      // A C# code generator produces the following source code for the preceeding example code:
      //        new System.DateTime();