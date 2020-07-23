using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterClasses
{
    public class Characteristics
    {
        public string LivingStandard { get; set; }
        public string UnusualCalling { get; set; }
        public string CulturalBlessing { get; set; }

        public int AweCommonSkill { get; set; }
        public int AthleticsCommonSkill { get; set; }
        public int AwarenessCommonSkill { get; set; }
        public int ExploreCommonSkill { get; set; }
        public int SongCommonSkill { get; set; }
        public int CraftCommonSkill { get; set; }
        public int InspireCommonSkill { get; set; }
        public int TravelCommonSkill { get; set; }
        public int InsightCommonSkill { get; set; }
        public int HealingCommonSkill { get; set; }
        public int CourtesyCommonSkill { get; set; }
        public int BattleCommonSkill { get; set; }
        public int PersuadeCommonSkill { get; set; }
        public int StealthCommonSkill { get; set; }
        public int SearchCommonSkill { get; set; }
        public int HuntingCommonSkill { get; set; }
        public int RiddleCommonSkill { get; set; }
        public int LoreCommonSkill { get; set; }

        public List<string> DistinctiveFeatures { get; set; }

        public Dictionary<string, int> WeaponSetOne { get; set; }
        public Dictionary<string, int> WeaponSetTwo { get; set; }
    }

    public class Culture : Characteristics
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public List<string> Specialties { get; set; }

    }

    public class Character : Characteristics
    {
        public int BodyAttribute { get; set; }
        public int BodyFavoredAttribute { get; set; }
        public int HeartAttribute { get; set; }
        public int HeartFavoredAttribute { get; set; }
        public int WitsAttribute { get; set; }
        public int WitsFavoredAttribute { get; set; }
    }

    public class Background
    {
        public string Culture { get; set; }
        public string Tiitle { get; set; }
        public int BasicBody { get; set; }
        public int BasicHeart { get; set; }
        public int BasicWits { get; set; }
        public string FavoredSkill { get; set; }
        public  List<string> DistinctiveFeatures { get; set; }
    }

    public class CultureWeaponSet
    {
        public string Name { get; set; }
        public Dictionary<string, int> WeaponSetOne { get; set; }
        public Dictionary<string, int> WeaponSetTwo { get; set; }
    }

}
