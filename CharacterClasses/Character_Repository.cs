﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterClasses
{
    public class Culture_Repository
    {
        private readonly List<Culture> _cultures = new List<Culture>();
        private readonly List<Background> _background = new List<Background>();
        private readonly List<CultureWeaponSet> _wepSet = new List<CultureWeaponSet>();
        private readonly List<Background> _bgCurrent = new List<Background>();
        private readonly List<WeaponGroup> _wepGroup = new List<WeaponGroup>();
        private readonly List<Weapon> _weapon = new List<Weapon>();
        private readonly List<WeaponSkill> _wepSkill = new List<WeaponSkill>();


        // CULTURE METHODS
        public bool CreateCulture(Culture culture)
        {
            int cultureStart = _cultures.Count;
            _cultures.Add(culture);
            bool added = (_cultures.Count > cultureStart) ? true : false;

            return added;
        }

        public List<Culture> GetCultures()
        {
            return _cultures;
        }


        // BACKGROUND METHODS
        public List<Background> GetBackground()
        {
            return _background;
        }

        public List<Background> GetBackgroundsByName(string name)
        {
            _bgCurrent.Clear();

            foreach (Background bg in _background)
            {
                string bgTitle = bg.Culture.Remove(2);
                if (name == bgTitle.ToLower())
                {
                    _bgCurrent.Add(bg);
                }
            }
            return _bgCurrent;
        }

        public bool CreateBackground(Background background)
        {
            int backStart = _background.Count;
            _background.Add(background);
            bool added = (_background.Count > backStart) ? true : false;

            return added;
        }

        // WEAPON SET METHODS
        public bool CreateWeaponSet(CultureWeaponSet set)
        {
            int setStart = _wepSet.Count;
            _wepSet.Add(set);
            bool added = (_wepSet.Count > setStart) ? true : false;

            return added;
        }

        public CultureWeaponSet GetWeaponSetByName(Culture culture)
        {
            string name = culture.CultureName.Remove(2);

            foreach (CultureWeaponSet ws in _wepSet)
            {
                if (name == ws.Name.Remove(2))
                {
                    return ws;
                }
            }
            return null;
        }

        // WEAPON SKILL METHODS
        public bool CreateWeaponGroup(WeaponGroup wepGroup)
        {
            int weaponStart = _wepGroup.Count;
            _wepGroup.Add(wepGroup);
            bool added = (_wepGroup.Count > weaponStart) ? true : false;

            return added;
        }

        public List<WeaponGroup> GetWeaponGroup()
        {
            return _wepGroup;
        }

        public bool CreateWeapon(Weapon weapon)
        {
            int weaponStart = _weapon.Count;
            _weapon.Add(weapon);
            bool added = (_weapon.Count > weaponStart) ? true : false;

            return added;
        }

        public List<Weapon> GetWeapon()
        {
            return _weapon;
        }

        public bool CreateWeaponSkill(WeaponSkill wepSkill)
        {
            int weaponStart = _wepSkill.Count;
            _wepSkill.Add(wepSkill);
            bool added = (_wepSkill.Count > weaponStart) ? true : false;

            return added;
        }

        public List<WeaponSkill> GetWeaponSkill()
        {
            return _wepSkill;
        }

        public string StringList(List<string> list)
        {
            return string.Join(", ", list);
        }

    }

    public class Character_Repository
    {
        public bool CreateCharacter()
        {
            return true;
        }
    }
}
