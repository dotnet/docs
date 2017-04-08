#using "NameIdPermission.dll"
//<Snippet1>
using namespace System;
using namespace System::IO;
using namespace System::Runtime::Remoting;
using namespace System::Security;
using namespace System::Security::Permissions;
using namespace System::Reflection;
using namespace MyPermission;

// Use the command line option '/keyfile' or appropriate project settings to sign this assembly.
[assembly:System::Security::AllowPartiallyTrustedCallersAttribute];
[AttributeUsage(AttributeTargets::Method|AttributeTargets::Constructor|AttributeTargets::Class|AttributeTargets::Struct|AttributeTargets::Assembly,AllowMultiple=true,Inherited=false)]
[Serializable]
public ref class NameIdPermissionAttribute: public CodeAccessSecurityAttribute
{
private:
   String^ m_Name;
   bool m_unrestricted;

public:
   NameIdPermissionAttribute( SecurityAction action )
      : CodeAccessSecurityAttribute( action )
   {
      m_Name = nullptr;
      m_unrestricted = false;
   }


   property String^ Name
   {
      String^ get()
      {
         return m_Name;
      }

      void set( String^ value )
      {
         m_Name = value;
      }

   }
   virtual IPermission^ CreatePermission() override
   {
      if ( m_unrestricted )
      {
         throw gcnew ArgumentException( "Unrestricted permissions not allowed in identity permissions." );
      }
      else
      {
         if ( m_Name == nullptr )
                  return gcnew NameIdPermission( PermissionState::None );
         return gcnew NameIdPermission( m_Name );
      }
   }

};

//</Snippet1>
