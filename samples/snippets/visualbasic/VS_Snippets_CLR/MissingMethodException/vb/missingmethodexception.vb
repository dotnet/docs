'Types:System.MissingMethodException Vendor: Richter
'Types:System.MissingMemberException Vendor: Richter
'Types:System.MissingFieldException Vendor: Richter
'<snippet1>
Imports System
Imports System.Reflection

Public Class App
    Public Shared Sub Main() 
        '<snippet2>
        Try
            ' Attempt to call a static DoSomething method defined in the App class.
            ' However, because the App class does not define this method, 
            ' a MissingMethodException is thrown.
            GetType(App).InvokeMember("DoSomething", BindingFlags.Static Or BindingFlags.InvokeMethod, _
                                       Nothing, Nothing, Nothing)
        Catch e As MissingMethodException
            ' Show the user that the DoSomething method cannot be called.
            Console.WriteLine("Unable to call the DoSomething method: {0}", e.Message)
        End Try
        '</snippet2>    
        '<snippet3>
        Try
            ' Attempt to access a static AField field defined in the App class.
            ' However, because the App class does not define this field, 
            ' a MissingFieldException is thrown.
            GetType(App).InvokeMember("AField", BindingFlags.Static Or BindingFlags.SetField, _
                                       Nothing, Nothing, New [Object]() {5})
        Catch e As MissingFieldException
            ' Show the user that the AField field cannot be accessed.
            Console.WriteLine("Unable to access the AField field: {0}", e.Message)
        End Try
        '</snippet3>    
        '<snippet4>
        Try
            ' Attempt to access a static AnotherField field defined in the App class.
            ' However, because the App class does not define this field, 
            ' a MissingFieldException is thrown.
            GetType(App).InvokeMember("AnotherField", BindingFlags.Static Or BindingFlags.GetField, _
                                       Nothing, Nothing, Nothing)
        Catch e As MissingMemberException
            ' Notice that this code is catching MissingMemberException which is the  
            ' base class of MissingMethodException and MissingFieldException.
            ' Show the user that the AnotherField field cannot be accessed.
            Console.WriteLine("Unable to access the AnotherField field: {0}", e.Message)
        End Try
    End Sub 
    '</snippet4> 
End Class 
' This code example produces the following output:
'
' Unable to call the DoSomething method: Method 'App.DoSomething' not found.
' Unable to access the AField field: Field 'App.AField' not found.
' Unable to access the AnotherField field: Field 'App.AnotherField' not found.
'</snippet1>