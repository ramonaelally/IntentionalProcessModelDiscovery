using CsvHelper;
using CsvHelper.Configuration;
using IntentionMiningAlgorithm.DataModel;
using System.Xml;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntentionMiningAlgorithm.Methods
{
    public class IntentionMining
    {
        public List<EventRecord> EventRecords { get; set; }

        public List<EventRecord> SensorRecords { get; set; }

        public List<ActivityType> ActivityTypes { get; set; }

        public List<IntentionType> IntentionTypes { get; set; }

        public List<StrategyType> StrategyTypes { get; set; }

        public List<Pattern> Patterns { get; set; }

        public List<PatternType> PatternTypes { get; set; }





        public void IntentionMiningDataLoad()
        {
            //using (var reader = new StreamReader(@"G:\Other computers\My Laptop\Intention Mining\Logs\BP-Meets-IoT2021\sim_21d1p\EventLog_1person-Coding.csv"))
            //using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            //{
            //    var records = csv.GetRecords<EventRecord>();
            //    this.EventRecords = records?.ToList();
            //}

            using (var reader = new StreamReader(@"G:\Other computers\My Laptop\Intention Mining\Logs\BP-Meets-IoT2021\sim_21d1p\EventLog_1person-Coding-Modified.csv"))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<EventRecord>();
                    this.EventRecords = records?.ToList();
                }
            }

            using (var reader = new StreamReader(@"G:\Other computers\My Laptop\Intention Mining\Logs\BP-Meets-IoT2021\sim_21d1p\StrategyNamesList-toBeUsed.csv"))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<PatternType>();
                    this.PatternTypes = records?.ToList();
                }

            }

            int counter = 0;
            this.Patterns = new List<Pattern>();
            foreach (var item in this.PatternTypes)
            {
                List<string> activitites = item.Pattern.Split(',').ToList();
                activitites.RemoveAll(x => x == String.Empty);
                this.Patterns.Add(new Pattern()
                {
                    PatternActivities = activitites,
                    PatternId = ++counter,
                    PatternName = String.Format(item.PatternTypeName).Trim(),
                });
            }

            //var config = new CsvConfiguration(CultureInfo.InvariantCulture) { HasHeaderRecord = false };
            //using (var reader = new StreamReader(@"G:\Other computers\My Laptop\Intention Mining\Logs\BP-Meets-IoT2021\sim_21d1p\PrefixSpan_filteredFrequentPatterns-toBeUsed.csv"))
            //{ //using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            //    //using (var csv = new CsvReader(reader, config))
            //    //{
            //    //    var records = csv.GetRecords<List<string>>();
            //    //    //this.EventRecords = records?.ToList();
            //    //}

            //    string line = string.Empty;
            //    int counter = 0;
            //    this.Patterns = new List<Pattern>();
            //    while ((line = reader.ReadLine()) != null)
            //    {
            //        List<string> activitites = line.Split(',').ToList();
            //        activitites.RemoveAll(x => x == String.Empty);
            //        this.Patterns.Add(new Pattern()
            //        {
            //            PatternActivities = activitites,
            //            PatternId = ++counter,
            //            PatternName = String.Format("Strategy{0}", counter),
            //        });

            //    }

            //}

            using (var reader = new StreamReader(@"G:\Other computers\My Laptop\Intention Mining\Logs\BP-Meets-IoT2021\sim_21d1p\Sensor_1person-Cleaned-Coding.csv"))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<EventRecord>();
                    this.SensorRecords = records?.ToList();
                }
            }

            //using (var reader = new StreamReader(@"C:\Users\Ramona\.Neo4jDesktop\relate-data\dbmss\dbms-ab3f02ba-f48b-4823-8724-cbdbf013aae6\import\activities.csv"))
            //using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            //{
            //    var records = csv.GetRecords<Activity>();
            //    this.Activities = records?.ToList();
            //}


            this.ActivityTypes = new List<ActivityType>()
            {
              new ActivityType(){ActivityTypeId=1, ActivityTypeName="go_wardrobe"},
              new ActivityType(){ActivityTypeId=2, ActivityTypeName="get_clothes"},
              new ActivityType(){ActivityTypeId=3, ActivityTypeName="change_clothes"},
              new ActivityType(){ActivityTypeId=4, ActivityTypeName="go_bathtub"},
              new ActivityType(){ActivityTypeId=5, ActivityTypeName="have_bath"},
              new ActivityType(){ActivityTypeId=6, ActivityTypeName="go_bathroom_sink"},
              new ActivityType(){ActivityTypeId=7, ActivityTypeName="brush_teeth"},
              new ActivityType(){ActivityTypeId=8, ActivityTypeName="go_bed"},
              new ActivityType(){ActivityTypeId=9, ActivityTypeName="sleep_in_bed"},
              new ActivityType(){ActivityTypeId=10, ActivityTypeName="go_kitchen_shelf"},
              new ActivityType(){ActivityTypeId=11, ActivityTypeName="get_glass"},
              new ActivityType(){ActivityTypeId=12, ActivityTypeName="go_kitchen_sink"},
              new ActivityType(){ActivityTypeId=13, ActivityTypeName="get_water"},
              new ActivityType(){ActivityTypeId=14, ActivityTypeName="drink_water"},
              new ActivityType(){ActivityTypeId=15, ActivityTypeName="go_computer"},
              new ActivityType(){ActivityTypeId=16, ActivityTypeName="clean"},
              new ActivityType(){ActivityTypeId=17, ActivityTypeName="go_book_shelf"},
              new ActivityType(){ActivityTypeId=18, ActivityTypeName="go_shoe_shelf"},
              new ActivityType(){ActivityTypeId=19, ActivityTypeName="dress_up_outdoor"},
              new ActivityType(){ActivityTypeId=20, ActivityTypeName="go_workplace"},
              new ActivityType(){ActivityTypeId=21, ActivityTypeName="work"},
              new ActivityType(){ActivityTypeId=22, ActivityTypeName="dress_down_outdoor"},
              new ActivityType(){ActivityTypeId=23, ActivityTypeName="finish_walk"},
              new ActivityType(){ActivityTypeId=24, ActivityTypeName="switch_computer_on"},
              new ActivityType(){ActivityTypeId=25, ActivityTypeName="go_computer_chair"},
              new ActivityType(){ActivityTypeId=26, ActivityTypeName="use_the_computer"},
              new ActivityType(){ActivityTypeId=27, ActivityTypeName="go_entrace"},
              new ActivityType(){ActivityTypeId=28, ActivityTypeName="interact_with_man"},
              new ActivityType(){ActivityTypeId=29, ActivityTypeName="wash_hands"},
              new ActivityType(){ActivityTypeId=30, ActivityTypeName="go_fridge"},
              new ActivityType(){ActivityTypeId=31, ActivityTypeName="get_food_from_fridge"},
              new ActivityType(){ActivityTypeId=32, ActivityTypeName="get_bread"},
              new ActivityType(){ActivityTypeId=33, ActivityTypeName="go_dining_table"},
              new ActivityType(){ActivityTypeId=34, ActivityTypeName="eat_cold_meal"},
              new ActivityType(){ActivityTypeId=35, ActivityTypeName="put_plate_to_sink"},
              new ActivityType(){ActivityTypeId=36, ActivityTypeName="go_wc"},
              new ActivityType(){ActivityTypeId=37, ActivityTypeName="wc_do"},
              new ActivityType(){ActivityTypeId=38, ActivityTypeName="wc_flush"},
              new ActivityType(){ActivityTypeId=39, ActivityTypeName="go_chair"},
              new ActivityType(){ActivityTypeId=40, ActivityTypeName="rest_in_chair"},
              new ActivityType(){ActivityTypeId=41, ActivityTypeName="go_windows"},
              new ActivityType(){ActivityTypeId=42, ActivityTypeName="raise_blinds"},
              new ActivityType(){ActivityTypeId=43, ActivityTypeName="open_windows"},
              new ActivityType(){ActivityTypeId=44, ActivityTypeName="go_exercise_place"},
              new ActivityType(){ActivityTypeId=45, ActivityTypeName="do_exercise"},
              new ActivityType(){ActivityTypeId=46, ActivityTypeName="close_windows"},
              new ActivityType(){ActivityTypeId=47, ActivityTypeName="lower_blinds"},
              new ActivityType(){ActivityTypeId=48, ActivityTypeName="go_outside"},
              new ActivityType(){ActivityTypeId=49, ActivityTypeName="walk_outside"},
              new ActivityType(){ActivityTypeId=50, ActivityTypeName="get_food"},
              new ActivityType(){ActivityTypeId=51, ActivityTypeName="pack_goods"},
              new ActivityType(){ActivityTypeId=52, ActivityTypeName="wash_dishes"},
              new ActivityType(){ActivityTypeId=53, ActivityTypeName="switch_computer_off"}
              };

            this.IntentionTypes = new List<IntentionType>()
            {
               new IntentionType(){IntentionTypeId =1 , IntentionTypeName = "AerateHome"},
               new IntentionType(){IntentionTypeId =2 , IntentionTypeName = "DoSport"},
               new IntentionType(){IntentionTypeId =3 , IntentionTypeName = "GetOut"},
               new IntentionType(){IntentionTypeId =4 , IntentionTypeName = "GetIn"},
               new IntentionType(){IntentionTypeId =5 , IntentionTypeName = "Hydrate"},
               new IntentionType(){IntentionTypeId =6 , IntentionTypeName = "Eat"},
               new IntentionType(){IntentionTypeId =7 , IntentionTypeName = "DoHousekeep"},
               new IntentionType(){IntentionTypeId =8 , IntentionTypeName = "Shop"},
               new IntentionType(){IntentionTypeId =9 , IntentionTypeName = "PerformBathroomRoutine"},
               new IntentionType(){IntentionTypeId =10 , IntentionTypeName = "Work"},
               new IntentionType(){IntentionTypeId =11 , IntentionTypeName = "Rest"},
              };


            this.StrategyTypes = new List<StrategyType>()
            {
               new StrategyType(){StrategyTypeId =1 , StrategyTypeName = "OpeningDoor" ,IntentionTypeId=3,
                              ActivityTypes =new List<ActivityType>(){ new ActivityType() { ActivityTypeId=3},
                                                                new ActivityType() { ActivityTypeId=28},
                                                                new ActivityType() { ActivityTypeId=19},
                                                                new ActivityType() { ActivityTypeId=22},
                                                                new ActivityType() { ActivityTypeId=27},
                                                                new ActivityType() { ActivityTypeId=18},
                                                                new ActivityType() { ActivityTypeId=1},
                                                                new ActivityType() { ActivityTypeId=2}} },
                 new StrategyType(){StrategyTypeId =2 , StrategyTypeName = "Exercising",IntentionTypeId=2,
                              ActivityTypes =new List<ActivityType>(){ new ActivityType() { ActivityTypeId=3},
                                                                new ActivityType() { ActivityTypeId=2},
                                                                new ActivityType() { ActivityTypeId=44},
                                                                new ActivityType() { ActivityTypeId=45},
                                                                 new ActivityType() { ActivityTypeId=1}} } ,
                 new StrategyType() { StrategyTypeId = 3, StrategyTypeName = "Walking", IntentionTypeId = 2 ,
                ActivityTypes = new List<ActivityType>() {             new ActivityType() { ActivityTypeId=3},
                                                                new ActivityType() { ActivityTypeId=2},
                                                                new ActivityType() { ActivityTypeId=49},
                                                                new ActivityType() { ActivityTypeId=23},
                                                                new ActivityType() { ActivityTypeId=19},
                                                                new ActivityType() { ActivityTypeId=22},
                                                                new ActivityType() { ActivityTypeId=27},
                                                                new ActivityType() { ActivityTypeId=18},
                                                                new ActivityType() { ActivityTypeId=1}} } ,
               new StrategyType() { StrategyTypeId = 4, StrategyTypeName = "OpeningDoor", IntentionTypeId = 4 ,
                ActivityTypes = new List<ActivityType>() {             new ActivityType() { ActivityTypeId=3},
                                                                new ActivityType() { ActivityTypeId=2},
                                                                new ActivityType() { ActivityTypeId=28},
                                                                new ActivityType() { ActivityTypeId=19},
                                                                new ActivityType() { ActivityTypeId=22},
                                                                new ActivityType() { ActivityTypeId=27},
                                                                new ActivityType() { ActivityTypeId=18},
                                                                 new ActivityType() { ActivityTypeId=1}} },
               new StrategyType() { StrategyTypeId = 5, StrategyTypeName = "AiringHome", IntentionTypeId = 1 ,
                ActivityTypes = new List<ActivityType>() {             new ActivityType() { ActivityTypeId=41},
                                                                new ActivityType() { ActivityTypeId=43},
                                                                new ActivityType() { ActivityTypeId=46},
                                                                new ActivityType() { ActivityTypeId=42},
                                                                new ActivityType() { ActivityTypeId=47}} },
               new StrategyType() { StrategyTypeId = 6, StrategyTypeName = "DrinkingWater", IntentionTypeId = 5 ,
                ActivityTypes = new List<ActivityType>() {             new ActivityType() { ActivityTypeId=10},
                                                                new ActivityType() { ActivityTypeId=12},
                                                                new ActivityType() { ActivityTypeId=13},
                                                                new ActivityType() { ActivityTypeId=14},
                                                                new ActivityType() { ActivityTypeId=11},
                                                                new ActivityType() { ActivityTypeId=35}}},
               new StrategyType() { StrategyTypeId = 7, StrategyTypeName = "ByCookedMeal", IntentionTypeId = 6 ,
                ActivityTypes = new List<ActivityType>() {             new ActivityType() { ActivityTypeName = "" }}},
               new StrategyType() { StrategyTypeId = 8, StrategyTypeName = "ByColdMeal", IntentionTypeId = 6 ,
                ActivityTypes = new List<ActivityType>() {             new ActivityType() { ActivityTypeId=34},
                                                                new ActivityType() { ActivityTypeId=32},
                                                                new ActivityType() { ActivityTypeId=30},
                                                                new ActivityType() { ActivityTypeId=31},
                                                                new ActivityType() { ActivityTypeId=33},
                                                                new ActivityType() { ActivityTypeId=10},
                                                                new ActivityType() { ActivityTypeId=35} } },
               new StrategyType() { StrategyTypeId = 9, StrategyTypeName = "Cleaning", IntentionTypeId = 7 ,
                ActivityTypes = new List<ActivityType>() { new ActivityType() { ActivityTypeId=16},
                                                                new ActivityType() { ActivityTypeId=15},
                                                                new ActivityType() { ActivityTypeId=17},
                                                                new ActivityType() { ActivityTypeId=1}
                                                               } },
               new StrategyType() { StrategyTypeId = 10, StrategyTypeName = "WashingDishes", IntentionTypeId = 7 ,
                ActivityTypes = new List<ActivityType>() { new ActivityType() { ActivityTypeId=52},
                                                                new ActivityType() { ActivityTypeId=12}
                                                                 } },
               new StrategyType() { StrategyTypeId = 11, StrategyTypeName = "Shopping", IntentionTypeId = 8 ,
                ActivityTypes = new List<ActivityType>() {             new ActivityType() { ActivityTypeId=3},
                                                                new ActivityType() { ActivityTypeId=2},
                                                                new ActivityType() { ActivityTypeId=48},
                                                                new ActivityType() { ActivityTypeId=18},
                                                                new ActivityType() { ActivityTypeId=50},
                                                                new ActivityType() { ActivityTypeId=51},
                                                                new ActivityType() { ActivityTypeId=19} ,
                                                                new ActivityType() { ActivityTypeId=22 },
                                                                 new ActivityType() { ActivityTypeId=1} } },
               new StrategyType() { StrategyTypeId = 12, StrategyTypeName = "TakingShower", IntentionTypeId = 9 ,
                ActivityTypes = new List<ActivityType>() {             new ActivityType() { ActivityTypeId=5},
                                                                new ActivityType() { ActivityTypeId=4}
                                                               } },
               new StrategyType() { StrategyTypeId = 13, StrategyTypeName = "WashingHands", IntentionTypeId = 9 ,
                ActivityTypes = new List<ActivityType>() {             new ActivityType() { ActivityTypeId=6},
                                                                new ActivityType() { ActivityTypeId=29}} },
               new StrategyType() { StrategyTypeId = 14, StrategyTypeName = "GoingToTheWC", IntentionTypeId = 9 ,
                ActivityTypes = new List<ActivityType>() {             new ActivityType() { ActivityTypeId=36},
                                                                new ActivityType() { ActivityTypeId=37},
                                                                new ActivityType() { ActivityTypeId=38}} },
                new StrategyType() { StrategyTypeId = 15, StrategyTypeName = "BrushingTeeth", IntentionTypeId = 9 ,
                ActivityTypes = new List<ActivityType>() {             new ActivityType() { ActivityTypeId=6},
                                                                new ActivityType() { ActivityTypeId=7}} },
               new StrategyType() { StrategyTypeId = 16, StrategyTypeName = "Sleeping", IntentionTypeId = 11 ,
                ActivityTypes = new List<ActivityType>() {             new ActivityType() { ActivityTypeId=3},
                                                                new ActivityType() { ActivityTypeId=2},
                                                                new ActivityType() { ActivityTypeId=8},
                                                                new ActivityType() { ActivityTypeId=9},
                                                                new ActivityType() { ActivityTypeId=1}} },
               new StrategyType() { StrategyTypeId = 17, StrategyTypeName = "Relaxing", IntentionTypeId = 11 ,
                ActivityTypes = new List<ActivityType>() {             new ActivityType() { ActivityTypeId=39},
                                                                new ActivityType() { ActivityTypeId=40 }
                                                             } },
               new StrategyType() { StrategyTypeId = 18, StrategyTypeName = "WorkingIndoor", IntentionTypeId = 10 ,
                ActivityTypes = new List<ActivityType>() {             new ActivityType() { ActivityTypeId=24},
                                                                new ActivityType() { ActivityTypeId=25},
                                                                new ActivityType() { ActivityTypeId=15},
                                                                new ActivityType() { ActivityTypeId=26},
                                                            } },
               new StrategyType() { StrategyTypeId = 19, StrategyTypeName = "WorkingOutdoor", IntentionTypeId = 10 ,
                   ActivityTypes = new List<ActivityType>() {          new ActivityType() { ActivityTypeId=3},
                                                                new ActivityType() { ActivityTypeId=2},
                                                                new ActivityType() { ActivityTypeId=20},
                                                                new ActivityType() { ActivityTypeId=21},
                                                                new ActivityType() { ActivityTypeId=18},
                                                                new ActivityType() { ActivityTypeId=19},
                                                                new ActivityType() { ActivityTypeId=1}} }


            };

        }

        public void StrategiesLogGeneration()
        {
            if (this.EventRecords != null)
            {
                List<StrategyGroup> strategyGroups = new List<StrategyGroup>();
                var currentStrategy = new List<Strategy>();
                var previousStrategy = new List<Strategy>();
                var currentActivity = new Activity();
                var previousActivity = new Activity();
                int strategyId = 1;
                int strategyGroupId = 1;
                int previousStrategyId = 0;
                int previousStrategyGroupId = 0;
                foreach (var record in this.EventRecords)
                {
                    //var currentActivityType = this.ActivityTypes.Find(x => x.ActivityTypeName == record.ActivityName);
                    //if (currentActivityType != null)
                    //{
                    var currentStrategies = this.Patterns.FindAll(x => x.PatternActivities.Exists(y => y.Trim() == record.ActivityName.Trim()));
                    if (previousStrategyGroupId != strategyGroupId)
                    {
                        previousStrategyGroupId = strategyGroupId;
                        previousStrategyId = strategyId;
                        var strategyGroup = new StrategyGroup()
                        {
                            StrategyGroupId = strategyGroupId,

                            StartDate = record.Timestamp,
                            EndDate = record.Timestamp,
                            Strategies = new List<Strategy>()
                        };

                        strategyGroups.Add(strategyGroup);
                        foreach (var item in currentStrategies)
                        {
                            if (!strategyGroup.Strategies.Exists(x => x.StrategyId == strategyId))
                            {

                                strategyGroup.Strategies.Add(new Strategy()
                                {
                                    StrategyId = strategyId++,
                                    StrategyName = item.PatternName,
                                    //StrategyTypeId = item.StrategyTypeId,
                                    ResourceId = record.ResourceId.Value,
                                    StartDate = record.Timestamp,
                                    EndDate = record.Timestamp,
                                    Activities = new List<Activity>() { new Activity() { ActivityId = record.EventId.Value, ActivityName = record.ActivityName, Timestamp = record.Timestamp } }
                                }
                                );
                            }
                        }

                    }
                    else
                    {
                        var currentStrategyGroup = strategyGroups.Find(x => x.StrategyGroupId == strategyGroupId);
                        if (currentStrategyGroup != null)
                        {
                            foreach (var strategyType in currentStrategies)
                            {
                                if (currentStrategyGroup.Strategies.Exists(x => x.StrategyName == strategyType.PatternName))
                                {
                                    var strategy = currentStrategyGroup.Strategies.Find(x => x.StrategyName == strategyType.PatternName);
                                    if (strategy != null)
                                    {
                                        //if (!strategy.Activities.Exists(x => x.ActivityName == record.ActivityName))
                                        {
                                            strategy.Activities.Add(new Activity() { ActivityId = record.EventId.Value, ActivityName = record.ActivityName, Timestamp = record.Timestamp });
                                        }
                                    }
                                }
                                else
                                {
                                    currentStrategyGroup.Strategies.Add(new Strategy()
                                    {
                                        StrategyId = strategyId,
                                        StrategyName = strategyType.PatternName,
                                        //StrategyTypeId = strategyType.StrategyTypeId,
                                        ResourceId = record.ResourceId.Value,
                                        StartDate = record.Timestamp,
                                        EndDate = record.Timestamp,
                                        Activities = new List<Activity>() { new Activity() { ActivityId = record.EventId.Value, ActivityName = record.ActivityName, Timestamp = record.Timestamp } }
                                    }
                              );

                                }
                            }
                            foreach (var strategyType in currentStrategies)
                            {
                                var item = currentStrategyGroup.Strategies.Find(x => x.StrategyName == strategyType.PatternName);
                                if (item != null)
                                {
                                    if (item.Activities.Count >= strategyType.PatternActivities.Count)
                                    {
                                        bool isStrategyComplete = true;
                                        foreach (var activity in item.Activities)
                                        {
                                            if (!strategyType.PatternActivities.Exists(x => x.Trim() == activity.ActivityName.Trim()))
                                            {
                                                isStrategyComplete = false;
                                            }
                                        }
                                        if (isStrategyComplete)
                                        {
                                            item.IsComplete = true;
                                            previousStrategyId = strategyId;
                                            previousStrategyGroupId = strategyGroupId;
                                            strategyGroupId++;
                                            strategyId++;
                                            break;
                                        }
                                    }
                                }
                            }
                        }

                    }
                }
                //}

                if (strategyGroups != null)
                {
                    List<Strategy> strategies = new List<Strategy>();
                    foreach (var strategyGroup in strategyGroups)
                    {
                        var completeStrategy = strategyGroup.Strategies.Find(x => x.IsComplete);
                        if (completeStrategy != null)
                        {
                            completeStrategy.Activities = completeStrategy.Activities.OrderBy(x => x.Timestamp).ToList();
                            completeStrategy.StartDate = completeStrategy.Activities.First().Timestamp;
                            completeStrategy.EndDate = completeStrategy.Activities.Last().Timestamp;
                            completeStrategy.Day = completeStrategy.StartDate.ToString("ddd-dd-MM-yyyy");
                            strategies.Add(completeStrategy);
                        }
                    }
                    using (var reader = new StreamWriter(@"G:\Other computers\My Laptop\Intention Mining\Logs\BP-Meets-IoT2021\sim_21d1p\StartegiesGeneratedLog-Coding"+ DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + ".csv"))
                    {
                        using (var csv = new CsvWriter(reader, CultureInfo.InvariantCulture))
                        {
                            csv.WriteRecords(strategies);
                        }
                    }
                }


            }
        }

        public void IntentionMiningSectionsDiscovery()
        {
            var path = @"C:\Users\Ramona\Desktop\StartegiesGeneratedLog-Coding-second.xml";
            XmlTextReader reader = new XmlTextReader(path);
            var strategies = new List<StrategyItem>();
            var strategyEdges = new List<StrategyEdge>();
            var startIndex = -1;
            var endIndex = -1;
            while (reader.Read())
            {
                XmlNodeType nodetype = reader.NodeType;
                switch (nodetype)
                {
                    case XmlNodeType.XmlDeclaration:
                        //DecCounter++;
                        break;
                    case XmlNodeType.ProcessingInstruction:
                        //PICounter++;
                        break;
                    case XmlNodeType.DocumentType:
                        //DocCounter++;
                        break;
                    case XmlNodeType.Comment:
                        //CommentCounter++;
                        break;
                    case XmlNodeType.Element:
                        // ElementCounter++;
                        if (reader.HasAttributes)
                        {
                            if (reader.Name == "Node")
                            {
                                var index = reader.GetAttribute("index");
                                var strategy = reader.GetAttribute("activity");

                                strategies.Add(new StrategyItem() { StrategyId = index, StrategyName = strategy });
                            }

                            if (reader.Name == "StartNode")
                            {
                                startIndex = Convert.ToInt32(reader.GetAttribute("index"));
                            }

                            if (reader.Name == "EndNode")
                            {
                                endIndex = Convert.ToInt32(reader.GetAttribute("index"));
                            }


                            if (reader.Name == "Edge")
                            {
                                var sourceIndex = reader.GetAttribute("sourceIndex");
                                var targetIndex = reader.GetAttribute("targetIndex");

                                strategyEdges.Add(new StrategyEdge() { SourceIndex = sourceIndex, TargetIndex = targetIndex });
                                //strategyEdges.Add(new StrategyEdge() { SourceIndex = targetIndex, TargetIndex = sourceIndex });
                            }

                        }// AttributeCounter += reader.AttributeCount;
                        break;
                    case XmlNodeType.Text:
                        // TextCounter++;
                        break;
                    case XmlNodeType.Whitespace:
                        // WhitespaceCounter++;
                        break;
                }
            }

            var sections = new List<Section>();
            foreach (var strategy in strategies)
            {
                sections.Add(new Section() { StrategyItem = strategy });
            }

            foreach (var edge in strategyEdges)
            {
                //var section = sections.Find(x => x.StrategyItem.StrategyId == edge.SourceIndex);
                var section = sections.Find(x => x.StrategyItem.StrategyId == edge.TargetIndex);
                if (section != null)
                {
                    if (!string.IsNullOrEmpty(section.IntentionSource))
                    {
                        if (edge.SourceIndex == startIndex.ToString())
                        {
                            sections.Add(new Section()
                            {
                                StrategyItem = section.StrategyItem,
                                IntentionSource = String.Format("Start"),
                                IntentionTarget = String.Format("Intention{0}", edge.TargetIndex)
                                //IntentionSource = String.Format("Intention{0}", edge.TargetIndex),
                                //IntentionTarget = String.Format("Intention{0}", edge.SourceIndex)
                            });
                        }
                        else
                        {
                            if (edge.TargetIndex == endIndex.ToString())
                            {
                                sections.Add(new Section()
                                {
                                    StrategyItem = section.StrategyItem,
                                    IntentionSource = String.Format("Intention{0}", edge.SourceIndex),
                                    IntentionTarget = String.Format("Complete")
                                    //IntentionSource = String.Format("Intention{0}", edge.TargetIndex),
                                    //IntentionTarget = String.Format("Intention{0}", edge.SourceIndex)
                                });
                            }
                            else
                            {
                                sections.Add(new Section()
                                {
                                    StrategyItem = section.StrategyItem,
                                    IntentionSource = String.Format("Intention{0}", edge.SourceIndex),
                                    IntentionTarget = String.Format("Intention{0}", edge.TargetIndex)
                                    //IntentionSource = String.Format("Intention{0}", edge.TargetIndex),
                                    //IntentionTarget = String.Format("Intention{0}", edge.SourceIndex)
                                });
                            }
                        }
                    }
                    else
                    {
                        if (edge.SourceIndex == startIndex.ToString())
                        {
                            section.IntentionSource = String.Format("Start");
                        }
                        else
                        {
                            section.IntentionSource = String.Format("Intention{0}", edge.SourceIndex);
                        }
                        if (edge.TargetIndex == endIndex.ToString())
                        {
                            section.IntentionTarget = String.Format("Complete");
                        }
                        else
                        {
                            section.IntentionTarget = String.Format("Intention{0}", edge.TargetIndex);
                        }
                        //section.IntentionSource = String.Format("Intention{0}", edge.TargetIndex);
                        //section.IntentionTarget = String.Format("Intention{0}", edge.SourceIndex);
                    }
                }
                else
                {
                    //End Node
                    sections.Add(new Section()
                    {
                        StrategyItem = new StrategyItem() { StrategyName = "CompleteStrategy", StrategyId = (strategies.Count + 1).ToString() },
                        IntentionSource = String.Format("Intention{0}", edge.SourceIndex),
                        IntentionTarget = String.Format("Complete")
                        //IntentionTarget = String.Format("Intention{0}", edge.TargetIndex)
                        //IntentionSource = String.Format("Intention{0}", edge.TargetIndex),
                        //IntentionTarget = String.Format("Intention{0}", edge.SourceIndex)
                    });
                }

            }

            sections = sections.OrderBy(x => x.IntentionTarget).ToList();
            foreach (var section in sections)
            {
                Console.WriteLine("<{0},{1},{2}>", section.IntentionSource, section.IntentionTarget, section.StrategyItem.StrategyName);
            }
            string filePath = @"G:\Other computers\My Laptop\Intention Mining\Logs\BP-Meets-IoT2021\sim_21d1p\map-sections" + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + ".csv";
            WriteToCsv(filePath, sections);
        }

        private static void WriteToCsv(string filePath, List<Section> sections)
        {
            // Combine the data into rows
            List<string> rows = new List<string>();

            foreach (var section in sections)
            {
                // Create a CSV-formatted row
                string row = $"{ section.IntentionSource},{section.IntentionTarget},{section.StrategyItem.StrategyName}";
                rows.Add(row);
            }
            // Write to CSV file using StreamWriter
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Write header if needed
                // writer.WriteLine("Column1,Column2,Column3");

                // Write data rows
                foreach (var row in rows)
                {
                    writer.WriteLine(row);
                }
            }
        }

        public void IntentionMiningModelDiscovery(
            List<Activity> activities = null,
            List<Intention> intentions = null,
            List<Sensor> sensors = null,
            List<Strategy> strategies = null)
        {
            if (this.EventRecords != null)
            {
                List<StrategyGroup> strategyGroups = new List<StrategyGroup>();
                var currentStrategy = new List<Strategy>();
                var previousStrategy = new List<Strategy>();
                var currentActivity = new Activity();
                var previousActivity = new Activity();
                int strategyId = 1;
                int strategyGroupId = 1;
                int previousStrategyId = 0;
                int previousStrategyGroupId = 0;
                foreach (var record in this.EventRecords)
                {
                    var currentActivityType = this.ActivityTypes.Find(x => x.ActivityTypeName.Trim() == record.ActivityName.Trim());
                    if (currentActivityType != null)
                    {
                        var currentStrategyTypes = this.StrategyTypes.FindAll(x => x.ActivityTypes.Exists(y => y.ActivityTypeId == currentActivityType.ActivityTypeId));
                        if (previousStrategyGroupId != strategyGroupId)
                        {
                            previousStrategyGroupId = strategyGroupId;
                            previousStrategyId = strategyId;
                            var strategyGroup = new StrategyGroup()
                            {
                                StrategyGroupId = strategyGroupId,

                                StartDate = record.Timestamp,
                                EndDate = record.Timestamp,
                                Strategies = new List<Strategy>()
                            };

                            strategyGroups.Add(strategyGroup);
                            foreach (var item in currentStrategyTypes)
                            {
                                if (!strategyGroup.Strategies.Exists(x => x.StrategyId == strategyId && x.StrategyTypeId == item.StrategyTypeId))
                                {

                                    strategyGroup.Strategies.Add(new Strategy()
                                    {
                                        StrategyId = strategyId,
                                        StrategyTypeId = item.StrategyTypeId,
                                        StartDate = record.Timestamp,
                                        EndDate = record.Timestamp,
                                        Activities = new List<Activity>() { new Activity() { ActivityId = record.EventId.Value, ActivityTypeId = currentActivityType.ActivityTypeId } }
                                    }
                                    );
                                }
                            }

                        }
                        else
                        {
                            var currentStrategyGroup = strategyGroups.Find(x => x.StrategyGroupId == strategyGroupId);
                            if (currentStrategyGroup != null)
                            {
                                foreach (var strategyType in currentStrategyTypes)
                                {
                                    if (currentStrategyGroup.Strategies.Exists(x => x.StrategyId == strategyId && x.StrategyTypeId == strategyType.StrategyTypeId))
                                    {
                                        var strategy = currentStrategyGroup.Strategies.Find(x => x.StrategyId == strategyId && x.StrategyTypeId == strategyType.StrategyTypeId);
                                        if (strategy != null)
                                        {
                                            if (!strategy.Activities.Exists(x => x.ActivityTypeId == currentActivityType.ActivityTypeId))
                                            {
                                                strategy.Activities.Add(new Activity() { ActivityId = record.EventId.Value, ActivityTypeId = currentActivityType.ActivityTypeId });
                                            }
                                        }
                                    }
                                    else
                                    {
                                        currentStrategyGroup.Strategies.Add(new Strategy()
                                        {
                                            StrategyId = strategyId,
                                            StrategyTypeId = strategyType.StrategyTypeId,
                                            StartDate = record.Timestamp,
                                            EndDate = record.Timestamp,
                                            Activities = new List<Activity>() { new Activity() { ActivityId = record.EventId.Value, ActivityTypeId = currentActivityType.ActivityTypeId } }
                                        }
                                  );

                                    }
                                }
                                foreach (var strategyType in currentStrategyTypes)
                                {
                                    var item = currentStrategyGroup.Strategies.Find(x => x.StrategyTypeId == strategyType.StrategyTypeId);
                                    if (item.Activities.Count >= strategyType.ActivityTypes.Count)
                                    {
                                        bool isStrategyComplete = true;
                                        foreach (var activity in item.Activities)
                                        {
                                            if (!strategyType.ActivityTypes.Exists(x => x.ActivityTypeId == activity.ActivityTypeId))
                                            {
                                                isStrategyComplete = false;
                                            }
                                        }
                                        if (isStrategyComplete)
                                        {
                                            previousStrategyId = strategyId;
                                            previousStrategyGroupId = strategyGroupId;
                                            strategyGroupId++;
                                            strategyId++;
                                            break;
                                        }
                                    }
                                }
                            }

                        }
                    }
                }
            }
        }

    }
}
