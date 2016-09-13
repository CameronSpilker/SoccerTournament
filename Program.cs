/*Draw a class diagram that represents a Soccer Tournament. 
 * You will need a Team parent class, a child soccer class, and a game class. 
 * Write a program that prompts the user to enter in the number of teams competing in an olympic soccer tournament. 
 * Then for the number of teams entered, prompt the user to enter the name of the team and the number of points the team has scored. 
 * Finally, display the results of the tournament. 
 * Make sure your console output matches the sample screenshot in the requirements below exactly.
 * 
 * Console output matches sample output completely (see screenshot below)
 First letter of each teams's name is capitalized
 Program uses a List object to store the list of teams
 Teams are sorted by the team's points in descending order
 Result table has column headers and separators for Position, Name, and Points
 Result table displays each team's position, name, and points
 Properly implements Team and SoccerTeam classes but you do NOT need to implement the Game class
 Use exception handling to make sure that the number of teams they enter is a valid integer (try/catch within a while loop).
 Adds comments to make code easier to understand
 Upload the project here and also upload the zipped project to the Learning Suite assignment (include the class diagram in your upload in the main root directory for your project so TAs can easily find it) and then schedule a time with the TAs for them to grade this assignment
 * Author: Cameron Spilker
 * Section: 2
 * Group: 11
 * Date: 9/13/2016
 * */





using System;
using System.Collections.Generic;
using System.Linq;


namespace ConsoleApplication1
{
    class Program
    {
        //This is my Team class with attributes 
        public class Team
        {
            public string teamName;
            public int wins;
            public int loss;

        }
        //This is my SoccerTeam class which is the child of Team, with its own attributes
        public class SoccerTeam : Team
        {
            public int draw;
            public int goalsFor;
            public int goalsAgainst;
            public int differential;
            public int points;
            public Game SoccerGame;


            //Consturctor that gets the team name and points
            public SoccerTeam(String sName, int iPoints)
            {
                this.teamName = sName;
                this.points = iPoints;
            }
        }
        //This is the game class which keeps track of the goals for each team
        public class Game 
        {
            public int goalsFor;
            public int goalsAgainst;

            public Game(int iGoalsFor, int iGoalsAgainst)
            {
                this.goalsFor = iGoalsFor;
                this.goalsAgainst = iGoalsAgainst;
            }

        }
        //this capitalizes the first letter of each team name
        static string UppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            return char.ToUpper(s[0]) + s.Substring(1);
        }

        static void Main(string[] args)
        {

            //These are my variables 
            bool bteamNumber = false;
            int iTeam = 1;
            string teamName = "aaaaaaaaaa";
            int points = 0;
            int iCounter = 1;



            //GATHER HOW MANY TEAMS, it will not allow letters or 0 

            while (!bteamNumber || iTeam == 0)
            {
                try
                    {   Console.WriteLine("How many teams?");
                        iTeam = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                        bteamNumber = true;

                        if (iTeam == 0)
                        {
                            Console.WriteLine("Enter a number more than 0.\n");
                        }
                       


                   
                    


                    //THIS MAKES SURE THE USER INPUTS A NUMBER
                }
                catch (Exception)
                {
                    Console.WriteLine();
                    Console.WriteLine("You must enter a number.");
                    Console.WriteLine();
                }

            }

            List<SoccerTeam> lSoccerTeam = new List<SoccerTeam>();


            bool bteamName = false;

            //THIS LOOP WILL GATHER TEAM NAMES AND POINTS
            for (int iCount = 1; iCount <= iTeam; iCount++)
            {


                while (!bteamName)
                {
                    Console.WriteLine("Enter Team " + iCount + "'s name:");
                    string userInput = Console.ReadLine();
                    Console.WriteLine();
                    teamName = UppercaseFirst(userInput);

                    if (teamName.Length < 11)
                       {
                            bteamName = true;
                       }
                        else
                        {
                            Console.WriteLine("Shorten the team name.\n");
                        }
                }

                bteamName = false;

                bool bteamPoints = false;

                //THIS WILL MAKE SURE THAT THE USER INPUTS A INT FOR POINTS
                while (!bteamPoints)
                {
                    try
                    {
                        Console.WriteLine("Enter " + teamName + "'s points:");
                        points = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                        bteamPoints = true;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine();
                        Console.WriteLine("You must enter a number.");
                        Console.WriteLine();
                    }

                }
                //GATHERS THE TEAMS INFORMATION AND CREATES A LIST
                SoccerTeam oTeam = new SoccerTeam(teamName, points);
                lSoccerTeam.Add(oTeam);

            }

            string dash = string.Empty;

            //THIS IS ALL FOR THE OUTPUT DISPLAY
            Console.WriteLine("Here is the sorted list:");
            Console.WriteLine();

            Console.Write("Position\t\t");
            Console.Write("Team Name\t\t\t\t");
            Console.WriteLine("Points");

            Console.Write(dash.PadRight(8, '-') + "\t\t");

            Console.Write(dash.PadRight(9, '-') + "\t\t\t\t");
            Console.WriteLine(dash.PadRight(6, '-'));

            //SORTS THE LIST IN DESCENDING ORDER
            List<SoccerTeam> sortedSoccerTeam = lSoccerTeam.OrderByDescending(lsTeam => lsTeam.points).ToList();


            //LOOP THAT OUTPUTS THE TEAMS INFORMATION
            foreach (SoccerTeam item in sortedSoccerTeam)
            {

                if (iCounter == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    
                }
                if(iCounter == 2)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    
                }
                if(iCounter == 3)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    
                }

                if (item.teamName.Length > 7)
                {
                     
                     Console.WriteLine(iCounter + "\t\t\t" + item.teamName + "\t\t\t\t" + item.points);
                }
                else
                {
                    Console.WriteLine(iCounter + "\t\t\t" + item.teamName + "\t\t\t\t\t" + item.points);
                }
                iCounter++;
            }
            Console.Read();

        }
    }
}

