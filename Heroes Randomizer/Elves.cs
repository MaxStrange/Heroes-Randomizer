using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes_Randomizer
{
    class Elves : Race
    {
        private int heroNumber = -1;
        enum elfHeroes { findan = 0, anwen = 1 };

        private int itemNumber = -1;
        enum elfItems
        {
            leafPlate = 0, goldenRoots = 1, deerAntler = 2, elderStaff = 3,
            doublingCape = 4, vineGloves = 5, treantSap = 6, dragonScales = 7,
            boostBoots = 8, ringOfLife = 9
        };

        private int largeUnit1Number = -1;
        private int largeUnit2Number = -1;
        enum elfLargeUnits
        {
            deer = 0, unicorns = 1, druids = 2, emeraldDragons = 3,
            treants = 4
        };

        private int smallUnitNumber = -1;
        enum elfSmallUnits { archers = 0, pixies = 1, bears = 2 };

        public Elves()
        {
            randomAssignEverything();
            this.maxMatchStrength = 17;
            this.minMatchStrength = 9;
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
            int heroNumber = generator.Next(2);

            switch (heroNumber)
            {
                case (int)elfHeroes.findan:
                    this._heroName = "Findan";
                    this.heroStrength = 3;
                    break;
                case (int)elfHeroes.anwen:
                    this._heroName = "Anwen";
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
                case (int)elfSmallUnits.archers:
                    this._smallUnit = "Archers";
                    this.smallUnitStrength = 1;
                    break;
                case (int)elfSmallUnits.pixies:
                    this._smallUnit = "Pixies";
                    this.smallUnitStrength = 2;
                    break;
                case (int)elfSmallUnits.bears:
                    this._smallUnit = "Bears";
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
                case (int)elfLargeUnits.deer:
                    this._largeUnit1 = "Deer";
                    this.large1Strength = 5;
                    break;
                case (int)elfLargeUnits.unicorns:
                    this._largeUnit1 = "Unicorns";
                    this.large1Strength = 5;
                    break;
                case (int)elfLargeUnits.druids:
                    this._largeUnit1 = "Druids";
                    this.large1Strength = 4;
                    break;
                case (int)elfLargeUnits.emeraldDragons:
                    this._largeUnit1 = "Emerald Dragons";
                    this.large1Strength = 6;
                    break;
                case (int)elfLargeUnits.treants:
                    this._largeUnit1 = "Treants";
                    this.large1Strength = 6;
                    break;
            }
            this.largeUnit1Number = unitNumber;
        }

        private void assignLargeUnit2(int unitNumber)
        {
            switch (unitNumber)
            {
                case (int)elfLargeUnits.deer:
                    this._largeUnit2 = "Deer";
                    this.large2Strength = 5;
                    break;
                case (int)elfLargeUnits.unicorns:
                    this._largeUnit2 = "Unicorns";
                    this.large2Strength = 5;
                    break;
                case (int)elfLargeUnits.druids:
                    this._largeUnit2 = "Druids";
                    this.large2Strength = 4;
                    break;
                case (int)elfLargeUnits.emeraldDragons:
                    this._largeUnit2 = "Emerald Dragons";
                    this.large2Strength = 6;
                    break;
                case (int)elfLargeUnits.treants:
                    this._largeUnit2 = "Treants";
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
                case (int)elfItems.leafPlate:
                    item = "Leaf Plate";
                    this.itemStrength = 2;
                    break;
                case (int)elfItems.goldenRoots:
                    item = "Golden Roots";
                    this.itemStrength = 2;
                    break;
                case (int)elfItems.deerAntler:
                    item = "Deer Antler";
                    this.itemStrength = 2;
                    break;
                case (int)elfItems.elderStaff:
                    item = "Elder Staff";
                    this.itemStrength = 0;
                    break;
                case (int)elfItems.doublingCape:
                    item = "Doubling Cape";
                    this.itemStrength = 2;
                    break;
                case (int)elfItems.vineGloves:
                    item = "Vine Gloves";
                    this.itemStrength = 1;
                    break;
                case (int)elfItems.treantSap:
                    item = "Treant Sap";
                    this.itemStrength = 2;
                    break;
                case (int)elfItems.dragonScales:
                    item = "Dragon Scales";
                    this.itemStrength = 1;
                    break;
                case (int)elfItems.boostBoots:
                    item = "Boost Boots";
                    this.itemStrength = 3;
                    break;
                case (int)elfItems.ringOfLife:
                    item = "Ring of Life";
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
                case (int)elfItems.dragonScales:
                    if ((this.largeUnit1Number == (int)elfLargeUnits.emeraldDragons) || (this.largeUnit2Number == (int)elfLargeUnits.emeraldDragons))
                        return false;
                    else
                        return true;
                case (int)elfItems.deerAntler:
                    if ((this.largeUnit1Number == (int)elfLargeUnits.deer) || (this.largeUnit2Number == (int)elfLargeUnits.deer))
                        return false;
                    else
                        return true;
                case (int)elfItems.elderStaff:
                    if ((this.largeUnit1Number == (int)elfLargeUnits.druids) || (this.largeUnit2Number == (int)elfLargeUnits.druids))
                        return false;
                    else
                        return true;
                case (int)elfItems.treantSap:
                    if ((this.largeUnit1Number == (int)elfLargeUnits.treants) || (this.largeUnit2Number == (int)elfLargeUnits.treants))
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
