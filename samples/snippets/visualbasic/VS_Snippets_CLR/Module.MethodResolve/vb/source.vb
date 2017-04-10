'<Snippet1>
Imports System.Reflection

Namespace ResolveMethodExample

    ' Metadata tokens for the MethodRefs that are to be resolved.
    ' If you change this program, some or all of these metadata tokens might
    ' change. The new token values can be discovered by compiling the example
    ' and examining the assembly with Ildasm.exe, using the /TOKENS option. 
    ' Recompile the program after correcting the token values. 
    Enum Tokens
        Case1 = &H2B000003
        Case2 = &HA00001F
        Case3 = &H2B000004
        Case4 = &H6000017
        Case5 = &H2B000004
    End Enum 


    Class G1(Of Tg1)

        Public Sub GM1(Of Tgm1) (ByVal param1 As Tg1, ByVal param2 As Tgm1)
        End Sub

        Public Sub M1(ByVal param As Tg1)
        End Sub
    End Class

    Class G2(Of Tg2)
    
        Public Sub GM2(Of Tgm2) (ByVal param1 As Tg2, ByVal param2 As Tgm2)
        
            ' Case 1: A generic method call that depends on its generic 
            ' context, because it uses the type parameters of the enclosing
            ' generic type G2 and the enclosing generic method GM2. The token 
            ' for the MethodSpec is Tokens.Case1.
            Dim g As New G1(Of Tg2)()
            g.GM1(Of Tgm2)(param1, param2)

            ' Case 2: A non-generic method call that depends on its generic 
            ' context, because it uses the type parameter of the enclosing
            ' generic type G2. The token for the MemberRef is Tokens.Case2.
            g.M1(param1)

            ' Case 3: A generic method call that does not depend on its generic 
            ' context, because it does not use type parameters of the enclosing
            ' generic type or method. The token for the MethodSpec is Tokens.Case3.
            Dim gi As New G1(Of Integer)()
            gi.GM1(Of Object)(42, New Object())

            ' Case 4: A non-generic method call that does not depend on its 
            ' generic context, because it does not use the type parameters of the
            ' enclosing generic type or method. The token for the MethodDef is 
            ' Tokens.Case4.
            Dim e As New Example()
            e.M()
        End Sub 
    End Class

    Class Example
        Public Sub M() 
            Dim g As New G1(Of Integer)()
            ' Case 5: A generic method call that does not have any generic 
            ' context. The token for the MethodSpec is Tokens.Case5.
            g.GM1(Of Object)(42, New Object())
        End Sub 
    
        Shared Sub Main() 
            Dim m As [Module] = GetType(Example).Assembly.ManifestModule
            Dim miResolved2 As MethodInfo = Nothing
        
            ' Case 1: A generic method call that is dependent on its generic context.
            '
            ' Create and display a MethodInfo representing the MethodSpec of the 
            ' generic method g.GM1(Of Tgm2)() that is called in G2(Of Tg2).GM2(Of Tgm2)().
            Dim t As Type = GetType(G1(Of )).MakeGenericType(GetType(G2(Of )).GetGenericArguments())
            Dim mi As MethodInfo = GetType(G2(Of )).GetMethod("GM2")
            Dim miTest As MethodInfo = t.GetMethod("GM1").MakeGenericMethod(mi.GetGenericArguments())
            Console.WriteLine(vbCrLf & "Case 1:" & vbCrLf & miTest.ToString())
        
            ' Resolve the MethodSpec token for method G1(Of Tg2).GM1(Of Tgm2)(), which 
            ' is called in method G2(Of Tg2).GM2(Of Tgm2)(). The GetGenericArguments 
            ' method must be used to obtain the context for resolving the method.
            Dim miResolved As MethodInfo = CType(m.ResolveMethod( _
                    CInt(Tokens.Case1), _
                    GetType(G2(Of )).GetGenericArguments(), _
                    GetType(G2(Of )).GetMethod("GM2").GetGenericArguments()), _
                MethodInfo)
            Console.WriteLine(miResolved)
            Console.WriteLine("Is the resolved method the same? {0}", miResolved Is miTest)
        
            ' The overload that doesn't specify generic context throws an exception
            ' because there is insufficient context to resolve the token.
            Try
                miResolved2 = CType(m.ResolveMethod(CInt(Tokens.Case1)), MethodInfo)
            Catch ex As Exception
                Console.WriteLine("{0}: {1}", ex.GetType(), ex.Message)
            End Try
        
        
            ' Case 2: A non-generic method call that is dependent on its generic context.
            '
            ' Create and display a MethodInfo representing the MemberRef of the 
            ' non-generic method g.M1() that is called in G2(Of Tg2).GM2(Of Tgm2)().
            t = GetType(G1(Of )).MakeGenericType(GetType(G2(Of )).GetGenericArguments())
            miTest = t.GetMethod("M1")
            Console.WriteLine(vbCrLf & "Case 2:" & vbCrLf & miTest.ToString())
        
            ' Resolve the MemberRef token for method G1(Of Tg2).M1(), which is
            ' called in method G2(Of Tg2).GM2(Of Tgm2)(). The GetGenericArguments 
            ' method must be used to obtain the context for resolving the method, 
            ' because the method parameter comes from the generic type G1, and the 
            ' because argument, Tg2, comes from the generic type that encloses the 
            ' call. There is no enclosing generic method, so Type.EmptyTypes could
            ' be passed for the genericMethodArguments parameter.
            miResolved = CType(m.ResolveMethod( _
                    CInt(Tokens.Case2), _
                    GetType(G2(Of )).GetGenericArguments(), _
                    GetType(G2(Of )).GetMethod("GM2").GetGenericArguments()), _
                MethodInfo)
            Console.WriteLine(miResolved)
            Console.WriteLine("Is the resolved method the same? {0}", miResolved Is miTest)
        
            ' The overload that doesn't specify generic context throws an exception
            ' because there is insufficient context to resolve the token.
            Try
                miResolved2 = CType(m.ResolveMethod(CInt(Tokens.Case2)), MethodInfo)
            Catch ex As Exception
                Console.WriteLine("{0}: {1}", ex.GetType(), ex.Message)
            End Try
        
        
            ' Case 3: A generic method call that is independent of its generic context.
            '
            ' Create and display a MethodInfo representing the MethodSpec of the 
            ' generic method gi.GM1(Of Object)() that is called in G2(Of Tg2).GM2(Of Tgm2)().
            mi = GetType(G1(Of Integer)).GetMethod("GM1")
            miTest = mi.MakeGenericMethod(New Type() {GetType(Object)})
            Console.WriteLine(vbCrLf & "Case 3:" & vbCrLf & miTest.ToString())
        
            ' Resolve the token for method G1(Of Integer).GM1(Of Object)(), which is 
            ' calledin G2(Of Tg2).GM2(Of Tgm2)(). The GetGenericArguments method is  
            ' used to obtain the context for resolving the method, but the method call
            ' in this case does not use type parameters of the enclosing type or
            ' method, so Type.EmptyTypes could be used for both arguments.
            miResolved = CType(m.ResolveMethod( _
                    CInt(Tokens.Case3), _
                    GetType(G2(Of )).GetGenericArguments(), _
                    GetType(G2(Of )).GetMethod("GM2").GetGenericArguments()), _
                MethodInfo)
            Console.WriteLine(miResolved)
            Console.WriteLine("Is the resolved method the same? {0}", miResolved Is miTest)
        
            ' The method call in this case does not depend on the enclosing generic
            ' context, so the token can also be resolved by the simpler overload.
            miResolved2 = CType(m.ResolveMethod(CInt(Tokens.Case3)), MethodInfo)
        
        
            ' Case 4: A non-generic method call that is independent of its generic context.
            '
            ' Create and display a MethodInfo representing the MethodDef of the 
            ' method e.M() that is called in G2(Of Tg2).GM2(Of Tgm2)().
            miTest = GetType(Example).GetMethod("M")
            Console.WriteLine(vbCrLf & "Case 4:" & vbCrLf & miTest.ToString())
        
            ' Resolve the token for method Example.M(), which is called in
            ' G2(Of Tg2).GM2(Of Tgm2)(). The GetGenericArguments method is used to 
            ' obtain the context for resolving the method, but the non-generic 
            ' method call does not use type parameters of the enclosing type or
            ' method, so Type.EmptyTypes could be used for both arguments.
            miResolved = CType(m.ResolveMethod( _
                    CInt(Tokens.Case4), _
                    GetType(G2(Of )).GetGenericArguments(), _
                    GetType(G2(Of )).GetMethod("GM2").GetGenericArguments()), _
                MethodInfo)
            Console.WriteLine(miResolved)
            Console.WriteLine("Is the resolved method the same? {0}", miResolved Is miTest)
        
            ' The method call in this case does not depend on any enclosing generic
            ' context, so the token can also be resolved by the simpler overload.
            miResolved2 = CType(m.ResolveMethod(CInt(Tokens.Case4)), MethodInfo)
        
        
            ' Case 5: Generic method call in a non-generic context.
            '
            ' Create and display a MethodInfo representing the MethodRef of the 
            ' closed generic method g.GM1(Of Object)() that is called in Example.M().
            mi = GetType(G1(Of Integer)).GetMethod("GM1")
            miTest = mi.MakeGenericMethod(New Type() {GetType(Object)})
            Console.WriteLine(vbCrLf & "Case 5:" & vbCrLf & miTest.ToString())
        
            ' Resolve the token for method G1(Of Integer).GM1(Of Object)(), which is 
            ' called in method Example.M(). The GetGenericArguments method is used to 
            ' obtain the context for resolving the method, but the enclosing type
            ' and method are not generic, so Type.EmptyTypes could be used for
            ' both arguments.
            miResolved = CType(m.ResolveMethod( _
                    CInt(Tokens.Case5), _
                    GetType(Example).GetGenericArguments(), _
                    GetType(Example).GetMethod("M").GetGenericArguments()), _
                MethodInfo)
            Console.WriteLine(miResolved)
            Console.WriteLine("Is the resolved method the same? {0}", miResolved Is miTest)
        
            ' The method call in this case does not depend on any enclosing generic
            ' context, so the token can also be resolved by the simpler overload.
            miResolved2 = CType(m.ResolveMethod(CInt(Tokens.Case5)), MethodInfo)
    
        End Sub 
    End Class 
End Namespace

' This example produces the following output:
'
'Case 1:
'Void GM1[Tgm2](Tg2, Tgm2)
'Void GM1[Tgm2](Tg2, Tgm2)
'Is the resolved method the same? True
'System.ArgumentException: A BadImageFormatException has been thrown while parsing the signature. This is likely due to lack of a generic context. Ensure genericTypeArguments and genericMethodArguments are provided and contain enough context.
'
'Case 2:
'Void M1(Tg2)
'Void M1(Tg2)
'Is the resolved method the same? True
'System.ArgumentException: A BadImageFormatException has been thrown while parsing the signature. This is likely due to lack of a generic context. Ensure genericTypeArguments and genericMethodArguments are provided and contain enough context.
'
'Case 3:
'Void GM1[Object](Int32, System.Object)
'Void GM1[Object](Int32, System.Object)
'Is the resolved method the same? True
'
'Case 4:
'Void M()
'Void M()
'Is the resolved method the same? True
'
'Case 5:
'Void GM1[Object](Int32, System.Object)
'Void GM1[Object](Int32, System.Object)
'Is the resolved method the same? True
' 
'</Snippet1>