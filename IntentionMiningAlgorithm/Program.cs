using IntentionMiningAlgorithm.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using MarkovSharp.TokenisationStrategies;

namespace IntentionMiningAlgorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IntentionMining intentionMiningAlgorithm = new IntentionMining();
            Console.WriteLine("Hello World!");
            intentionMiningAlgorithm.IntentionMiningDataLoad();
            intentionMiningAlgorithm.StrategiesLogGeneration();
            //intentionMiningAlgorithm.IntentionMiningSectionsDiscovery();
            //List<List<string>> activityGroups = new List<List<string>>
            //{
            //    new List<string> { "go_wardrobe", "get_clothes", "change_clothes" },
            //    new List<string> { "go_kitchen", "prepare_food", "eat_food" },
            //    new List<string> { "go_gym", "workout", "shower" }
            //    // Add more activity groups here
            //};

            //var markov = new StringMarkov();

            //foreach (var group in activityGroups)
            //{
            //    markov.Learn(group);
            //}

            //for (int i = 0; i < activityGroups.Count; i++)
            //{
            //    List<string> generatedName = markov.Walk().ToList();
            //    string shortName = string.Join("_", generatedName);
            //    Console.WriteLine($"Activity Group: {string.Join(", ", activityGroups[i])}");
            //    Console.WriteLine($"Generated Name: {shortName}");
            //    Console.WriteLine();
            //}
        }
    }
}
