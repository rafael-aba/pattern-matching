using System;

namespace pattern_matching
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Let us show how amazing pattern matching is!");
            Tuples_Structures_On_The_Fly();
        }

        private static void Tuples_Structures_On_The_Fly() {
            Console.WriteLine("STRUCTURES ON THE FLY\n");
            // Assume you have a x,y coordinate 
            var example_A = (1, 4); // Access by using .Item1, .Item2, and so on
            var example_B = (x: 4, y: 1); // Access by using .x and .y
            var example_C = (x: 10, y: 20, 30); // Access by .x, .y, .Item3
            (var example_D_x, var example_D_y) = (-1.0, -2.0); // Supports other than just integers
            var example_E = (name: "Rafael", surname: "Batista", company: "Rock Content", position: "Fullstack Developer", currentWorkPlace: "Home Office", doingNow: "Presenting how amazing this tuples are!"); // Strings are also fair deal

            Console.WriteLine($"- Coordinates A set as ({example_A.Item1},{example_A.Item2})");
            Console.WriteLine($"- Coordinates B set as ({example_B.x},{example_B.y})");
            Console.WriteLine($"- Coordinates C set as ({example_C.x},{example_C.y},{example_C.Item3})");
            Console.WriteLine($"- Coordinates D set as ({example_D_x},{example_D_y})");
            Console.WriteLine($"- Presented by {example_E.name} {example_E.surname} that works at {example_E.company} as a {example_E.position}. He is currently working {example_E.currentWorkPlace} and is actually {example_E.doingNow}");

            // Bringing the variables out and changing their values
            (var x, var y) = example_B;
            Console.WriteLine($"- The values x and y originated from {example_B} are, respectively, {x} and {y}");
            x = 7;
            example_B.y = 8;
            Console.WriteLine($"- After some changes, the original value is {example_B} and the extracted values are {x} and {y} -> value and not reference!");

            // Common scenario: Swapping two values 
            Console.WriteLine($"- The values of x and y are, respectively, {x} and {y}");

            (x, y) = (y, x); // NO NEED FOR A THIRD VARIABLE!

            Console.WriteLine($"- The new values of x and y are, respectively, {x} and {y} !");

            Console.WriteLine("-----------------------------------------------------");
        }
    }
}
