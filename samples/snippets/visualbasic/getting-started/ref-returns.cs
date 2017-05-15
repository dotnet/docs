 using System;
 
public class Sentence
{
   private string[] words;
   private int currentSearchPointer;

  public Sentence(string sentence)
  {
      words = sentence.Split(' ');
      currentSearchPointer = -1;
  }

  public ref string FindNext(string startWithString, ref bool found)
  {
      for (int count = currentSearchPointer + 1; count < words.Length; count++)
      {
         if (words[count].StartsWith(startWithString))
         {
            currentSearchPointer = count;
            found = true;
            return ref words[currentSearchPointer];
         }
      }
      currentSearchPointer = -1;
      found = false;
      return ref words[0];
   }
  
   public string GetSentence()
   {
      String stringToReturn = null;
      foreach (var word in words)
         stringToReturn += $"{word} ";
      
      return stringToReturn.Trim();    
   }
}