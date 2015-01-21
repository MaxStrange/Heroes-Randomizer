using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Heroes_Randomizer
{
    public partial class Form1 : Form
    {
        Random randomizer = new Random();
        
        private Race p1Race;
        private Race p2Race;

        enum raceNames { humans = 1, demons = 2, undead = 3, wizards = 4, elves = 5 };

        public Form1()
        {
            InitializeComponent();
        }

        private Race assignRace(int raceDeterminer)
        {
            switch (raceDeterminer)
            {
                case (int)raceNames.humans :
                    return new Humans();
                case (int)raceNames.demons :
                    return new Demons();
                case (int)raceNames.undead :
                    return new Undead();
                case (int)raceNames.wizards :
                    return new Wizards();
                case (int)raceNames.elves :
                    return new Elves();
            }
            return null;
        }

        private void randomizerP1_Click(object sender, EventArgs e)
        {
            do
            {
                int randomNumber = randomizer.Next(1, 6);
                this.p1Race = assignRace(randomNumber);
            }
            while (matchIsNotEven());

            displayInformationP1();
        }

        private void randomizeP2_Click(object sender, EventArgs e)
        {
            do
            {
                int randomNumber = randomizer.Next(1, 6);
                this.p2Race = assignRace(randomNumber);
            }
            while (matchIsNotEven());

            displayInformationP2();
        }

        private bool matchIsNotEven()
        {
            if (this.checkBoxEvenMatch.Checked)
            {
                if (bothPlayersAreRandomized())
                {
                    int p1Strength = this.p1Race.matchStrength;
                    int p2Strength = this.p2Race.matchStrength;
                    if (match(p1Strength, p2Strength))
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        private bool match(int p1Strength, int p2Strength)
        {
            if ((p1Strength < (p2Strength - 1)) || (p1Strength > (p2Strength + 1)))
                return false;
            else
                return true;
        }

        private bool bothPlayersAreRandomized()
        {
            if (this.p1Race == null)
                return false;
            if (this.p2Race == null)
                return false;
            return true;
        }

        private void displayInformationP1()
        {
            this.HeroBoxP1.Text = this.p1Race.heroName;
            this.SmallUnitBoxP1.Text = this.p1Race.smallUnit;
            this.LargeUnitBoxP1.Text = this.p1Race.largeUnit1;
            this.LargeUnit2BoxP1.Text = this.p1Race.largeUnit2;
            this.ItemBoxP1.Text = this.p1Race.item;
            this.matchValueBoxP1.Text = "" + this.p1Race.matchStrength;

            string heroImageFilePath = findHeroImage(this.p1Race.heroName);
            try
            {
                this.pictureBoxP1.Image = new Bitmap(heroImageFilePath);
            }
            catch (System.ArgumentException)
            {
            }
        }

        private void displayInformationP2()
        {
            this.heroBoxP2.Text = this.p2Race.heroName;
            this.smallUnitBoxP2.Text = this.p2Race.smallUnit;
            this.largeUnit1BoxP2.Text = this.p2Race.largeUnit1;
            this.largeUnit2BoxP2.Text = this.p2Race.largeUnit2;
            this.itemBoxP2.Text = this.p2Race.item;
            this.matchValueBoxP2.Text = "" + this.p2Race.matchStrength;

            string heroImageFilePath = findHeroImage(this.p2Race.heroName);
            try
            {
                this.pictureBoxP2.Image = new Bitmap(heroImageFilePath);
            }
            catch (System.ArgumentException)
            {
            }
        }

        private string findHeroImage(string heroName)
        {
            string heroImagePath = "Images\\";

            switch (heroName)
            {
                case "Azexes":
                    heroImagePath = heroImagePath + "Azexes.jpg";
                    break;
                case "Findan":
                    heroImagePath = heroImagePath + "Findan.jpg";
                    break;
                case "Anwen":
                    heroImagePath = heroImagePath + "Anwen.png";
                    break;
                case "Azh Rafir":
                    heroImagePath = heroImagePath + "Azh_Rafir.jpg";
                    break;
                case "Carlyle":
                    heroImagePath = heroImagePath + "Count_carlyle.png";
                    break;
                case "Godric":
                    heroImagePath = heroImagePath + "Godric.jpg";
                    break;
                case "Fiona":
                    heroImagePath = heroImagePath + "Fiona.jpg";
                    break;
                case "Markal":
                    heroImagePath = heroImagePath + "Markal.jpg";
                    break;
                case "Cyrus":
                    heroImagePath = heroImagePath + "Cyrus.jpg";
                    break;
                case "Aidan":
                    heroImagePath = heroImagePath + "Aidan.jpg";
                    break;
                case "Varkas":
                    heroImagePath = heroImagePath + "Varkas.jpg";
                    break;
                case "Jezebeth":
                    heroImagePath = heroImagePath + "Jezebeth.jpg";
                    break;
                case "Ludmilla":
                    heroImagePath = heroImagePath + "Ludmilla.jpg";
                    break;
                case "Nadia":
                    heroImagePath = heroImagePath + "Nadia.jpg";
                    break;
            }
            return heroImagePath;
        }

        private void redoItemP1_Click(object sender, EventArgs e)
        {   
            this.p1Race.assignItem();
            this.p1Race.calculateMatchStrength();
            this.ItemBoxP1.Text = this.p1Race.item;
            this.matchValueBoxP1.Text = "" + this.p1Race.matchStrength;
        }

        private void redoItemP2_Click(object sender, EventArgs e)
        {    
            this.p2Race.assignItem();
            this.p2Race.calculateMatchStrength();
            this.itemBoxP2.Text = this.p2Race.item;
            this.matchValueBoxP2.Text = "" + this.p2Race.matchStrength;
        }
    }
}
