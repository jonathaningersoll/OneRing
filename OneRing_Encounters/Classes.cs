using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneRing_Encounters
{

    public enum CultureType { Dwarf, Elf, Woodman, ManOfLakeTown, Hobbit }
    public enum StandardType { Martial, Wealthy }

    public class Culture
    {
        public int MyProperty { get; set; }
    }
    
    public class CulturalBlessing
    {
        public int MyProperty { get; set; }
    }

    public class Companion
    {
        public string Name { get; set; }
        public Culture Culture { get; set; }
        public string LivingStandard { get; set; }
        public CulturalBlessing CulturalBlessing { get; set; }

        IDictionary<string, string> specialties = new Dictionary<string, string>()
        {
            {"Beast-Lore", "Flavor text." },
            {"Burglary", "Flavor text." },
            {"Boating", "Flavor text." }
        };

    }

    public class CommonSkills
    {

    }

    public class Attributes
    {

    }

    public class Traits
    {

    }

    public class WeaponSkills
    {

    }
}
