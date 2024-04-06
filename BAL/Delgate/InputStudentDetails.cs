namespace StudentManagementSystem.BAL.Delegate
{
    public class InputStudent
    {


        public static void PrintWelcomeMessage()
        {
            // Changing console text color to cyan
            Console.ForegroundColor = ConsoleColor.Cyan;

            // Printing with animation
            string message = "----------------Welcome to the Student Management System-------------";
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(50); // Adding delay for animation effect
            }

            // Resetting console text color
            Console.ResetColor();
            Console.WriteLine(); // Moving cursor to the next line
        }
         public static void Choice()
        { 
           Console.ForegroundColor = ConsoleColor.Cyan;

            // Printing with animation
            string message = "Enter your Choice";
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(50); // Adding delay for animation effect
            }

            // Resetting console text color
            Console.ResetColor();
            Console.WriteLine(); // Moving cursor to the next line
        }
        
         public static void Exit()
        { 
           Console.ForegroundColor = ConsoleColor.Cyan;

            // Printing with animation
            string message = "Exit........";
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(50); // Adding delay for animation effect
            }

            // Resetting console text color
            Console.ResetColor();
            Console.WriteLine(); // Moving cursor to the next line
        }

    }
}