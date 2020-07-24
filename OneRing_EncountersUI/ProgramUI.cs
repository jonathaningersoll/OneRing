using CharacterClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
                    CreateCharacter();
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
                BuildCulture();
                //Configure culture
                    //Choose culture
                    //Configure weapon skills
                    //Configure specialties
                    //Configure background
                    //Build the Culture

                //Configure calling
                    //Favor two skills
                    //Add an additional Trait
                    //Configure Shadow Weakness

                //Configure Favored Attributes
                    //Add 3 points to an Attribute
                    //Add 2 points to an Attribute
                    //Add 2 point to an Attribute

                //Raise skill levels (Common and Weapon skills)

                //Calculate Endurance and Hope (from Culture) (culture.Endurance + character.Heart)
                
                //Calculate Starting Gear
                    //Add weapon
                    //Add armor
                    //Add shield
                    //Damage rating = basic body
                    //Parry = basic wits

                //Configure Wisdom and Valor

                
            }
        }

        private void BuildCulture()
        {
            Culture newCulture = new Culture();

            //Choose culture:


            //View culture details
            Console.Clear();
            Console.WriteLine("Please select a culture to view their details:\n");
           
            //List cultures
            ListCultures();

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

                    break;
                case "8":
                    Console.WriteLine("Press any key to go back to previous menu...");
                    break;
                default:
                    break;
            }
            //while loop?
            //Select culture to use
            //or go back to list of cultures
            //If culture selected, assign values to newCulture

            //Configure weapon skills
            SelectWeaponSet();
            //Configure specialties
            //SelectSpecialties();
            //Configure background
            //SelectBackground();
            //Build the Culture
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
                                       $"\n" +
                                       $">Backgrounds:\n");
            DisplayBackgrounds(name);
            Console.WriteLine("\n");
            }

        // Weapon Set methods:
        private void SelectWeaponSet()
        {

        }
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
                    $"{index}. {background.Title}\n" +
                    $" - Basic Attributes: Body: {background.BasicBody}, Heart: {background.BasicHeart}, Wits: {background.BasicWits}\n" +
                    $" - Favored Skill: {background.FavoredSkill}\n" +
                    $" - Distinctive Features (Choose Two): {df}");
                index++;
            }
            Console.WriteLine("Press any key to return to previous menu...");
            Console.ReadKey();
        }

        //List current culture's backgrounds
        private void ListBackgrounds(string name)
        {
            //Create new list of current culture's backgrounds
            List<Background> backgrounds = _charRepo.GetBackgroundsByName(name);
            //Begin index
            int index = 1;
            //Begin iterating over list of current culture's backgrounds
            foreach(Background background in backgrounds)
            {
                //print out the index number and background title
                Console.WriteLine($"{index}. {background.Title}");
                //increment the index
                index++;
            }
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
                Title = "By Hammer and Anvil",
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
                Title = "Wordweaver",
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
                Title = "Gifted Senses",
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
                Title = "A Life of Toil",
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
