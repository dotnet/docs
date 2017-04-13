//<snippet1>
#using <System.dll>

using namespace System;
using namespace System::Security::Permissions;
using namespace System::Collections;

[Flags]

public enum class MailslotPermissionAccess
{
   None = 0,
   Send = 1 << 1,
   Receive = 1 << 2 | MailslotPermissionAccess::Send
};


[Serializable]
public ref class MailslotPermissionEntry
{
private:
   String^ name;
   String^ machineName;
   MailslotPermissionAccess permissionAccess;

internal:
   MailslotPermissionEntry( ResourcePermissionBaseEntry^ baseEntry )
   {
      this->permissionAccess = (MailslotPermissionAccess)baseEntry->PermissionAccess;
      this->name = baseEntry->PermissionAccessPath[ 0 ]->ToString();
      this->machineName = baseEntry->PermissionAccessPath[ 1 ]->ToString();
   }

   ResourcePermissionBaseEntry^ GetBaseEntry()
   {
      array<String^>^newStrings = {this->Name,this->MachineName};
      ResourcePermissionBaseEntry^ baseEntry = gcnew ResourcePermissionBaseEntry( (int)(this->PermissionAccess),newStrings );
      return baseEntry;
   }

public:
   MailslotPermissionEntry( MailslotPermissionAccess permissionAccess, String^ name, String^ machineName )
   {
      this->permissionAccess = permissionAccess;
      this->name = name;
      this->machineName = machineName;
   }

   property String^ Name 
   {
      String^ get()
      {
         return this->name;
      }
   }

   property String^ MachineName 
   {
      String^ get()
      {
         return this->machineName;
      }
   }

   property MailslotPermissionAccess PermissionAccess 
   {
      MailslotPermissionAccess get()
      {
         return this->permissionAccess;
      }
   }
};


[Serializable]
public ref class MailslotPermission: public ResourcePermissionBase
{
private:
   ArrayList^ innerCollection;
   void SetNames()
   {
      this->PermissionAccessType = MailslotPermissionAccess::typeid;
      array<String^>^newStrings = {"Name","Machine"};
      this->TagNames = newStrings;
   }


internal:
   void AddPermissionAccess( MailslotPermissionEntry^ entry )
   {
      ResourcePermissionBase::AddPermissionAccess( entry->GetBaseEntry() );
   }

   void Clear()
   {
      ResourcePermissionBase::Clear();
   }

   void RemovePermissionAccess( MailslotPermissionEntry^ entry )
   {
      ResourcePermissionBase::RemovePermissionAccess( entry->GetBaseEntry() );
   }


public:
   MailslotPermission()
   {
      SetNames();
   }

   MailslotPermission( PermissionState state )
      : ResourcePermissionBase( state )
   {
      SetNames();
   }

   //<Snippet2>
   MailslotPermission( MailslotPermissionAccess permissionAccess, String^ name, String^ machineName )
   {
      SetNames();
      this->AddPermissionAccess( gcnew MailslotPermissionEntry( permissionAccess,name,machineName ) );
   }

   MailslotPermission( array<MailslotPermissionEntry^>^permissionAccessEntries )
   {
      SetNames();
      if ( permissionAccessEntries == nullptr )
            throw gcnew ArgumentNullException( "permissionAccessEntries" );

      for ( int index = 0; index < permissionAccessEntries->Length; ++index )
         this->AddPermissionAccess( permissionAccessEntries[ index ] );
   }
   //</Snippet2>

   property ArrayList^ PermissionEntries 
   {
      ArrayList^ get()
      {
         if ( this->innerCollection == nullptr )
                  this->innerCollection = gcnew ArrayList;

         this->innerCollection->InsertRange( 0, safe_cast<ICollection^>(ResourcePermissionBase::GetPermissionEntries()) );
         return this->innerCollection;
      }
   }
};
//</snippet1>

void main(){}
