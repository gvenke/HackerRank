using System;
using HackerRank;

class TestBed
{
    private static HackerRankChallenge _challenge;

    static void Main(string[] args)
    {

        _challenge = new SherlockAndAnagrams();

        // run automated tests, if any
        _challenge.RunAutoTests();

        // run manual tests
        Console.WriteLine("\nSTART MANUAL TESTING...\n");

        Start:
            if (_challenge.Args?.Length > 0)
            {
                Console.WriteLine($"Enter {_challenge.Args.Length} arguments\n");
            }
            
            int argCounter = 0;

            // collect arguments from user input if applicable
            while (argCounter < _challenge.Args?.Length)
            {                    
                _challenge.Args[argCounter] = Console.ReadLine();
                argCounter++;
            }

            // run test and output result
            try
            {
                var result = _challenge.RunManualTest();
                Console.Write($"\nRESULT: {result}");
            } catch (Exception e) {
                Console.WriteLine($"ERROR OCCURRED: {e.Message}\n");
            }
            Console.ReadLine();

            // rinse, repeat
            goto Start;
    
    }
}
