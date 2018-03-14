'<snippet1>
' This example demonstrates the Console.Beep(Int32, Int32) method
Imports System
Imports System.Threading

Class Sample
   Public Shared Sub Main()
      ' Declare the first few notes of the song, "Mary Had A Little Lamb".
      Dim Mary As Note() =  { _
            New Note(Tone.B, Duration.QUARTER), _
            New Note(Tone.A, Duration.QUARTER), _
            New Note(Tone.GbelowC, Duration.QUARTER), _
            New Note(Tone.A, Duration.QUARTER), _
            New Note(Tone.B, Duration.QUARTER), _
            New Note(Tone.B, Duration.QUARTER), _
            New Note(Tone.B, Duration.HALF), _
            New Note(Tone.A, Duration.QUARTER), _
            New Note(Tone.A, Duration.QUARTER), _
            New Note(Tone.A, Duration.HALF), _
            New Note(Tone.B, Duration.QUARTER), _
            New Note(Tone.D, Duration.QUARTER), _
            New Note(Tone.D, Duration.HALF)}
      ' Play the song
      Play(Mary)
   End Sub 'Main
   
   ' Play the notes in a song.
   Protected Shared Sub Play(tune() As Note)
      Dim n As Note
      For Each n In  tune
         If n.NoteTone = Tone.REST Then
            Thread.Sleep(CInt(n.NoteDuration))
         Else
            Console.Beep(CInt(n.NoteTone), CInt(n.NoteDuration))
         End If
      Next n
   End Sub 'Play 
   ' Define the frequencies of notes in an octave, as well as 
   ' silence (rest).
   
   Protected Enum Tone
      REST = 0
      GbelowC = 196
      A = 220
      Asharp = 233
      B = 247
      C = 262
      Csharp = 277
      D = 294
      Dsharp = 311
      E = 330
      F = 349
      Fsharp = 370
      G = 392
      Gsharp = 415
   End Enum 'Tone
   
   ' Define the duration of a note in units of milliseconds.
   
   Protected Enum Duration
      WHOLE = 1600
      HALF = WHOLE / 2
      QUARTER = HALF / 2
      EIGHTH = QUARTER / 2
      SIXTEENTH = EIGHTH / 2
   End Enum 'Duration
   
   ' Define a note as a frequency (tone) and the amount of 
   ' time (duration) the note plays.
   Protected Structure Note
      Private toneVal As Tone
      Private durVal As Duration
      
      ' Define a constructor to create a specific note.
      Public Sub New(frequency As Tone, time As Duration)
         toneVal = frequency
         durVal = time
      End Sub 'New
      
      ' Define properties to return the note's tone and duration.
      Public ReadOnly Property NoteTone() As Tone
         Get
            Return toneVal
         End Get
      End Property
      
      Public ReadOnly Property NoteDuration() As Duration
         Get
            Return durVal
         End Get
      End Property
   End Structure 'Note '
'This example produces the following results:
'
'This example plays the first few notes of "Mary Had A Little Lamb" 
'through the console speaker.
'
End Class 'Sample
'</snippet1>