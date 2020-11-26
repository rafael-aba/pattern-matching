using System;
using System.Collections.Generic;
using System.Linq;
using Items;

namespace pattern_matching
{
    class Program
    {
        static void Main(string[] args)
        {
            // A feature already on F#, Kotlin, Swift, Haskell, SNOBOL
            Console.WriteLine("Let us show how amazing pattern matching is!");
            Expressions();
            SwitchStatement();
        }

        private static void Expressions() {
            Console.WriteLine("Suppose we want a square between 5 and 30 units of area.\n");
            
            Console.WriteLine("Creating a square of side 4 unit of measurement\n");
            var square = new Square(Color.White, 4);

            // if (square.Area() > 10 && square.Area() < 20)
            if (square.Area() is > 5 and < 30)
                Console.WriteLine("Looks like we have our square!");
            else
                Console.WriteLine("Bammer.");

            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Now we have a list of squares from side 1 to 7. We are looking for squares of area between 5 and 30, and perimeter also between 15 and 17 .\n");

            var squares = new List<Square> () {
                new Square(Color.White, 1),
                new Square(Color.White, 2),
                new Square(Color.White, 3),
                new Square(Color.White, 4),
                new Square(Color.White, 5),
                new Square(Color.White, 6),
                new Square(Color.White, 7)
            };

            Console.WriteLine("Filtering squares...\n");
            var chosen_ones = squares.Where(s => s.Area() is > 5 and < 30 && s.Perimeter() is > 15 and < 17);

            Console.WriteLine($"{chosen_ones.Count()} had the property we wanted.\n");
            Console.WriteLine("-----------------------------------------------------");
        }

        private static void SwitchStatement() {
            SimplifyingManyIfs();
            SimplifyingObjectMatching();
        }

        private static void SimplifyingManyIfs() {
            var square = new Square(Color.White, 5);
            Console.WriteLine($"This shape is {GetHowBigTheShapeIs_Old_And_Boring_Way(square)}! ");
            Console.WriteLine($"This shape is {GetHowBigTheShapeIs_New_And_Cool_Way(square)}! ");
            Console.WriteLine("-----------------------------------------------------");
        }

        private static string GetHowBigTheShapeIs_Old_And_Boring_Way(Shape shape) {
            if (shape.Area() < 5) {
                return "very small";
            }
            if (shape.Area() < 21) {
                return "small";
            }
            if (shape.Area() < 55) {
                return "kinda meh";
            }
            if (shape.Area() < 144) {
                return "it is getting interesting";
            }
            if (shape.Area() < 377) {
                return "big";
            }
            if (shape.Area() < 987) {
                return "very big";
            }
            return "OMG WHAT IS THAT";
        }

        private static string GetHowBigTheShapeIs_New_And_Cool_Way(Shape shape) {
            return shape.Area() switch {
                < 5 => "very small",
                < 21 => "small",
                < 55 => "kinda meh",
                < 144=> "it is getting interesting",
                < 377 => "big",
                < 987 => "very big",
                _ => "OMG WHAT IS THAT"
            };
        }

        private static void SimplifyingObjectMatching() {
            Console.WriteLine("Let us do something crazy with the following shapes");
            var shapes = new List<Quadrilateral>() {
                new Square(Color.White, 5),
                new Square(Color.Green, 0.5),
                new Rectangle(Color.Green, 3, 3),
                new Rectangle(Color.Violet, 3, 3),
                new Rectangle(Color.Violet, 0.03, 0.4),
                new Square(Color.Orange, 101),
                new Rectangle(Color.Yellow, 100, 500),
                new Rectangle(Color.Black, 100, 500),
            };

            foreach(var shape in shapes) {
                Console.WriteLine( shape switch { // positional pattern all around
                    Square {color: Color.White} => $"I am a {Color.White} square!", // Type Pattern
                    Square s when s.color == Color.Green && s.Area() is > 0 and < 1 => $"I am a tiny {s.color} square!", // Type & conjunctive and pattern
                    {color: Color.Green} => "The only thing I am sure is that I am GREEN BABY!", // Property Pattern
                    Square and (true, > 100, _) and {color: Color.Orange} => "I am a very specific square", // wait what? type, tuple, and conjunctive patterns!
                    (Square or {color: Color.Yellow}) and  (_, > 100, _) => "I am... something?", // above, but increased with disjunctive and parenthesized patterns
                    (true, _, _) => "I am a regular shape hehe", // Tuple Pattern
                    (false, > 0 and < 1, var perimeter) => $"I am a tiny not regular shape. Just so you know, perimeter is measily {perimeter} units!", // Tuple and relational Pattern
                    not Square => "I am not a square duh",
                    _ => "I am a rebel, I don't fit anywhere!" // Wild Card
                });
            }
        }
    }
}
