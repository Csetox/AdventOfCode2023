﻿using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace AdventOfCode2023
{
    static class Day1
    {
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
        static void Day1Task2()
        {
            List<string> input = File.ReadAllLines("input1Day1.txt").ToList();
            List<string> changedNumbers = new();

            for (int i = 0; i < input.Count; i++)
            {
                input[i] = input[i].Replace("one", "o1e"); // replacing the occurances of numbers with their number
                input[i] = input[i].Replace("two", "t2o"); // plus the letters that can be in another number
                input[i] = input[i].Replace("three", "th3e");// for example: oneight is 18 so the one shouldn't be 1 but 1e
                input[i] = input[i].Replace("four", "4");  // but twone is 21 so the one should be o1e etc.
                input[i] = input[i].Replace("five", "5e");
                input[i] = input[i].Replace("six", "6");
                input[i] = input[i].Replace("seven", "7n");
                input[i] = input[i].Replace("eight", "e8t");
                input[i] = input[i].Replace("nine", "n9e");

                changedNumbers.Add(input[i]);
            }

            Console.WriteLine(GetSum(changedNumbers));
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
    }
}
