using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes_Randomizer
{
    class Humans : Race
    {
        private int heroNumber = -1;
        enum humanHeroes { carlyle = 0, godric = 1, varkas = 2 };

        private int itemNumber = -1;
        enum humanItems
        {
            phoenixFeather = 0, lionsMain = 1, knightsArmor = 2, goldenSpear = 3,
            holyBlade = 4, kingsCrown = 5, blessedWing = 6, featheredHelm = 7,
            staffOfElrath = 8, crownOfElrath = 9
        };
            
        private int largeUnit1Number = -1;
        private int largeUnit2Number = -1;
        enum humanLargeUnits
        {
            knights = 0, priestesses = 1, griffins = 2, swordmasters = 3,
            angels = 4
        };

        private int smallUnitNumber = -1;
        enum humanSmallUnits { archers = 0, swordsmen = 1, pikemen = 2 };
        
        public Humans()
        {
            randomAssignEverything();
            this.maxMatchStrength = 20;
            this.minMatchStrength = 10;
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
                case (int)humanHeroes.carlyle:
                    this._heroName = "Carlyle";
                    this.heroStrength = 2;
                    break;
                case (int)humanHeroes.godric:
                    this._heroName = "Godric";
                    this.heroStrength = 5;
                    break;
                case (int)humanHeroes.varkas:
                    this._heroName = "Varkas";
                    this.heroStrength = 2;
                    break;
            }
            this.heroNumber = heroNumber;
        }

        private void assignSmallUnit(Random generator)
        {
            int smallUnitNumber = generator.Next(3);

            switch (smallUnitNumber)
            {
                case (int)humanSmallUnits.archers:
                    this._smallUnit = "Archers";
                    this.smallUnitStrength = 0;
                    break;
                case (int)humanSmallUnits.pikemen:
                    this._smallUnit = "Pikemen";
                    this.smallUnitStrength = 2;
                    break;
                case (int)humanSmallUnits.swordsmen:
                    this._smallUnit = "Swordsmen";
                    this.smallUnitStrength = 1;
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
                case (int)humanLargeUnits.knights:
                    this._largeUnit1 = "Knights";
                    this.large1Strength = 5;
                    break;
                case (int)humanLargeUnits.priestesses:
                    this._largeUnit1 = "Priestesses";
                    this.large1Strength = 5;
                    break;
                case (int)humanLargeUnits.griffins:
                    this._largeUnit1 = "Griffins";
                    this.large1Strength = 6;
                    break;
                case (int)humanLargeUnits.swordmasters:
                    this._largeUnit1 = "Swordmasters";
                    this.large1Strength = 7;
                    break;
                case (int)humanLargeUnits.angels:
                    this._largeUnit1 = "Angels";
                    this.large1Strength = 7;
                    break;
            }
            this.largeUnit1Number = unitNumber;
        }

        private void assignLargeUnit2(int unitNumber)
        {
            switch (unitNumber)
            {
                case (int)humanLargeUnits.knights:
                    this._largeUnit2 = "Knights";
                    this.large2Strength = 5;
                    break;
                case (int)humanLargeUnits.priestesses:
                    this._largeUnit2 = "Priestesses";
                    this.large2Strength = 5;
                    break;
                case (int)humanLargeUnits.griffins:
                    this._largeUnit2 = "Griffins";
                    this.large2Strength = 6;
                    break;
                case (int)humanLargeUnits.swordmasters:
                    this._largeUnit2 = "Swordmasters";
                    this.large2Strength = 7;
                    break;
                case (int)humanLargeUnits.angels:
                    this._largeUnit2 = "Angels";
                    this.large2Strength = 7;
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
                case (int)humanItems.phoenixFeather:
                    item = "Phoenix feather";
                    this.itemStrength = 1;
                    break;
                case (int)humanItems.lionsMain:
                    item = "Lion's main";
                    this.itemStrength = 2;
                    break;
                case (int)humanItems.knightsArmor:
                    item = "Knight's armor";
                    this.itemStrength = 2;
                    break;
                case (int)humanItems.goldenSpear:
                    item = "Golden spear";
                    this.itemStrength = 2;
                    break;
                case (int)humanItems.holyBlade:
                    item = "Holy blade";
                    this.itemStrength = 1;
                    break;
                case (int)humanItems.kingsCrown:
                    item = "King's crown";
                    this.itemStrength = 3;
                    break;
                case (int)humanItems.blessedWing:
                    item = "Blessed wing";
                    this.itemStrength = 2;
                    break;
                case (int)humanItems.featheredHelm:
                    item = "Feathered helm";
                    this.itemStrength = 2;
                    break;
                case (int)humanItems.staffOfElrath:
                    item = "Staff of elrath";
                    this.itemStrength = 2;
                    break;
                case (int)humanItems.crownOfElrath:
                    item = "Crown of elrath";
                    this.itemStrength = 2;
                    break;
            }
            this._item = item;
            this.itemNumber = itemNumber;
        }

        private bool itemIsUseless()
        {
            switch (this.itemNumber)
            {
                case (int)humanItems.staffOfElrath:
                    if ((this.largeUnit1Number == (int)humanLargeUnits.priestesses) || (this.largeUnit2Number == (int)humanLargeUnits.priestesses))
                        return false;
                    else
                        return true;
                case (int)humanItems.featheredHelm:
                    if ((this.largeUnit1Number == (int)humanLargeUnits.griffins) || (this.largeUnit2Number == (int)humanLargeUnits.griffins))
                        return false;
                    else
                        return true;
                case (int)humanItems.goldenSpear:
                    if (this.smallUnitNumber == (int)humanSmallUnits.pikemen)
                        return false;
                    else
                        return true;
                case (int)humanItems.blessedWing:
                    if ((this.largeUnit1Number == (int)humanLargeUnits.angels) || (this.largeUnit2Number == (int)humanLargeUnits.angels))
                        return false;
                    else
                        return true;
                case (int)humanItems.knightsArmor:
                    if ((this.largeUnit1Number == (int)humanLargeUnits.knights) || (this.largeUnit2Number == (int)humanLargeUnits.knights))
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
                this.large2Strength + this.itemStrength);
        }
    }
}
