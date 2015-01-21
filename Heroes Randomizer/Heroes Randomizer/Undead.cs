using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes_Randomizer
{
    class Undead : Race
    {
        private int heroNumber = -1;
        enum undeadHeroes { ludmilla = 0, markal = 1, fiona = 2 };

        private int itemNumber = -1;
        enum undeadItems
        {
            cursedShield = 0, bloodOfTheOne = 1, ritualDagger = 2, spiderCloak = 3,
            plagueRat = 4, bloodRing = 5, crownOfThorns = 6, twilightUrn = 7,
            bookOfTheDead = 8, talonsTalon = 9
        };

        private int largeUnit1Number = -1;
        private int largeUnit2Number = -1;
        enum undeadLargeUnits
        {
            ghosts = 0, vampires = 1, wraiths = 2, deathKnights = 3,
            boneDragons = 4
        };

        private int smallUnitNumber = -1;
        enum undeadSmallUnits { skeletons = 0, zombies = 1, ebonGuard = 2 };

        public Undead()
        {
            randomAssignEverything();
            this.maxMatchStrength = 17;
            this.minMatchStrength = 11;
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
                case (int)undeadHeroes.ludmilla:
                    this._heroName = "Ludmilla";
                    this.heroStrength = 3;
                    break;
                case (int)undeadHeroes.markal:
                    this._heroName = "Markal";
                    this.heroStrength = 4;
                    break;
                case (int)undeadHeroes.fiona:
                    this._heroName = "Fiona";
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
                case (int)undeadSmallUnits.skeletons:
                    this._smallUnit = "Skeletons";
                    this.smallUnitStrength = 1;
                    break;
                case (int)undeadSmallUnits.zombies:
                    this._smallUnit = "Zombies";
                    this.smallUnitStrength = 1;
                    break;
                case (int)undeadSmallUnits.ebonGuard:
                    this._smallUnit = "Ebon Guard";
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
                case (int)undeadLargeUnits.vampires:
                    this._largeUnit1 = "Vampires";
                    this.large1Strength = 5;
                    break;
                case (int)undeadLargeUnits.ghosts:
                    this._largeUnit1 = "Ghosts";
                    this.large1Strength = 5;
                    break;
                case (int)undeadLargeUnits.wraiths:
                    this._largeUnit1 = "Wraiths";
                    this.large1Strength = 5;
                    break;
                case (int)undeadLargeUnits.deathKnights:
                    this._largeUnit1 = "Death Knights";
                    this.large1Strength = 7;
                    break;
                case (int)undeadLargeUnits.boneDragons:
                    this._largeUnit1 = "Bone Dragons";
                    this.large1Strength = 7;
                    break;
            }
            this.largeUnit1Number = unitNumber;
        }

        private void assignLargeUnit2(int unitNumber)
        {
            switch (unitNumber)
            {
                case (int)undeadLargeUnits.vampires:
                    this._largeUnit2 = "Vampires";
                    this.large2Strength = 5;
                    break;
                case (int)undeadLargeUnits.ghosts:
                    this._largeUnit2 = "Ghosts";
                    this.large2Strength = 5;
                    break;
                case (int)undeadLargeUnits.wraiths:
                    this._largeUnit2 = "Wraiths";
                    this.large2Strength = 5;
                    break;
                case (int)undeadLargeUnits.deathKnights:
                    this._largeUnit2 = "Death Knights";
                    this.large2Strength = 7;
                    break;
                case (int)undeadLargeUnits.boneDragons:
                    this._largeUnit2 = "Bone Dragons";
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
                case (int)undeadItems.cursedShield:
                    item = "Cursed Shield";
                    this.itemStrength = 2;
                    break;
                case (int)undeadItems.bloodOfTheOne:
                    item = "Blood of the One";
                    this.itemStrength = 2;
                    break;
                case (int)undeadItems.ritualDagger:
                    item = "Ritual Dagger";
                    this.itemStrength = 1;
                    break;
                case (int)undeadItems.spiderCloak:
                    item = "Spider Cloak";
                    if ((this.largeUnit1Number == (int)undeadLargeUnits.wraiths) || (this.largeUnit2Number == (int)undeadLargeUnits.wraiths))
                        this.itemStrength = 3;
                    else
                        this.itemStrength = 1;
                    break;
                case (int)undeadItems.plagueRat:
                    item = "Plague Rat";
                    this.itemStrength = 2;
                    break;
                case (int)undeadItems.bloodRing:
                    item = "Blood Ring";
                    this.itemStrength = 2;
                    break;
                case (int)undeadItems.crownOfThorns:
                    item = "Crown of Thorns";
                    this.itemStrength = 2;
                    break;
                case (int)undeadItems.twilightUrn:
                    item = "Twilight Urn";
                    this.itemStrength = 2;
                    break;
                case (int)undeadItems.bookOfTheDead:
                    item = "Book of the Dead";
                    this.itemStrength = 1;
                    break;
                case (int)undeadItems.talonsTalon:
                    item = "Talon's Talon";
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
                case (int)undeadItems.bloodOfTheOne:
                    if ((this.largeUnit1Number == (int)undeadLargeUnits.vampires) || (this.largeUnit2Number == (int)undeadLargeUnits.vampires))
                        return false;
                    else
                        return true;
                case (int)undeadItems.talonsTalon:
                    if ((this.largeUnit1Number == (int)undeadLargeUnits.boneDragons) || (this.largeUnit2Number == (int)undeadLargeUnits.boneDragons))
                        return false;
                    else
                        return true;
                case (int)undeadItems.plagueRat:
                    if (this.smallUnitNumber == (int)undeadSmallUnits.zombies)
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
