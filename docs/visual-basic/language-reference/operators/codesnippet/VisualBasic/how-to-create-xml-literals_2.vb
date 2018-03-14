        Dim libraryRequest As XDocument = 
            <?xml version="1.0" encoding="UTF-8" standalone="yes"?>
            <?xml-stylesheet type="text/xsl" href="show_book.xsl"?>
            <!-- Tests that the application works. -->
            <books>
                <book/>
            </books>
        Console.WriteLine(libraryRequest)