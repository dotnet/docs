	class CredentialList : ICredentials
	{
		class CredentialInfo
		{
			public Uri uriObj;
			public String authenticationType;
			public NetworkCredential networkCredentialObj;
      
			public CredentialInfo(Uri uriObj, String authenticationType, NetworkCredential networkCredentialObj)
			{
				this.uriObj = uriObj;
				this.authenticationType = authenticationType;
				this.networkCredentialObj = networkCredentialObj;
			}
		}

		private ArrayList arrayListObj;

		public CredentialList()
		{
			arrayListObj = new ArrayList();
		}

		public void Add (Uri uriObj, String authenticationType, NetworkCredential credential)
		{
			// Add a 'CredentialInfo' object into a list.
			arrayListObj.Add (new CredentialInfo(uriObj, authenticationType, credential));      
		}
		// Remove the 'CredentialInfo' object from the list that matches to the given 'Uri' and 'AuthenticationType'
		public void Remove (Uri uriObj, String authenticationType)
		{
			for(int index=0;index < arrayListObj.Count; index++)
			{
				CredentialInfo credentialInfo = (CredentialInfo)arrayListObj[index];
				if(uriObj.Equals(credentialInfo.uriObj)&& authenticationType.Equals(credentialInfo.authenticationType))
					arrayListObj.RemoveAt(index);
			}
		}
		public NetworkCredential GetCredential (Uri uriObj, String authenticationType)
		{
			for(int index=0;index < arrayListObj.Count; index++)
			{
				CredentialInfo credentialInfoObj = (CredentialInfo)arrayListObj[index];
				if(uriObj.Equals(credentialInfoObj.uriObj) && authenticationType.Equals(credentialInfoObj.authenticationType))
					return credentialInfoObj.networkCredentialObj;
			}
			return null;
		}
	};