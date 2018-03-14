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