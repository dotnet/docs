// System.Net.Authorization.Authorization(string,bool,string)

/* This program demonstrates the contructor 'Authorization(string,bool,string)' of the authorization 
 * class.
 * 
 * We implement the interface "IAuthenticationModule" to make CloneBasic which is a custom authentication module.
 * The custom authentication module encodes username and password as base64 strings and then returns 
 * back an authorization instance. This authorization is internally used by the HttpWebRequest for 
 * authentication.
 * * 
 * Please Note : This program has to be compiled as a dll.
 */
using System;
using System.Net;
using System.Text;

namespace CloneBasicAuthentication
{

    public class CloneBasic : IAuthenticationModule
    {
        private string m_authenticationType ;
        private bool m_canPreAuthenticate ;

        public CloneBasic()
        {
            m_authenticationType = "CloneBasic";
            m_canPreAuthenticate = false;
        }
        public string AuthenticationType
        {
            get{
                return m_authenticationType;
               }
        }
        public bool CanPreAuthenticate
        {
            get{
                return m_canPreAuthenticate;
               }
        }

// <Snippet1>
        public Authorization Authenticate( string challenge,WebRequest request,ICredentials credentials)
        {
            try
            {
                string message;
                // Check if Challenge string was raised by a site which requires CloneBasic authentication.
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
            // a)Concatenate username and password seperated by space;
            // b)Apply ASCII encoding to obtain a stream of bytes;
            // c)Apply Base64 Encoding to this array of bytes to obtain our encoded authorization message.

                message = myCredentials.UserName + " " + myCredentials.Password;
                // Apply AsciiEncoding to our user name and password to obtain it as an array of bytes.
                Encoding asciiEncoding = Encoding.ASCII;
                byte[] byteArray = new byte[asciiEncoding.GetByteCount(message)];
                byteArray = asciiEncoding.GetBytes(message);

                // Perform Base64 transform.
                message = Convert.ToBase64String(byteArray);
            // The following overloaded contructor sets the 'Message' property of authorization to the base64 string;
            // that  we just formed and it also sets the 'Complete' property to true and the connection group id;
            // to the domain of the NetworkCredential object.
                Authorization myAuthorization = new Authorization("CloneBasic " + message,true,request.ConnectionGroupName);
                return myAuthorization;
            }
            catch(Exception e)
            {
                    Console.WriteLine("Exception Raised ...:"+e.Message);    
                return null;
            }
          }

// </Snippet1>
        
        public Authorization PreAuthenticate(WebRequest request,ICredentials credentials)
        {
          return null;
        }
    }
}

