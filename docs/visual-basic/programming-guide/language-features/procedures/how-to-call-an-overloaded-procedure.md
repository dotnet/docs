---
title: "How to: Call an Overloaded Procedure (Visual Basic)"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "Visual Basic code, procedures"
  - "procedures [Visual Basic], overloading"
  - "procedures [Visual Basic], calling"
  - "procedures [Visual Basic], multiple versions"
  - "procedure calls [Visual Basic], overloaded"
ms.assetid: 3bb331fb-f6bc-406f-9ca0-9609b497014c
---
# How to: Call an Overloaded Procedure (Visual Basic)
The advantage of overloading a procedure is in the flexibility of the call. The calling code can obtain the information it needs to pass to the procedure and then call a single procedure name, no matter what arguments it is passing.  
  
### To call a procedure that has more than one version defined  
  
1.  In the calling code, determine which data to pass to the procedure.  
  
2.  Write the procedure call in the normal way, presenting the data in the argument list. Be sure the arguments match the parameter list in one of the versions defined for the procedure.  
  
3.  You do not have to determine which version of the procedure to call. Visual Basic passes control to the version matching your argument list.  
  
     The following example calls the `post` procedure declared in [How to: Define Multiple Versions of a Procedure](./how-to-define-multiple-versions-of-a-procedure.md). It obtains the customer identification, determines whether it is a `String` or an `Integer`, and then in either case calls the same procedure.  
  
     [!code-vb[VbVbcnProcedures#56](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnProcedures/VB/Class1.vb#56)]  
  
     [!code-vb[VbVbcnProcedures#57](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnProcedures/VB/Class1.vb#57)]  
  
## See also

- [Procedures](./index.md)
- [Procedure Parameters and Arguments](./procedure-parameters-and-arguments.md)
- [Procedure Overloading](./procedure-overloading.md)
- [Troubleshooting Procedures](./troubleshooting-procedures.md)
- [How to: Define Multiple Versions of a Procedure](./how-to-define-multiple-versions-of-a-procedure.md)
- [How to: Overload a Procedure that Takes Optional Parameters](./how-to-overload-a-procedure-that-takes-optional-parameters.md)
- [How to: Overload a Procedure that Takes an Indefinite Number of Parameters](./how-to-overload-a-procedure-that-takes-an-indefinite-number-of-parameters.md)
- [Considerations in Overloading Procedures](./considerations-in-overloading-procedures.md)
- [Overload Resolution](./overload-resolution.md)
- [Overloads](../../../../visual-basic/language-reference/modifiers/overloads.md)
