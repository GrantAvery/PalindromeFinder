using System;
using System.Text;
using System.Text.RegularExpressions;

namespace PalindromeFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;

            // Uses args if they exist, but if not it has a more verbose option to ask for input
            if (args != null && args.Length > 0 && args[0] != null)
            {
                Console.WriteLine(isPalindrome(args[0]));
            }
            else
            {
                Console.WriteLine("Welcome! Please enter text and then hit Enter. " +
                    "I will tell you whether the text is a palindrome.");
                input = Console.ReadLine();

                bool response = isPalindrome(input);

                if (response)
                {
                    Console.WriteLine($"\"{input}\" is a palindrome!");

                }
                else
                {
                    Console.WriteLine($"\"{input}\" is not a palindrome!");
                }
            }
        }

        public static bool isPalindrome(string input)
        {
            // Regex explanation:
            // ^ is equivalent to "not" when inside the []
            // \p{L} finds all unicode letters according to Regex, but nothing else
            // + checks all characters in the string, not just the first
            // In all, it finds all non-letters and removes them
            string validInput = Regex.Replace(input, @"[^\p{L}]+", "").ToLower();

            for (int j = 0; j < (validInput.Length / 2); j++)
            {
                if (validInput[j] == validInput[validInput.Length - j - 1])
                {
                    // The letters on each side match, so far so good
                }
                else
                {
                    // Not a palindrome
                    return false;
                }
            }

            // If we've gotten here, all the opposite letters match, aka it is a palindrome
            return true;
        }
    }
}
