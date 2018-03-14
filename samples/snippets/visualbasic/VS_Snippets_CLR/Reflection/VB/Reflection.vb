'Types: System.Reflection.Assembly Vendor:Richter
'Types: System.Reflection.AssemblyName Vendor:Richter
'Types: System.Reflection.MemberInfo Vendor:Richter
'Types: System.Reflection.Module Vendor:Richter
'Types: System.Reflection.ParameterInfo Vendor:Richter
'Types: System.Reflection.PropertyInfo Vendor:Richter
'<snippet1>
Imports System.Reflection

Module Module1
    Sub Main()
        ' This variable holds the amount of indenting that 
        ' should be used when displaying each line of information.
        Dim indent As Int32 = 0
	'<snippet2>
        ' Display information about the EXE assembly.
        Dim a As Assembly = GetType(Module1).Assembly
        Display(indent, "Assembly identity={0}", a.FullName)
        Display(indent + 1, "Codebase={0}", a.CodeBase)

        ' Display the set of assemblies our assemblies reference.
        Dim an As AssemblyName
        Display(indent, "Referenced assemblies:")
        For Each an In a.GetReferencedAssemblies()
            Display(indent + 1, "Name={0}, Version={1}, Culture={2}, PublicKey token={3}", _
                an.Name, an.Version, an.CultureInfo.Name, BitConverter.ToString(an.GetPublicKeyToken))
        Next
        '</snippet2>
        Display(indent, "")

        ' Display information about each assembly loading into this AppDomain.
        For Each a In AppDomain.CurrentDomain.GetAssemblies()
            Display(indent, "Assembly: {0}", a)

            ' Display information about each module of this assembly.
            Dim m As [Module]
            For Each m In a.GetModules(True)
                Display(indent + 1, "Module: {0}", m.Name)
            Next

            ' Display information about each type exported from this assembly.
            Dim t As Type
            indent += 1
            For Each t In a.GetExportedTypes()
                Display(0, "")
                Display(indent, "Type: {0}", t)

                ' For each type, show its members & their custom attributes.
                Dim mi As MemberInfo
                indent += 1
                For Each mi In t.GetMembers()
                    Display(indent, "Member: {0}", mi.Name)
                    DisplayAttributes(indent, mi)

                    ' If the member is a method, display information about its parameters.
                    Dim pi As ParameterInfo
                    If mi.MemberType = MemberTypes.Method Then
                        For Each pi In CType(mi, MethodInfo).GetParameters()
                            Display(indent + 1, "Parameter: Type={0}, Name={1}", pi.ParameterType, pi.Name)
                        Next
                    End If

                    ' If the member is a property, display information about the property's accessor methods.
                    If mi.MemberType = MemberTypes.Property Then
                        Dim am As MethodInfo
                        For Each am In CType(mi, PropertyInfo).GetAccessors()
                            Display(indent + 1, "Accessor method: {0}", am)
                        Next
                    End If
                Next
                indent -= 1
            Next
            indent -= 1
        Next
    End Sub

    ' Displays the custom attributes applied to the specified member.
    Sub DisplayAttributes(ByVal indent As Int32, ByVal mi As MemberInfo)
        ' Get the set of custom attributes; if none exist, just return.
        Dim attrs() As Object = mi.GetCustomAttributes(False)
        If attrs.Length = 0 Then Return

        ' Display the custom attributes applied to this member.
        Display(indent + 1, "Attributes:")
        Dim o As Object
        For Each o In attrs
            Display(indent + 2, "{0}", o.ToString())
        Next
    End Sub

    ' Display a formatted string indented by the specified amount.
    Sub Display(ByVal indent As Int32, ByVal format As String, ByVal ParamArray params() As Object)
        Console.Write(New String(" "c, indent * 2))
        Console.WriteLine(format, params)
    End Sub
End Module

'The output shown below is abbreviated.
'
'Assembly identity=Reflection, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
'  Codebase=file:///C:/Reflection.exe
'Referenced assemblies:
'  Name=mscorlib, Version=1.0.5000.0, Culture=, PublicKey token=B7-7A-5C-56-19-34-E0-89
'  Name=Microsoft.VisualBasic, Version=7.0.5000.0, Culture=, PublicKey token=B0-3F-5F-7F-11-D5-0A-3A
'
'Assembly: mscorlib, Version=1.0.5000.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
'  Module: mscorlib.dll
'  Module: prc.nlp
'  Module: prcp.nlp
'  Module: ksc.nlp
'  Module: ctype.nlp
'  Module: xjis.nlp
'  Module: bopomofo.nlp
'  Module: culture.nlp
'  Module: region.nlp
'  Module: sortkey.nlp
'  Module: charinfo.nlp
'  Module: big5.nlp
'  Module: sorttbls.nlp
'  Module: l_intl.nlp
'  Module: l_except.nlp
'
'  Type: System.Object
'    Member: GetHashCode
'    Member: Equals
'      Parameter: Type=System.Object, Name=obj
'    Member: ToString
'    Member: Equals
'      Parameter: Type=System.Object, Name=objA
'      Parameter: Type=System.Object, Name=objB
'    Member: ReferenceEquals
'      Parameter: Type=System.Object, Name=objA
'      Parameter: Type=System.Object, Name=objB
'    Member: GetType
'    Member: .ctor
'
'  Type: System.ICloneable
'    Member: Clone
'
'  Type: System.Collections.IEnumerable
'    Member: GetEnumerator
'      Attributes:
'        System.Runtime.InteropServices.DispIdAttribute
'
'  Type: System.Collections.ICollection
'    Member: get_IsSynchronized
'    Member: get_SyncRoot
'    Member: get_Count
'    Member: CopyTo
'      Parameter: Type=System.Array, Name=array
'      Parameter: Type=System.Int32, Name=index
'    Member: Count
'      Accessor method: Int32 get_Count()
'    Member: SyncRoot
'      Accessor method: System.Object get_SyncRoot()
'    Member: IsSynchronized
'      Accessor method: Boolean get_IsSynchronized()
'
'</snippet1>