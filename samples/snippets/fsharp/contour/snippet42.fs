
let makeGame2 target guess =
    if guess = target then
       System.Console.WriteLine("You win!")
    else 
       System.Console.WriteLine("Wrong. Try again.")
        
let playGame2 = makeGame2 7
playGame2 2
playGame2 9
playGame2 7

let alphaGame2 = makeGame2 'q'
alphaGame2 'c'
alphaGame2 'r'
alphaGame2 'j'
alphaGame2 'q'