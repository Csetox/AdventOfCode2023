using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace AdventOfCode2023
{
    static class Day2
    {
        static void Main()
        {
            Day2Task1();
        }
        public static void Day2Task1()
        {
            //Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
            //Need to split at ':' ';' and ','
            //var input = File.ReadAllLines("InputDay2.txt");
            string input="Game 111: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green";

            string gameNum = input.Split(':')[0].Split(' ')[1];
            int length = input.Split(':')[1].Split(';').Length;
            int[,] gameCubes = new int[3, length]; // [0] is red; [1] is green; [2] is blue

            var s = input.Split(':')[1].Split(';').Select(str => str.Substring(1)).ToArray();




            //  | which hand in one game 
            //  V             | which color
            //                V            | removing the first whitespace found before every number
            //                             V
            string redCubes = input.Split(':')[1].Split(';')[0].Split(',')[0].Substring(1);
            // Console.WriteLine(redCubes);

            List<Game> foo = Parse();

            for (int i = 0; i < foo.Count; i++)
            {
                Console.WriteLine(foo[i].gameId);
            }
        }
        public static List<Game> Parse()
        {
            List<string> input = File.ReadAllLines("InputDay2.txt").ToList();

            List<Game> gameList = new();

            for (int i = 0; i < input.Count; i++)
            {
                int[] cubeHands = { 0, 0, 0 }; // Initializing the array
                string currentGame = input[i];

                int GameID = Convert.ToInt32(currentGame.Split(':')[0].Split(' ')[1]);

                string[] hands = currentGame.Split(':')[1]
                                            .Split(';')
                                            .ToArray();

                foreach (var item in hands)
                {
                    gameList.Add(item.GetIndividualHands(GameID));
                }
            }
            return gameList;
        }
        public static Game GetIndividualHands(this string input, int gameId)
        {
            string[] colorRaw = input.Split(',')
                                     .Select(str => str.Substring(1))
                                     .ToArray();

            int[] RedGreenBlue = { 0, 0, 0 };

            string[,] colors = new string[3, 3];

            for (int i = 0; i < colorRaw.Length; i++)
            {
                colors[i,1] = colorRaw[i].Split(' ')[1];

                colors[i,0] = colorRaw[i].Split(' ')[0];
            }
            for (int i = 0; i < colorRaw.Length; i++)
            {
                switch (colors[i, 1])
                {
                    case "red":
                        RedGreenBlue[0] = Convert.ToInt32(colors[i, 0]);
                        break;
                    case "green":
                        RedGreenBlue[1] = Convert.ToInt32(colors[i, 0]);
                        break;
                    case "blue":
                        RedGreenBlue[2] = Convert.ToInt32(colors[i, 0]);
                        break;
                }
            }
            
            return new Game(gameId, RedGreenBlue[0], RedGreenBlue[1], RedGreenBlue[2]);
        }
        
    }
    class Game
    {
        public int gameId;
        public int numberOfReds;
        public int numberOfGreens;
        public int numberOfBlues;

        public Game(int gameId,int reds,int greens,int blues)
        {
            this.gameId = gameId;
            numberOfReds = reds;
            numberOfGreens = greens;
            numberOfBlues = blues;
        }
        /// <summary>
        /// Returns false if one of the cubes go over the limit, otherwise true.
        /// </summary>
        /// <returns></returns>
        public bool DetermineIfTheGameIsPossible() => (numberOfReds <= 12 && numberOfGreens <= 13 && numberOfBlues <= 14);
    }
}
