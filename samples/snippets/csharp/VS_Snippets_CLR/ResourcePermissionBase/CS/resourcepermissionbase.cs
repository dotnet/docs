//<snippet1>
using System;        
using System.Security.Permissions;  
using System.Collections;

[Serializable()]
public class MailslotPermission: ResourcePermissionBase
{
 
	private ArrayList innerCollection;

	public MailslotPermission() 
	{
		SetNames();
	}                                                                

	public MailslotPermission(PermissionState state):base(state)
	{
		SetNames();
	}  

    //<Snippet2>
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
    //</Snippet2>

	public ArrayList PermissionEntries 
	{
		get 
		{
			if (this.innerCollection == null)                     
				this.innerCollection = new ArrayList();
			this.innerCollection.InsertRange(0,base.GetPermissionEntries()); 

			return this.innerCollection;                                                               
		}
	}

	internal void AddPermissionAccess(MailslotPermissionEntry entry) 
	{
		base.AddPermissionAccess(entry.GetBaseEntry());
	}

	internal new void Clear() 
	{
		base.Clear();
	}

	internal void RemovePermissionAccess(MailslotPermissionEntry entry) 
	{
		base.RemovePermissionAccess(entry.GetBaseEntry());
	}

	private void SetNames() 
	{
		this.PermissionAccessType = typeof(MailslotPermissionAccess);
		this.TagNames = new string[]{"Name","Machine"};
	}                                
}

[Flags]         
public enum MailslotPermissionAccess 
{
	None = 0,
	Send = 1 << 1,
	Receive = 1 << 2 | Send,
} 

[Serializable()]     
public class MailslotPermissionEntry 
{
	private string name;
	private string machineName;
	private MailslotPermissionAccess permissionAccess;

	public MailslotPermissionEntry(MailslotPermissionAccess permissionAccess, string name, string machineName) 
	{
		this.permissionAccess = permissionAccess;
		this.name = name;
		this.machineName = machineName;
	}  

	internal MailslotPermissionEntry(ResourcePermissionBaseEntry baseEntry) 
	{
		this.permissionAccess = (MailslotPermissionAccess)baseEntry.PermissionAccess;
		this.name = baseEntry.PermissionAccessPath[0]; 
		this.machineName = baseEntry.PermissionAccessPath[1]; 
	}

	public string Name 
	{
		get 
		{                
			return this.name;                
		}                        
	}

	public string MachineName 
	{
		get 
		{                
			return this.machineName;                
		}                        
	}

	public MailslotPermissionAccess PermissionAccess 
	{
		get 
		{
			return this.permissionAccess;
		}                        
	}      

	internal ResourcePermissionBaseEntry GetBaseEntry() 
	{
		ResourcePermissionBaseEntry baseEntry = new ResourcePermissionBaseEntry((int)this.PermissionAccess, new string[] {this.Name,this.MachineName});            
		return baseEntry;
	}

}
//</snippet1>
