using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

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
            Day1Task2();
        }
        static void Day1Task1()
        {
            List<string> input = File.ReadAllLines("input1Day1.txt").ToList();

            Console.WriteLine(GetSum(input));
        }
        public static char GetNumber(this string input)
        {
            int j = 0;
            while (j < input.Length && !char.IsDigit(input[j])) j++;
            return input[j];
        }

        public static int GetSum(List<string> input)
        {
            List<int> num = new();
            for (int i = 0; i < input.Count; i++)
            {
                string reversed = new string(input[i].ToCharArray().Reverse().ToArray());
                char[] numbers = new char[2];

                numbers[0] = input[i].GetNumber();
                numbers[1] = reversed.GetNumber();

                num.Add(Convert.ToInt32(new string(numbers)));
                //Console.WriteLine(input[i] + $" {num[i]}");
            }
            return num.Sum();
        }
        static void Day1Task2()
        {
            List<string> input = File.ReadAllLines("input1Day1.txt").ToList();

            List<string> numbers = GetNumberFromLetters(input);

            foreach(var item in numbers)
            {
                Console.WriteLine(item);
            }

            int res = GetSum(numbers);
            Console.WriteLine(res);
        }
        public static List<string> GetNumberFromLetters(List<string> input)
        {
            List<string> numbers = new();

            for (int i = 0; i < input.Count; i++)
            {
                foreach (KeyValuePair<string, int> kvp in numbersInLetters)
                {
                    if (input.Contains(kvp.Key))
                    {
                        Console.WriteLine(input[i].ChangeNumberInLetterToNumber(kvp.Key, kvp.Value));
                        numbers.Add(input[i].ChangeNumberInLetterToNumber(kvp.Key, kvp.Value));
                    }
                }
            }
            return numbers;
        }
        public static string ChangeNumberInLetterToNumber(this string input, string numberLetter, int number)
        {
            List<char> array = new();

            for (int i = 0; i < input.Length-numberLetter.Length; i++)
            {
                string sbstr = input.Substring(i, numberLetter.Length);

                if (sbstr == numberLetter)
                {
                    array = input.ToCharArray().ToList();

                    array.RemoveRange(i, numberLetter.Length);
                    array.Insert(i, char.Parse(number.ToString()));
                }
            }



            return new string(array.ToArray());
        }
    }
}
