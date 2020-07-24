using CharacterClasses;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OneRing_EncountersUI
{
    class ProgramUI
    {
        private readonly Culture_Repository _charRepo = new Culture_Repository();
        public void Run()
        {
            SeedWeaponSets();
            SeedBackgrounds();
            SeedCultures();
            RunMenu();
        }

        public void RunMenu()
        {
            Console.Clear();
            Console.WriteLine("What would you like to do?\n" +
                "1. Create a character\n" +
                "2. Show created characters\n");

            string ans = Console.ReadLine();

            switch (ans)
            {
                case "1":
                    // Create A Character
                    Console.Clear();
                    CreateCharacter();

                    Character newCharacter = new Character();
                    break;
                case "2":
                    // Display Created Characters
                    break;
                default:
                    Console.WriteLine("Please choose an appropriate option.");
                    break;
            }
        }

        private void CreateCharacter()
        {
            Console.Clear();
            Character newCharacter = new Character();

            bool createChar = true;
            while (createChar)
            {
                Console.WriteLine("Please select a culture to view their stats:\n");
                ListCultures();
                Console.WriteLine("7. Exit to previous menu");

                //Capture selection
                List<Culture> cultures = _charRepo.GetCultures();
                string ansCulture = Console.ReadLine();
                switch (ansCulture)
                {
                    //View culture options
                    case "1":
                        Console.Clear();
                        DisplayCulture(cultures[0]);
                        break;
                    case "2":
                        Console.Clear();
                        DisplayCulture(cultures[1]);
                        break;
                    case "3":
                        Console.Clear();
                        DisplayCulture(cultures[2]);
                        break;
                    case "4":
                        Console.Clear();
                        DisplayCulture(cultures[3]);
                        break;
                    case "5":
                        Console.Clear();
                        DisplayCulture(cultures[4]);
                        break;
                    case "6":
                        Console.Clear();
                        DisplayCulture(cultures[5]);
                        break;
                    case "7":
                        Console.WriteLine("Press any key to go back to previous menu...");
                        createChar = false;
                        break;
                    default:
                        break;
                        // Choose character's culture
                        // Choose culture weapon skillset
                        // View background details
                        // Choose culture background
                        // Choose background attributes, favored skill, and two distinctive features
                        //Assign everything
                }
            }
        }

        private void ListCultures()
        {
            List<Culture> cultures = _charRepo.GetCultures();
            int index = 1;
            foreach (Culture culture in cultures)
            {
                Console.WriteLine($"{index}. {culture.Name}");
                index++;
            }
        }

        private void DisplayCulture(Culture culture)
        {
            Console.Clear();

            Character newCharacter = new Character();
            CultureWeaponSet rawWepSet = _charRepo.GetWeaponSetByName(culture);

            string wepSetOne = CultureWeaponSetLister(rawWepSet.WeaponSetOne);
            string wepSetTwo = CultureWeaponSetLister(rawWepSet.WeaponSetTwo);
            string name = culture.Name.Remove(2).ToLower();
            Console.WriteLine($"{culture.Name} selected.Please review the stats for the {culture.Name}:\n" +
                                   "\n" +
                                   "Common Skills:" +
                                       "--------------------------------------------\n" +
                                       $"|Awe           { culture.AweCommonSkill}   |Inspire         {culture.InspireCommonSkill}   |Persuade     {culture.PersuadeCommonSkill}  |\n" +
                                       $"|Athletics     { culture.AthleticsCommonSkill}   |Travel          {culture.TravelCommonSkill}   |Stealth         |\n" +
                                       $"|Awareness     { culture.AwarenessCommonSkill}   |Insight         {culture.InsightCommonSkill}   |Search       {culture.SearchCommonSkill}  |\n" +
                                       $"|Explore       { culture.ExploreCommonSkill }   |Healing             |Hunting         |\n" +
                                       $"|Song          { culture.SongCommonSkill }   |Courtesy        {culture.CourtesyCommonSkill}   |Riddle          |\n" +
                                       $"|Craft         { culture.CraftCommonSkill }   |Battle          {culture.BattleCommonSkill}   |Lore         {culture.LoreCommonSkill}  |\n" +
                                       "----------------------------------------------------------\n" +
                                       $">Standard of Living: {culture.LivingStandard}\n" +
                                       $"\n>Cultural Blessing: {culture.CulturalBlessing}\n" +
                                       "\n>Weapon Skill options:\n" +
                                       $"1) {wepSetOne}\n" +
                                       $"2) {wepSetTwo}\n" +
                                       "\n" +
                                       "Please select an option:\n" +
                                       "1. View Backgrounds\n" +
                                       $"2. Select the {culture.Name} culture for your character\n" +
                                       "3. Back to Culture menu\n");
            string ansCult = Console.ReadLine();
            switch (ansCult)
            {
                case "1":
                    Console.Clear();
                    DisplayBackgrounds(name);
                    Console.ReadLine();
                    break;
                case "2":
                    newCharacter.LivingStandard = culture.LivingStandard;
                    newCharacter.CulturalBlessing = culture.CulturalBlessing;
                    newCharacter.AweCommonSkill = culture.AweCommonSkill;
                    newCharacter.AthleticsCommonSkill = culture.AthleticsCommonSkill;
                    newCharacter.AwarenessCommonSkill = culture.AwarenessCommonSkill;
                    newCharacter.ExploreCommonSkill = culture.ExploreCommonSkill;
                    newCharacter.SongCommonSkill = culture.SongCommonSkill;
                    newCharacter.CraftCommonSkill = culture.CraftCommonSkill;
                    newCharacter.InspireCommonSkill = culture.InspireCommonSkill;
                    newCharacter.TravelCommonSkill = culture.TravelCommonSkill;
                    newCharacter.InsightCommonSkill = culture.InsightCommonSkill;
                    newCharacter.HealingCommonSkill = culture.HealingCommonSkill;
                    newCharacter.CourtesyCommonSkill = culture.CourtesyCommonSkill;
                    newCharacter.BattleCommonSkill = culture.BattleCommonSkill;
                    newCharacter.PersuadeCommonSkill = culture.PersuadeCommonSkill;
                    newCharacter.StealthCommonSkill = culture.StealthCommonSkill;
                    newCharacter.SearchCommonSkill = culture.SearchCommonSkill;
                    newCharacter.HuntingCommonSkill = culture.HuntingCommonSkill;
                    newCharacter.RiddleCommonSkill = culture.LoreCommonSkill;
                    newCharacter.DistinctiveFeatures = culture.DistinctiveFeatures;

                    Console.Clear();
                    Console.WriteLine("Which background would you like to select?");

                    //count the number of backgrounds in the list
                    int bgCount = _charRepo.GetBackground().Count();

                    //capture user input and change to integer
                    ListBackgrounds(name);
                    string ansBackground = Console.ReadLine();
                    int ansBg = int.Parse(ansBackground);

                    //while the user input is less than or equal to the amount of backgrounds,
                    if (ansBg <= bgCount)
                    {
                        //retrieve an index, and query the user to know:
                            //which two traits they would like and...
                            //which weapon set they would like

                            //assign wepSetOne or wepSetTwo to the newCharacter
                            //assign background.favoredSkill to the newCharacter
                    }
                    // Instead of a swtich statement, just capture this as the index to select the index of the background



                    break;
                case "back":
                    break;
            }
        }

        // Weapon Set methods:
        private string CultureWeaponSetLister(Dictionary<string, int> wepSet)
        {
            List<string> weapon = new List<string>();
            foreach (KeyValuePair<string, int> weaponAndValue in wepSet)
            {
                weapon.Add(weaponAndValue.ToString());
            }
            return string.Join(", ", weapon);
        }

        // Backgrounds
        private void DisplayBackgrounds(string name)
        {
            List<Background> backgrounds = _charRepo.GetBackgroundsByName(name);
            int index = 1;
            foreach (Background background in backgrounds)
            {
                string df = _charRepo.StringList(background.DistinctiveFeatures);
                Console.WriteLine("---------------------------------------\n" +
                    $"{index}. {background.Tiitle}\n" +
                    $" - Basic Attributes: Body: {background.BasicBody}, Heart: {background.BasicHeart}, Wits: {background.BasicWits}\n" +
                    $" - Favored Skill: {background.FavoredSkill}\n" +
                    $" - Distinctive Features (Choose Two): {df}");
                index++;
            }
            Console.WriteLine("Press any key to return to Culture...");
            Console.ReadKey();
        }

        private void ListBackgrounds(string name)
        {
            //Create new list
            List<Background> backgrounds = _charRepo.GetBackgroundsByName(name);
            int index = 1;
            foreach(Background background in backgrounds)
            {
                Console.WriteLine($"{index}. {background.Tiitle}");
            }
            //GetBackgroundsByName(); and foreach background, just print out
            //index number
            //background name
        }

        // Seed Weapon Sets:
        private void SeedWeaponSets()
        {
            CultureWeaponSet barding = new CultureWeaponSet()
            {
                Name = "Barding",
                WeaponSetOne = new Dictionary<string, int>()
                {
                    { "(Swords)", 2 },
                    { "Spear", 1 },
                    { "Dagger", 1 }
                },
                WeaponSetTwo = new Dictionary<string, int>()
                {
                    { "Great Bow", 2 },
                    { "Spear", 1 },
                    { "Dagger", 1 }
                }
            };
            _charRepo.CreateWeaponSet(barding);

            CultureWeaponSet dwarf = new CultureWeaponSet()
            {
                Name = "Dwarf",
                WeaponSetOne = new Dictionary<string, int>()
                {
                    { "(Axes)", 2 },
                    { "Short Sword", 1 },
                    { "Dagger", 1 }
                },
                WeaponSetTwo = new Dictionary<string, int>()
                {
                    { "Mattock", 2 },
                    { "Short Sword", 1 },
                    { "Dagger", 1 }
                }
            };
            _charRepo.CreateWeaponSet(dwarf);
        }

        // Seed Backgrounds:
        private void SeedBackgrounds()
        {
            Background bardOne = new Background()
            {
                Culture = "Barding",
                Tiitle = "By Hammer and Anvil",
                BasicBody = 5,
                BasicHeart = 7,
                BasicWits = 2,
                FavoredSkill = "Craft",
                DistinctiveFeatures = new List<string>()
                {
                    "Adventerous",
                    "Cautious",
                    "Determined",
                    "Generous",
                    "Hardy",
                    "Merciful",
                    "Proud",
                    "Stern"
                }
            };
            _charRepo.CreateBackground(bardOne);

            Background bardTwo = new Background()
            {
                Culture = "Barding",
                Tiitle = "Wordweaver",
                BasicBody = 4,
                BasicHeart = 6,
                BasicWits = 4,
                FavoredSkill = "Riddle",
                DistinctiveFeatures = new List<string>()
                {
                    "Adventerous",
                    "Clever",
                    "Eager",
                    "Fair-Spoken",
                    "Lordly",
                    "Reckless",
                    "Tall",
                    "Trusty"
                }
            };
            _charRepo.CreateBackground(bardTwo);

            Background bardThree = new Background()
            {
                Culture = "Barding",
                Tiitle = "Gifted Senses",
                BasicBody = 6,
                BasicHeart = 6,
                BasicWits = 2,
                FavoredSkill = "Search",
                DistinctiveFeatures = new List<string>()
                {
                    "Adventerous",
                    "Cautious",
                    "Cunning",
                    "Fair-Spoken",
                    "Patient",
                    "Steadfast",
                    "True-Hearted",
                    "Wary"
                }
            };
            _charRepo.CreateBackground(bardThree);

            Background dwarfOne = new Background()
            {
                Culture = "Dwarf",
                Tiitle = "A Life of Toil",
                BasicBody = 6,
                BasicHeart = 2,
                BasicWits = 6,
                FavoredSkill = "Explore",
                DistinctiveFeatures = new List<string>()
                {
                    "Energetic",
                    "Fierce",
                    "Hardened",
                    "Proud",
                    "Stern",
                    "Vengeful",
                    "Wary",
                    "Wilful"
                }
            };
            _charRepo.CreateBackground(dwarfOne);

        }

        // Seed Cultures
        private void SeedCultures()
        {
            Culture barding = new Culture()
            {
                Name = "Barding",
                Description = "Barding Description",
                LivingStandard = "Prosperous",
                UnusualCalling = "None",
                CulturalBlessing = "Stout-Hearted - When making a test using Valour, Barding characters can roll the Feat die twice, and keep the best result",
                AweCommonSkill = 1,
                AthleticsCommonSkill = 0,
                AwarenessCommonSkill = 0,
                ExploreCommonSkill = 2,
                SongCommonSkill = 1,
                CraftCommonSkill = 1,
                InspireCommonSkill = 2,
                TravelCommonSkill = 2,
                InsightCommonSkill = 2,
                HealingCommonSkill = 0,
                CourtesyCommonSkill = 2,
                BattleCommonSkill = 2,
                PersuadeCommonSkill = 3,
                StealthCommonSkill = 0,
                SearchCommonSkill = 1,
                HuntingCommonSkill = 0,
                RiddleCommonSkill = 0,
                LoreCommonSkill = 1,



            };
            _charRepo.CreateCulture(barding);

            Culture dwarfLonelyMountain = new Culture()
            {
                Name = "Dwarf of the Lonely Mountain",
                Description = "Dwarf Description",
                LivingStandard = "Rich",
                UnusualCalling = "Warden",
                CulturalBlessing = "Redoubtable - Dwarf characters calculate their starting Fatigue threshold by adding up the Encumbrance ratings of all the items they are carrying, and then subtracting their favored Heart score from the total.",
                AweCommonSkill = 0,
                AthleticsCommonSkill = 0,
                AwarenessCommonSkill = 0,
                ExploreCommonSkill = 2,
                SongCommonSkill = 1,
                CraftCommonSkill = 3,
                InspireCommonSkill = 2,
                TravelCommonSkill = 3,
                InsightCommonSkill = 0,
                HealingCommonSkill = 0,
                CourtesyCommonSkill = 0,
                BattleCommonSkill = 1,
                PersuadeCommonSkill = 0,
                StealthCommonSkill = 0,
                SearchCommonSkill = 3,
                HuntingCommonSkill = 0,
                RiddleCommonSkill = 2,
                LoreCommonSkill = 1,
            };
            _charRepo.CreateCulture(dwarfLonelyMountain);
        }


    }
}
