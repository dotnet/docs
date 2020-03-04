using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DependencyModel;
using RuntimeEnvironment = Microsoft.DotNet.PlatformAbstractions.RuntimeEnvironment;

namespace ExtensionsSample
{
    class Program
    {
        static void Main()
        {
            var connection = new SqliteConnection("Data Source=:memory:");
            connection.Open();

            EnsureLoadable(
                package: "mod_spatialite",
                library: "mod_spatialite");

            #region snippet_LoadExtension
            // Load the SpatiaLite extension
            connection.LoadExtension("mod_spatialite");

            var command = connection.CreateCommand();
            command.CommandText =
            @"
                SELECT spatialite_version()
            ";
            var version = (string)command.ExecuteScalar();

            Console.WriteLine($"Using SpatiaLite {version}");
            #endregion
        }

        static void EnsureLoadable(string package, string library)
        {
            var runtimeLibrary = DependencyContext.Default?.RuntimeLibraries.FirstOrDefault(l => l.Name == package);
            if (runtimeLibrary == null)
                return;

            string sharedLibraryExtension;
            string pathVariableName;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                sharedLibraryExtension = ".dll";
                pathVariableName = "PATH";
            }
            else
            {
                // NB: Modifying the path at runtime only works on Windows. On Linux and Mac, set LD_LIBRARY_PATH or
                //     DYLD_LIBRARY_PATH before running the app
                return;
            }

            var candidateAssets = new Dictionary<(string Package, string Asset), int>();
            var rid = RuntimeEnvironment.GetRuntimeIdentifier();
            var rids = DependencyContext.Default.RuntimeGraph.First(g => g.Runtime == rid).Fallbacks.ToList();
            rids.Insert(0, rid);

            foreach (var group in runtimeLibrary.NativeLibraryGroups)
            {
                foreach (var file in group.RuntimeFiles)
                {
                    if (string.Equals(
                        Path.GetFileName(file.Path),
                        library + sharedLibraryExtension,
                        StringComparison.OrdinalIgnoreCase))
                    {
                        var fallbacks = rids.IndexOf(group.Runtime);
                        if (fallbacks != -1)
                        {
                            candidateAssets.Add((runtimeLibrary.Path, file.Path), fallbacks);
                        }
                    }
                }
            }

            var assetPath = candidateAssets
                .OrderBy(p => p.Value)
                .Select(p => p.Key)
                .FirstOrDefault();
            if (assetPath != default)
            {
                string assetDirectory = null;
                if (File.Exists(Path.Combine(AppContext.BaseDirectory, assetPath.Asset)))
                {
                    // NB: Framework-dependent deployments copy assets to the application base directory
                    assetDirectory = Path.Combine(
                        AppContext.BaseDirectory,
                        Path.GetDirectoryName(assetPath.Asset.Replace('/', Path.DirectorySeparatorChar)));
                }
                else
                {
                    string assetFullPath = null;
                    var probingDirectories = ((string)AppDomain.CurrentDomain.GetData("PROBING_DIRECTORIES"))
                        .Split(Path.PathSeparator);
                    foreach (var directory in probingDirectories)
                    {
                        var candidateFullPath = Path.Combine(
                            directory,
                            (assetPath.Package + "/" + assetPath.Asset).Replace('/', Path.DirectorySeparatorChar));
                        if (File.Exists(candidateFullPath))
                        {
                            assetFullPath = candidateFullPath;
                        }
                    }

                    Debug.Assert(assetFullPath != null);

                    assetDirectory = Path.GetDirectoryName(assetFullPath);
                }

                Debug.Assert(assetDirectory != null);

                var path = new HashSet<string>(Environment.GetEnvironmentVariable(pathVariableName).Split(Path.PathSeparator));

                if (path.Add(assetDirectory))
                    Environment.SetEnvironmentVariable(pathVariableName, string.Join(Path.PathSeparator, path));
            }
        }
    }
}
