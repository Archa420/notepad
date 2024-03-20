using System;
using System.IO;

namespace YourNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            // Your code here
            Console.WriteLine("Enter your name:");
            string username = Console.ReadLine();

            Console.WriteLine("Enter the text to save:");
            string text = Console.ReadLine();

            // Save the text to a file
            string filePath = $"saved_files/{username}_file.txt"; // Assuming a directory named "saved_files"
            File.WriteAllText(filePath, text);

            Console.WriteLine("Text saved successfully.");
        }
    }
}
