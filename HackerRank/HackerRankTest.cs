﻿using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System;
using HackerRank;

class HackerRankTest
{
    private static HackerRankBase _hackerRank;

    static void Main(string[] args)
    {

        _hackerRank = new SherlockString();
        
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
            var result = _hackerRank.TestFunction();
            Console.WriteLine($"\n{result}\n");
            
            // rinse, repeat
            goto Start;
    }
}