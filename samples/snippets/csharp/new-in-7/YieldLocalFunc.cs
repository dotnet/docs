using System;
using System.Collections.Generic;
using System.Linq;

namespace new_in_7
{
    public class YieldLocalFuncDemo
    {
        // <SnippetYieldExample>
        public IEnumerable<string> SequenceToLowercase(IEnumerable<string> input)
        {
            if (input.Count() == 0)
            {
                throw new Exception("There are no items to convert to lowercase!");
            }
            
            return LowercaseIterator();
            
            IEnumerable<string> LowercaseIterator()
            {
                foreach (var item in input)
                {
                    var output = item.ToLower();
                    yield return output;
                }
            }
        }
        // </SnippetYieldExample>
    }
}