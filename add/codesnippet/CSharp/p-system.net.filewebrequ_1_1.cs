                // Create a Uri object. 
                Uri myUrl = new Uri ("file://" + fileName);

                // Create a FileWebRequest object.
                myFileWebRequest = (FileWebRequest)WebRequest.CreateDefault (myUrl);

                // Set the time-out to the value selected by the user.
                myFileWebRequest.Timeout = timeout;

                // Set the Method property to POST  
                myFileWebRequest.Method = "POST";