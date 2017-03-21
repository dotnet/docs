            Uri myUri = new Uri(url);
				// Creates an HttpWebRequest for the specified URL. 
				HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(myUri); 
				HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
				if (myHttpWebResponse.StatusCode == HttpStatusCode.OK)
					Console.WriteLine("\r\nRequest succeeded and the requested information is in the response , Description : {0}",
										myHttpWebResponse.StatusDescription);
				DateTime today = DateTime.Now;
				// Uses the LastModified property to compare with today's date.
				if (DateTime.Compare(today,myHttpWebResponse.LastModified) == 0)
					Console.WriteLine("\nThe requested URI entity was modified today");
				else
					if (DateTime.Compare(today,myHttpWebResponse.LastModified) == 1)
						Console.WriteLine("\nThe requested URI was last modified on:{0}",
											myHttpWebResponse.LastModified);
				// Releases the resources of the response.
				myHttpWebResponse.Close(); 