using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CharacterClasses
{
    public enum WeaponGroup { Sword=1, Axe, Bow, Spear, Other }
    public class Characteristics
    {
        public Background Background { get; set; }
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


    }

    public class Culture : Characteristics
    {
        public string Description { get; set; }
        public string CultureName { get; set; }
        public List<string> Specialties { get; set; }

        public Dictionary<string, int> WeaponSetOne { get; set; }
        public Dictionary<string, int> WeaponSetTwo { get; set; }

    }

    public class Character : Characteristics
    {
        public int BodyAttribute { get; set; }
        public int BodyFavoredAttribute { get; set; }
        public int HeartAttribute { get; set; }
        public int HeartFavoredAttribute { get; set; }
        public int WitsAttribute { get; set; }
        public int WitsFavoredAttribute { get; set; }
        public Culture Culture { get; set; }

        public WeaponSkill WeaponSkillOne { get; set; }
        public WeaponSkill WeaponSkillTwo { get; set; }
        public WeaponSkill WeaponSkillThree { get; set; }
        public WeaponSkill WeaponSkillFour { get; set; }
        public WeaponSkill WeaponSkillFive { get; set; }
        public WeaponSkill WeaponSkillSix { get; set; }
    }

    public class Background
    {
        public string Culture { get; set; }
        public string Title { get; set; }
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

    public class CommonSkill
    {
        public string SkillName { get; set; }
        public int SkillValue { get; set; }
        public bool IsFavored { get; set; }
        public string SkillGroupMember { get; set; }
    }
    public class WeaponSkill
    {
        public string CultureName { get; set; }
        public string Profficiency { get; set; }
        public int SkillValue { get; set; }
        public bool IndividualSkill { get; set; }
        public bool CulturalSkill { get; set; }
    }

    public class Weapon
    {
        public string WeaponName { get; set; }
        public int Damage { get; set; }
        public WeaponGroup WeaponGroup { get; set; }
        public int Edge { get; set; }
        public int Injury { get; set; }
        public int Encumberance { get; set; }
    }
}
