    Dim contact As XElement = 
        <contact>
            <name>Patrick Hines</name>
            <phone type="home">206-555-0144</phone>
            <phone type="work">425-555-0145</phone>
        </contact>

    Console.WriteLine("Phone number: " & contact.<phone>.Value)