using System;
using Microsoft.Data.Sqlite;
using SQLitePCL;

namespace SystemLibrarySample
{
    class Program
    {
        #region snippet_NativeLibraryAdapter
        class NativeLibraryAdapter : IGetFunctionPointer
        {
            readonly IntPtr _library;

            public NativeLibraryAdapter(string name)
                => _library = SQLitePCL.NativeLibrary.Load(name);

            public IntPtr GetFunctionPointer(string name)
                => SQLitePCL.NativeLibrary.TryGetExport(_library, name, out var address)
                    ? address
                    : IntPtr.Zero;
        }
        #endregion

        static void Main()
        {
            #region snippet_SetProvider
            SQLite3Provider_dynamic_cdecl
                .Setup("sqlite3", new NativeLibraryAdapter("sqlite3"));
            SQLitePCL.raw.SetProvider(new SQLite3Provider_dynamic_cdecl());
            #endregion

            var connection = new SqliteConnection();
            Console.WriteLine($"System SQLite version: {connection.ServerVersion}");
        }
    }
}
