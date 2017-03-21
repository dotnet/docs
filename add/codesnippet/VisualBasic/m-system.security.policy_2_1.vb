            Dim oa1() As [Object]
            Dim site As New Site("www.wideworldimporters.com")
            Dim oa2 As [Object]() = {url, site}
            Dim ev3a As New Evidence(oa1, oa2)
            enum1 = ev3a.GetHostEnumerator()
            Dim enum2 As IEnumerator = ev3a.GetAssemblyEnumerator()
            enum2.MoveNext()
            Dim obj1 As [Object] = enum2.Current
            enum2.MoveNext()
            Console.WriteLine(("URL = " & obj1.ToString() & "  Site = " & enum2.Current.ToString()))