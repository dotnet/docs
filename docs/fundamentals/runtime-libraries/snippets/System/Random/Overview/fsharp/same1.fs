module Same1

// <Snippet12>
open System
open System.IO

let showRandomNumbers seed =
    let rnd = Random seed
    for _ = 0 to 20 do 
        printfn $"{rnd.NextDouble()}"

let persistSeed (seed: int) =
    use bin = new BinaryWriter(new FileStream(@".\seed.dat", FileMode.Create))
    bin.Write seed

let displayNewRandomNumbers () =
    use bin = new BinaryReader(new FileStream(@".\seed.dat", FileMode.Open))
    let seed = bin.ReadInt32()

    let rnd = Random seed
    for _ = 0 to 20 do 
        printfn $"{rnd.NextDouble()}"

let seed = 100100
showRandomNumbers seed
printfn ""

persistSeed seed

displayNewRandomNumbers ()

// The example displays output like the following:
//       0.500193602172748
//       0.0209461245783354
//       0.465869495396442
//       0.195512794514891
//       0.928583675496552
//       0.729333720509584
//       0.381455668891527
//       0.0508996467343064
//       0.019261200921266
//       0.258578445417145
//       0.0177532266908107
//       0.983277184415272
//       0.483650274334313
//       0.0219647376900375
//       0.165910115077118
//       0.572085966622497
//       0.805291457942357
//       0.927985211335116
//       0.4228545699375
//       0.523320379910674
//       0.157783938645285
//
//       0.500193602172748
//       0.0209461245783354
//       0.465869495396442
//       0.195512794514891
//       0.928583675496552
//       0.729333720509584
//       0.381455668891527
//       0.0508996467343064
//       0.019261200921266
//       0.258578445417145
//       0.0177532266908107
//       0.983277184415272
//       0.483650274334313
//       0.0219647376900375
//       0.165910115077118
//       0.572085966622497
//       0.805291457942357
//       0.927985211335116
//       0.4228545699375
//       0.523320379910674
//       0.157783938645285
// </Snippet12>
