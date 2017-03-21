        ' Get the current UserControlBaseType property value.
        Console.WriteLine( _
            "Current UserControlBaseType value: '{0}'", _
            pagesSection.UserControlBaseType)

        ' Set the UserControlBaseType property to
        ' "MyNameSpace.MyCustomControlBaseType".
        pagesSection.UserControlBaseType = _
            "MyNameSpace.MyCustomControlBaseType"