//<Snippet1>
using System;
using System.Collections;
using System.Text;
using Microsoft.Build.Utilities;
using Microsoft.Build.Framework;

namespace MSBuildTasks
{
    /// <summary>
    /// A very simple and incomplete ToolTask to wrap the ILASM.EXE tool.
    /// </summary>
    public class ILAsm : ToolTask
    {
        #region Member Data
        /// <summary>
        /// Gets the collection of parameters used by the task class.
        /// </summary>
        /// <value>Parameter bag.</value>
        protected internal Hashtable Bag
        {
            get
            {
                return bag;
            }
        }

        private Hashtable bag = new Hashtable();
        #endregion

        #region ILAsm Task Properties
        /// <summary>
        /// The Source file that is to be compled (.il)
        /// </summary>
        public ITaskItem Source
        {
            get { return Bag["Source"] as ITaskItem; }
            set { Bag["Source"] = value; }
        }
        /// <summary>
        /// Either EXE or DLL indicating the assembly type to be generated
        /// </summary>
        public string TargetType
        {
            get { return Bag["TargetType"] as string; }
            set { Bag["TargetType"] = value; }
        }
        #endregion

        #region ToolTask Members
        protected override string ToolName
        {
            get { return "ILAsm.exe"; }
        }

        /// <summary>
        /// Use ToolLocationHelper to find ILASM.EXE in the Framework directory
        /// </summary>
        /// <returns></returns>
        protected override string GenerateFullPathToTool()
        {
            // Ask ToolLocationHelper to find ILASM.EXE - it will look in the latest framework directory available
            return ToolLocationHelper.GetPathToDotNetFrameworkFile(ToolName, TargetDotNetFrameworkVersion.VersionLatest);
        }
        #endregion

        #region ILAsm Task Members
        /// <summary>
        /// Construct the command line from the task properties by using the CommandLineBuilder
        /// </summary>
        /// <returns></returns>
        protected override string GenerateCommandLineCommands()
        {
            CommandLineBuilder builder = new CommandLineBuilder();

            // We don't need the tool's logo information shown
            builder.AppendSwitch("/nologo");

            string targetType = Bag["TargetType"] as string;
            // Be explicit with our switches
            if (targetType != null)
            {
                if (String.Compare(targetType, "DLL", true) == 0)
                {
                    builder.AppendSwitch("/DLL");
                }
                else if (String.Compare(targetType, "EXE", true) == 0)
                {
                    builder.AppendSwitch("/EXE");
                }
                else
                {
                    Log.LogWarning("Invalid TargetType (valid values are DLL and EXE) specified: {0}", targetType);
                }
            }

            // Add the filename that we want the tool to process
            builder.AppendFileNameIfNotNull(Bag["Source"] as ITaskItem);

            // Log a High importance message stating the file that we are assembling
            Log.LogMessage(MessageImportance.High, "Assembling {0}", Bag["Source"]);

            // We have all of our switches added, return the commandline as a string
            return builder.ToString();
        }
        #endregion
    }
}
//</Snippet1>