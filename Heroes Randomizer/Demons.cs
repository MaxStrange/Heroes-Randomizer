using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes_Randomizer
{
    class Demons : Race
    {
        private int heroNumber = -1;
        enum demonHeroes { azexes = 0, aidan = 1, jezebeth = 2 };

        private int itemNumber = -1;
        enum demonItems { rageShield = 0, thornWhip = 1, magmaShard = 2, celerityRing = 3,
            burningHorn = 4, volcanoArmor = 5, pitMastersTail = 6, cripplingFlail = 7,
            reviveFlame = 8, chaosCrown = 9 };

        private int largeUnit1Number = -1;
        private int largeUnit2Number = -1;
        enum demonLargeUnits { sorcerers = 0, succubus = 1, pitfiends = 2, abyssalLords = 3,
            nightmares = 4 };

        private int smallUnitNumber = -1;
        enum demonSmallUnits { hornedDemons = 0, imps = 1, hellHounds = 2 };

        public Demons()
        {
            randomAssignEverything();
            this.maxMatchStrength = 21;
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
                case (int)demonHeroes.azexes:
                    this._heroName = "Azexes";
                    this.heroStrength = 5;
                    break;
                case (int)demonHeroes.aidan:
                    this._heroName = "Aidan";
                    this.heroStrength = 3;
                    break;
                case (int)demonHeroes.jezebeth:
                    this._heroName = "Jezebeth";
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
                case (int)demonSmallUnits.hornedDemons:
                    this._smallUnit = "Horned Demons";
                    this.smallUnitStrength = 1;
                    break;
                case (int)demonSmallUnits.imps:
                    this._smallUnit = "Imps";
                    this.smallUnitStrength = 1;
                    break;
                case (int)demonSmallUnits.hellHounds:
                    this._smallUnit = "Hellhounds";
                    this.smallUnitStrength = 1;
                    break;
            }
            this.smallUnitNumber = smallUnitNumber;
        }

        private void assignLargeUnit(int largeUnitNumber, int unitNumber)
        {
            if (unitNumber == 1)
                assignLargeUnit1(largeUnitNumber);
            else
                assignLargeUnit2(largeUnitNumber);
        }

        private void assignLargeUnit1(int unitNumber)
        {
            switch (unitNumber)
            {
                case (int)demonLargeUnits.sorcerers:
                    this._largeUnit1 = "Sorcerers";
                    this.large1Strength = 4;
                    break;
                case (int)demonLargeUnits.succubus:
                    this._largeUnit1 = "Succubus";
                    this.large1Strength = 5;
                    break;
                case (int)demonLargeUnits.pitfiends:
                    this._largeUnit1 = "Pitfiends";
                    this.large1Strength = 8;
                    break;
                case (int)demonLargeUnits.abyssalLords:
                    this._largeUnit1 = "Abyssal Lords";
                    this.large1Strength = 7;
                    break;
                case (int)demonLargeUnits.nightmares:
                    this._largeUnit1 = "Nightmares";
                    this.large1Strength = 5;
                    break;
            }
            this.largeUnit1Number = unitNumber;
        }

        private void assignLargeUnit2(int unitNumber)
        {
            switch (unitNumber)
            {
                case (int)demonLargeUnits.sorcerers:
                    this._largeUnit2 = "Sorcerers";
                    this.large2Strength = 4;
                    break;
                case (int)demonLargeUnits.succubus:
                    this._largeUnit2 = "Succubus";
                    this.large2Strength = 5;
                    break;
                case (int)demonLargeUnits.pitfiends:
                    this._largeUnit2 = "Pitfiends";
                    this.large2Strength = 8;
                    break;
                case (int)demonLargeUnits.abyssalLords:
                    this._largeUnit2 = "Abyssal Lords";
                    this.large2Strength = 7;
                    break;
                case (int)demonLargeUnits.nightmares:
                    this._largeUnit2 = "Nightmares";
                    this.large2Strength = 5;
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
                case (int)demonItems.rageShield:
                    item = "Rage Shield";
                    this.itemStrength = 2;
                    break;
                case (int)demonItems.thornWhip:
                    item = "Thorn Whip";
                    this.itemStrength = 2;
                    break;
                case (int)demonItems.magmaShard:
                    item = "Magma Shard";
                    this.itemStrength = 2;
                    break;
                case (int)demonItems.celerityRing:
                    item = "Celerity Ring";
                    this.itemStrength = 4;
                    break;
                case (int)demonItems.burningHorn:
                    item = "Burning Horn";
                    this.itemStrength = 2;
                    break;
                case (int)demonItems.volcanoArmor:
                    item = "Volcano Armor";
                    this.itemStrength = 2;
                    break;
                case (int)demonItems.pitMastersTail:
                    item = "Pit Master's Tail";
                    this.itemStrength = 2;
                    break;
                case (int)demonItems.cripplingFlail:
                    item = "Crippling Flail";
                    this.itemStrength = 2;
                    break;
                case (int)demonItems.reviveFlame:
                    item = "Revive Flame";
                    this.itemStrength = 1;
                    break;
                case (int)demonItems.chaosCrown:
                    item = "Chaos Crown";
                    this.itemStrength = 3;
                    break;
            }

            this._item = item;
            this.itemNumber = itemNumber;
        }

        private bool itemIsUseless()
        {
            switch (this.itemNumber)
            {
                case (int)demonItems.thornWhip:
                    if ((this.largeUnit1Number == (int)demonLargeUnits.nightmares) || (this.largeUnit2Number == (int)demonLargeUnits.nightmares))
                        return false;
                    else
                        return true;
                case (int)demonItems.magmaShard:
                    if ((this.largeUnit1Number == (int)demonLargeUnits.abyssalLords) || (this.largeUnit2Number == (int)demonLargeUnits.abyssalLords))
                        return false;
                    else
                        return true;
                case (int)demonItems.burningHorn:
                    if ((this.largeUnit1Number == (int)demonLargeUnits.succubus) || (this.largeUnit2Number == (int)demonLargeUnits.succubus))
                        return false;
                    else
                        return true;
                case (int)demonItems.pitMastersTail:
                    if ((this.largeUnit1Number == (int)demonLargeUnits.pitfiends) || (this.largeUnit2Number == (int)demonLargeUnits.pitfiends))
                        return false;
                    else
                        return true;
                default :
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
