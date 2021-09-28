﻿' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Globalization

Module Example
    Public Sub Main()
        Dim values() As String = {"a tale of two cities", "gROWL to the rescue",
                                   "inside the US government", "sports and MLB baseball",
                                   "The Return of Sherlock Holmes", "UNICEF and children"}

        Dim ti As TextInfo = CultureInfo.CurrentCulture.TextInfo
        For Each value In values
            Console.WriteLine("{0} --> {1}", value, ti.ToTitleCase(value))
        Next
    End Sub
End Module
' The example displays the following output:
'    a tale of two cities --> A Tale Of Two Cities
'    gROWL to the rescue --> Growl To The Rescue
'    inside the US government --> Inside The US Government
'    sports and MLB baseball --> Sports And MLB Baseball
'    The Return of Sherlock Holmes --> The Return Of Sherlock Holmes
'    UNICEF and children --> UNICEF And Children
' </Snippet1>
