			UriBuilder baseUri = new UriBuilder("http://www.contoso.com/default.aspx?Param1=7890");
			string queryToAppend = "param2=1234";

			if (baseUri.Query != null && baseUri.Query.Length > 1)
				baseUri.Query = baseUri.Query.Substring(1) + "&" + queryToAppend; 
			else
				baseUri.Query = queryToAppend; 