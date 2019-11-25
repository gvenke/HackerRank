using System;
using HackerRank;

class TestBed
{
    private static HackerRankChallenge _challenge;

    static void Main(string[] args)
    {

        _challenge = new SandBox();

        //// begin temp code
        //string[] a1 = new[] { "WEWOUCUIDG", "CGTRMEZEPX", "ZFEJWISRSB", "BSYXAYDFEJ", "JDLEBVHHKS" };
        //string[] a2 = new[] { "FDAGCXGKCT", "KWNECHMRXZ", "WMLRYUCOCZ", "HJRRJBOAJO", "QJZZVUYXIC" };
        //foreach(var s1 in a1)
        //{
        //    foreach(var s2 in a2)
        //    {
        //        _challenge.Args[0] = s1;
        //        _challenge.Args[1] = s2;
        //        var r1 = (int)_challenge.RunManualTest();
        //        _challenge.Args[0] = s2;
        //        _challenge.Args[1] = s1;
        //        var r2 = (int)_challenge.RunManualTest();
        //        if (r1 != r2)
        //        {
        //            Console.WriteLine($"{r1} => {r2}");
        //            Console.WriteLine($"{s1} => {s2}");
        //            Console.Write(Environment.NewLine);
        //        }
        //    }
        //}
        //Console.ReadLine();
        //// end temp code

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
        }
        catch (Exception e)
        {
            Console.WriteLine($"ERROR OCCURRED: {e.Message}\n");
        }
        Console.ReadLine();

        // rinse, repeat
        goto Start;

    }
}
