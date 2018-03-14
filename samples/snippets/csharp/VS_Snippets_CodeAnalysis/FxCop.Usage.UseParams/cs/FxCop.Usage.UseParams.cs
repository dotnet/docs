//<Snippet1>
using System;

[assembly: CLSCompliant(true)]
namespace UsageLibrary
{
    public class UseParams 
    {
        // This method violates the rule.
        [CLSCompliant(false)]
        public void VariableArguments(__arglist) 
        { 
            ArgIterator argumentIterator = new ArgIterator(__arglist);
            for(int i = 0; i < argumentIterator.GetRemainingCount(); i++) 
            { 
                Console.WriteLine(
                    __refvalue(argumentIterator.GetNextArg(), string));
            } 
        }

        // This method satisfies the rule.
        public void VariableArguments(params string[] wordList)
        { 
            for(int i = 0; i < wordList.Length; i++) 
            { 
                Console.WriteLine(wordList[i]);
            } 
        }
    }
}
//</Snippet1>
