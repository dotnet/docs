//<snippet1>
// This example demonstrates the Console.Beep(Int32, Int32) method
using System;
using System.Threading;

class Sample 
{
    public static void Main() 
    {
// Declare the first few notes of the song, "Mary Had A Little Lamb".
    Note[] Mary = 
        {
        new Note(Tone.B, Duration.QUARTER),
        new Note(Tone.A, Duration.QUARTER),
        new Note(Tone.GbelowC, Duration.QUARTER),
        new Note(Tone.A, Duration.QUARTER),
        new Note(Tone.B, Duration.QUARTER),
        new Note(Tone.B, Duration.QUARTER),
        new Note(Tone.B, Duration.HALF),
        new Note(Tone.A, Duration.QUARTER),
        new Note(Tone.A, Duration.QUARTER),
        new Note(Tone.A, Duration.HALF),
        new Note(Tone.B, Duration.QUARTER),
        new Note(Tone.D, Duration.QUARTER),
        new Note(Tone.D, Duration.HALF)
        };
// Play the song
    Play(Mary);
    }

// Play the notes in a song.
    protected static void Play(Note[] tune)
    {
    foreach (Note n in tune)
        {
        if (n.NoteTone == Tone.REST)
            Thread.Sleep((int)n.NoteDuration);
        else
            Console.Beep((int)n.NoteTone, (int)n.NoteDuration);
        }
    }

// Define the frequencies of notes in an octave, as well as 
// silence (rest).
    protected enum Tone
    {
    REST   = 0,
    GbelowC = 196,
    A      = 220,
    Asharp = 233,
    B      = 247,
    C      = 262,
    Csharp = 277,
    D      = 294,
    Dsharp = 311,
    E      = 330,
    F      = 349,
    Fsharp = 370,
    G      = 392,
    Gsharp = 415, 
    }

// Define the duration of a note in units of milliseconds.
    protected enum Duration
    {
    WHOLE     = 1600,
    HALF      = WHOLE/2,
    QUARTER   = HALF/2,
    EIGHTH    = QUARTER/2,
    SIXTEENTH = EIGHTH/2,
    }

// Define a note as a frequency (tone) and the amount of 
// time (duration) the note plays.
    protected struct Note
    {
    Tone     toneVal;
    Duration durVal;

// Define a constructor to create a specific note.
    public Note(Tone frequency, Duration time)
        {
        toneVal = frequency;
        durVal  = time;
        }

// Define properties to return the note's tone and duration.
    public Tone NoteTone { get{ return toneVal; } }
    public Duration NoteDuration { get{ return durVal; } }
    }
}
/*
This example produces the following results:

This example plays the first few notes of "Mary Had A Little Lamb" 
through the console speaker.
*/
//</snippet1>