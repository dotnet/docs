//-----------------------------------------------------------------------------
//<Snippet2>
using System;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

[Serializable]
[SqlUserDefinedAggregate(Format.Native)]
public struct CountVowels
{
    // count only the vowels in the passed-in strings
    private SqlInt32 countOfVowels;


    public void Init()
    {
        countOfVowels = 0;
    }


    public void Accumulate(SqlString value)
    {
        // list of vowels to look for
        string vowels = "aeiou";
        
        // for each character in the given parameter
        for (int i=0; i < value.ToString().Length; i++)
        {
            // for each character in the vowels string
            for (int j=0; j < vowels.Length; j++)
            {
                // convert parameter character to lowercase and compare to vowel
                if (value.Value.Substring(i,1).ToLower() == vowels.Substring(j,1))
                {
                    // it is a vowel, increment the count
                    countOfVowels+=1;
                }
            }
        }
    }


    public void Merge(CountVowels value)
    {
        Accumulate(value.Terminate());
    }


    public SqlString Terminate()
    {
        return countOfVowels.ToString();
    }
}
//</Snippet2>


//-----------------------------------------------------------------------------
//<Snippet6>
[SqlUserDefinedAggregate(Format.Native)]
public class SampleAggregate
{
   //...
}
//</Snippet6>
