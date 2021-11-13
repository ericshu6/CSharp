﻿using System.Diagnostics;

Random random = new();
Stopwatch stopwatch = new();
Console.Clear();
Console.WriteLine("Welcome to Agile! This is a numeric typing test.\nType the digits printed. Press any key to start, and type 'stop' to stop.");
_ = Console.ReadKey();
try
{
    Console.Clear();
    int numCorrect = 0;
    int numTotal = 0;
    List<double> times = new();
    while (true)
	{
        string prompt = random.Next(0, 10000).ToString("D4");
        Console.WriteLine(prompt);
        stopwatch.Start();
        string input = Console.ReadLine();
        stopwatch.Stop();
        times.Add(stopwatch.Elapsed.TotalSeconds);
        stopwatch.Reset();
        if (input == prompt)
        {
            numCorrect += 1;
            numTotal += 1;
        }
        else if (input.ToLower() == "stop")
        {
            Console.Clear();
            break;
        }
        else
        {
            numTotal += 1;
        }
        Console.Clear();
    }
    string percentCorrect;
    if (numTotal == 0)
    {
        percentCorrect = "Cannot divide by zero!";
    }
    else
    {
        int rawPercent = numCorrect / numTotal * 100;
        percentCorrect = rawPercent.ToString() + "%";
    }
    var avgTime = times.Sum(x => Convert.ToDouble(x)) / times.Count;
    Console.WriteLine("Results:\nCorrect: " + numCorrect + "\nTotal: " + numTotal + "\nPercent correct: " + percentCorrect + "\nAverage time/prompt: " + avgTime + " sec" + "\nPress any key to exit...");
    _ = Console.ReadKey();
}
catch (Exception e)
{
    Console.WriteLine("An error has occurred and the tests have stopped. Error: " + e.InnerException  + "\nPress any key to exit...");
    _ = Console.ReadKey(true);
}