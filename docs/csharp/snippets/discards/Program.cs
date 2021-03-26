using System;
using System.Threading.Tasks;

namespace Discards
{
    class Program
    {
        static async Task Main(string[] args)
        {
            DiscardPatternMatching.DiscardSwitchExample();
            DiscardExamples.DiscardOutParameter();
            await AsyncExample.TaskDiscard();
            DiscardOrVariable.DiscardVariables();
            Example.Main();
        }
    }
}
