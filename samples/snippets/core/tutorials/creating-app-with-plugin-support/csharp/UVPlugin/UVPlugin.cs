using PluginBase;
using System;
using System.Runtime.InteropServices;

namespace UVPlugin
{
    public class UVPlugin : ICommand
    {
        public string Name => "uv";

        public string Description => "Uses the native library libuv to show its version.";

        public int Execute()
        {
            Console.WriteLine($"Using libuv version {GetVersion()}.");
            return 0;
        }

        [DllImport("libuv", CallingConvention = CallingConvention.Cdecl)]
        private extern static uint uv_version();

        private static Version GetVersion()
        {
            uint version = uv_version();
            return new Version((int)(version & 0xFF0000) >> 16, (int)(version & 0xFF00) >> 8, (int)(version & 0xFF));
        }
    }
}
