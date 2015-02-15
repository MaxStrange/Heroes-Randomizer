using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes_Randomizer
{
    class Race
    {
        protected int heroStrength;
        protected int smallUnitStrength;
        protected int large1Strength;
        protected int large2Strength;
        protected int itemStrength;

        protected int _matchStrength;

        public int matchStrength
        {
            get { return this._matchStrength; }
        }

        protected int maxMatchStrength;
        protected int minMatchStrength;

        protected int _raceNumber;

        public int raceNumber
        {
            get { return this._raceNumber; }
        }

        protected string _heroName;

        public string heroName
        {
            get { return this._heroName; }
        }

        protected string _largeUnit1;

        public string largeUnit1
        {
            get { return this._largeUnit1; }
        }

        protected string _largeUnit2;

        public string largeUnit2
        {
            get { return this._largeUnit2; }
        }

        protected string _smallUnit;

        public string smallUnit
        {
            get { return this._smallUnit; }
        }

        protected string _item;

        public string item
        {
            get { return this._item; }
        }

        virtual public void assignItem()
        {
        }

        virtual public void calculateMatchStrength()
        {
        }
    }
}
