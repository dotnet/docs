Dim uBuild As New UriBuilder("http://www.contoso.com/")
uBuild.Path = "index.htm"
uBuild.Fragment = "main"
        
Dim myUri As Uri = uBuild.Uri
