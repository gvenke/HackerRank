using System;
using HackerRank;

class TestBed
{
    private static HackerRankChallenge _hackerRank;

    static void Main(string[] args)
    {
    
         _hackerRank = new HighValuePalidrome();

        // run automated tests, if any
        _hackerRank.RunAutoTests();

        // initiate manual testing if applicable
        if (_hackerRank.ManualTestingEnabled)
        {
            // run manual tests
            Console.WriteLine("\nSTART MANUAL TESTING...\n");

            Start:
                int argCounter = 0;

                // collect arguments from user input if applicable
                while (argCounter < _hackerRank.Args.Length)
                {
                    _hackerRank.Args[argCounter] = Console.ReadLine();
                    argCounter++;
                }

                // run test and output result
                var result = _hackerRank.RunManualTest();
                Console.WriteLine($"\n{result}\n");

                // rinse, repeat
                goto Start;
        }
    }
}
