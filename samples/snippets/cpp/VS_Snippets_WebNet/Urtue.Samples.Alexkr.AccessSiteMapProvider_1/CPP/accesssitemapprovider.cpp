// <Snippet1>
#using <System.Data.dll>
#using <System.Transactions.dll>
#using <System.EnterpriseServices.dll>
#using <System.dll>
#using <System.Web.dll>
#using <System.Configuration.dll>

using namespace System;
using namespace System::Collections;
using namespace System::Collections::Specialized;
using namespace System::Configuration;
using namespace System::Data;
using namespace System::Data::OleDb;
using namespace System::Security::Permissions;
using namespace System::Web;

/// An extremely simple AccessSiteMapProvider that only supports a
/// site map node hierarchy 1 level deep.

[AspNetHostingPermission(SecurityAction::Demand,Level=AspNetHostingPermissionLevel::Minimal)]
public ref class AccessSiteMapProvider: public StaticSiteMapProvider
{
private:
   SiteMapNode ^ rootNode;
   OleDbConnection^ accessConnection;

   // This string is case sensitive.
   String^ AccessConnectionStringName;

public:
   // Implement a default constructor.
   AccessSiteMapProvider()
   {
      initialized = false;
      AccessConnectionStringName = "accessSiteMapConnectionString";
   }


private:

   // Some basic state to help track the initialization state of the provider.
   bool initialized;

public:

   property bool IsInitialized 
   {
      virtual bool get()
      {
         return initialized;
      }

   }

   property SiteMapNode ^ RootNode 
   {

      // <Snippet5>
      // Return the root node of the current site map.
      virtual SiteMapNode ^ get() override
      {
         SiteMapNode ^ temp = nullptr;
         temp = BuildSiteMap();
         return temp;
      }

   }

protected:

   // </Snippet5>
   // <Snippet7>
   virtual SiteMapNode ^ GetRootNodeCore() override
   {
      return RootNode;
   }


public:

   // </Snippet7>
   // <Snippet2>
   // Initialize is used to initialize the properties and any state that the
   // AccessProvider holds, but is not used to build the site map.
   // The site map is built when the BuildSiteMap method is called.
   virtual void Initialize( String^ name, NameValueCollection^ attributes ) override
   {
      if ( IsInitialized )
            return;

      StaticSiteMapProvider::Initialize( name, attributes );
      
      // Create and test the connection to the Microsoft Access database.
      // Retrieve the Value of the Access connection string from the
      // attributes NameValueCollection.
      String^ connectionString = attributes[ AccessConnectionStringName ];
      if ( nullptr == connectionString || connectionString->Length == 0 )
            throw gcnew Exception( "The connection string was not found." );
      else
            accessConnection = gcnew OleDbConnection( connectionString );

      initialized = true;
   }


protected:

   // </Snippet2>
   ///
   /// SiteMapProvider and StaticSiteMapProvider methods that this derived class must override.
   ///
   // <Snippet3>
   // Clean up any collections or other state that an instance of this may hold.
   virtual void Clear() override
   {
      System::Threading::Monitor::Enter( this );
      try
      {
         rootNode = nullptr;
         StaticSiteMapProvider::Clear();
      }
      finally
      {
         System::Threading::Monitor::Exit( this );
      }

   }


public:

   // </Snippet3>
   // <Snippet4>
   // Build an in-memory representation from persistent
   // storage, and return the root node of the site map.
   virtual SiteMapNode ^ BuildSiteMap() override
   {
      // Since the SiteMap class is static, make sure that it is
      // not modified while the site map is built.
      System::Threading::Monitor::Enter( this );
      try
      {
         
         // If there is no initialization, this method is being
         // called out of order.
         if (  !IsInitialized )
         {
            throw gcnew Exception( "BuildSiteMap called incorrectly." );
         }
         
         // If there is no root node, then there is no site map.
         if ( nullptr == rootNode )
         {
            
            // Start with a clean slate
            Clear();
            
            // Select the root node of the site map from Microsoft Access.
            int rootNodeId = -1;
            if ( accessConnection->State == ConnectionState::Closed )
               accessConnection->Open();
            
            // <Snippet6>
            OleDbCommand^ rootNodeCommand = gcnew OleDbCommand
               ("SELECT nodeid, url, name FROM SiteMap WHERE parentnodeid IS NULL", accessConnection);
            OleDbDataReader^ rootNodeReader = rootNodeCommand->ExecuteReader();
            if ( rootNodeReader->HasRows )
            {
               rootNodeReader->Read();
               rootNodeId = rootNodeReader->GetInt32( 0 );
               
               // Create a SiteMapNode that references the current StaticSiteMapProvider.
               rootNode = gcnew SiteMapNode(this, rootNodeId.ToString(), 
                  rootNodeReader->GetString( 1 ),rootNodeReader->GetString( 2 ));
            }
            else
               return nullptr;
            rootNodeReader->Close();
            
            // </Snippet6>
            // Select the child nodes of the root node.
            OleDbCommand^ childNodesCommand = gcnew OleDbCommand
               ("SELECT nodeid, url, name FROM SiteMap WHERE parentnodeid = ?", accessConnection);
            OleDbParameter^ rootParam = gcnew OleDbParameter( "parentid", OleDbType::Integer);
            rootParam->Value = rootNodeId;
            childNodesCommand->Parameters->Add( rootParam );
            OleDbDataReader^ childNodesReader = childNodesCommand->ExecuteReader();
            if ( childNodesReader->HasRows )
            {
               SiteMapNode ^ childNode = nullptr;
               while ( childNodesReader->Read() )
               {
                  childNode = gcnew SiteMapNode( this, 
					  System::Convert::ToString(childNodesReader->GetInt32( 0 )),
                     childNodesReader->GetString( 1 ),
                     childNodesReader->GetString( 2 ) 
                  );
                  // Use the SiteMapNode AddNode method to add
                  // the SiteMapNode to the ChildNodes collection.
                  AddNode( childNode, rootNode );
               }
            }
            childNodesReader->Close();
            accessConnection->Close();
         }
         return rootNode;
      }
      finally
      {
         System::Threading::Monitor::Exit( this );
      }

   }

   // </Snippet4>
};

// </Snippet1>
