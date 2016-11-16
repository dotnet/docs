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