using System;
using System.Collections.Generic;
using System.IO;

class User {
    public string Username { get; set; }
    public string Password { get; set; }
}

class Program {
    static List<User> users = new List<User>();

    static void Main(string[] args) {
        while (true) {
            Console.WriteLine("1. Register User");
            Console.WriteLine("2. Remove User");
            Console.WriteLine("3. Analyze Text in Notepad");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice) {
                case "1":
                    RegisterUser();
                    break;
                case "2":
                    RemoveUser();
                    break;
                case "3":
                    AnalyzeText();
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void RegisterUser() {
        Console.Write("Enter username: ");
        string username = Console.ReadLine();
        Console.Write("Enter password: ");
        string password = Console.ReadLine();

        users.Add(new User { Username = username, Password = password });

        Console.WriteLine("User registered successfully.");
    }

    static void RemoveUser() {
        Console.Write("Enter username to remove: ");
        string username = Console.ReadLine();

        User userToRemove = users.Find(u => u.Username == username);
        if (userToRemove != null) {
            users.Remove(userToRemove);
            Console.WriteLine("User removed successfully.");
        } else {
            Console.WriteLine("User not found.");
        }
    }

    static void AnalyzeText() {
        Console.WriteLine("Enter text in notepad:");
        string text = Console.ReadLine();

        int letterCount = 0;
        int numberCount = 0;
        int commaCount = 0;
        int dotCount = 0;

        foreach (char c in text) {
            if (char.IsLetter(c)) {
                letterCount++;
            } else if (char.IsDigit(c)) {
                numberCount++;
            } else if (c == ',') {
                commaCount++;
            } else if (c == '.') {
                dotCount++;
            }
        }

        Console.WriteLine($"Letter Count: {letterCount}");
        Console.WriteLine($"Number Count: {numberCount}");
        Console.WriteLine($"Comma Count: {commaCount}");
        Console.WriteLine($"Dot Count: {dotCount}");
    }
}
