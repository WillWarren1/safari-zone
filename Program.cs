using System;
using System.Linq;

namespace safari_zone
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Mark saw some animals.");

      var db = new SafariVacationContext();

      var coolAnimal = new SeenAnimal
      {
        Species = "Elephant",
        CountOfTimesSeen = 13,
        LocationOfLastSeen = "Grasslands"
      };

      var coolAnimal2 = new SeenAnimal
      {
        Species = "Field Mouse",
        CountOfTimesSeen = 1,
        LocationOfLastSeen = "Grasslands"
      };

      var coolAnimal3 = new SeenAnimal
      {
        Species = "Blue Whale",
        CountOfTimesSeen = 16,
        LocationOfLastSeen = "Ocean"
      };

      var coolAnimal4 = new SeenAnimal
      {
        Species = "Camel",
        CountOfTimesSeen = 4,
        LocationOfLastSeen = "Desert"
      };

      var coolAnimal5 = new SeenAnimal
      {
        Species = "Slothmonkey",
        CountOfTimesSeen = 2700,
        LocationOfLastSeen = "Jungle"
      };

      var coolAnimal6 = new SeenAnimal
      {
        Species = "Lion",
        CountOfTimesSeen = 7,
        LocationOfLastSeen = "Sahara"
      };

      var coolAnimal7 = new SeenAnimal
      {
        Species = "Tiger",
        CountOfTimesSeen = 13,
        LocationOfLastSeen = "Grasslands"
      };

      var coolAnimal8 = new SeenAnimal
      {
        Species = "Bear",
        CountOfTimesSeen = 20,
        LocationOfLastSeen = "forest"
      };

      //   db.Animals.Add(coolAnimal);
      //   db.Animals.Add(coolAnimal2);
      //   db.Animals.Add(coolAnimal3);
      //   db.Animals.Add(coolAnimal4);
      //   db.Animals.Add(coolAnimal5);
      //   db.Animals.Add(coolAnimal6);
      //   db.Animals.Add(coolAnimal7);
      //   db.Animals.Add(coolAnimal8);
      //   db.SaveChanges();

      //SELECT
      var allThemAnimals = db.Animals;
      string allVowels = "AEIOU";

      foreach (var animal in allThemAnimals)
      {
        if (allVowels.Contains(animal.Species[0]))
        {
          Console.WriteLine($"Mark saw an {animal.Species}");
        }
        else
        {
          Console.WriteLine($"Mark saw a {animal.Species}");
        }
      }

      //UPDATE
      var updatedAnimals = db.Animals.FirstOrDefault(animal => animal.Species == "Slothmonkey");
      //   Console.WriteLine(updatedAnimals.Species);
      if (updatedAnimals != null)
      {
        updatedAnimals.CountOfTimesSeen = 2701;
        updatedAnimals.LocationOfLastSeen = "Ocean";
        // Console.WriteLine(updatedAnimals.CountOfTimesSeen);
      }

      var bear = db.Animals.FirstOrDefault(animal => animal.Species == "Bear");
      //   Console.WriteLine(bear.Species);
      if (bear != null)
      {
        bear.CountOfTimesSeen = 14;
        bear.LocationOfLastSeen = "Jungle";
        // Console.WriteLine(bear.CountOfTimesSeen);
      }
      db.SaveChanges();

      //display jungle
      var jungleAnimals = db.Animals.Where(animal => animal.LocationOfLastSeen == "Jungle");
      foreach (var animal in jungleAnimals)
      {
        Console.WriteLine($"Mark saw {animal.Species} in the jungle");
      }

      //remove desert animals
      var desertAnimals = db.Animals.FirstOrDefault(animal => animal.LocationOfLastSeen.Contains("Desert"));
      //   Console.WriteLine(desertAnimals.Species);
      if (desertAnimals != null)
      {
        db.Animals.Remove(desertAnimals);
      }
      db.SaveChanges();

      //count all the animals
      var allAnimals = db.Animals;
      var animalCount = 0;
      foreach (var animal in allAnimals)
      {
        animalCount += animal.CountOfTimesSeen;
      }
      Console.WriteLine($"Mark saw {animalCount} animals");

      // count lions and tigers and bears oh my
      var ligerBear = db.Animals.Where(animal => animal.Species == "Bear" || animal.Species == "Lion" || animal.Species == "Tiger");
      var ligerBearCount = 0;
      foreach (var animal in ligerBear)
      {
        ligerBearCount += animal.CountOfTimesSeen;
      }
      Console.WriteLine($"Mark saw {ligerBearCount} lions, tigers, and bears. Oh my!");
    }
  }
}
