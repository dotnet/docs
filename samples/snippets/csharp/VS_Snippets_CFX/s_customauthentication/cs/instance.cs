
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.
//  Snippet for CustomAuthentication
//	07/17/06 a-arhu new IssuerBasedValidator(); // must use default constructor (issuer);

using System;
using System.Configuration;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Security;

// Multi-party chat application using Peer Channel (a multi-party channel).
// If you are unfamiliar with new concepts used in this sample, refer to the WCF Basic\GettingStarted sample.

namespace Microsoft.ServiceModel.Samples
{
    // Chat service contract.
    // Applying the [PeerBehavior] attribute on the service contract enables retrieval of PeerNode from IClientChannel.
	[ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples", CallbackContract = typeof(IChat))]
	public interface IChat
	{
		[OperationContract(IsOneWay = true)]
				void Join(string member);

		[OperationContract(IsOneWay = true)]
				void Chat(string member, string msg);

		[OperationContract(IsOneWay = true)]
				void Leave(string member);
	}

	public interface IChatChannel : IChat, IClientChannel
	{
	}

	class IssuerBasedValidator : X509CertificateValidator
	{
		string issuerThumbprint;
//instance.cs(48,30): error CS0115: 'Microsoft.ServiceModel.Samples.IssuerBasedValidator.Validate
//(System.Security.Cryptography.X509Certificates.X509Certificate2)':
//No suitable method found to override.	
/*        public IssuerBasedValidator(X509Certificate2 issuer)
        {
            if(issuer == null)
                throw new ArgumentException("issuer");
            this.issuerThumbprint = issuer.Thumbprint;
        }
        */
		public override void Validate(X509Certificate2 certificate)
		{
			X509Chain chain = new X509Chain();
			chain.Build(certificate);
			foreach(X509ChainElement element in chain.ChainElements)
			{
				if (element.Certificate.Thumbprint == issuerThumbprint)
					return;
			}
			throw new SecurityTokenValidationException(
				String.Format("The certificate '{0}' failed validation", certificate));
		}
	}

	public class ChatApp : IChat
	{
	// Host the chat instance within this EXE console application.
		public static void Main()
		{
	    // Get the memberId from configuration.
			string member = ConfigurationManager.AppSettings["member"];
			string issuerName = ConfigurationManager.AppSettings["issuer"];

	    // <Snippet1>
	    // Construct InstanceContext to handle messages on the callback interface.
	    // An instance of ChatApp is created and passed to the InstanceContext.
			InstanceContext site = new InstanceContext(new ChatApp());

	    // Create the participant with the given endpoint configuration.
	    // Each participant opens a duplex channel to the mesh.
	    // Participant is an instance of the chat application that has opened a channel to the mesh.

			using (DuplexChannelFactory<IChatChannel> cf =
				new DuplexChannelFactory<IChatChannel>(site,"ChatEndpoint"))
			{
				X509Certificate2 issuer = GetCertificate(
					StoreName.CertificateAuthority,
					StoreLocation.CurrentUser, "CN=" + issuerName,
					X509FindType.FindBySubjectDistinguishedName);
				cf.Credentials.Peer.Certificate =
					GetCertificate(StoreName.My,
					StoreLocation.CurrentUser,
					"CN=" + member,
					X509FindType.FindBySubjectDistinguishedName);
				cf.Credentials.Peer.PeerAuthentication.CertificateValidationMode  =
					X509CertificateValidationMode.Custom;
				cf.Credentials.Peer.PeerAuthentication.CustomCertificateValidator =
					new IssuerBasedValidator();

				using (IChatChannel participant = cf.CreateChannel())
				{
		    // Retrieve the PeerNode associated with the participant and register for online/offline events.
		    // PeerNode represents a node in the mesh. Mesh is the named collection of connected nodes.
					IOnlineStatus ostat = participant.GetProperty<IOnlineStatus>();
					ostat.Online += new EventHandler(OnOnline);
					ostat.Offline += new EventHandler(OnOffline);

					Console.WriteLine($"{member} is ready");
					Console.WriteLine("Press <ENTER> to send the chat message.");

		    // Announce self to other participants.
					participant.Join(member);
					Console.ReadLine();
					participant.Chat(member, "Hi there - I am chatting");

					Console.WriteLine("Press <ENTER> to terminate this instance of chat.");
					Console.ReadLine();
		    // Leave the mesh and close the client.
					participant.Leave(member);
				}
			}
	    // </Snippet1>
		}

	// IChat implementation.
		public void Join(string member)
		{
			Console.WriteLine($"{member} joined");
		}

		public void Chat(string member, string msg)
		{
			Console.WriteLine($"[{member}] {msg}");
		}

		public void Leave(string member)
		{
			Console.WriteLine($"[{member} left]");
		}

	// PeerNode event handlers.
		static void OnOnline(object sender, EventArgs e)
		{
			Console.WriteLine("** Online");
		}

		static void OnOffline(object sender, EventArgs e)
		{
			Console.WriteLine("** Offline");
		}

		static internal X509Certificate2 GetCertificate(StoreName storeName, StoreLocation storeLocation, string key, X509FindType findType)
		{
			X509Certificate2 result;

			X509Store store = new X509Store(storeName, storeLocation);
			store.Open(OpenFlags.ReadOnly);
			try
			{
				X509Certificate2Collection matches;
				matches = store.Certificates.Find(findType, key, false);
				if (matches.Count > 1)
					throw new InvalidOperationException(
						String.Format("More than one certificate with key '{0}' found in the store.", key));
				if (matches.Count == 0)
					throw new InvalidOperationException(
						String.Format("No certificates with key '{0}' found in the store.", key));
				result = matches[0];
			}
			finally
			{
				store.Close();
			}

			return result;
		}
	}
}
