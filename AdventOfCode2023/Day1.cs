using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace AdventOfCode2023
{
    static class Day1
    {
        public static Dictionary<string, int> numbersInLetters = new Dictionary<string, int>()
            {
                {"one",1},
                {"two",2},
                {"three",3},
                {"four",4},
                {"five",5},
                {"six",6},
                {"seven",7},
                {"eight",8},
                {"nine",9}
            };
        static void Main(string[] args)
        {
            Day1Task1();
        }
        static void Day1Task1()
        {
            List<string> input = File.ReadAllLines("input1Day1.txt").ToList();

            List<int> num = new();
            for (int i = 0; i < input.Count; i++)
            {
                string reversed = new string(input[i].ToCharArray().Reverse().ToArray());
                char[] numbers = new char[2];

                numbers[0] = input[i].GetNumber();
                numbers[1] = reversed.GetNumber();

                num.Add(Convert.ToInt32(new string(numbers)));
                Console.WriteLine(input[i] + $" {num[i]}");
            }

            Console.WriteLine(num.Sum());
        }
        public static char GetNumber(this string input)
        {
            int j = 0;
            while (j < input.Length && !char.IsDigit(input[j])) j++;
            return input[j];
        }

        static void Day1Task2()
        {
            List<string> input = File.ReadAllLines("input1Day1.txt").ToList();


        }
        public static int GetNumberFromLetters(this string input)
        {



            return 0;
        }
    }
}
