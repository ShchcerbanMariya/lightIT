using System;

namespace lightIT
{
    class Player
    {
        public int health;
        public string name;
        public Player()
        {
            health = 100;
            name = "player";
        }
        public Player(int health, string name)
        {
            this.health = health;
            this.name = name;
        }
        public int AddHealth()
        {
            Random randomHealth = new Random();
            if (this.health < 35 && this.name == "computer") // higher chance
            {
                this.health += randomHealth.Next(23, 26);
            }
            else
            {
                this.health += randomHealth.Next(18, 26);
            }
            return this.health;
        }
        public int Damage(int min, int max)
        {
            Random randomDamage = new Random();
            this.health -= randomDamage.Next(min, max);
            if (health < 0) this.health = 0;
            return this.health;
        }

        public override string ToString()
        {
            return $"{name}, has {health} of health";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0; // counter of mistakes

            Random random = new Random();
            Player computer = new Player(100, "computer");
            Player gamer = new Player(100, "gamer");
            Player currentplayer = computer;
            Player theOpponent = gamer;

            //choose the first player
            int firstep = random.Next(0, 2);
            if (firstep == 1)
            {
                currentplayer = gamer;
                theOpponent = computer;
            }
            Console.WriteLine(@"            Welcome to the game!
            You and your opponent have 100 points of health.
            You can choose one of the three commands. 
            Write the number of command to choose it:
            1. The damage to the opponent from 18 to 25 points;
            2. The damage to the opponent from 10 to 35 points;
            3. Add health;
            
            Let`s start! Good Luck!"
            );
            Console.WriteLine();

            do
            {
                Console.WriteLine($"current player: {currentplayer.name}");

                //chose the command 
                int chooseTheStep = -1;
                
                if (currentplayer == computer)
                {
                    chooseTheStep = random.Next(1, 4);
                }
                if (currentplayer == gamer)
                {
                    Console.Write("enter the number of command: ");
                    bool check = int.TryParse(Console.ReadLine(), out chooseTheStep);
                }
                int change = 0;


                switch (chooseTheStep)
                {
                    case 1:
                        change = theOpponent.health - theOpponent.Damage(18, 26);
                        Console.WriteLine($"the small range of damage was chosen and got -{change}");
                        break;
                    case 2:
                        change = theOpponent.health - theOpponent.Damage(10, 36);
                        Console.WriteLine($"the high range of damage was chosen and got -{change}");

                        break;
                    case 3:
                        change = currentplayer.health - currentplayer.AddHealth();
                        Console.WriteLine($"the player decided to add health and got +{-change}");
                        break;
                    default:
                        Console.WriteLine("incorrect  command, try once more");
                        counter ++;
                        if (counter == 5)
                        {
                            Console.WriteLine("Try to start the game once more and read the rules");
                            return;
                        }
                        continue;
                }

                Console.WriteLine(currentplayer.ToString());
                Console.WriteLine(theOpponent.ToString());

                if (currentplayer == gamer)
                {
                    currentplayer = computer;
                    theOpponent = gamer;
                }
                else
                {
                    currentplayer = gamer;
                    theOpponent = computer;
                }
                Console.WriteLine();

                if (computer.health <= 0)
                {
                    Console.WriteLine("player won");
                }
                if (gamer.health <= 0)
                {
                    Console.WriteLine("computer won");
                }


            }
            while (computer.health > 0 && gamer.health > 0);

        }
    }
}
