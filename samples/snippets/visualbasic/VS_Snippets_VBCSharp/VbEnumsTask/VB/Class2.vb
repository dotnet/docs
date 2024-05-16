Public Class Class2

    '******************************************************************************
    '<Snippet31>
    Enum SecurityLevel
        IllegalEntry = -1
        MinimumSecurity = 0
        MaximumSecurity = 1
    End Enum
    '</Snippet31>


    '******************************************************************************
    '<Snippet30>
    Public Enum InterfaceColors
        MistyRose = &HE1E4FF&
        SlateGray = &H908070&
        DodgerBlue = &HFF901E&
        DeepSkyBlue = &HFFBF00&
        SpringGreen = &H7FFF00&
        ForestGreen = &H228B22&
        Goldenrod = &H20A5DA&
        Firebrick = &H2222B2&
    End Enum
    '</Snippet30>


    '******************************************************************************
    '<Snippet28>
    Enum filePermissions
        create = 1
        read = 2
        write = 4
        delete = 8
    End Enum
    '</Snippet28>


    '******************************************************************************
    Sub TestRefer2()
        Dim X As Integer
        Dim Y As Integer

        '<Snippet29>
        Dim file1Perm As filePermissions
        file1Perm = filePermissions.create Or filePermissions.read
        '</Snippet29>

        '<Snippet26>
        X = Days.Saturday
        '</Snippet26>

        '<Snippet27>
        Y = WorkDays.Saturday
        '</Snippet27>

        '<Snippet32>
        X = Days.Saturday
        Y = WorkDays.Saturday
        '</Snippet32>
    End Sub


    '******************************************************************************
    Sub TestRefer()
        Dim X As Integer

        '<Snippet18>
        X = Days.Sunday
        '</Snippet18>

        Dim DayValue As Integer

        '<Snippet19>
        DayValue = FirstDayOfWeek.Saturday
        '</Snippet19>
    End Sub


    '******************************************************************************
    Class CircularA
        Public Const conB = 1

        '<Snippet16>
        Public Const conA = conB * 2
        '</Snippet16>
    End Class

    Class CircularB
        Public Const conA = 1

        '<Snippet17>
        Public Const conB = conA / 2
        '</Snippet17>
    End Class


    '******************************************************************************
    Class Consts
        '<Snippet10>
        Const conPi = 3.14159265358979
        Public Const conMaxPlanets As Integer = 9
        Const conReleaseDate = #1/1/1995#
        '</Snippet10>

        '<Snippet13>
        Public Const conVersion = "07.10.A"
        Const conCodeName = "Enigma"
        '</Snippet13>

        '<Snippet15>
        Const conPi2 = conPi * 2
        '</Snippet15>


        Class WrapConsts
            '<Snippet11>
            Public Const conMaxPlanets As Integer = 9
            '</Snippet11>

            '<Snippet12>
            Const conReleaseDate = #1/1/1995#
            '</Snippet12>

            '<Snippet14>
            Const conCodeName = "Enigma"
            '</Snippet14>
        End Class
    End Class


    '******************************************************************************
    ' HowtoGroupRelatedConstantValuesTogether
    ' <snippet1>
    Public Enum temperatureValues
        Scorching
        Hot
        Lukewarm
        Cool
        Cold
    End Enum
    ' </snippet1>


    '******************************************************************************
    Class WrapTemp
        '<Snippet20>
        '<Snippet21>
        Private Enum temperatureValues
            '</Snippet21>
            Scorching
            Hot
            Lukewarm
            Cool
            Cold
        End Enum
        '</Snippet20>
    End Class

    '******************************************************************************
    ' HowtoDetermineTheStringAssociatedWithAnEnumerationValue
    ' <snippet2>
    Public Enum flavorEnum
        salty
        sweet
        sour
        bitter
    End Enum

    Private Sub TestMethod()
        MsgBox("The strings in the flavorEnum are:")
        Dim i As String
        For Each i In [Enum].GetNames(GetType(flavorEnum))
            MsgBox(i)
        Next
    End Sub
    ' </snippet2>


    '******************************************************************************
    ' HowtoDeclareEnumerations
    ' <snippet3>
    Private Enum SampleEnum
        SampleMember
    End Enum
    Public Enum SampleEnum2
        SampleMember
    End Enum
    Protected Enum SampleEnum3
        SampleMember
    End Enum
    Friend Enum SampleEnum4
        SampleMember
    End Enum
    Protected Friend Enum SampleEnum5
        SampleMember
    End Enum
    ' </snippet3>

    ' <snippet4>
    Public Enum Days
        Sunday
        Monday
        Tuesday
        Wednesday
        Thursday
        Friday
        Saturday
    End Enum
    ' </snippet4>

    ' <snippet5>
    Public Enum WorkDays
        Saturday
        Sunday = 0
        Monday
        Tuesday
        Wednesday
        Thursday
        Friday
        Invalid = -1
    End Enum
    ' </snippet5>

    ' <snippet6>
    Public Enum MyEnum As Byte
        Zero
        One
        Two
    End Enum
    ' </snippet6>


    '******************************************************************************
    ' HowtoIterateThroughAnEnumerationInVisualBasic
    Public Sub Method7()
        ' <snippet7>
        Dim items As Array
        items = System.Enum.GetValues(GetType(FirstDayOfWeek))
        Dim item As String
        For Each item In items
            MsgBox(item)
        Next
        ' </snippet7>
    End Sub


    '******************************************************************************
    ' HowtoDeclareAConstant
    Class Wrapper
        ' <snippet8>
        Public Const DaysInYear = 365
        Private Const WorkDays = 250
        ' </snippet8>
    End Class


    '******************************************************************************
    ' <snippet9>
    Public Const MyInteger As Integer = 42
    Private Const DaysInWeek As Short = 7
    Protected Friend Const Funday As String = "Sunday"
    ' </snippet9>
End Class
