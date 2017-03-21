	public MailslotPermission(MailslotPermissionAccess permissionAccess, string name, string machineName)
	{
		SetNames();
		this.AddPermissionAccess(new MailslotPermissionEntry(permissionAccess, name, machineName));              
	}

	public MailslotPermission(MailslotPermissionEntry[] permissionAccessEntries) 
	{
		SetNames();
		if (permissionAccessEntries == null)
			throw new ArgumentNullException("permissionAccessEntries");
      
		for (int index = 0; index < permissionAccessEntries.Length; ++index)
			this.AddPermissionAccess(permissionAccessEntries[index]);                          
	}