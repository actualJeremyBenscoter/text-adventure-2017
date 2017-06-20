using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicTextAdventure
{
    class Program
    {
        //Game state
        //We use this to store the current state of the game.
        //This is how we will know how to react to a command the player gives us
        //and how far they have made it in the game.
        static string _gameState = "house";

        static int _hunger = 0;
        static bool _unknownCommand = false;

        static string[] _houseCommands = new string[] { "investigate", "climb" };

        /// <summary>
        /// The Main method is known as the program's entry point. This is where the program
        /// begins executing. This is where the game will begin.
        /// 
        /// We will ignore the Main methods arguments because they will not be needed for
        /// the game.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            while (_gameState != "exit")
            {
                Console.Clear();
                CheckUnknownCommand();
                CheckHunger();
                OutputHunger();
                OutputMessage();
                HandleCommand();
            }
        }

        static void CheckUnknownCommand()
        {
            if(_unknownCommand)
            {
                Console.WriteLine("[UNKNOWN COMMAND]\n");
                _unknownCommand = false;
            }
        }

        static void OutputHunger()
        {
            Console.WriteLine("[Hunger: " + _hunger + "]\n");
        }

        static void CheckHunger()
        {
            if (_gameState == "wait_monster")
            {
                _hunger += 2;
            }
            else if(_gameState == "run_table")
            {
                _hunger += 1;
            }
            else if (_gameState == "eat_debris")
            {
                _hunger += 1;
            }
            else if (_gameState == "in")
            {
                _hunger += 3;
            }

            if (_hunger > 10)
            {
                _gameState = "starved";
            }
        }

        static void OutputMessage()
        {
            switch (_gameState)
            {
                case "house":
                    Console.WriteLine("You are in a dark enclosed space. There are soft fuzzies under you along with some sawdust and bits of paper. It's comfortable, but you are hungry. You see light ahead and feel a breeze coming from above.\n\nWhat would you like to do? [INVESTIGATE the light or CLIMB towards the breeze?]");
                    break;
                case "investigate":
                    Console.WriteLine("You go towards the light. There is noise outside. You peek out and see humans eating. You've made it to the table before, stealing leftover bits of pastries. You remember how delicious that was. This smells different, Your stomach rumbles faintly.\n[Would you like to WAIT, RUN under the table, or go BACK?]");
                    break;
                case "climb":
                    Console.WriteLine("You climb up the wood, skipping over pipes as you go. When you get to the top, the breeze is stronger. Light is streaming through a vent.\n\n[Would you like to PEEK or go BACK?]");
                    break;
                case "wait_monster":
                    Console.WriteLine("[+2 Hunger]\n\nYou saw the humans leave the table, but the monster that lives in the house came and ate all the debris that the smallest humans dropped.Filthy loud barking creature.It gets food every morning and night!That reminds you! [Would you like to CHECK under the table to see if he missed anything, go look at his food BOWL, or go BACK to your hole?]");
                    break;
                case "run_table":
                    Console.WriteLine("[+1 Hunger]\n\nYou make it to the table and snatch a piece of broccoli that had been dropped by the smallest human. Then you heard the nails of the monster hitting the floor. Why do the humans let that beast live with them!? [Will you ESCAPE to your hole with the broccoli or try to HIDE under the stove?]");
                    break;
                case "peek":
                    Console.WriteLine("You peak out of the window. As you squeeze through to get a better look, you push yourself too hard and go tumbling out! As you tumble head over tail, you wonder what kind of food you expected to find out there.\n\nLuckily, you fell into a pile of leaves.");
                    Console.WriteLine("Sniffing the air, you wonder if life would be better out here. A loud bird cry is heard. \n\n[Should you try living OUTSIDE or go back IN?]");
                    break;
                case "check":
                    Console.WriteLine("You go out and sniff around for any leftovers. That's when you hear a scream. One of the humans must have spotted you! You didn't find any food and you lost track of where your escape is.\n\n[Should you run TOWARDS the scream or AWAY from the scream?]");
                    break;
                case "bowl":
                    Console.WriteLine("You scurry around to the offering space. Here, the humans pay tribute to the monster so it does not eat them in their sleep. You see the bits of crunchy food that has overflowed from the alter and has gotten lost in the crack behind the bowl. You grab a piece and eat a bit. It's not the most delicious thing, but it's good!\n\n[Should you attempt to take a piece BACK to your hole or EAT your fill here?]");
                    break;
                case "escape":
                    Console.WriteLine("As you run towards your house, the monster gives chase. You are almost to the safety of your hole! Then you hit an invisible barrier! You run into it 7 times to make sure you aren't crazy. Now you're dizzy. There is something touching your feet! It's moving!\"I'm just going to put it outside,\" said a human voice. \"There's no reason to kill it!\" Another human responds, but you remember that you can't speak English. You panic, but then you feel leaves under your feet. You run again and this time you don't hit a barrier. Unfortunately, you are now outside.Chances are, you will survive a week at the most. But hey! At least you have Broccoli!");
                    Console.WriteLine("Sniffing the air, you wonder if life would be better out here. A loud bird cry is heard. \n\n[Should you try living OUTSIDE or go back IN?]");
                    break;
                case "hide":
                    Console.WriteLine("You run underneath the stove. There are bits of old food here, mostly dry and unappetizing. You somehow dropped the broccoli as you ran. Drat.\n\n[Will you attempt to EAT some of the debris or just WAIT for everything to calm down?]");
                    break;
                case "towards":
                    Console.WriteLine("You don't know why you chose to run past the human, but you made it under the giant couch in the living room. Holy mother of Mickey! There is popcorn everywhere! The human was still making a raucous out from under the couch, but the noise was erratic. The dog was barking near the door to the yard, and you are in awe of the banquet set before you.\n\nAs you chomp down on popcorn you wonder if you should \n\n[spend the night HERE, or TAKE a piece of popcorn home after eating a bit.]");
                    break;
                case "away":
                    Console.WriteLine("You run away scurrying as fast as your tiny legs can carry you. You know where you are. This is  where all the best things are found They call this the land of Pantry! Unfortunately, you remember your friend Billy and your cousin Phyllis. Both were explorers who came to see what they could find. You haven't heard from either of them since they left.\n\n[Do you want to GO in farther or WAIT for the human to go away?]");
                    break;
                case "back":
                    Console.WriteLine("Sitting in your soft home with the food makes you glad you live where you do. Yes, it's not always easy, but it could be worse.\n\nNibbling on the treat you wonder when your friend from the garden is going to come visit.\n\nYou hear the tiniest human moving around outside in the kitchen.A piece of broccoli appears by your hole.\n\nGrabbing it, you pull it inside for later.\n\nYou fall asleep in your warm nest.You dream of breakfast.");
                    break;
                case "eat_debris":
                    Console.WriteLine("[+1 Hunger] You eat the debris. It tastes awful. It's crunchy. You spit it out, but it hurt your mouth. You feel hungrier, somehow.");
                    break;
                case "outside":
                    Console.WriteLine("Sorry. You have not purchased the OUTSIDE DLC. Enter Key now.");
                    break;
                case "here":
                    Console.WriteLine("You wake up from a nightmare. You are surrounded by popcorn bits. There is so much more to eat. It's everywhere. There's no way you could eat in all.\n\nYou try to calm yourself down, but that's when you hear the meow.\n\nTHE LEADER OF THE HOME IS NEAR!\n\nYour eyes go wide and you see a claw reaching towards you!");
                    break;
                case "go":
                    Console.WriteLine("You smell glorious peanut butter!");
                    Console.WriteLine();
                    Console.WriteLine("Without thinking you run directly for it!You hear a click behind you, but you ignore it, eating the peanut butter immediately.");
                    Console.WriteLine();
                    Console.WriteLine("You hear the monster barking outside of the land of pantry.");
                    Console.WriteLine();
                    Console.WriteLine("You try to run away, but you are trapped in some kind of clear box!");
                    Console.WriteLine();
                    Console.WriteLine("Oh no!");
                    Console.WriteLine();
                    Console.WriteLine("The human is opening the door!");
                    Console.WriteLine();
                    Console.WriteLine("\"You keep putting them outside, and they keep coming back!\" A human voice said.");
                    Console.WriteLine();
                    Console.WriteLine("You didn't know you could speak human!!");
                    Console.WriteLine();
                    Console.WriteLine("You feel yourself being lifted up. You look at the terrifying face of the human.She is moving but you just keep running around trying to escape. Finally, you collapse into the pile of peanut butter, exhausted.");
                    Console.WriteLine();
                    Console.WriteLine("The human drops you into something green.You are still to scared to move.");
                    Console.WriteLine();
                    Console.WriteLine("As time passes, you take the most delicious bath of your life.");
                    Console.WriteLine();
                    Console.WriteLine("Sniffing the air, you wonder if life would be better out here. A loud bird cry is heard. \n\n[Should you try living OUTSIDE or go back IN?]");
                    break;
                case "wait_human":
                    Console.WriteLine("The more you think about it, the more terrified you become. You smell all the delicious things, but can't help but wonder what terrors hide here. Looking down, you see some dried bananas. you drag a piece under a bag and hide from the human who opens the door and then shuts it after looking around a while and telling the monster it's a \"silly dog.\" You aren't hungry anymore, but you still have a banana piece!\n\n[Will you go FARTHER into the land of Pantry or go BACK home with your banana?]");
                    break;
                case "eat_fill":
                    Console.WriteLine("You eat so much food you can barely move!\n\nThen you hear the worst of noises!It's worse than the barking monster!\n\nYou try to calm yourself down, but that's when you hear the cry of the catsome fiend.\n\nTHE LEADER OF THE HOME IS NEAR!\n\nYour eyes go wide and you see a claw reaching towards you!");
                    break;
                case "run_why":
                    Console.WriteLine("All you can think is why?!?!?!\n\nWhat was I thinking ?!\n\nThat crispy disgusting food must have rotted my brain!");
                    break;
                case "part2":
                    Console.WriteLine("Thank you for playing The Land of Pantry. If you would like to play the sequel, Escape the Fuzziest of Terrors!, please visit our website at www.giveusallyourmoneyforthesetinygames.com.\n\nWe hope you had fun!");
                    break;
                case "in":
                    Console.WriteLine("[+3 Hunger] Your attempts are failures. You cannot get back inside.");
                    Console.WriteLine("Sniffing the air, you wonder if life would be better out here. A loud bird cry is heard. \n\n[Should you try living OUTSIDE or go back IN?]");
                    break;
                case "starved":
                    Console.WriteLine("You are overcome with hunger and cannot continue. [Would you like to RESTART or QUIT?]");
                    break;
            }
        }

        /// <summary>
        /// This method handles input from the player and then routes it the 
        /// appropriate "handler method" based on the current state of the game.
        /// 
        /// We route to each "handler method" using if statements, which allow us
        /// to compare the game state to different values for routing.
        /// </summary>
        static void HandleCommand()
        {
            string command = Console.ReadLine().ToLower();

            //check state and process
            if (_gameState == "house")
            {
                HandleHouseCommand(command);
            }
            else if (_gameState == "investigate")
            {
                HandleInvestigateCommand(command);
            }
        }

        static void HandleHouseCommand(string command)
        {
            if (_houseCommands.Contains(command))
            {
                _gameState = command;
            }
            else
            {
                _unknownCommand = true;
            }
        }

        static void HandleInvestigateCommand(string command)
        {
            if(command == "run")
            {
                _gameState = "run_table";
            }
            else if (command == "wait")
            {
                _gameState = "wait_monster";
            }
            else if (command == "back")
            {
                _gameState = "house";
            }
            else
            {
                _unknownCommand = true;
            }
        }

        static void HandleClimbCommand(string command)
        {
            if (command == "wait")
            {
                _gameState = "wait_monster";
            }
            else if (command == "back")
            {
                _gameState = "house";
            }
            else
            {
                _unknownCommand = true;
            }
        }

        static void HandleWaitMonsterCommand(string command)
        {
            if(command == "check")
            {
                _gameState = "check";
            }
            else if(command == "bowl")
            {
                _gameState = "bowl";
            }
            else if (command == "back")
            {
                _gameState = "house";
            }
            else
            {
                _unknownCommand = true;
            }
        }

        static void HandleRunTableCommand(string command)
        {
            if (command == "escape")
            {
                _gameState = "escape";
            }
            else if (command == "hide")
            {
                _gameState = "hide";
            }
            else
            {
                _unknownCommand = true;
            }
        }

        static void HandlePeekCommand(string command)
        {
            if (command == "outside")
            {
                _gameState = "outside";
            }
            else if (command == "in")
            {
                //do nothing
            }
            else
            {
                _unknownCommand = true;
            }
        }
    }
}
