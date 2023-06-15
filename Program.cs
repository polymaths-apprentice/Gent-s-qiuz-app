using System;
using System.Threading;

class Program
{
    static int score = 0;
    static bool isTimeUp = false;

    static void Main()
    {
          // Ask for user's name
        Console.WriteLine("Welcome to the Quiz!");
        Console.Write("Please enter your name: ");
        string userName = Console.ReadLine();
        Console.WriteLine("Hello, " + userName + "! Welcome to the quiz.\n");

        // Set the countdown timer
        int totalTime = 60; // Total time in seconds
        var timerThread = new Thread(() => CountdownTimer(totalTime));
        timerThread.Start();

        // Quiz questions, options, and answers
        string[] questions = {
            "Who is the biggest Cloud Provider in Cloud Computing field?",
            "Which tool is the most used to orchestrate Containers?",
            "Which Programming Language do DevOps Engineers use the most?"
        };

        string[][] options = {
            new string[] { "a) AWS", "b) Microsoft Azure", "c) Google Cloud Platform", "d) Linode" },
            new string[] { "a) Jenkins", "b) Kubernetes", "c) Terraform", "d) Ansible" },
            new string[] { "a) JavaScript", "b) Java", "c) Python", "d) Ruby" }
        };

        int[] answers = { 0, 1, 2 }; // Index of the correct answer for each question

        // Loop through the questions
        for (int i = 0; i < questions.Length; i++)
        {
            Console.WriteLine(questions[i]);

            // Display the options
            for (int j = 0; j < options[i].Length; j++)
            {
                Console.WriteLine(options[i][j]);
            }
            Console.Write("Enter your answer (a, b, c, d): ");
            string userAnswer = Console.ReadLine();
            // Check if the answer is correct
            if (userAnswer.ToLower() == GetOptionLetter(answers[i]))
            {
                Console.WriteLine("Correct!");
                score += 10; // Increment score by 10 for each correct answer
            }
            else
            {
                Console.WriteLine("Wrong!");
            }

            Console.WriteLine();

            // Check if time is up
            if (isTimeUp == true)
            {
                Console.WriteLine("\nTime expired. Quiz ended.");
                DisplayFinalScore(userName);
                Environment.Exit(0); // Exit the program
            }
        }

        // Display final score
        Console.WriteLine("Quiz completed, " + userName + "!");
        DisplayFinalScore(userName);
    }
    
    static void CountdownTimer(int totalTime)
    {
        Console.WriteLine("You have " + totalTime + " seconds to complete the quiz.\n");

        for (int i = totalTime; i >= 0; i--)
        {
            Console.Write("Time remaining: " + i + " seconds");

            if (i > 0)
            {
                Console.Write("\r"); // Move the cursor back to the beginning of the line
                Thread.Sleep(1000); // Delay for 1 second
            }
            else
            {
                isTimeUp = true;
                return;
            }
        }
    }
     static string GetOptionLetter(int index)
    {
        return ((char)('a' + index)).ToString();
    }

    static void DisplayFinalScore(string userName)
    {
        Console.WriteLine("Your score: " + score + " points");
    }
}
