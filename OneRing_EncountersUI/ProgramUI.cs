using CharacterClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
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
                    {
                        // Create A Character
                        CreateCharacter();
                        break;
                    }
                case "2":
                    {
                        // Display Created Characters
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Please choose an appropriate option.");
                        break;
                    }
            }
        }

        // Build the Character
        private void CreateCharacter()
        {
            Console.Clear();
            bool createChar = true;
            while (createChar)
            {
                var newCharacter = new Character();
                var newCulture = new Culture();

                //CultureMenu builds the new culture and spits out a culture ready for value assignment
                newCulture = CultureMenu(newCulture);
                newCharacter.Culture = newCulture;
                Console.WriteLine(newCulture.CultureName); //can get rid of this.
                Console.WriteLine(newCharacter.Culture.CultureName);
                Console.ReadLine();

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

                //Final: Add newCharacter to list of characters.

            }
        }

        //Build the Culture for the Character
        private Culture CultureMenu(Culture newCulture)
        {
            bool cultDetailMenu = true;
            while (cultDetailMenu)
            {
                Console.Clear();
                Console.WriteLine("Would you like to view the details of each culture first [y/n]?");
                string detailAns = Console.ReadLine().ToLower();

                switch (detailAns)
                {
                    case "y":
                        {
                            ViewDetailMenu();
                            break;
                        }
                    case "n":
                        {
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Please enter an appropriate value");
                            break;
                        }
                }
                //list all cultures

                var culters = _charRepo.GetCultures().ToArray();

                //Query for index culture.atindex(num);
                Console.Clear();
                Console.WriteLine("Please enter the number of the culture you would like to select:");
                int cultIndex = 1;
                foreach (Culture culture in culters)
                {
                    Console.WriteLine($"{cultIndex}. {culture.CultureName}");
                    cultIndex++;
                }
                int selectedCulture = int.Parse(Console.ReadLine());
                selectedCulture = selectedCulture - 1;
                newCulture.AthleticsCommonSkill = culters[selectedCulture].AthleticsCommonSkill;
                newCulture.AwarenessCommonSkill = culters[selectedCulture].AwarenessCommonSkill;
                newCulture.AweCommonSkill = culters[selectedCulture].AweCommonSkill;
                newCulture.BattleCommonSkill = culters[selectedCulture].BattleCommonSkill;
                newCulture.CourtesyCommonSkill = culters[selectedCulture].CourtesyCommonSkill;
                newCulture.CraftCommonSkill = culters[selectedCulture].CraftCommonSkill;
                newCulture.CulturalBlessing = culters[selectedCulture].CulturalBlessing;
                newCulture.CultureName = culters[selectedCulture].CultureName;
                newCulture.ExploreCommonSkill = culters[selectedCulture].ExploreCommonSkill;
                newCulture.HealingCommonSkill = culters[selectedCulture].HealingCommonSkill;
                newCulture.HuntingCommonSkill = culters[selectedCulture].HuntingCommonSkill;
                newCulture.InsightCommonSkill = culters[selectedCulture].InsightCommonSkill;
                newCulture.InspireCommonSkill = culters[selectedCulture].InspireCommonSkill;
                newCulture.LivingStandard = culters[selectedCulture].LivingStandard;
                newCulture.LoreCommonSkill = culters[selectedCulture].LoreCommonSkill;
                newCulture.PersuadeCommonSkill = culters[selectedCulture].PersuadeCommonSkill;
                newCulture.RiddleCommonSkill = culters[selectedCulture].RiddleCommonSkill;
                newCulture.SearchCommonSkill = culters[selectedCulture].SearchCommonSkill;
                newCulture.SongCommonSkill = culters[selectedCulture].SongCommonSkill;
                newCulture.StealthCommonSkill = culters[selectedCulture].StealthCommonSkill;
                newCulture.TravelCommonSkill = culters[selectedCulture].TravelCommonSkill;

                Console.WriteLine(newCulture.LivingStandard);
                Console.ReadLine();
            }
            return newCulture;

            Console.Clear();
            CultureMenu();
            var cultureList = _charRepo.GetCultures();
            int index = 1;
            Console.WriteLine("Please enter a number to select a culture or option:");
            Seperator();
            foreach (Culture culture in cultureList)
            {
                Console.WriteLine($"{index}. {culture.CultureName}");
                index++;
            }
            Seperator();
            int final = index++;
            Console.WriteLine($"{final}. View each culture's details");

            string ansCultString = Console.ReadLine();
            int ansCult = Int32.Parse(ansCultString);
            ansCult--;
            if (ansCult >= cultureList.Count)
            {
                bool cultDetailsMenu = true;
                while (cultDetailsMenu)
                {
                    Console.Clear();
                    var List = _charRepo.GetCultures();
                    int ind = 1;
                    Console.WriteLine("Please enter a number to select a culture or option:");
                    Seperator();
                    foreach (Culture culture in cultureList)
                    {
                        Console.WriteLine($"{index}. {culture.CultureName}");
                        index++;
                    }
                    //DisplayCulture

                    //switch case to turn cultDetailsMenu to false
                }
            }
            else if (ansCult > cultureList.Count)
            {
                // Create new culture and assign values to it based on the index number
                Culture tempCulture = cultureList.ElementAt(ansCult);
                newCulture.CultureName = tempCulture.CultureName;
                newCulture.LivingStandard = tempCulture.LivingStandard;
                newCulture.CulturalBlessing = tempCulture.CulturalBlessing;

                newCulture.AweCommonSkill = tempCulture.AweCommonSkill;
                newCulture.AthleticsCommonSkill = tempCulture.AthleticsCommonSkill;
                newCulture.AwarenessCommonSkill = tempCulture.AwarenessCommonSkill;
                newCulture.ExploreCommonSkill = tempCulture.ExploreCommonSkill;
                newCulture.SongCommonSkill = tempCulture.SongCommonSkill;
                newCulture.CraftCommonSkill = tempCulture.CraftCommonSkill;
                newCulture.InsightCommonSkill = tempCulture.InsightCommonSkill;
                newCulture.TravelCommonSkill = tempCulture.TravelCommonSkill;
                newCulture.HealingCommonSkill = tempCulture.HealingCommonSkill;
                newCulture.CourtesyCommonSkill = tempCulture.BattleCommonSkill;
                newCulture.BattleCommonSkill = tempCulture.BattleCommonSkill;
                newCulture.PersuadeCommonSkill = tempCulture.PersuadeCommonSkill;
                newCulture.SearchCommonSkill = tempCulture.SearchCommonSkill;
                newCulture.RiddleCommonSkill = tempCulture.RiddleCommonSkill;
                newCulture.LoreCommonSkill = tempCulture.LoreCommonSkill;
            }
            else
            {
                Console.WriteLine("Please choose an appropriate option");
            }

            //Configure culture
            //Choose culture
            //Configure weapon skills
            //ConfigureWeaponSkills();
            //Configure specialties
            //ConfigureSpecialties();
            //Configure background
            //ConfigureBackground();
            //Build the Culture


            //Configure calling
            //Favor two skills
            //Add an additional Trait
            //Configure Shadow Weakness

            return newCulture;
        }

        private void ViewDetailMenu()
        {
            bool detailView = true;
            while (detailView)
            {
                Console.Clear();
                //list Cultures
                //list details of selected culture
                var culters = _charRepo.GetCultures().ToArray();

                //Query for index culture.atindex(num);
                Console.WriteLine("Please enter the number of the culture you would like to view:");
                int cultIndex = 1;
                foreach (Culture culture in culters)
                {
                    Console.WriteLine($"{cultIndex}. {culture.CultureName}");
                    cultIndex++;
                }

                int ans = int.Parse(Console.ReadLine());
                ans = ans - 1;
                var selectedCulture = culters[ans];

                //send culture to displayculture();

                DisplayCultureDetails(selectedCulture);
                Console.Clear();
                Console.WriteLine("Would you like to view the details of another culture [y/n]?");
                string anss = Console.ReadLine().ToLower();

                switch (anss)
                {
                    case "y":
                        {
                            break;
                        }
                    case "n":
                        {
                            detailView = false;
                            break;
                        }
                }
            }
        }

        private int CultureMenu()
        {
            Console.Clear();
            Console.WriteLine($"Enter a number to choose a culture for your character:\n");
            int number;
            //Get the cultures and store them in a list
            var cultureList = _charRepo.GetCultures();
            int index = 0;
            //iterate over the list
            foreach (Culture culture in cultureList)
            {
                Console.WriteLine($"{index}. {culture.CultureName}");
                index++;
            }
            int final = cultureList.Count() + 1;
            Console.WriteLine($"\n{final}. View culture details");
            int cultAns = int.Parse(Console.ReadLine());

            if (cultAns < final)
            {
                return cultAns;
            }
            else if (cultAns == final)
            {
                return cultAns;
            }
            else
            {
                return cultAns;
            }

        }

        private List<string> ListCultureNames()
        {
            //Get list of cultures
            List<Culture> cultures = _charRepo.GetCultures();
            //Create a string list of the culture names
            List<string> cultureNames = new List<string>();
            //For each name of a culture in the cultures listed,
            foreach (Culture culture in cultures)
            {
                //Add the string name to the string list "cultureNames"
                cultureNames.Add(culture.CultureName);
            }
            //Spit it out.
            return cultureNames;
        }

        private void ListCultures(List<string> cultureList)
        {
            //Start indexer at 1
            int index = 1;
            //For each culture name in the culturelist,
            foreach (string cult in cultureList)
            {
                //Write the index as well as the name of the culture
                Console.WriteLine($"{index}. {cult}");
                //Add 1 to the index
                index++;
            }
        }

        private void DisplayCultureDetails(Culture culture)
        {
            Console.Clear();
            CultureWeaponSet rawWepSet = _charRepo.GetWeaponSetByName(culture);

            string wepSetOne = CultureWeaponSetLister(rawWepSet.WeaponSetOne);
            string wepSetTwo = CultureWeaponSetLister(rawWepSet.WeaponSetTwo);
            string name = culture.CultureName.Remove(2).ToLower();
            Console.WriteLine($"{culture.CultureName} selected.Please review the stats for the {culture.CultureName}:\n" +
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
            Console.WriteLine("Press any key to continue...");
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
            foreach (Background background in backgrounds)
            {
                //print out the index number and background title
                Console.WriteLine($"{index}. {background.Title}");
                //increment the index
                index++;
            }
        }

        private void Seperator()
        {
            Console.WriteLine("------------------------------");
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
                CultureName = "Barding",
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
                CultureName = "Dwarf of the Lonely Mountain",
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
