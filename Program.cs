using System;
using Console = Colorful.Console;
using System.Drawing;

namespace PasswordGenerator
{
    public class MainClass
    {
        private static readonly string chars = "qwertyuiopasdfghjklzxcvbnm";
        private static readonly string numbers = "1234567890";
        private static readonly string specialChars = "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~";

        public static void Main()
        {
            Console.WriteAscii("Password Generator", Color.Tomato);
            int lenght = Convert.ToInt32(input("Set password lenght:"));

            bool allowSpecialChars = false;
            switch(input("Allow special characters [y/n]:"))
            { case "y": allowSpecialChars = true; break; }

            bool randomCharactersSize = false;
            switch(input("Random characters size [y/n]"))
            { case "y": randomCharactersSize = true; break;}

            bool useNumbers = false;
            switch(input("Use numbers [y/n]"))
            { case "y": useNumbers = true; break; }

            string allowedChars = chars;
            if (allowSpecialChars) { allowedChars += specialChars; }
            if (useNumbers) { allowedChars += numbers; }

            string password = string.Empty;
            Random rand = new Random();
            for(int i =0;i < lenght; i++)
            {
                if(randomCharactersSize)
                {
                    char rChar = allowedChars[rand.Next(allowedChars.Length)];
                    if (rand.Next(2) != 1)
                    {
                        password += rChar.ToString().ToUpper();
                    }
                    else
                    {
                        password += rChar;
                    }
                }
            }

            Console.Write("Your Password: ", Color.Snow);
            Console.Write(password, Color.Azure);
            Console.Read();
        }

        private static string input(string prefix)
        {
            Console.Write(prefix, Color.Yellow);
            Console.ForegroundColor = Color.Cyan;
            string leght = Console.ReadLine();
            Console.ResetColor();
            Console.WriteLine();
            return leght;
        }
    }
}
