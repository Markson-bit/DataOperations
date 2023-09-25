using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Linq;

namespace DataOperations
{
    class Program
    {
        static void WriteListElement<T>(List<T> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        static void Main(string[] args)
        {
            var listOfNumbers = new List<int>
            {
                3, 5, 1, 2, 8, 12, 34, 55
            };


            var listOfNames = new List<string>
            {
                "Logan",
                "Felipe",
                "Joe"
            };

            var listOfSurnames = new List<string>
            {
                "Kapuczinho",
                "Montes",
                "Bacon"
            };

            var listOfPlayers = new List<Player>
            {
                new Player
                {
                    Number = 11,
                    Name = "Joe",
                    Surname = "Bacon"
                },
                new Player
                {
                    Number = 14,
                    Name = "Logan",
                    Surname = "Kapuczinho"
                },
                new Player
                {
                    Number = 10,
                    Name = "Felipe",
                    Surname = "Montes"
                },
                new Player
                {
                    Number = 11,
                    Name = "Test",
                    Surname = "Test2"
                }
            };

            //Return elements from listOfNumber with value increased by 2
            var list = listOfNumbers.Select(x => { return x + 2; }).ToList();
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine(); Console.WriteLine();

            // Returns Names, from list of Players
            List<string> list1 = listOfPlayers.Select(x => x.Name).ToList();
            WriteListElement(list1); Console.WriteLine();
            

            // Returns Names of Players, who have number 14 or 10, and are not null
            var list2 = listOfPlayers.Where(x => x.Number == 14 || x.Number == 10 && x.Number != null).ToList();

            list2.ForEach( x =>
            {
                Console.WriteLine(x.Name + " " + x.Surname); 
            });

            // Sorting Ints, and returns them by order
            Console.WriteLine();
            var sortedInts = listOfNumbers.Where(x => x != null).OrderBy(x => x).ToList();
            WriteListElement(sortedInts);

            // Grouping Players by their Numbers
            Console.WriteLine();
            var groups = listOfPlayers.GroupBy(x => x.Number).ToList();
            groups.ForEach(x =>
            {
                Console.WriteLine(x.Key);
                x.ToList().ForEach(y =>
                {
                    Console.WriteLine(y.Name + " ");
                });
            });
        }
    }
}