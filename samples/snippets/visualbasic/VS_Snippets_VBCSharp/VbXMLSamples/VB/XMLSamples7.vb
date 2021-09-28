' Topic: XML Value Property

Public Class Samples7
    Public Shared Sub Main()

        '<Snippet15>
    Dim contact As XElement = 
        <contact>
            <name>Patrick Hines</name>
            <phone type="home">206-555-0144</phone>
            <phone type="work">425-555-0145</phone>
        </contact>

    Console.WriteLine("Phone number: " & contact.<phone>.Value)
        '</Snippet15>

    End Sub

    Public Shared Sub Main0()

        '<Snippet16>
    Dim contact As XElement = 
        <contact>
          <name>Patrick Hines</name>
          <phone type="home">206-555-0144</phone>
          <phone type="work">425-555-0145</phone>
        </contact>


    Dim types = contact.<phone>.Attributes("type")

    For Each attr In types
      Console.WriteLine(attr.Value)
    Next
        '</Snippet16>
    End Sub

    Public Shared Sub Main1()
        ' Topic: XML Child Axis Property
        '<Snippet17>
        Dim contact As XElement = 
            <contact>
                <name>Patrick Hines</name>
                <phone type="home">206-555-0144</phone>
                <phone type="work">425-555-0145</phone>
            </contact>

        Dim homePhone = From hp In contact.<phone> 
                        Where contact.<phone>.@type = "home" 
                        Select hp

        Console.WriteLine("Home Phone = {0}", homePhone(0).Value)
        '</Snippet17>
    End Sub

    Public Shared Sub Main2()
        '<Snippet18>  
        Dim contacts As XElement = 
            <contacts>
                <contact>
                    <name>Patrick Hines</name>
                    <phone type="home">206-555-0144</phone>
                </contact>
                <contact>
                    <name>Lance Tucker</name>
                    <phone type="work">425-555-0145</phone>
                </contact>
            </contacts>

        Dim homePhone = From contact In contacts.<contact> 
                        Where contact.<phone>.@type = "home" 
                        Select contact.<phone>

        Console.WriteLine("Home Phone = {0}", homePhone(0).Value)
        '</Snippet18>

    End Sub
End Class