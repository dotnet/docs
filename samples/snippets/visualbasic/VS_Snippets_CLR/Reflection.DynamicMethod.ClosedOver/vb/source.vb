' REDMOND\glennha
'<Snippet1>
Imports System
Imports System.Reflection
Imports System.Reflection.Emit

' These classes are for demonstration purposes.
'
Public Class Example
    Private _id As Integer = 0
    
    Public Sub New(ByVal newId As Integer) 
        _id = newId    
    End Sub
    
    Public ReadOnly Property ID() As Integer 
        Get
            Return _id
        End Get
    End Property 
End Class

Public Class DerivedFromExample
    Inherits Example
    
    Public Sub New(ByVal newId As Integer) 
        MyBase.New(newId)
    End Sub
End Class
 
' Two delegates are declared: UseLikeInstance treats the dynamic
' method as if it were an instance method, and UseLikeStatic
' treats the dynamic method in the ordinary fashion.
' 
Public Delegate Function UseLikeInstance(ByVal newID As Integer) _
    As Integer 
Public Delegate Function UseLikeStatic(ByVal ex As Example, _
    ByVal newID As Integer) As Integer 

Public Class Demo
    
    Public Shared Sub Main() 
        ' This dynamic method changes the private _id field. It 
        ' has no name; it returns the old _id value (return type 
        ' Integer); it takes two parameters, an instance of Example 
        ' and an Integer that is the new value of _id; and it is 
        ' declared with Example as the owner type, so it can 
        ' access all members, public and private.
        '
        Dim changeID As New DynamicMethod( _
            "", _
            GetType(Integer), _
            New Type() {GetType(Example), GetType(Integer)}, _
            GetType(Example) _
        )
        
        ' Get a FieldInfo for the private field '_id'.
        Dim fid As FieldInfo = GetType(Example).GetField( _
            "_id", _
            BindingFlags.NonPublic Or BindingFlags.Instance _
        )
        
        Dim ilg As ILGenerator = changeID.GetILGenerator()
        
        ' Push the current value of the id field onto the 
        ' evaluation stack. It's an instance field, so load the
        ' instance of Example before accessing the field.
        ilg.Emit(OpCodes.Ldarg_0)
        ilg.Emit(OpCodes.Ldfld, fid)
        
        ' Load the instance of Example again, load the new value 
        ' of id, and store the new field value. 
        ilg.Emit(OpCodes.Ldarg_0)
        ilg.Emit(OpCodes.Ldarg_1)
        ilg.Emit(OpCodes.Stfld, fid)
        
        ' The original value of the id field is now the only 
        ' thing on the stack, so return from the call.
        ilg.Emit(OpCodes.Ret)
        
        
        ' Create a delegate that uses changeID in the ordinary
        ' way, as a static method that takes an instance of
        ' Example and an Integer.
        '
        Dim uls As UseLikeStatic = CType( _
            changeID.CreateDelegate(GetType(UseLikeStatic)), _
            UseLikeStatic _
        )
        
        ' Create an instance of Example with an id of 42.
        '
        Dim ex As New Example(42)
        
        ' Create a delegate that is bound to the instance of 
        ' of Example. This is possible because the first 
        ' parameter of changeID is of type Example. The 
        ' delegate has all the parameters of changeID except
        ' the first.
        Dim uli As UseLikeInstance = CType( _
            changeID.CreateDelegate( _
                GetType(UseLikeInstance), _
                ex), _
            UseLikeInstance _
        )
        
        ' First, change the value of _id by calling changeID as
        ' a static method, passing in the instance of Example.
        '
        Console.WriteLine( _
            "Change the value of _id; previous value: {0}", _
            uls(ex, 1492) _
        )
        
        ' Change the value of _id again using the delegate 
        ' bound to the instance of Example.
        '
        Console.WriteLine( _
            "Change the value of _id; previous value: {0}", _
            uli(2700) _
        )
        
        Console.WriteLine("Final value of _id: {0}", ex.ID)
    

        ' Now repeat the process with a class that derives
        ' from Example.
        '
        Dim dfex As New DerivedFromExample(71)

        uli = CType( _
            changeID.CreateDelegate( _
                GetType(UseLikeInstance), _
                dfex), _
            UseLikeInstance _
        )

        Console.WriteLine( _
            "Change the value of _id; previous value: {0}", _
            uls(dfex, 73) _
        )
        Console.WriteLine( _
            "Change the value of _id; previous value: {0}", _
            uli(79) _
        )
        Console.WriteLine("Final value of _id: {0}", dfex.ID)

    End Sub
End Class

' This code example produces the following output:
'
'Change the value of _id; previous value: 42
'Change the value of _id; previous value: 1492
'Final value of _id: 2700
'Change the value of _id; previous value: 71
'Change the value of _id; previous value: 73
'Final value of _id: 79' 
'</Snippet1>