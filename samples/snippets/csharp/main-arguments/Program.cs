using System;
using System.Threading.Tasks;

namespace main_arguments
{
    class Program
    {
        #region AsyncMain
        static async Task<int> Main(string[] args)
        {
            return await AsyncConsoleWork();
        }
        #endregion

        private static async Task<int> AsyncConsoleWork()
        {
            await Task.Delay(1000);
            return 0;
        }
    }
}
