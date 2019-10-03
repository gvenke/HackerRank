using System;
using HackerRank;

class HackerRankTest
{
    private static HackerRankBase _hackerRank;

    static void Main(string[] args)
    {
    
         _hackerRank = new HighValuePalidrome();

        // run automated tests, if any
        _hackerRank.RunAutoTests();

        // run manual tests
        Console.WriteLine("\nStart manual testing...\n");

        Start:
            int argCounter = 0;

            // collect arguments from user input if applicable
            if  (_hackerRank.Args != null && _hackerRank.Args.Length > 0) {
                do
                {
                    _hackerRank.Args[argCounter] = Console.ReadLine();
                    argCounter++;
                } while (argCounter < _hackerRank.Args.Length - 1);
            }   

            // run test and output result
            var result = _hackerRank.RunManualTest();
            Console.WriteLine($"\n{result}\n");
            
            // rinse, repeat
            goto Start;
    }
}
