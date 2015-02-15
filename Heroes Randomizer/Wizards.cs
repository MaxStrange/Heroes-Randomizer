using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes_Randomizer
{
    class Wizards : Race
    {
        private int heroNumber = -1;
        enum wizardHeroes { azhRafir = 0, nadia = 1, cyrus = 2 };

        private int itemNumber = -1;
        enum wizardItems { gauntlet = 0, absorbCirclet = 1, manaShield = 2, battleWand = 3,
            djinnsSash = 4, goldenFist = 5, scimitar = 6, bindingOrb = 7,
            transformGem = 8, revivalRing = 9 };
                
        private int largeUnit1Number = -1;
        private int largeUnit2Number = -1;
        enum wizardLargeUnits { mages = 0, titans = 1, rakshasas = 2, phoenixes = 3,
            djinnis = 4 };

        private int smallUnitNumber = -1;
        enum wizardSmallUnits { gremlins = 0, apprentices = 1, golems = 2 };

        public Wizards()
        {
            randomAssignEverything();
            this.maxMatchStrength = 18;
            this.minMatchStrength = 8;
        }

        private void randomAssignEverything()
        {
            Random randomGenerator = new Random();
            assignHero(randomGenerator);
            assignSmallUnit(randomGenerator);
            int large1 = randomGenerator.Next(5);
            int large2 = randomGenerator.Next(5);
            while (large1 == large2)
            {
                large2 = randomGenerator.Next(5);
            }
            assignLargeUnit(large1, 1);
            assignLargeUnit(large2, 2);
            do
            {
                assignItem();
            }
            while (itemIsUseless());
            calculateMatchStrength();
        }

        private void assignHero(Random generator)
        {
            int heroNumber = generator.Next(3);

            switch (heroNumber)
            {
                case (int)wizardHeroes.nadia:
                    this._heroName = "Nadia";
                    this.heroStrength = 1;
                    break;
                case (int)wizardHeroes.cyrus:
                    this._heroName = "Cyrus";
                    this.heroStrength = 1;
                    break;
                case (int)wizardHeroes.azhRafir:
                    this._heroName = "Azh Rafir";
                    this.heroStrength = 3;
                    break;
            }
            this.heroNumber = heroNumber;
        }

        private void assignSmallUnit(Random generator)
        {
            int smallUnitNumber = generator.Next(3);

            switch (smallUnitNumber)
            {
                case (int)wizardSmallUnits.gremlins:
                    this._smallUnit = "Gremlins";
                    this.smallUnitStrength = 1;
                    break;
                case (int)wizardSmallUnits.golems:
                    this._smallUnit = "Golems";
                    this.smallUnitStrength = 1;
                    break;
                case (int)wizardSmallUnits.apprentices:
                    this._smallUnit = "Apprentices";
                    this.smallUnitStrength = 0;
                    break;
            }
            this.smallUnitNumber = smallUnitNumber;
        }

        private void assignLargeUnit(int largeUnitNumber, int unitNumber)
        {
            if (unitNumber == 1)
            {
                assignLargeUnit1(largeUnitNumber);
            }
            else
            {
                assignLargeUnit2(largeUnitNumber);
            }
        }

        private void assignLargeUnit1(int unitNumber)
        {
            switch (unitNumber)
            {
                case (int)wizardLargeUnits.mages:
                    this._largeUnit1 = "Mages";
                    this.large1Strength = 5;
                    break;
                case (int)wizardLargeUnits.titans:
                    this._largeUnit1 = "Titans";
                    this.large1Strength = 7;
                    break;
                case (int)wizardLargeUnits.rakshasas:
                    this._largeUnit1 = "Rakshasas";
                    this.large1Strength = 6;
                    break;
                case (int)wizardLargeUnits.djinnis:
                    this._largeUnit1 = "Djinnis";
                    this.large1Strength = 4;
                    break;
                case (int)wizardLargeUnits.phoenixes:
                    this._largeUnit1 = "Phoenixes";
                    this.large1Strength = 6;
                    break;
            }
            this.largeUnit1Number = unitNumber;
        }

        private void assignLargeUnit2(int unitNumber)
        {
            switch (unitNumber)
            {
                case (int)wizardLargeUnits.mages:
                    this._largeUnit2 = "Mages";
                    this.large2Strength = 5;
                    break;
                case (int)wizardLargeUnits.titans:
                    this._largeUnit2 = "Titans";
                    this.large2Strength = 7;
                    break;
                case (int)wizardLargeUnits.rakshasas:
                    this._largeUnit2 = "Rakshasas";
                    this.large2Strength = 6;
                    break;
                case (int)wizardLargeUnits.djinnis:
                    this._largeUnit2 = "Djinnis";
                    this.large2Strength = 4;
                    break;
                case (int)wizardLargeUnits.phoenixes:
                    this._largeUnit2 = "Phoenixes";
                    this.large2Strength = 6;
                    break;
            }
            this.largeUnit2Number = unitNumber;
        }

        override public void assignItem()
        {
            Random generator = new Random();
            int itemNumber = generator.Next(10);

            string item = "";

            switch (itemNumber)
            {
                case (int)wizardItems.gauntlet:
                    item = "Gauntlet";
                    this.itemStrength = 1;
                    break;
                case (int)wizardItems.absorbCirclet:
                    item = "Absorb Circlet";
                    this.itemStrength = 2;
                    break;
                case (int)wizardItems.manaShield:
                    item = "Mana Shield";
                    this.itemStrength = 3;
                    break;
                case (int)wizardItems.battleWand:
                    item = "Battle Wand";
                    this.itemStrength = 0;
                    break;
                case (int)wizardItems.djinnsSash:
                    item = "Djinn's Sash";
                    this.itemStrength = 1;
                    break;
                case (int)wizardItems.goldenFist:
                    item = "Golden Fist";
                    this.itemStrength = 2;
                    break;
                case (int)wizardItems.scimitar:
                    item = "Scimitar";
                    this.itemStrength = 2;
                    break;
                case (int)wizardItems.bindingOrb:
                    item = "Binding Orb";
                    this.itemStrength = 2;
                    break;
                case (int)wizardItems.transformGem:
                    item = "Transform Gem";
                    this.itemStrength = 2;
                    break;
                case (int)wizardItems.revivalRing:
                    item = "Revival Ring";
                    this.itemStrength = 1;
                    break;
            }
            this._item = item;
            this.itemNumber = itemNumber;
        }

        private bool itemIsUseless()
        {
            switch (this.itemNumber)
            {
                case (int)wizardItems.djinnsSash:
                    if ((this.largeUnit1Number == (int)wizardLargeUnits.djinnis) || (this.largeUnit2Number == (int)wizardLargeUnits.djinnis))
                        return false;
                    else
                        return true;
                case (int)wizardItems.scimitar:
                    if ((this.largeUnit1Number == (int)wizardLargeUnits.rakshasas) || (this.largeUnit2Number == (int)wizardLargeUnits.rakshasas))
                        return false;
                    else
                        return true;
                case (int)wizardItems.goldenFist:
                    if ((this.largeUnit1Number == (int)wizardLargeUnits.titans) || (this.largeUnit2Number == (int)wizardLargeUnits.titans))
                        return false;
                    else
                        return true;
                case (int)wizardItems.transformGem:
                    if ((this.largeUnit1Number == (int)wizardLargeUnits.mages) || (this.largeUnit2Number == (int)wizardLargeUnits.mages))
                        return false;
                    else
                        return true;
                default:
                    return false;
            }
        }

        override public void calculateMatchStrength()
        {
            this._matchStrength = (this.heroStrength + this.smallUnitStrength + this.large1Strength +
                this.large2Strength + this.itemStrength + 1);
            //the plus one is for the wizard's annoying wall ability
        }
    }
}
