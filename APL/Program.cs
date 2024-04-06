using System;
namespace StudentManagementSystem;
using StudentManagementSystem.BAL.Delegate;
public class Program
{
  
        public delegate void Print();

        static void Main(string[] args)
        {
            PrintWelcomeMessage();
             
            ChoiceMenu.PrintChoices();
        }

        static void PrintWelcomeMessage()
        {
            Print printWelcomeDelegate = new Print(InputStudent.PrintWelcomeMessage);
            printWelcomeDelegate();
             Print printChoice = new Print(InputStudent.Choice);
             printChoice();
        }

        
    }

    

    

