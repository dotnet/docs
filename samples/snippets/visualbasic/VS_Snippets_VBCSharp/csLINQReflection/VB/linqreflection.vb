'<snippet1>
Imports System.Reflection
Imports System.IO
Imports System.Linq
Module Module1

    Sub Main()
        Dim asmbly As Assembly = 
            Assembly.Load("System.Core, Version=3.5.0.0, Culture=neutral, PublicKeyToken= b77a5c561934e089")

        Dim pubTypesQuery = From type In asmbly.GetTypes() 
                            Where type.IsPublic 
                            From method In type.GetMethods() 
                            Where method.ReturnType.IsArray = True 
                            Let name = method.ToString() 
                            Let typeName = type.ToString() 
                            Group name By typeName Into methodNames = Group


        Console.WriteLine("Getting ready to iterate")
        For Each item In pubTypesQuery
            Console.WriteLine(item.methodNames)

            For Each type In item.methodNames
                Console.WriteLine(" " & type)
            Next
        Next
        Console.ReadKey()
    End Sub

End Module
'</snippet1>

'Dim pubTypesQuery = From typ In asmbly.GetTypes() 
'                    Where typ.IsPublic = True 
'                    Let typMethods = From m In typ.GetMethods() 
'                                     Where m.IsPublic = True 
'                                     Select m.Name 
'                    Group By namespace = typ.Namespace Into types = Group 
'                    Select New With {.Name = typ.Name, .Methods = 
'                                        }
