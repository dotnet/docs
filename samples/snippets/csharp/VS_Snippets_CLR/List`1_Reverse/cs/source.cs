// REDMOND\glennha
// <Snippet1>
using System;
using System.Collections.Generic;

public class Example
{
    public static void Main()
    {
        List<string> dinosaurs = new List<string>();

        dinosaurs.Add("Pachycephalosaurus");
        dinosaurs.Add("Parasauralophus");
        dinosaurs.Add("Mamenchisaurus");
        dinosaurs.Add("Amargasaurus");
        dinosaurs.Add("Coelophysis");
        dinosaurs.Add("Oviraptor");

        Console.WriteLine();
        foreach(string dinosaur in dinosaurs)
        {
            Console.WriteLine(dinosaur);
        }

        dinosaurs.Reverse();

        Console.WriteLine();
        foreach(string dinosaur in dinosaurs)
        {
            Console.WriteLine(dinosaur);
        }

        dinosaurs.Reverse(1, 4);

        Console.WriteLine();
        foreach(string dinosaur in dinosaurs)
        {
            Console.WriteLine(dinosaur);
        }
    }
}

/* This code example produces the following output:

Pachycephalosaurus
Parasauralophus
Mamenchisaurus
Amargasaurus
Coelophysis
Oviraptor

Oviraptor
Coelophysis
Amargasaurus
Mamenchisaurus
Parasauralophus
Pachycephalosaurus

Oviraptor
Parasauralophus
Mamenchisaurus
Amargasaurus
Coelophysis
Pachycephalosaurus
 */
// </Snippet1>


