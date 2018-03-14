Option Explicit On
Option Strict On

' e0954147-548b-461f-9c4b-a8f88845616c
' /target (Visual Basic)

' <snippet37>
<Assembly: System.CLSCompliant(True)> 

<System.CLSCompliant(False)>
Public Class AClass
End Class

Module Module1
    Sub Main()
    End Sub
End Module
' </snippet37>

Class Class83fc339d6652415db205b5133319b5b0
    ' 83fc339d-6652-415d-b205-b5133319b5b0
    ' /main

    ' <snippet16>
    ' Compile with /r:System.dll,SYSTEM.WINDOWS.FORMS.DLL /main:MyC
    Public Class MyC
        Inherits System.Windows.Forms.Form
    End Class
    ' </snippet16>

End Class

Namespace Class9a93fb53c080497bbf9b441022dbbc39
    ' 9a93fb53-c080-497b-bf9b-441022dbbc39
    ' /imports (Visual Basic)

    ' <snippet21>
    Module MyModule
        Sub Main()
            Console.WriteLine("test")
            ' Otherwise, would need
            ' System.Console.WriteLine("test")
        End Sub
    End Module
    ' </snippet21>

End Namespace

Class Classf735c57d1cf94f2fa26f0de630fd4077
    ' f735c57d-1cf9-4f2f-a26f-0de630fd4077
    ' /define (Visual Basic)

    ' <snippet45>
    ' Vbc /define:DEBUGMODE=True,TRAPERRORS=False test.vb
    Sub mysub()
#If debugmode Then
        ' Insert debug statements here.
         MsgBox("debug mode")
#Else
        ' Insert default statements here.
#End If
    End Sub
    ' </snippet45>

End Class

