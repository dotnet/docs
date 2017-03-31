' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet1>
Imports System.Collections.Generic

Module Example
   Public Sub Main()
      ' Organization of runningBacks 5-tuple:
      '    Component 1: Player name
      '    Component 2: Number of games played
      '    Component 3: Number of attempts (carries)
      '    Component 4: Number of yards gained 
      '    Component 5: Number of touchdowns   
      Dim runningBacks() =
          { Tuple.Create("Payton, Walter", 190, 3838, 16726, 110),  
            Tuple.Create("Sanders, Barry", 153, 3062, 15269, 99),            
            Tuple.Create("Brown, Jim", 118, 2359, 12312, 106),            
            Tuple.Create("Dickerson, Eric", 144, 2996, 13259, 90),            
            Tuple.Create("Faulk, Marshall", 176, 2836, 12279, 100) } 
      ' Calculate statistics.
      ' Organization of runningStats 5-tuple:
      '    Component 1: Player name
      '    Component 2: Number of attempts per game
      '    Component 3: Number of yards per game
      '    Component 4: Number of yards per attempt 
      '    Component 5: Number of touchdowns per attempt   
      Dim runningStats() = ComputeStatistics(runningBacks)

      ' Display the result.          
      Console.WriteLine("{0,-16} {1,5} {2,6} {3,7} {4,7} {5,7} {6,7} {7,5} {8,7}", 
                        "Name", "Games", "Att", "Att/Gm", "Yards", "Yds/Gm",
                        "Yds/Att", "TD", "TD/Att")
      Console.WriteLine()
      For ctr As Integer = 0 To runningBacks.Length - 1
         Console.WriteLine("{0,-16} {1,5} {2,6:N0} {3,7:N1} {4,7:N0} {5,7:N1} {6,7:N2} {7,5} {8,7:N3}", 
                           runningBacks(ctr).Item1, runningBacks(ctr).Item2, runningBacks(ctr).Item3, 
                           runningStats(ctr).Item2, runningBacks(ctr).Item4, runningStats(ctr).Item3, 
                           runningStats(ctr).Item4, runningBacks(ctr).Item5, runningStats(ctr).Item5)
         Console.WriteLine()  
      Next     
   End Sub

   Private Function ComputeStatistics(players() As Tuple(Of String, Integer, Integer, Integer, Integer)) _
                    As Tuple(Of String, Double, Double, Double, Double)()

      Dim result As Tuple(Of String, Double, Double, Double, Double)
      Dim list As New List(Of Tuple(Of String, Double, Double, Double, Double))()
      
      For Each player In players
         ' Create result object containing player name and statistics.
         result = Tuple.Create(player.Item1,  
                            player.Item3/player.Item2, player.Item4/player.Item2,
                            player.Item4/player.Item3, player.Item5/player.Item3)
         list.Add(result)         
      Next
      Return list.ToArray()  
   End Function
End Module
' The example displays the following output:
'    Name             Games    Att  Att/Gm   Yards  Yds/Gm Yds/Att    TD  TD/Att
'    
'    Payton, Walter     190  3,838    20.2  16,726    88.0    4.36   110   0.029
'    
'    Sanders, Barry     153  3,062    20.0  15,269    99.8    4.99    99   0.032
'    
'    Brown, Jim         118  2,359    20.0  12,312   104.3    5.22   106   0.045
'    
'    Dickerson, Eric    144  2,996    20.8  13,259    92.1    4.43    90   0.030
'    
'    Faulk, Marshall    176  2,836    16.1  12,279    69.8    4.33   100   0.035
' </Snippet1>
