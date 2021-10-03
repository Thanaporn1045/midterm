using System;

namespace ข้อหนึ่งแฮงค์แมน
{
    class Program
    {
        enum Menu 
        { 
            Playgame = 1,
            Exit
        }  
        static void Main(string[] args)
        {
            ShowMenu();
        }
        static void ShowMenu() 
        {
            Console.WriteLine("Welcome to Hangman Game");
            Console.WriteLine("-----------------------");
            Console.WriteLine("1. Play game");
            Console.WriteLine("2. Exit");
            InputandCheckMenu();

        }
        static void InputandCheckMenu() 
        {
            Console.Write("Please Select Menu : ");
            Menu numMenu = (Menu)int.Parse(Console.ReadLine());
            if(numMenu == Menu.Playgame) { RandomProblem(); }
            else if (numMenu == Menu.Exit) { }
            else { ShowMenuisIncollect(); }
        }
        static void ShowMenuisIncollect() 
        {
            Console.WriteLine("Menu Incorrect Please Try Again");
            InputandCheckMenu();
        }
        static void RandomProblem()
        {
            Random random = new Random();
            string[] Problem = { "Tennis", "Football", "Badminton" };
            int resultRandom = random.Next(Problem.Length);
            set(Problem[resultRandom]);
        }
        static void set(string Problem)
        {
            int IncorrectScore = 0;
            char[] ArrayofProblem;
            char[] ArrayofAns = new char[Problem.Length];
            ArrayofProblem = Problem.ToCharArray();            
            for(int i = 0;i<ArrayofProblem.Length;i++)
            { ArrayofAns [i] = '_'; }
            first(IncorrectScore, ArrayofAns, ArrayofProblem);
        }
        
        static void first(int IncorrectScore, char[] ArrayofAns, char[] ArrayofProblem) 
        {
            Console.Clear();
            Console.WriteLine("Play Game Hangman");
            Console.WriteLine("--------------------");
            Console.WriteLine("Incorrect Score : {0}", IncorrectScore);
            for (int i = 0; i < ArrayofAns.Length; i++)
            { Console.Write(ArrayofAns[i]);
                Console.Write(" ");
            }
            Console.WriteLine("");
            InputAns(IncorrectScore,ArrayofAns,ArrayofProblem);
        }
        static void InputAns(int IncorrectScore,char[] ArrayofAns, char[] ArrayofProblem)
        {
            Console.Write("Input letter alphabet : "); 
            Char Ans = char.Parse(Console.ReadLine());
            Console.Clear();
            word(IncorrectScore,ArrayofAns, ArrayofProblem,Ans);
        }
        
        static void word(int IncorrectScore,char[] ArrayofAns,char[] ArrayofProblem,char Ans)
            {
                int right = 0;
                for(int i=0;i<ArrayofProblem.Length;i++)
                {
                    if (Ans == ArrayofProblem[i]) { ArrayofAns[i] = Ans; right++; }
                    else { }
                }
                if (right == 0) { IncorrectScore = IncorrectScore + 1; Checkend(IncorrectScore, ArrayofAns, ArrayofProblem); }
                else { Checkend(IncorrectScore, ArrayofAns, ArrayofProblem); }
        
        static void Checkend(int IncorrectScore, char[] ArrayofAns, char[] ArrayofProblem)
        {
                int Count=0;
                for(int i = 0;i<ArrayofAns.Length;i ++)
                {
                    if (ArrayofAns[i] == ArrayofProblem[i]) { Count++; }
                    else { }
                }
            
           if (Count == ArrayofProblem.Length) { Console.WriteLine("You win!!"); }
           else if (IncorrectScore == 6) { Console.WriteLine("Game over"); }
            else { first(IncorrectScore,ArrayofAns,ArrayofProblem);}
            }
        }

    }
}
