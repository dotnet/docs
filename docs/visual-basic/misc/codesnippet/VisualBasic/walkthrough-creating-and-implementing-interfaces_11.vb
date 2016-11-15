        Sub Test()
            '  Create an instance of the class.
            Dim T As New ImplementationClass
            ' Assign the class instance to the interface.
            ' Calls to the interface members are 
            ' executed through the class instance.
            testInstance = T
            ' Set a property.
            testInstance.Prop1 = 9
            ' Read the property.
            MsgBox("Prop1 was set to " & testInstance.Prop1)
            '  Test the method and raise an event.
            testInstance.Method1(5)
        End Sub