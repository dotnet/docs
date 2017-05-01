using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.ComponentModel.Design;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.ExtensionManager;

namespace Contoso.VSSkinHost
{
    /// <summary>
    /// This is the class that implements the package exposed by this assembly.
    ///
    /// The minimum requirement for a class to be considered a valid package for Visual Studio
    /// is to implement the IVsPackage interface and register itself with the shell.
    /// This package uses the helper classes defined inside the Managed Package Framework (MPF)
    /// to do it: it derives from the Package class that provides the implementation of the 
    /// IVsPackage interface and uses the registration attributes defined in the framework to 
    /// register itself and its components with the shell.
    /// </summary>
    // This attribute tells the PkgDef creation utility (CreatePkgDef.exe) that this class is
    // a package.
    [PackageRegistration(UseManagedResourcesOnly = true)]
    // This attribute is used to register the informations needed to show the this package
    // in the Help/About dialog of Visual Studio.
    [InstalledProductRegistration(false, "#110", "#112", "1.0", IconResourceID = 400)]
    // This attribute is needed to let the shell know that this package exposes some menus.
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(GuidList.guidVSSkinHostPkgString)]
    public sealed class VSSkinHostPackage : Package
    {
        /// <summary>
        /// Default constructor of the package.
        /// Inside this method you can place any initialization code that does not require 
        /// any Visual Studio service because at this point the package object is created but 
        /// not sited yet inside Visual Studio environment. The place to do all the other 
        /// initialization is the Initialize method.
        /// </summary>
        public VSSkinHostPackage()
        {
            Trace.WriteLine(string.Format(CultureInfo.CurrentCulture, "Entering constructor for: {0}", this.ToString()));
        }



        /////////////////////////////////////////////////////////////////////////////
        // Overriden Package Implementation
        #region Package Members

        /// <summary>
        /// Initialization of the package; this method is called right after the package is sited, so this is the place
        /// where you can put all the initilaization code that rely on services provided by VisualStudio.
        /// </summary>
        protected override void Initialize()
        {
            Trace.WriteLine (string.Format(CultureInfo.CurrentCulture, "Entering Initialize() of: {0}", this.ToString()));
            base.Initialize();

            // Add our command handlers for menu (commands must exist in the .vsct file)
            OleMenuCommandService mcs = GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            if ( null != mcs )
            {
                // Create the command for the menu item.
                //CommandID menuCommandID = new CommandID(GuidList.guidVSSkinHostCmdSet, (int)PkgCmdIDList.cmdidSetSkin);
                //MenuCommand menuItem = new MenuCommand(MenuItemCallback, menuCommandID );
                //mcs.AddCommand( menuItem );
                InitSkinList();
            }
        }
        #endregion
        
        //<snippet01>
        // This is the CommandID of the placeholder menu item, 
        // as defined in the .vsct file.
        int CmdIdBase = 0x103;

        // These lists will store name and path information.
        private ArrayList SkinNames = new ArrayList();
        private ArrayList SkinPaths = new ArrayList();

        // Call this from Initialize().
        private void InitSkinList()
        {
            //<snippet02>
            var mcs = GetService(typeof(IMenuCommandService)) 
                as OleMenuCommandService;
            int counter = CmdIdBase;
            
            // Get the Extension Manager service.
            var ExtMgrSvc = GetService(typeof(SVsExtensionManager)) 
                as IVsExtensionManager;
            
            // Iterate through installed extensions.
            var attributes = new Dictionary<string, string>();
            attributes.Add("Type", "Skin");
            foreach (string SkinPath
                in ExtMgrSvc.GetEnabledExtensionContentLocations(
                "CustomExtension", attributes))
            {
                // Store the name and path information.
                SkinPaths.Add(SkinPath);
                SkinNames.Add(ExtMgrSvc.CreateExtension(SkinPath).Header.Name);
 
                // Create a CommandID for the new menu item.
                var cmdID = new CommandID(
                    GuidList.guidVSSkinHostCmdSet, counter);
                
                // Create the menu item and add its event handlers.
                var mc = new OleMenuCommand(
                    new EventHandler(OnSkinExec), cmdID);
                mc.BeforeQueryStatus += new EventHandler(OnSkinQueryStatus);
                mcs.AddCommand(mc);

                counter ++;
            }
            //</snippet02>
        }

        private void OnSkinQueryStatus(object sender, EventArgs e)
        {
            var menuCommand = sender as OleMenuCommand;
            if (null != menuCommand)
            {
                // Determine which menu item was queried.
                int skinIndex = menuCommand.CommandID.ID - this.CmdIdBase;
                if (skinIndex >= 0 && skinIndex < this.SkinNames.Count)
                {
                    // Set the text.
                    menuCommand.Text = this.SkinNames[skinIndex] as string;
                }
            }
        }
        
        private void OnSkinExec(object sender, EventArgs e)
        {
            var menuCommand = sender as OleMenuCommand;
            if (null != menuCommand)
            {
                // Get the name of the skin from the menu item.
                string skinName = menuCommand.Text;

                // Locate the name in the list of skins. 
                int i = this.SkinNames.IndexOf(skinName);

                // Get the corrsponding path.
                var skinPath = SkinPaths[i] as string;

                if (SkinNames.Count > 0)
                {         
                    if (File.Exists(skinPath) || Directory.Exists(skinPath))
                    {
                        // Put code here to apply the skin extension...
                        MessageBox.Show("Skin " + skinName + " found:\r\n" 
                            + skinPath + ". \r\n\r\nApplying skin...");
                    }
                   else MessageBox.Show("Could not find skin " + skinName);
                }
            }
        }
        //</snippet01>
        
        /// <summary>
        /// This function is the callback used to execute a command when the a menu item is clicked.
        /// See the Initialize method to see how the menu item is associated to this function using
        /// the OleMenuCommandService service and the MenuCommand class.
        /// </summary>
        private void MenuItemCallback(object sender, EventArgs e)
        {
            // Show a Message Box to prove we were here
            IVsUIShell uiShell = (IVsUIShell)GetService(typeof(SVsUIShell));
            Guid clsid = Guid.Empty;
            int result;
            Microsoft.VisualStudio.ErrorHandler.ThrowOnFailure(uiShell.ShowMessageBox(
                       0,
                       ref clsid,
                       "VS Skin Host",
                       string.Format(CultureInfo.CurrentCulture, "Inside {0}.MenuItemCallback()", this.ToString()),
                       string.Empty,
                       0,
                       OLEMSGBUTTON.OLEMSGBUTTON_OK,
                       OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST,
                       OLEMSGICON.OLEMSGICON_INFO,
                       0,        // false
                       out result));
        }


        

    }
}
