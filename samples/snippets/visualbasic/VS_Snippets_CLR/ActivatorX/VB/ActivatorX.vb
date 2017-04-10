'Types:System.Activator Vendor: Richter
'<snippet1>
Imports System.Reflection
Imports System.Text

Module Module1
    Sub Main()
        '<snippet2> 
        ' Create an instance of the StringBuilder type using 
        ' Activator.CreateInstance.
        Dim o As Object = Activator.CreateInstance(GetType(StringBuilder))

        ' Append a string into the StringBuilder object and display the 
        ' StringBuilder.
        Dim sb As StringBuilder = CType(o, StringBuilder)
        sb.Append("Hello, there.")
        Console.WriteLine(sb)
        '</snippet2>

        '<snippet3>
        ' Create an instance of the SomeType class that is defined in this assembly.
        Dim oh As System.Runtime.Remoting.ObjectHandle = _
            Activator.CreateInstanceFrom(Assembly.GetEntryAssembly().CodeBase, _
                                         GetType(SomeType).FullName)

        ' Call an instance method defined by the SomeType type using this object.
        Dim st As SomeType = CType(oh.Unwrap(), SomeType)

        st.DoSomething(5)
        '</snippet3>
    End Sub

    Class SomeType
        Public Sub DoSomething(ByVal x As Int32)
            Console.WriteLine("100 / {0} = {1}", x, 100 \ x)
        End Sub
    End Class
End Module

' This code produces the following output:
' 
' Hello, there.
' 100 / 5 = 20
'</snippet1>
