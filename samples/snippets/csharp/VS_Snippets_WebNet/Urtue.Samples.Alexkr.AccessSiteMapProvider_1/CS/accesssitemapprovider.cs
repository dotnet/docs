// <Snippet1>
namespace Samples.AspNet.CS.Controls {

    using System;
    using System.Collections;
    using System.Collections.Specialized;
    using System.Data;
    using System.Data.OleDb;
    using System.Security.Permissions;
    using System.Web;

    /// An extremely simple AccessSiteMapProvider that only supports a
    /// site map node hierarchy 1 level deep.
    [AspNetHostingPermission(SecurityAction.Demand, Level=AspNetHostingPermissionLevel.Minimal)]
    public class AccessSiteMapProvider : StaticSiteMapProvider
    {
        private SiteMapNode rootNode =  null;
        private OleDbConnection accessConnection = null;

        // This string is case sensitive.
        private string AccessConnectionStringName = "accessSiteMapConnectionString";

        // Implement a default constructor.
        public AccessSiteMapProvider () { }

        // Some basic state to help track the initialization state of the provider.
        private bool initialized = false;
        public virtual bool IsInitialized {
            get {
                return initialized;
            }
        }
// <Snippet5>
        // Return the root node of the current site map.
        public override SiteMapNode RootNode {
            get {
                SiteMapNode temp = null;
                temp = BuildSiteMap();
                return temp;
            }
        }
// </Snippet5>
// <Snippet7>
        protected override SiteMapNode GetRootNodeCore() {
            return RootNode;
        }
// </Snippet7>
// <Snippet2>
        // Initialize is used to initialize the properties and any state that the
        // AccessProvider holds, but is not used to build the site map.
        // The site map is built when the BuildSiteMap method is called.
        public override void Initialize(string name, NameValueCollection attributes) {
            if (IsInitialized)
                return;

            base.Initialize(name, attributes);

            // Create and test the connection to the Microsoft Access database.

            // Retrieve the Value of the Access connection string from the
            // attributes NameValueCollection.
            string connectionString = attributes[AccessConnectionStringName];

            if (null == connectionString || connectionString.Length == 0)
                throw new Exception ("The connection string was not found.");
            else
                accessConnection = new OleDbConnection(connectionString);

            initialized = true;
        }
// </Snippet2>

        ///
        /// SiteMapProvider and StaticSiteMapProvider methods that this derived class must override.
        ///
// <Snippet3>
        // Clean up any collections or other state that an instance of this may hold.
        protected override void Clear() {
            lock (this) {
                rootNode = null;
                base.Clear();
            }
        }
// </Snippet3>

// <Snippet4>
        // Build an in-memory representation from persistent
        // storage, and return the root node of the site map.
        public override SiteMapNode BuildSiteMap() {

            // Since the SiteMap class is static, make sure that it is
            // not modified while the site map is built.
            lock(this) {

                // If there is no initialization, this method is being
                // called out of order.
                if (! IsInitialized) {
                    throw new Exception("BuildSiteMap called incorrectly.");
                }

                // If there is no root node, then there is no site map.
                if (null == rootNode) {
                    // Start with a clean slate
                    Clear();

                    // Select the root node of the site map from Microsoft Access.
                    int rootNodeId = -1;

                    if (accessConnection.State == ConnectionState.Closed)
                        accessConnection.Open();
// <Snippet6>
                    OleDbCommand rootNodeCommand =
                        new OleDbCommand("SELECT nodeid, url, name FROM SiteMap WHERE parentnodeid IS NULL",
                                         accessConnection);
                    OleDbDataReader rootNodeReader = rootNodeCommand.ExecuteReader();

                    if(rootNodeReader.HasRows) {
                        rootNodeReader.Read();
                        rootNodeId = rootNodeReader.GetInt32(0);
                        // Create a SiteMapNode that references the current StaticSiteMapProvider.
                        rootNode   = new SiteMapNode(this,
                                                     rootNodeId.ToString(),
                                                     rootNodeReader.GetString(1),
                                                     rootNodeReader.GetString(2));

                    }
                    else return null;

                    rootNodeReader.Close();
// </Snippet6>
                    // Select the child nodes of the root node.
                    OleDbCommand childNodesCommand =
                        new OleDbCommand("SELECT nodeid, url, name FROM SiteMap WHERE parentnodeid = ?",
                                         accessConnection);
                    OleDbParameter rootParam = new OleDbParameter("parentid", OleDbType.Integer);
                    rootParam.Value = rootNodeId;
                    childNodesCommand.Parameters.Add(rootParam);

                    OleDbDataReader childNodesReader = childNodesCommand.ExecuteReader();

                    if (childNodesReader.HasRows) {

                        SiteMapNode childNode = null;
                        while(childNodesReader.Read()) {
                            childNode =  new SiteMapNode(this,
                                                         childNodesReader.GetInt32(0).ToString(),
                                                         childNodesReader.GetString(1),
                                                         childNodesReader.GetString(2));

                            // Use the SiteMapNode AddNode method to add
                            // the SiteMapNode to the ChildNodes collection.
                            AddNode(childNode, rootNode);
                        }
                    }

                    childNodesReader.Close();
                    accessConnection.Close();
                }
                return rootNode;
            }
        }
// </Snippet4>
    }
}
// </Snippet1>