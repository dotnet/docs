using System;
using System.IO;
using System.Text;
using System.Reflection;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.Shell;
using EnvDTE;
using EnvDTE80;
using Microsoft.Win32;
using IOleServiceProvider = Microsoft.VisualStudio.OLE.Interop.IServiceProvider;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VSSDK.Tools.VsIdeTesting;
using Microsoft.VisualStudio;

namespace Microsoft.VsSDK.IntegrationTestLibrary
{
    /// <summary>
    /// </summary>
    public class TestUtils
    {

        #region Methods: Handling embedded resources
        /// <summary>
        /// Gets the embedded file identified by the resource name, and converts the
        /// file into a string.
        /// </summary>
        /// <param name="resourceName">In VS, is DefaultNamespace.FileName?</param>
        /// <returns></returns>
        public static string GetEmbeddedStringResource(Assembly assembly, string resourceName)
        {
            string result = null;

            // Use the .NET procedure for loading a file embedded in the assembly
            Stream stream = assembly.GetManifestResourceStream(resourceName);
            if (stream != null)
            {
                // Convert bytes to string
                byte[] fileContentsAsBytes = new byte[stream.Length];
                stream.Read(fileContentsAsBytes, 0, (int)stream.Length);
                result = Encoding.Default.GetString(fileContentsAsBytes);
            }
            else
            {
                // Embedded resource not found - list available resources
                Debug.WriteLine("Unable to find the embedded resource file '" + resourceName + "'.");
                Debug.WriteLine("  Available resources:");
                foreach (string aResourceName in assembly.GetManifestResourceNames())
                {
                    Debug.WriteLine("    " + aResourceName);
                }
            }

            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="embeddedResourceName"></param>
        /// <param name="baseFileName"></param>
        /// <param name="fileExtension"></param>
        /// <returns></returns>
        public static void WriteEmbeddedResourceToFile(Assembly assembly, string embeddedResourceName, string fileName)
        {
            // Get file contents
            string fileContents = GetEmbeddedStringResource(assembly, embeddedResourceName);
            if (fileContents == null)
                throw new ApplicationException("Failed to get embedded resource '" + embeddedResourceName + "' from assembly '" + assembly.FullName);

            // Write to file
            StreamWriter sw = new StreamWriter(fileName);
            sw.Write(fileContents);
            sw.Close();
        }

        /// <summary>
        /// Writes an embedded resource to a file.
        /// </summary>
        /// <param name="assembly">The name of the assembly that the embedded resource is defined.</param>
        /// <param name="embeddedResourceName">The name of the embedded resource.</param>
        /// <param name="fileName">The file to write the embedded resource's content.</param>
        public static void WriteEmbeddedResourceToBinaryFile(Assembly assembly, string embeddedResourceName, string fileName)
        {
            // Get file contents
            Stream stream = assembly.GetManifestResourceStream(embeddedResourceName);
            if (stream == null)
                throw new InvalidOperationException("Failed to get embedded resource '" + embeddedResourceName + "' from assembly '" + assembly.FullName);

            // Write to file
            BinaryWriter sw = null;
            FileStream fs = null;
            try
            {
                byte[] fileContentsAsBytes = new byte[stream.Length];
                stream.Read(fileContentsAsBytes, 0, (int)stream.Length);

                FileMode mode = FileMode.CreateNew;
                if (File.Exists(fileName))
                {
                    mode = FileMode.Truncate;
                }

                fs = new FileStream(fileName, mode);

                sw = new BinaryWriter(fs);
                sw.Write(fileContentsAsBytes);
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
                if (sw != null)
                {
                    sw.Close();
                }
            }
        }

        #endregion

        #region Methods: Handling temporary files and directories
        /// <summary>
        /// Returns the first available file name on the form
        ///   [baseFileName]i.[extension]
        /// where [i] starts at 1 and increases until there is an available file name
        /// in the given directory. Also creates an empty file with that name to mark
        /// that file as occupied.
        /// </summary>
        /// <param name="directory">Directory that the file should live in.</param>
        /// <param name="baseFileName"></param>
        /// <param name="extension">may be null, in which case the .[extension] part
        /// is not added.</param>
        /// <returns>Full file name.</returns>
        public static string GetNewFileName(string directory, string baseFileName, string extension)
        {
            // Get the new file name
            string fileName = GetNewFileOrDirectoryNameWithoutCreatingAnything(directory, baseFileName, extension);

            // Create an empty file to mark it as taken
            StreamWriter sw = new StreamWriter(fileName);

            sw.Write("");
            sw.Close();
            return fileName;
        }
        /// <summary>
        /// Returns the first available directory name on the form
        ///   [baseDirectoryName]i
        /// where [i] starts at 1 and increases until there is an available directory name
        /// in the given directory. Also creates the directory to mark it as occupied.
        /// </summary>
        /// <param name="directory">Directory that the file should live in.</param>
        /// <param name="baseDirectoryName"></param>
        /// <returns>Full directory name.</returns>
        public static string GetNewDirectoryName(string directory, string baseDirectoryName)
        {
            // Get the new file name
            string directoryName = GetNewFileOrDirectoryNameWithoutCreatingAnything(directory, baseDirectoryName, null);

            // Create an empty directory to make it as occupied
            Directory.CreateDirectory(directoryName);

            return directoryName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="baseFileName"></param>
        /// <param name="extension"></param>
        /// <returns></returns>
        private static string GetNewFileOrDirectoryNameWithoutCreatingAnything(string directory, string baseFileName, string extension)
        {
            // - get a file name that we can use
            string fileName;
            int i = 1;

            string fullFileName = null;
            while (true)
            {
                // construct next file name
                fileName = baseFileName + i;
                if (extension != null)
                    fileName += '.' + extension;

                // check if that file exists in the directory
                fullFileName = Path.Combine(directory, fileName);

                if (!File.Exists(fullFileName) && !Directory.Exists(fullFileName))
                    break;
                else
                    i++;
            }

            return fullFileName;
        }
        #endregion

        #region Methods: Handling solutions
        /// <summary>
        /// Closes the currently open solution (if any), and creates a new solution with the given name.
        /// </summary>
        /// <param name="solutionName">Name of new solution.</param>
        public void CreateEmptySolution(string directory, string solutionName)
        {
            CloseCurrentSolution(__VSSLNSAVEOPTIONS.SLNSAVEOPT_NoSave);

            string solutionDirectory = GetNewDirectoryName(directory, solutionName);

            // Create and force save solution
            IVsSolution solutionService = (IVsSolution)VsIdeTestHostContext.ServiceProvider.GetService(typeof(IVsSolution));
            solutionService.CreateSolution(solutionDirectory, solutionName, (uint)__VSCREATESOLUTIONFLAGS.CSF_SILENT);
            solutionService.SaveSolutionElement((uint)__VSSLNSAVEOPTIONS.SLNSAVEOPT_ForceSave, null, 0);
            DTE dte = VsIdeTestHostContext.Dte;
            Assert.AreEqual(solutionName + ".sln", Path.GetFileName(dte.Solution.FileName), "Newly created solution has wrong Filename");
        }

        public void CloseCurrentSolution(__VSSLNSAVEOPTIONS saveoptions)
        {
            // Get solution service
            IVsSolution solutionService = (IVsSolution)VsIdeTestHostContext.ServiceProvider.GetService(typeof(IVsSolution));

            // Close already open solution
            solutionService.CloseSolutionElement((uint)saveoptions, null, 0);
        }

        public void ForceSaveSolution()
        {
            // Get solution service
            IVsSolution solutionService = (IVsSolution)VsIdeTestHostContext.ServiceProvider.GetService(typeof(IVsSolution));

            // Force-save the solution
            solutionService.SaveSolutionElement((uint)__VSSLNSAVEOPTIONS.SLNSAVEOPT_ForceSave, null, 0);
        }

        /// <summary>
        /// Get current number of open project in solution
        /// </summary>
        /// <returns></returns>
        public int ProjectCount()
        {
            // Get solution service
            IVsSolution solutionService = (IVsSolution)VsIdeTestHostContext.ServiceProvider.GetService(typeof(IVsSolution));
            object projectCount;
            solutionService.GetProperty((int)__VSPROPID.VSPROPID_ProjectCount, out projectCount);
            return (int)projectCount;
        }
        #endregion

        #region Methods: Handling projects
        /// <summary>
        /// Creates a project.
        /// </summary>
        /// <param name="projectName">Name of new project.</param>
        /// <param name="templateName">Name of project template to use</param>
        /// <param name="language">language</param>
        /// <returns>New project.</returns>
        public void CreateProjectFromTemplate(string projectName, string templateName, string language, bool exclusive)
        {
            DTE dte = (DTE)VsIdeTestHostContext.ServiceProvider.GetService(typeof(DTE));

            Solution2 sol = dte.Solution as Solution2;
            string projectTemplate = sol.GetProjectTemplate(templateName, language);

            // - project name and directory
            string solutionDirectory = Directory.GetParent(dte.Solution.FullName).FullName;
            string projectDirectory = GetNewDirectoryName(solutionDirectory, projectName);

            dte.Solution.AddFromTemplate(projectTemplate, projectDirectory, projectName, false);
        }
        #endregion

        #region Methods: Handling project items
        /// <summary>
        /// Create a new item in the project
        /// </summary>
        /// <param name="parent">the parent collection for the new item</param>
        /// <param name="templateName"></param>
        /// <param name="language"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public ProjectItem AddNewItemFromVsTemplate(ProjectItems parent, string templateName, string language, string name)
        {
            if (parent == null)
                throw new ArgumentException("project");
            if (name == null)
                throw new ArgumentException("name");

            DTE dte = (DTE)VsIdeTestHostContext.ServiceProvider.GetService(typeof(DTE));

            Solution2 sol = dte.Solution as Solution2;

            string filename = sol.GetProjectItemTemplate(templateName, language);

            parent.AddFromTemplate(filename, name);

            return parent.Item(name);
        }

        /// <summary>
        /// Save an open document.
        /// </summary>
        /// <param name="documentMoniker">for filebased documents this is the full path to the document</param>
        public void SaveDocument(string documentMoniker)
        {
            // Get document cookie and hierarchy for the file
            IVsRunningDocumentTable runningDocumentTableService = (IVsRunningDocumentTable)VsIdeTestHostContext.ServiceProvider.GetService(typeof(IVsRunningDocumentTable));
            uint docCookie;
            IntPtr docData;
            IVsHierarchy hierarchy;
            uint itemId;
            runningDocumentTableService.FindAndLockDocument(
                (uint)Microsoft.VisualStudio.Shell.Interop._VSRDTFLAGS.RDT_NoLock,
                documentMoniker,
                out hierarchy,
                out itemId,
                out docData,
                out docCookie);

            // Save the document
            IVsSolution solutionService = (IVsSolution)VsIdeTestHostContext.ServiceProvider.GetService(typeof(IVsSolution));
            solutionService.SaveSolutionElement((uint)__VSSLNSAVEOPTIONS.SLNSAVEOPT_ForceSave, hierarchy, docCookie);
        }

        public void CloseInEditorWithoutSaving(string fullFileName)
        {
            // Get the RDT service
            IVsRunningDocumentTable runningDocumentTableService = (IVsRunningDocumentTable)VsIdeTestHostContext.ServiceProvider.GetService(typeof(IVsRunningDocumentTable));
            Assert.IsNotNull(runningDocumentTableService, "Failed to get the Running Document Table Service");

            // Get our document cookie and hierarchy for the file
            uint docCookie;
            IntPtr docData;
            IVsHierarchy hierarchy;
            uint itemId;
            runningDocumentTableService.FindAndLockDocument(
                (uint)Microsoft.VisualStudio.Shell.Interop._VSRDTFLAGS.RDT_NoLock,
                fullFileName,
                out hierarchy,
                out itemId,
                out docData,
                out docCookie);

            // Get the SolutionService
            IVsSolution solutionService = VsIdeTestHostContext.ServiceProvider.GetService(typeof(IVsSolution)) as IVsSolution;
            Assert.IsNotNull(solutionService, "Failed to get IVsSolution service");

            // Close the document
            solutionService.CloseSolutionElement(
                (uint)__VSSLNSAVEOPTIONS.SLNSAVEOPT_NoSave,
                hierarchy,
                docCookie);
        }
        #endregion

        #region Methods: Handling Toolwindows
        public bool CanFindToolwindow(Guid persistenceGuid)
        {
            IVsUIShell uiShellService = VsIdeTestHostContext.ServiceProvider.GetService(typeof(SVsUIShell)) as IVsUIShell;
            Assert.IsNotNull(uiShellService);
            IVsWindowFrame windowFrame;
            int hr = uiShellService.FindToolWindow((uint)__VSFINDTOOLWIN.FTW_fFindFirst, ref persistenceGuid, out windowFrame);
            Assert.IsTrue(hr == VSConstants.S_OK);

            return (windowFrame != null);
        }
        #endregion

        #region Methods: Loading packages
        public IVsPackage LoadPackage(Guid packageGuid)
        {
            IVsShell shellService = (IVsShell)VsIdeTestHostContext.ServiceProvider.GetService(typeof(SVsShell));
            IVsPackage package;
            shellService.LoadPackage(ref packageGuid, out package);
            Assert.IsNotNull(package, "Failed to load package");
            return package;
        }
        #endregion

        /// <summary>
        /// Executes a Command (menu item) in the given context
        /// </summary>
        public void ExecuteCommand(CommandID cmd)
        {
            object Customin = null;
            object Customout = null;
            string guidString = cmd.Guid.ToString("B").ToUpper();
            int cmdId = cmd.ID;
            DTE dte = VsIdeTestHostContext.Dte;
            dte.Commands.Raise(guidString, cmdId, ref Customin, ref Customout);
        }

    }
}
