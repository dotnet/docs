Module Module6

    Sub Main()
        ' Variable takeAGuess is a Boolean function. It stores the target
        ' number that is set in makeTheGame.
        Dim takeAGuess As gameDelegate = makeTheGame()

        ' Set up the loop to play the game.
        Dim guess As Integer
        Dim gameOver = False
        While Not gameOver
            guess = CInt(InputBox("Enter a number between 1 and 10 (0 to quit)", "Guessing Game", "0"))
            ' A guess of 0 means you want to give up.
            If guess = 0 Then
                gameOver = True
            Else
                ' Tests your guess and announces whether you are correct. Method takeAGuess
                ' is called multiple times with different guesses. The target value is not 
                ' accessible from Main and is not passed in.
                gameOver = takeAGuess(guess)
                Console.WriteLine("Guess of " & guess & " is " & gameOver)
            End If
        End While

    End Sub

    Delegate Function gameDelegate(ByVal aGuess As Integer) As Boolean

    Public Function makeTheGame() As gameDelegate

        ' Generate the target number, between 1 and 10. Notice that 
        ' target is a local variable. After you return from makeTheGame,
        ' it is not directly accessible.
        Randomize()
        Dim target As Integer = CInt(Int(10 * Rnd() + 1))

        ' Print the answer if you want to be sure the game is not cheating
        ' by changing the target at each guess.
        Console.WriteLine("(Peeking at the answer) The target is " & target)

        ' The game is returned as a lambda expression. The lambda expression
        ' carries with it the environment in which it was created. This 
        ' environment includes the target number. Note that only the current
        ' guess is a parameter to the returned lambda expression, not the target. 

        ' Does the guess equal the target?
        Dim playTheGame = Function(guess As Integer) guess = target

        Return playTheGame

    End Function

End Module