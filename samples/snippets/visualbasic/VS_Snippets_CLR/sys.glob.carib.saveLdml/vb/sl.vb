'<snippet1>
' This example demonstrates the CultureAndRegionInfoBuilder.Save and 
' CreateFromLdml methods.
' Compile this example with a reference to sysglobl.dll.

Imports System
Imports System.Globalization
Imports System.IO
Imports System.Xml

Class Sample
    Public Shared Sub Main() 
        Dim savedCARIB As String = "mySavedCARIB.xml"
        Dim msg1 As String = "The name of the original CultureAndRegionInfoBuilder" & _
                             " is ""{0}""."
        Dim msg2 As String = "Reconstituting the CultureAndRegionInfoBuilder object " & _
                             "from ""{0}""."
        Dim msg3 As String = "The name of the reconstituted CultureAndRegionInfoBuilder" & _
                             " is ""{0}""."

        ' Construct a new, privately used culture that extends the en-US culture 
        ' provided by the .NET Framework. In this sample, the CultureAndRegion-
        ' Types.Specific parameter creates a minimal CultureAndRegionInfoBuilder 
        ' object that you must populate with culture and region information.

        Dim cib1 As CultureAndRegionInfoBuilder = Nothing
        Dim cib2 As CultureAndRegionInfoBuilder = Nothing
        
        Try
            cib1 = New CultureAndRegionInfoBuilder("x-en-US-sample", _
                                        CultureAndRegionModifiers.None)
        Catch ae As ArgumentException
            Console.WriteLine(ae)
            Return
        End Try
        
        ' Populate the new CultureAndRegionInfoBuilder object with culture information.
        Dim ci As New CultureInfo("en-US")
        cib1.LoadDataFromCultureInfo(ci)
        
        ' Populate the new CultureAndRegionInfoBuilder object with region information.
        Dim ri As New RegionInfo("US")
        cib1.LoadDataFromRegionInfo(ri)
        
        ' Display a property of the new custom culture.
        Console.Clear()
        Console.WriteLine(msg1, cib1.CultureName)
        
        ' Save the new CultureAndRegionInfoBuilder object in the specified file in
        ' LDML format. The file is saved in the same directory as the application 
        ' that calls the Save method.

        Console.WriteLine("Saving the custom culture to a file...")
        Try
            cib1.Save(savedCARIB)
        Catch exc As IOException
            Console.WriteLine("** I/O exception: {0}", exc.Message)
            Return
        End Try
        
        ' Create a new CultureAndRegionInfoBuilder object from the persisted file.
        Console.WriteLine(msg2, savedCARIB)
        Try
            cib2 = CultureAndRegionInfoBuilder.CreateFromLdml(savedCARIB)
        Catch xe As XmlException
            Console.WriteLine("** XML validation exception: {0}", xe.Message)
            Return
        End Try
        
        ' Display a property of the resonstituted custom culture.
        Console.WriteLine(msg3, cib2.CultureName)

        ' At this point you could call the Register method and make the reconstituted
        ' custom culture available to other applications. The mySavedCARIB.xml file
        ' remains on your computer.

    End Sub 'Main ' 
End Class 'Sample

'This code example produces the following results:
'
'The name of the original CultureAndRegionInfoBuilder is "x-en-US-sample".
'Saving the custom culture to a file...
'Reconstituting the CultureAndRegionInfoBuilder object from "mySavedCARIB.xml".
'The name of the reconstituted CultureAndRegionInfoBuilder is "x-en-US-sample".
'
'</snippet1>