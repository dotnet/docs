// REDMOND\glennha
// <Snippet1>
using System;

public class DinoDiscoverySet
{
    public static void Main()
    {
        string[] dinosaurs =
        {
            "Compsognathus", "Amargasaurus", "Oviraptor",
            "Velociraptor",  "Deinonychus",  "Dilophosaurus",
            "Gallimimus",    "Triceratops"
        };

        DinoDiscoverySet GoMesozoic = new DinoDiscoverySet(dinosaurs);
        
        GoMesozoic.DiscoverAll();
        GoMesozoic.DiscoverByEnding("saurus");
    }

    private string[] dinosaurs;

    public DinoDiscoverySet(string[] items)
    {
        dinosaurs = items;
    }

    public void DiscoverAll()
    {
        Console.WriteLine();
        foreach(string dinosaur in dinosaurs)
        {
            Console.WriteLine(dinosaur);
        }
    }

    public void DiscoverByEnding(string Ending)
    {
        Predicate<string> dinoType;

        switch (Ending.ToLower())
        {
            case "raptor":
                dinoType = EndsWithRaptor;
                break;
            case "tops":
                dinoType = EndsWithTops;
                break;
            case "saurus":
            default:
                dinoType = EndsWithSaurus;
                break;
        }
        Console.WriteLine(
            "\nArray.Exists(dinosaurs, \"{0}\"): {1}",
            Ending,
            Array.Exists(dinosaurs, dinoType));

        Console.WriteLine(
            "\nArray.TrueForAll(dinosaurs, \"{0}\"): {1}",
            Ending,
            Array.TrueForAll(dinosaurs, dinoType));

        Console.WriteLine(
            "\nArray.Find(dinosaurs, \"{0}\"): {1}",
            Ending,
            Array.Find(dinosaurs, dinoType));

        Console.WriteLine(
            "\nArray.FindLast(dinosaurs, \"{0}\"): {1}",
            Ending,
            Array.FindLast(dinosaurs, dinoType));

        Console.WriteLine(
            "\nArray.FindAll(dinosaurs, \"{0}\"):", Ending);

        string[] subArray =
            Array.FindAll(dinosaurs, dinoType);

        foreach(string dinosaur in subArray)
        {
            Console.WriteLine(dinosaur);
        }
    }

    // Search predicate returns true if a string ends in "saurus".
    private bool EndsWithSaurus(string s)
    {
        if ((s.Length > 5) &&
            (s.Substring(s.Length - 6).ToLower() == "saurus"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Search predicate returns true if a string ends in "raptor".
    private bool EndsWithRaptor(String s)
    {
        if ((s.Length > 5) &&
            (s.Substring(s.Length - 6).ToLower() == "raptor"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Search predicate returns true if a string ends in "tops".
    private bool EndsWithTops(String s)
    {
        if ((s.Length > 3) &&
            (s.Substring(s.Length - 4).ToLower() == "tops"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

/* This code example produces the following output:

Compsognathus
Amargasaurus
Oviraptor
Velociraptor
Deinonychus
Dilophosaurus
Gallimimus
Triceratops

Array.Exists(dinosaurs, "saurus"): True

Array.TrueForAll(dinosaurs, "saurus"): False

Array.Find(dinosaurs, "saurus"): Amargasaurus

Array.FindLast(dinosaurs, "saurus"): Dilophosaurus

Array.FindAll(dinosaurs, "saurus"):
Amargasaurus
Dilophosaurus
*/
// </Snippet1>


