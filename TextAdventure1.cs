using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolBox
{
    class TextAdventure1
    {
        //This is the main function that is called in order to run the application
        public static void Main123()
        {
            bool running = true;
            string input;
            int roomNumber = 1;

            //create an instance of the Datastore
            var datstr = new DataStore();
            // this is the shorthand way of assigning the internal variable at creation time 
            var r = new Room() { ds = datstr };

            Console.WriteLine(datstr.welcome);
            while (running) {
                while (roomNumber < datstr.maxNumberOfRooms)
                {
                    // assign the number of the room to the room object after it is created
                    r.roomNumber = roomNumber;
                    Console.WriteLine($"You are in room #{r.roomNumber}");
                    input = Console.ReadLine();
                    if (input.ToLower().Equals("quit")) { goto End; } // gotos are bad practice but this is for readability
                    if (input.ToLower().Equals("verbs")) { Console.WriteLine(r.getVerbs()); }
                    if (input.ToLower().Equals("nouns")) { Console.WriteLine(r.getNouns()); }
                    Console.WriteLine(r.Interact(input));
                    if (r.exitRoom(input.ToLower())){ roomNumber++; }
                }
                running = false; 
            }

        Console.WriteLine("You did it you !!! You Escaped !!! ");
        //Labels are generally considered bad practice but for readability they will be used here 
        End:
            Console.WriteLine("Good Bye -- Thanks for playing");
        }
    }

    public class Room
    {
        public int roomNumber { set; get; }
        public DataStore ds { set; get; }

        public string getVerbs()
        {
            string result = "";
            //fancy concatination 
            string key = $"room{roomNumber}_verbs";
            ds.verbsAndNouns.TryGetValue(key, out result);
            return result ?? "Please enter a valid command.";
        }

        public string getNouns() {
            string result = "";

            string key = $"room{roomNumber}_nouns";
            ds.verbsAndNouns.TryGetValue(key, out result);
            return result ?? "Please enter a valid command.";
        }

        public string Interact(string userInput)
        {
            string result = "";
            //fast return if the user if just checking the lists
            if ((userInput == "verbs") || (userInput == "nouns")) return "";
            string key = $"room{roomNumber}_{ userInput.ToLower().Replace(" ", "_")}";
            ds.interaction.TryGetValue(key, out result);
            return result ?? "Please enter a valid command.";
        }
        public bool exitRoom(string userInput)
        {
            //fancy concatination in C# 
            string key = $"room{roomNumber}_{ userInput.ToLower().Replace(" ", "_")}_exit";
            return ds.interaction.ContainsKey(key);

        }

    }

    //Ideally this would be in a different file DataStore.cs .
    public class DataStore
    {
        
        public string welcome { get; }
        public int maxNumberOfRooms { get; }
        public Dictionary<string, string> verbsAndNouns { set; get; } 
        public Dictionary<string, string> interaction { set; get; }

        //This is a constructor it lets you setup and populate your class variables. There are shorcuts around it now in alot of languages
        public DataStore()
        {
            //@"" is for string literals so that new lines are special characters are kept
            welcome = @" ----------------------------------------------------------------------------
 --------------------------- Welcome to Text Adventure ----------------------
 ----------------------------------------------------------------------------
- Quit the game with the [QUIT] command -

 You have woken up in a strange room use VERBS and NOUNS in order to escape.
 In order to see the list of VERBS type verbs {enter} 
 In order to see the list of NOUNS type nouns {enter} 
 e.g. check door 
 Have fun!!";
            maxNumberOfRooms = 3; 
            verbsAndNouns = new Dictionary<string, string>()
                {
                    { "room1_verbs","check, flick, hit" }
                   ,{ "room1_nouns","door, window, vent, switch" }

                   ,{ "room2_verbs","check, grab, lift" }
                   ,{ "room2_nouns","box, rope, toy, key" }

            };


            interaction = new Dictionary<string, string>()
                {
                     { "room1_check_door" ,"It's not going to be that easy. The door is locked"}
                    ,{ "room1_check_window" ,"It's nailed shut."}
                    ,{ "room1_check_vent" ,"The vent cover is barely holding on, maybe if I hit it..."}
                    ,{ "room1_check_switch" ,"Hmmm ...  it looks like an old light switch"}

                    ,{ "room1_flick_door" ,"The door lets out a dull metallic ring, and you finger hurts."}
                    ,{ "room1_flick_window" ,"The glass doesn't break."}
                    ,{ "room1_flick_vent" ,"Ouch."}
                    ,{ "room1_flick_switch" ,"Nothing happens, good thing it is day time."}

                    ,{ "room1_hit_door" ,"You ram your shoulder into the metal door. Nothing happens."}
                    ,{ "room1_hit_window" ,"You punch the window. It doesn't break."}
                    ,{ "room1_hit_vent" ,"The vent cover falls off and you see a path to another room."}
                    ,{ "room1_hit_switch" ,"You hit the swith. Nothing.... Maybe if you flick it?"}

                    ,{ "room1_hit_vent_exit" ,""}

                    ,{ "room2_check_box" ,"Huh, it's just a box"}
                    ,{ "room2_check_rope" ,"The rope leads to a hole in the ceiling"}
                    ,{ "room2_check_toy" ,"An old doll that looks creepy. Well most dolls are creepy."}
                    ,{ "room2_check_key" ,"A brass key."}

                    ,{ "room2_grab_box" ,"You got to lift the box up but stop as you hear the sound of something sleeping inside it."}
                    ,{ "room2_grab_rope" ,"This is gym class all over again. As you climb the rope the darkness gives way to fresh air and sunlight. You are free!"}
                    ,{ "room2_grab_toy" ,"You grab the doll and it falls apart in your hands. You carefully put in back together and rest it back on the ground."}
                    ,{ "room2_grab_key" ,"The key is cold and attached to the ground by a string."}

                    ,{ "room2_lift_box" ,"You got to lift the box up but stop as you hear the sound of something sleeping inside it."}
                    ,{ "room2_lift_rope" ,"You tug on the end of the rope. It should be able to support your weight."}
                    ,{ "room2_lift_toy" ,"The doll looks even creepier up close. Did its eyes just move? You put it down."}
                    ,{ "room2_lift_key" ,"The key is attached to the ground by a string. You lift the key up to see what the string is attached to. It looks like a grenage pin. you put the key down."}

                    ,{ "room2_grab_rope_exit" ,""}

                };
        }
    }
}
