
//<snippet1>
// This example demonstrates the Console.Beep(Int32, Int32) method
using namespace System;
using namespace System::Threading;
ref class Sample
{
protected:

   // Define the frequencies of notes in an octave, as well as 
   // silence (rest).
   enum class Tone
   {
      REST = 0,
      GbelowC = 196,
      A = 220,
      Asharp = 233,
      B = 247,
      C = 262,
      Csharp = 277,
      D = 294,
      Dsharp = 311,
      E = 330,
      F = 349,
      Fsharp = 370,
      G = 392,
      Gsharp = 415
   };


   // Define the duration of a note in units of milliseconds.
   enum class Duration
   {
      WHOLE = 1600,
      HALF = Duration::WHOLE / 2,
      QUARTER = Duration::HALF / 2,
      EIGHTH = Duration::QUARTER / 2,
      SIXTEENTH = Duration::EIGHTH / 2
   };


public:

   // Define a note as a frequency (tone) and the amount of 
   // time (duration) the note plays.
   value struct Note
   {
   public:
      Tone toneVal;
      Duration durVal;

      // Define a constructor to create a specific note.
      Note( Tone frequency, Duration time )
      {
         toneVal = frequency;
         durVal = time;
      }


      property Tone NoteTone 
      {

         // Define properties to return the note's tone and duration.
         Tone get()
         {
            return toneVal;
         }

      }

      property Duration NoteDuration 
      {
         Duration get()
         {
            return durVal;
         }

      }

   };


protected:

   // Play the notes in a song.
   static void Play( array<Note>^ tune )
   {
      System::Collections::IEnumerator^ myEnum = tune->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         Note n =  *safe_cast<Note ^>(myEnum->Current);
         if ( n.NoteTone == Tone::REST )
                  Thread::Sleep( (int)n.NoteDuration );
         else
                  Console::Beep( (int)n.NoteTone, (int)n.NoteDuration );
      }
   }


public:
   static void Main()
   {
      
      // Declare the first few notes of the song, "Mary Had A Little Lamb".
      array<Note>^ Mary = {Note( Tone::B, Duration::QUARTER ),Note( Tone::A, Duration::QUARTER ),Note( Tone::GbelowC, Duration::QUARTER ),Note( Tone::A, Duration::QUARTER ),Note( Tone::B, Duration::QUARTER ),Note( Tone::B, Duration::QUARTER ),Note( Tone::B, Duration::HALF ),Note( Tone::A, Duration::QUARTER ),Note( Tone::A, Duration::QUARTER ),Note( Tone::A, Duration::HALF ),Note( Tone::B, Duration::QUARTER ),Note( Tone::D, Duration::QUARTER ),Note( Tone::D, Duration::HALF )};
      
      // Play the song
      Play( Mary );
   }

};

int main()
{
   Sample::Main();
}

/*
This example produces the following results:

This example plays the first few notes of "Mary Had A Little Lamb" 
through the console speaker.
*/
//</snippet1>
