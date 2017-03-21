        public Authorization Authenticate( string challenge,WebRequest request,ICredentials credentials)
        {
            try
            {
                string message;
                // Check if Challenge string was raised by a site which requires 'CloneBasic' authentication.
                if ((challenge == null) || (!challenge.StartsWith("CloneBasic")))
                    return null; 
                NetworkCredential myCredentials;
                if (credentials is CredentialCache)
                {
                    myCredentials = credentials.GetCredential(request.RequestUri,"CloneBasic");
                    if (myCredentials == null)
                        return null;
                }
                else    
                    myCredentials = (NetworkCredential)credentials;  
                // Message encryption scheme : 
                //   a)Concatenate username and password seperated by space;
                //   b)Apply ASCII encoding to obtain a stream of bytes;
                //   c)Apply Base64 Encoding to this array of bytes to obtain our encoded authorization message.
                 
                message = myCredentials.UserName + " " + myCredentials.Password;
                // Apply AsciiEncoding to 'message' string to obtain it as an array of bytes.
                Encoding ascii = Encoding.ASCII;
                byte[] byteArray = new byte[ascii.GetByteCount(message)];
                byteArray = ascii.GetBytes(message);

                // Performing Base64 transformation.
                message = Convert.ToBase64String(byteArray);
                Authorization myAuthorization = new Authorization("CloneBasic " + message,true);
                string[] protectionRealm = new string[]{request.RequestUri.AbsolutePath};
                myAuthorization.ProtectionRealm = protectionRealm;

                return myAuthorization;
            }
            catch(Exception e)
            {
                Console.WriteLine("The following exception was raised in Authenticate method:{0}",e.Message);
                return null;
            }
          }