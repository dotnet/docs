' Visual Basic .NET Document
Option Strict On

Imports System.Collections.Generic
Imports System.Text.RegularExpressions

Module Example
    Public Sub Main()
        InstantiateRegex()
        UseMatch()
        Console.WriteLine()
        UseMatchCollection()
        Console.WriteLine()
        UseGroupCollection()
        Console.WriteLine()
        UseCaptureCollection()
        Console.WriteLine()
        UseGroup()
        Console.WriteLine()
        UseCapture()
        Console.WriteLine()
        UseNamedGroups()
    End Sub

    Private Sub InstantiateRegex
        ' <Snippet1>
        ' Declare object variable of type Regex.
        Dim r As Regex
        ' Create a Regex object and define its regular expression.
        r = New Regex("\s2000")
        ' </Snippet1>
    End Sub

    Private Sub UseMatch()
        ' <Snippet2>
        ' Create a new Regex object.
        Dim r As New Regex("abc")
        ' Find a single match in the input string.
        Dim m As Match = r.Match("123abc456")
        If m.Success Then
            ' Print out the character position where a match was found. 
            Console.WriteLine("Found match at position " & m.Index.ToString())
        End If
        ' The example displays the following output:
        '       Found match at position 3      
        ' </Snippet2>
    End Sub

    Private Sub UseMatchCollection()
        ' <Snippet3>
        Dim mc As MatchCollection
        Dim results As New List(Of String)
        Dim matchposition As New List(Of Integer)

        ' Create a new Regex object and define the regular expression.
        Dim r As New Regex("abc")
        ' Use the Matches method to find all matches in the input string.
        mc = r.Matches("123abc4abcd")
        ' Loop through the match collection to retrieve all 
        ' matches and positions.
        For i As Integer = 0 To mc.Count - 1
            ' Add the match string to the string array.
            results.Add(mc(i).Value)
            ' Record the character position where the match was found.
            matchposition.Add(mc(i).Index)
        Next i
        ' List the results.
        For ctr As Integer = 0 To Results.Count - 1
            Console.WriteLine("'{0}' found at position {1}.", _
                              results(ctr), matchposition(ctr))
        Next
        ' The example displays the following output:
        '       'abc' found at position 3.
        '       'abc' found at position 7.
        ' </Snippet3>
    End Sub

    Public Sub UseGroupCollection
        ' <Snippet4>
        ' Define groups "abc", "ab", and "b".
        Dim r As New Regex("(a(b))c")
        Dim m As Match = r.Match("abdabc")
        Console.WriteLine("Number of groups found = " _
                          & m.Groups.Count)
        ' The example displays the following output:
        '       Number of groups found = 3
        ' </Snippet4>
    End Sub

    Private Sub UseCaptureCollection()
        ' <Snippet5>
        Dim counter As Integer
        Dim m As Match
        Dim cc As CaptureCollection
        Dim gc As GroupCollection

        ' Look for groupings of "Abc".
        Dim r As New Regex("(Abc)+")
        ' Define the string to search.
        m = r.Match("XYZAbcAbcAbcXYZAbcAb")
        gc = m.Groups

        ' Display the number of groups.
        Console.WriteLine("Captured groups = " & gc.Count.ToString())

        ' Loop through each group.
        Dim i, ii As Integer
        For i = 0 To gc.Count - 1
            cc = gc(i).Captures
            counter = cc.Count

            ' Display the number of captures in this group.
            Console.WriteLine("Captures count = " & counter.ToString())

            ' Loop through each capture in the group.            
            For ii = 0 To counter - 1
                ' Display the capture and its position.
                Console.WriteLine(cc(ii).ToString() _
                    & "   Starts at character " & cc(ii).Index.ToString())
            Next ii
        Next i
        ' The example displays the following output:
        '       Captured groups = 2
        '       Captures count = 1
        '       AbcAbcAbc   Starts at character 3
        '       Captures count = 3
        '       Abc   Starts at character 3
        '       Abc   Starts at character 6
        '       Abc   Starts at character 9  
        ' </Snippet5>
    End Sub

    Private Sub UseGroup()
        ' <Snippet6>
        Dim matchposition As New List(Of Integer)
        Dim results As New List(Of String)
        ' Define substrings abc, ab, b.
        Dim r As New Regex("(a(b))c")
        Dim m As Match = r.Match("abdabc")
        Dim i As Integer = 0
        While Not (m.Groups(i).Value = "")
            ' Add groups to string array.
            results.Add(m.Groups(i).Value)
            ' Record character position. 
            matchposition.Add(m.Groups(i).Index)
            i += 1
        End While

        ' Display the capture groups.
        For ctr As Integer = 0 to results.Count - 1
            Console.WriteLine("{0} at position {1}", _
                              results(ctr), matchposition(ctr))
        Next
        ' The example displays the following output:
        '       abc at position 3
        '       ab at position 3
        '       b at position 4
        ' </Snippet6>
    End Sub

    Private Sub UseCapture()
        ' <Snippet7>
        Dim r As Regex
        Dim m As Match
        Dim cc As CaptureCollection
        Dim posn, length As Integer

        r = New Regex("(abc)+")
        m = r.Match("bcabcabc")
        Dim i, j As Integer
        i = 0
        Do While m.Groups(i).Value <> ""
            Console.WriteLine(m.Groups(i).Value)
            ' Grab the Collection for Group(i).
            cc = m.Groups(i).Captures
            For j = 0 To cc.Count - 1

                Console.WriteLine("   Capture at position {0} for {1} characters.", _
                                  cc(j).Index, cc(j).Length)
                ' Position of Capture object.
                posn = cc(j).Index
                ' Length of Capture object.
                length = cc(j).Length
            Next j
            i += 1
        Loop
        ' The example displays the following output:
        '       abcabc
        '          Capture at position 2 for 6 characters.
        '       abc
        '          Capture at position 2 for 3 characters.
        '          Capture at position 5 for 3 characters.
        ' </Snippet7>
    End Sub

    Private Sub UseNamedGroups()
        ' <Snippet8>
        Dim r As New Regex("^(?<name>\w+):(?<value>\w+)")
        Dim m As Match = r.Match("Section1:119900")
        Console.WriteLine(m.Groups("name").Value)
        Console.WriteLine(m.Groups("value").Value)
        ' The example displays the following output:
        '       Section1
        '       119900
        ' </Snippet8>
    End Sub
End Module

