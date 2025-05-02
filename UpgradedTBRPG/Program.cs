// See https://aka.ms/new-console-template for more information
/*player stats*/
double[] playerStats = { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 }; /* Every stat will be added later.*/
bool playerLife = true;

List<string> statLabels = new List<string> { "HP", "DMG", "HC", "BC", "EC", "CC" };

/*warrior stats */

Dictionary<string, double> WarriorStats = new Dictionary<string, double>();

WarriorStats["HP"] = 120;
WarriorStats["DMG"] = 25;
WarriorStats["HC"] = 0.8;
WarriorStats["BC"] = 0.25;
WarriorStats["EC"] = 0.01;
WarriorStats["CC"] = 0.1;
List<string> Wkeys = WarriorStats.Keys.ToList();

/*mage stats */
Dictionary<string, double> MageStats = new Dictionary<string, double>();

MageStats["HP"] = 80;
MageStats["DMG"] = 30;
MageStats["HC"] = 0.7;
MageStats["BC"] = 0.01;
MageStats["EC"] = 0.05;
MageStats["CC"] = 0.05;
List<string> Mkeys = MageStats.Keys.ToList();

/*Rogue stats */
Dictionary<string, double> RogueStats = new Dictionary<string, double>();

RogueStats["HP"] = 100;
RogueStats["DMG"] = 20;
RogueStats["HC"] = 0.85;
RogueStats["BC"] = 0.05;
RogueStats["EC"] = 0.1;
RogueStats["CC"] = 0.20;
List<string> Rkeys = RogueStats.Keys.ToList();



/*goblin*/
double[] goblinStats = { 50, 10, 0.65, 0.1, 0.1, 0.05};

/*Chief Goblin */

double[] chiefGoblinStats = { 100, 15, 0.75, 0.2, 0.05, 0.1 };

/*bandit */
double[] banditStats = { 80, 12, 0.75, 0.15, 0.1, 0.1 };

/* wolf */
double[] wolfStats = { 65, 12, 0.7, 0.1, 0.1, 0.15 };

Random rnd = new Random();
string startingParameter = "";



 void EnemyEncounter(string enemyName, double [] enemyStats, string enemyAttackSound) {
    while (enemyStats[0] > 0 && playerStats[0] > 0)
    {

        Console.WriteLine(enemyName);
        Console.WriteLine(statLabels[0] + ": " + enemyStats[0]);

        Console.WriteLine("You");
        Console.WriteLine(statLabels[0] + ": " + playerStats[0]);
        string inputParameter = Console.ReadLine().ToLower();

        if (inputParameter == "a")
        {
            Console.WriteLine("Aaaaargh!");
            int attackRoll = rnd.Next(1, 101);
            if (attackRoll < 100 - playerStats[2] * 100)
            {
                Console.WriteLine("You missed");
            }
            else
            {

                int enemyEvasionRoll = rnd.Next(1, 101);
                if (enemyEvasionRoll >= 100 - enemyStats[3] * 100)
                {
                    Console.WriteLine(enemyName + " dodged your attack");
                }
                else
                {
                    int enemyBlockRoll = rnd.Next(1, 101);
                    if (enemyBlockRoll >= 100 - enemyStats[3] * 100)
                    {
                        Console.WriteLine(enemyName + " blocked your attack");
                    }
                    else
                    {
                        int critRoll = rnd.Next(1, 101);
                        if (critRoll >= 100 - playerStats[5] * 100)
                        {
                            Console.WriteLine("You dealt a critical hit! " + playerStats[1] * 1.5 + " damage to " + enemyName + " !");
                            enemyStats[0] = enemyStats[0] - playerStats[1] * 1.5;
                            if (enemyStats[0] <= 0)
                            {
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("You dealt " + playerStats[1] + " damage");
                            enemyStats[0] = enemyStats[0] - playerStats[1];
                            if (enemyStats[0] <= 0)
                            {
                                break;
                            }
                        }

                    }


                }
            }

            //Console.WriteLine("Goblin HP: " + goblinStats[0]);
        }
        else if (inputParameter == "h") {
            Console.WriteLine("Bzzzt!");
            int healRoll = rnd.Next(1, 11);
            playerStats[0] = playerStats[0] + healRoll;
            Console.WriteLine("You healed yourself " + healRoll);
        }
        else
        {
            Console.WriteLine("Please enter a valid input.");
            continue;
        }
        Console.WriteLine(enemyAttackSound);
        int enemyAttackroll = rnd.Next(1, 101);
        if (enemyAttackroll >= 100 - enemyStats[2] * 100)
        {
            int playerEvasionRoll = rnd.Next(1, 101);
            if (playerEvasionRoll >= 100 - playerStats[4] * 100)
            {
                Console.WriteLine("You dodged enemy's attack");
            }
            else
            {
                int playerBlockRoll = rnd.Next(1, 101);
                if (playerBlockRoll >= 100 - playerStats[3] * 100)
                {
                    Console.WriteLine("You blocked enemy's attack");
                }
                else
                {
                    int enemyCritRoll = rnd.Next(1, 101);
                    if (enemyCritRoll >= 100 - enemyStats[5] * 100)
                    {
                        Console.WriteLine("Enemy dealt a critical hit ! " + enemyStats[1] * 1.5 + " damage to you");
                        playerStats[0] = playerStats[0] - enemyStats[1] * 1.5;

                    }
                    else
                    {
                        Console.WriteLine("Enemy dealt " + enemyStats[1] + " damage to you");
                        playerStats[0] = playerStats[0] - enemyStats[1];
                    }

                    //Console.WriteLine("Goblin: \n" + goblinStats[0]);
                    //Console.WriteLine("You: \n " + playerStats[0]); 

                }
            }
        }
        else
        {
            Console.WriteLine("Enemy missed his attack");
        }


    }
    if (enemyStats[0] <= 0)
    {
        Console.WriteLine("You killed the " + enemyName);
    }
    else if (playerStats[0] <= 0)
    {
        Console.WriteLine("You Died");
        playerLife = false;
    }

    else
{
    Console.WriteLine("Please enter a valid input.");
}
}

while (playerLife)
{
    /*Landing Masage*/
    Console.WriteLine("Welcome traveler! Welcome to the land of adventures! You may choose between Warrior, Mage or Rogue as your class. To see their stats enter i. To start the adventure enter s.");

    startingParameter = Console.ReadLine().ToLower();
    if (startingParameter == "i")
    {


        int a = 0;
        Console.WriteLine("Warrior Stats ");
        while (a <= 5)
        {
            Console.WriteLine(Wkeys[a] + ": " + WarriorStats[Wkeys[a]]);
            a++;
        }

        int b = 0;
        Console.WriteLine("Mage Stats ");
        while (b <= 5)
        {
            Console.WriteLine(Mkeys[b] + ": " + MageStats[Mkeys[b]]);
            b++;
        }

        int c = 0;
        Console.WriteLine("Rogue Stats ");
        while (c <= 5)
        {
            Console.WriteLine(Rkeys[c] + ": " + RogueStats[Rkeys[c]]);
            c++;
        }

    }
    else if (startingParameter == "s")
    {

        Console.WriteLine("To choose your class enter the first letter of your desired class.");
        while (true)
        {
            string classParameter = Console.ReadLine();

            if (classParameter == "w")
            {
                int i = 0;
                while (i <= 5)
                {
                    playerStats[i] = WarriorStats[Wkeys[i]];
                    i++;
                }
                break;
            }
            else if (classParameter == "m")
            {

                int i = 0;
                while (i <= 5)
                {
                    playerStats[i] = MageStats[Mkeys[i]];
                    i++;
                }
                break;
            }
            else if (classParameter == "r")
            {

                int i = 0;
                while (i <= 5)
                {
                    playerStats[i] = RogueStats[Rkeys[i]];
                    i++;
                }
                break;
            }
            else
            {
                Console.WriteLine("Please enter w, m or r to choose a class");

                continue;
            }

        }

        Console.WriteLine("Act I: Dark Woods");
        Console.WriteLine("As you travel amidst the dark woods of Creania you came across with a stranded goblin. It sensed your presence. Get ready to fight.");

        Console.WriteLine("Enter a to attack, enter h to heal.");

        EnemyEncounter("Goblin",goblinStats, "Ssskkreee!");

        Console.WriteLine("Congratulation for your victory traveller. Be humble it was only a goblin. You will face grave danger in your path. But for now only thing between you and your destiny is a raging wolf from the upfront hill. Get to your weapons!");
        
        EnemyEncounter("Wolf", wolfStats, "Grrrrr...");

        Console.WriteLine("As i see not only goblin but a mere wolf to is not a opponent for your might traveller. Now you face a real danger. Be ready!");

        EnemyEncounter("Chief Goblin", chiefGoblinStats, "Graakk!");

        Console.WriteLine("END OF ACT I");

        Console.WriteLine("Act II: Road to Creania");
        
        Console.WriteLine("You found yourself at a crossroads near Creania. Crossroads that are oddly silent. Remember traveller every storm comes with it's own silence. As for your storm, it is a highly equipped bandit. Stand your ground!");
        EnemyEncounter("Bandit", banditStats, "I will lick yee blood from yee coin!");

    }
}