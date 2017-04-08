using System;
using System.Collections.ObjectModel;
using System.IdentityModel.Claims;
using System.Net;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.ServiceModel.Description;

namespace Example
{
    /// <summary>
    /// Before running:
    /// Use setup.bat to create a new test certificate "service.com".
    /// 
    /// Shows how to implement a SecurityStateEncoder to take full control of protecting
    /// the cookie security context token so that it does not depend on DPAPI.
    /// Code originally from:
    /// C:\dd\indigo_wap\ndp\indigo\samples\internal\Security\community\SctCookieWithSecurityStateEncoder\SelfHostedSecurityStateEncoderService
    /// </summary>
    class CookieSctService
    {
        static void Main(string[] args)
        {
            // Enable tracing so that we can see what happens on the service.
            // Trace.Listeners.Add(new ConsoleTraceListener());
            /*
            using (ServiceHost serviceHost = new ServiceHost(typeof(EchoService)))
            {
                Configure(serviceHost);

                serviceHost.Open();

                PrintEndpointAddresses(serviceHost);

                Console.WriteLine("Press [Enter] key to stop the service.");
                Console.ReadLine();
            }
        }

        static void PrintEndpointAddresses(ServiceHost serviceHost)
        {
            Console.WriteLine("Service is listening at the following addresses:");
            foreach (ChannelDispatcher channel in serviceHost.ChannelDispatchers)
            {
                foreach (EndpointDispatcher endpoint in channel.Endpoints)
                {
                    Console.WriteLine(endpoint.EndpointAddress.Uri.AbsoluteUri);
                }
            }*/
        }
        // <snippet2>
        // <snippet1>
        static void Configure(ServiceHost serviceHost)
        {
            /*
             * There are certain settings that cannot be configured via app.config.  
             * The security state encoder is one of them.
             * Plug in a SecurityStateEncoder that uses the configured certificate 
             * to protect the security context token state.
             * 
             * Note: You don't need a security state encoder for cookie mode.  This was added to the 
             * sample to illustrate how you would plug in a custom security state encoder should
             * your scenario require one.
             * */
            serviceHost.Credentials.SecureConversationAuthentication.SecurityStateEncoder = 
                    new CertificateSecurityStateEncoder(serviceHost.Credentials.ServiceCertificate.Certificate);
         // </snippet1>
           Collection<Type> myClaimTypes = new Collection<Type>();
            myClaimTypes = serviceHost.Credentials.SecureConversationAuthentication.SecurityContextClaimTypes;
        }

        // </snippet2>
    }
    public class CertificateSecurityStateEncoder : SecurityStateEncoder
    {
        RSACryptoServiceProvider rsaCryptoServiceProvider;
        CookieContainerSerializer serializer;
        RijndaelManaged aesAlg;

        public CertificateSecurityStateEncoder(X509Certificate2 protectionCertificate)
        {
            if (protectionCertificate == null)
            {
                throw new ArgumentNullException("protectionCertificate");
            }

            if (protectionCertificate.HasPrivateKey == false)
            {
                throw new ArgumentException("protectionCertificate does not contain the private key which is required for performing encypt / decrypt operations.");
            }

            rsaCryptoServiceProvider = protectionCertificate.PrivateKey as RSACryptoServiceProvider;
            if (rsaCryptoServiceProvider == null)
            {
                throw new NotSupportedException("protectionCertificate must have a private key of type RSACryptoServiceProvider.");
            }

            serializer = new CookieContainerSerializer();

            // The symmetric key algorithm used to protect the cookie.
            aesAlg = new RijndaelManaged();
        }


        protected override byte[] EncodeSecurityState(byte[] data)
        {
            // Create a new cookie container that will protect the WCF cookie.
            // Possible improvement: use a caching scheme so that a new cookie container
            // need not be created each time to improve performance.
            CookieContainer cookieContainer = new CookieContainer(rsaCryptoServiceProvider, aesAlg);

            // Encrypt the cookie from WCF with our own scheme so that any of the backend services
            // can decrypt it.
            cookieContainer.EncryptCookie(data);

            // Return the cookie container as a byte array.
            return serializer.Serialize(cookieContainer);
        }


        protected override byte[] DecodeSecurityState(byte[] data)
        {
            // Possible improvement: use a caching scheme so that a new cookie container
            // need not be created each time to improve performance.
            CookieContainer cookieContainer = serializer.Deserialize(rsaCryptoServiceProvider, aesAlg, data);

            // Decrypt the cookie and return it to WCF so that WCF can use the cookie to 
            // perform its own cryptographic operations.
            return cookieContainer.DecryptCookie();
        }

    }
    class CookieContainerSerializer
    {
        /// <summary>
        /// Turns a byte array back into a CookieContainer.
        /// </summary>
        /// <param name="rsaKey">The protection RSA key to decrypt the symmetric key.</param>
        /// <param name="aesAlg">The symmetric key algorithm to use to decrypt the cookie block.</param>
        /// <param name="data">The byte array to deserialize.</param>
        /// <returns>The deserialized cookie container instance.</returns>
        public CookieContainer Deserialize(RSACryptoServiceProvider rsaKey, RijndaelManaged aesAlg, byte[] data)
        {
            CookieContainer cookieContainer = new CookieContainer(rsaKey, aesAlg);
            // Length of the IV according to the AES algorithm (in bytes).
            int ivLength = aesAlg.BlockSize / 8;

            // Determine how much buffer to read to retrieve the symmetric key.
            int symmetricKeyLength = DataBitsConverter.ToInt(data, 0, sizeof(int));

            // Perform some basic data validation
            if (symmetricKeyLength <= 0)
            {
                throw new InvalidOperationException("symmetricKeyLength must be greater than zero.");
            }
            checked
            {
                if (sizeof(int) + symmetricKeyLength + ivLength > data.Length)
                {
                    throw new InvalidOperationException("symmetricKeyLength + encryptedSymmetricKey + IV (in bytes) exceeds the data buffer length.");
                }
            }

            // Use an index to track the next byte to read in the the data buffer.
            int index = sizeof(int);

            // Retrieve the encrypted symmetric key.
            cookieContainer.EncryptedSymmetricKey = new byte[symmetricKeyLength];
            Array.Copy(data, index, cookieContainer.EncryptedSymmetricKey, 0, symmetricKeyLength);
            index += symmetricKeyLength;

            // Retrieve the IV.
            cookieContainer.IV = new byte[ivLength];
            Array.Copy(data, index, cookieContainer.IV, 0, ivLength);
            index += ivLength;

            // Retrieve the encrypted cookie.
            cookieContainer.EncryptedCookie = new byte[data.Length - index];
            Array.Copy(data, index, cookieContainer.EncryptedCookie, 0, data.Length - index);

            // Re-create the encryptor / decryptor with the new symmetric key and IV.
            cookieContainer.CreateCryptoTransformers();

            return cookieContainer;
        }

        /// <summary>
        /// Serialize the cookie container into a byte array.
        /// </summary>
        /// <returns>Byte array that represents the Cookie Container</returns>
        public byte[] Serialize(CookieContainer cookieContainer)
        {
            // First turn the encryptedSymmetricKey.Length into a byte array 
            byte[] keyLength = DataBitsConverter.ToBytes(cookieContainer.EncryptedSymmetricKey.Length);
            // Allocate the total buffer required.
            int bufferSize = keyLength.Length + cookieContainer.EncryptedSymmetricKey.Length + cookieContainer.IV.Length + cookieContainer.EncryptedCookie.Length;
            byte[] buffer = new byte[bufferSize];

            // Copy SymmetricKeyLength to the buffer.
            Array.Copy(keyLength, buffer, keyLength.Length);
            // Keep track of the next available space in the buffer.
            int index = keyLength.Length;

            // Copy the encrypted symmetric key to the buffer.
            Array.Copy(cookieContainer.EncryptedSymmetricKey, 0, buffer, index, cookieContainer.EncryptedSymmetricKey.Length);
            index += cookieContainer.EncryptedSymmetricKey.Length;

            // Copy the IV to the buffer
            Array.Copy(cookieContainer.IV, 0, buffer, index, cookieContainer.IV.Length);
            index += cookieContainer.IV.Length;

            // The rest of the buffer contains the encrypted SCT Cookie.
            Array.Copy(cookieContainer.EncryptedCookie, 0, buffer, index, cookieContainer.EncryptedCookie.Length);
            return buffer;
        }

    }
    class CookieContainer
    {
        byte[] encryptedSymmetricKey;
        byte[] iv;
        byte[] encryptedCookie;
        ICryptoTransform encryptor;
        ICryptoTransform decryptor;
        RijndaelManaged aesAlg;
        RSACryptoServiceProvider protectionRsaKey;

        /// <summary>
        /// Creates a new cookie container and auto-generate a symmetric key protected
        /// with the RSA key.
        /// </summary>
        /// <param name="rsaKey">The RSA key to protect the generated symmetric key.</param>
        /// <param name="aesAlg">The symmetric key algorithm to use.</param>
        public CookieContainer(RSACryptoServiceProvider rsaKey, RijndaelManaged aesAlg)
        {
            this.aesAlg = aesAlg;
            this.iv = aesAlg.IV;

            // Use the RSA key in the X509Certificate to protect the symmetric key.
            this.protectionRsaKey = rsaKey;
            this.encryptedSymmetricKey = protectionRsaKey.Encrypt(aesAlg.Key, true);

            // Create the enryptor and decryptor that will perform the actual 
            // cryptographic operations.
            CreateCryptoTransformers();
        }

        public byte[] EncryptedSymmetricKey
        {
            get { return encryptedSymmetricKey; }
            set { encryptedSymmetricKey = value; }
        }

        public byte[] IV
        {
            get { return iv; }
            set { iv = value; }
        }

        public byte[] EncryptedCookie
        {
            get { return encryptedCookie; }
            set { encryptedCookie = value; }
        }

        public void CreateCryptoTransformers()
        {
            // Only a service configured with the right X509 certificate
            // can decrypt the symmetric key.
            byte[] symmetricKey = protectionRsaKey.Decrypt(encryptedSymmetricKey, true);

            // Create an encryptor based on the symmetric key which can be used to encrypt SCT cookie blob.
            this.encryptor = aesAlg.CreateEncryptor(symmetricKey, iv);

            // Create a decryptor based on the symmetric key which can be used to decrypt SCT cookie blob.
            this.decryptor = aesAlg.CreateDecryptor(symmetricKey, iv);

        }

        public void EncryptCookie(byte[] cookie)
        {
            encryptedCookie = encryptor.TransformFinalBlock(cookie, 0, cookie.Length);
        }

        public byte[] DecryptCookie()
        {
            return decryptor.TransformFinalBlock(encryptedCookie, 0, encryptedCookie.Length);
        }
    }
    class DataBitsConverter
    {
        const int IntSize = sizeof(int);
        const int ByteSize = 8;

        public static byte[] ToBytes(int u)
        {
            byte[] b = new byte[IntSize];
            for (int i = 0; i < IntSize; i++)
            {
                b[i] = (byte)(u >> i * ByteSize);
            }
            return b;
        }

        public static int ToInt(byte[] b)
        {
            return ToInt(b, 0, b.Length);
        }

        public static int ToInt(byte[] b, int startIndex, int length)
        {
            checked
            {
                if (startIndex + length > b.Length)
                {
                    throw new ArgumentOutOfRangeException("startIndex + length > b.length");
                }
            }

            int intValue = 0;

            for (int i = length; i > startIndex; i--)
            {
                intValue = (intValue << ByteSize) + b[i - 1];
            }
            return intValue;
        }
    }


}
