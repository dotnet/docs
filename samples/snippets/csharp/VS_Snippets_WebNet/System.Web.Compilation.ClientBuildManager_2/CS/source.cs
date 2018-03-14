// <Snippet1>

using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Compilation;
using System.Security;
using System.Security.Permissions;

namespace PrecompBuildSystem
{
    [PermissionSet(SecurityAction.Demand, Unrestricted = true)]
    public class PrecompBuilder
    {
        private static ClientBuildManager builder;
        private static String _vPath;	// Virtual
        private static String _pPath;	// Physical
        private static String _tPath;	// Target
        private static PrecompilationFlags _flags;
        private static ClientBuildManagerParameter _cbmParameter;
        private static String _keyContainer;

        public static void Main(string[] args)
        {
            // Check arguments.
            if (ValidateAndSetArguments(args))
            {
                //<Snippet2>
                _cbmParameter = new ClientBuildManagerParameter();
                _cbmParameter.PrecompilationFlags = _flags;
                _cbmParameter.StrongNameKeyContainer = _keyContainer;

                builder = new
                        ClientBuildManager(_vPath, _pPath, _tPath, _cbmParameter);
                //</Snippet2>
                // Pre-compile.
                if (Precompiler())
                {
                    Console.Write("Build succeeded. Result is at " + _tPath + ".");
                }
            }
        }

        private static bool ValidateAndSetArguments(string[] args)
        {
            try
            {
                if (args.Length > 0)
                {
                    _vPath = args[0];
                }
                else
                {
                    _vPath = (string)AppSettingsExpressionBuilder.GetAppSetting
                        ("virtualDirectory");
                }

                if (args.Length > 1)
                {
                    _pPath = args[1];
                }
                else
                {
                    _pPath = (string)AppSettingsExpressionBuilder.GetAppSetting
                        ("physicalDirectory");
                }

                if (args.Length > 2)
                {
                    _tPath = args[2];
                }
                else
                {
                    _tPath = (string)AppSettingsExpressionBuilder.GetAppSetting
                        ("targetDirectory");
                }

                if (args.Length > 3)
                {
                    string[] precompFlags = args[3].Split('|');
                    foreach (string flag in precompFlags)
                    {
                        _flags |= (PrecompilationFlags)Enum.Parse
                            (typeof(PrecompilationFlags), flag.Trim());
                    }
                }
                else
                {
                    _flags = PrecompilationFlags.Clean |
                        PrecompilationFlags.ForceDebug;
                }

                if (args.Length > 4)
                {
                    _keyContainer = args[4];
                }

                return true;
            }
            catch (Exception e)
            {
                OutputErrorList(e);
            }
            return false;
        }
        private static void OutputErrorList(Exception e)
        {
            Console.Write("Error: " + e.Message);
        }

        private static bool Precompiler()
        {
            try
            {
                builder.PrecompileApplication();

                // The precompilation was successful.
                return true;
            }
            catch (Exception e)
            {
                OutputErrorList(e);
            }

            // The precompilation failed.
            return false;
        }
    }
}
// </Snippet1>