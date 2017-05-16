'<snippet1>
' This code example demonstrates members of the System.StringComparer class.

Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Globalization
Imports System.Threading

Class Sample
    
    Public Shared Sub Main() 
        ' Create a list of string.
        Dim list As New List(Of String) 
        
        ' Get the tr-TR (Turkish-Turkey) culture.
        Dim turkish As New CultureInfo("tr-TR")
        
        ' Get the culture that is associated with the current thread.
        Dim thisCulture As CultureInfo = Thread.CurrentThread.CurrentCulture
        
        ' Get the standard StringComparers.
        Dim invCmp As StringComparer = StringComparer.InvariantCulture
        Dim invICCmp As StringComparer = StringComparer.InvariantCultureIgnoreCase
        Dim currCmp As StringComparer = StringComparer.CurrentCulture
        Dim currICCmp As StringComparer = StringComparer.CurrentCultureIgnoreCase
        Dim ordCmp As StringComparer = StringComparer.Ordinal
        Dim ordICCmp As StringComparer = StringComparer.OrdinalIgnoreCase
        
        ' Create a StringComparer that uses the Turkish culture and ignores case.
        Dim turkICComp As StringComparer = StringComparer.Create(turkish, True)
        
        ' Define three strings consisting of different versions of the letter I.
        ' LATIN CAPITAL LETTER I (U+0049)
        Dim capitalLetterI As String = "I"
        
        ' LATIN SMALL LETTER I (U+0069)
        Dim smallLetterI As String = "i"
        
        ' LATIN SMALL LETTER DOTLESS I (U+0131)
        Dim smallLetterDotlessI As String = "ı"
        
        ' Add the three strings to the list.
        list.Add(capitalLetterI)
        list.Add(smallLetterI)
        list.Add(smallLetterDotlessI)
        
        ' Display the original list order.
        Display(list, "The original order of the list entries...")
        
        ' Sort the list using the invariant culture.
        list.Sort(invCmp)
        Display(list, "Invariant culture...")
        list.Sort(invICCmp)
        Display(list, "Invariant culture, ignore case...")
        
        ' Sort the list using the current culture.
        Console.WriteLine("The current culture is ""{0}"".", thisCulture.Name)
        list.Sort(currCmp)
        Display(list, "Current culture...")
        list.Sort(currICCmp)
        Display(list, "Current culture, ignore case...")
        
        ' Sort the list using the ordinal value of the character code points.
        list.Sort(ordCmp)
        Display(list, "Ordinal...")
        list.Sort(ordICCmp)
        Display(list, "Ordinal, ignore case...")
        
        ' Sort the list using the Turkish culture, which treats LATIN SMALL LETTER 
        ' DOTLESS I differently than LATIN SMALL LETTER I.
        list.Sort(turkICComp)
        Display(list, "Turkish culture, ignore case...")
    
    End Sub 'Main
    
    Public Shared Sub Display(ByVal lst As List(Of String), ByVal title As String)
        Dim c As Char
        Dim s As String
        Dim codePoint As Integer

        Console.WriteLine(title)
        For Each s In lst
            c = s(0)
            codePoint = Convert.ToInt32(c)
            Console.WriteLine("0x{0:x}", codePoint)
        Next s
        Console.WriteLine()
    End Sub 'Display
End Class 'Sample '

'This code example produces the following results:
'
'The original order of the list entries...
'0x49
'0x69
'0x131
'
'Invariant culture...
'0x69
'0x49
'0x131
'
'Invariant culture, ignore case...
'0x49
'0x69
'0x131
'
'The current culture is "en-US".
'Current culture...
'0x69
'0x49
'0x131
'
'Current culture, ignore case...
'0x49
'0x69
'0x131
'
'Ordinal...
'0x49
'0x69
'0x131
'
'Ordinal, ignore case...
'0x69
'0x49
'0x131
'
'Turkish culture, ignore case...
'0x131
'0x49
'0x69
'
'</snippet1>