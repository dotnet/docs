            // Declare a generic method.
            CodeMemberMethod printMethod = new CodeMemberMethod();
            CodeTypeParameter sType = new CodeTypeParameter("S");
            sType.HasConstructorConstraint = true;
            CodeTypeParameter tType = new CodeTypeParameter("T");
            sType.HasConstructorConstraint = true;

            printMethod.Name = "Print";
            printMethod.TypeParameters.Add(sType);
            printMethod.TypeParameters.Add(tType);
