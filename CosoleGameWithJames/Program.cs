using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CosoleGameWithJames
{
    class Program
    {
        static string newline = "\n";

        /*
         * bool
         * string
         * double
         * int
          */
        static void Main(string[] args)
        {

            //player character
            Character mainCharacter = new Character(1, 100, 2);
            mainCharacter.CriticalHitChance = 10;

            Console.WriteLine("Welcome to a Battle.");

            CreateUserName(mainCharacter);
            

            //defined stats
            Console.WriteLine(mainCharacter.Name);
            Console.WriteLine("Attack: " + mainCharacter.Attack);
            Console.WriteLine("Hitpoints: " + mainCharacter.HitPoints + newline + "Defense: " + mainCharacter.Defence + newline);


            Character monCharacter = new Character(12, 100, 14);
            monCharacter.Name = "Earl";
            monCharacter.CriticalHitChance = 10;
            Console.WriteLine("monCharacter");
            Console.WriteLine("Attack: " + monCharacter.Attack);
            Console.WriteLine("Hitpoints: " + monCharacter.HitPoints + newline + "Defense: " + monCharacter.Defence + newline);

            BattleEngine(mainCharacter, monCharacter);

            //defined stats
            Console.WriteLine(mainCharacter.Name);
            Console.WriteLine("Attack: " + mainCharacter.Attack);
            Console.WriteLine("Hitpoints: " + mainCharacter.HitPoints + newline + "Defense: " + mainCharacter.Defence + newline);


            Console.WriteLine("monCharacter");
            Console.WriteLine("Attack: " + monCharacter.Attack);
            Console.WriteLine("Hitpoints: " + monCharacter.HitPoints + newline + "Defense: " + monCharacter.Defence + newline);



        }

        private static void BattleEngine(Character mainCharacter, Character monCharacter)
        {
            bool battleOver = false;

            while (battleOver == false)
            {
                Console.WriteLine("what would you like to do?" + newline
                    + "1. attack" + newline
                    + "2. defend" + newline
                    + "3. runaway");
                Random random = new Random();

                switch (Console.ReadLine())
                {
                    case "1": //Attack
                        Console.WriteLine("How will you attack?");
                        Console.WriteLine("1. Throw a punch.");

                        switch (Console.ReadLine())
                        {
                            case "1": // Punch

                                ThrowAPunch(mainCharacter, monCharacter, random);
                                Console.WriteLine("He counters!");
                                ThrowAPunch(monCharacter, mainCharacter, random);

                                break;
                            default:
                                break;
                        }
                        break;

                    case "2"://Defend
                        ThrowAPunch(monCharacter, mainCharacter, random);
                        Console.WriteLine("Hitpoints: " + mainCharacter.HitPoints + newline);
                        break;

                    case "3"://Runaway
                        Console.WriteLine("you have decided to run");
                        battleOver = true;
                        break;

                    default:
                        break;

                }
                Console.WriteLine("Test");
                if (monCharacter.HitPoints <= 0)
                {
                    Console.WriteLine("you have won the battle");
                    battleOver = true;

                }
                if (mainCharacter.HitPoints <= 0)
                {
                    Console.WriteLine(newline + "you have lost the battle");
                    battleOver = true;
                }



            }
        }

        private static void ThrowAPunch(Character striker, Character defender, Random random)
        {
            double criticalHit = 1;

            if (random.Next(0, 100) <= striker.CriticalHitChance)
            {
                criticalHit = 1.5;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Critical hit!");
                Console.ResetColor();
            }

            int damage = Convert.ToInt16(defender.HitPoints - striker.Attack * criticalHit);
            defender.TakeDamage( damage);
            Console.WriteLine(striker.Name + " THROW A MIGHTY BLOW: " + damage);
            Console.WriteLine(defender.Name + " Hitpoints: " + defender.HitPoints + newline);
        }

        private static void CreateUserName(Character character)
        {
            bool correctName = false;

            while (correctName == false)
            {
                Console.WriteLine("What is your name?");
                character.Name = Console.ReadLine();
                Console.WriteLine("You said your name is " + character.Name + "? y/n");

                switch (Console.ReadLine())
                {
                    case "y":
                        correctName = true;
                        break;
                    case "n":
                        Console.WriteLine("Okay then, speak louder...");
                        break;
                    default:
                        Console.WriteLine("Your not making any sense.");
                        break;
                }
            }
        }

        public class Character
        {

            #region Declarations

            string name;
            byte attack;
            int hitPoints;
            int defence;
            int maxHitPoint;
            double criticalHitChance = 10;

            #endregion

            #region Constructors

            public Character(byte attack, int hitPoints, int defence)
            {
                this.attack = attack;
                this.hitPoints = hitPoints;
                this.maxHitPoint = hitPoints;
                this.defence = defence;
            }

            #endregion

            #region Properties

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public byte Attack
            {
                get { return attack; }
                set { attack = value; }
            }

            public int HitPoints
            {
                get { return hitPoints; }
                set { hitPoints = value; }
            }

            public int Defence
            {
                get { return defence; }
                set { defence = value; }
            }

            public double CriticalHitChance
            {
                get { return criticalHitChance; }
                set { criticalHitChance = value; }
            }

            #endregion

            #region methods

            public void TakeDamage(int amount)
            {
                hitPoints = hitPoints - amount;
                if (hitPoints / maxHitPoint <= 0.2)
                {
                    criticalHitChance = 90;
                }
                   
            }
               


            #endregion
        }


       
    }
}
