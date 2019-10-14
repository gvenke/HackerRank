using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerRank
{
    public abstract class HackerRankChallenge
    {
        private const string AutoTestsPassed = "** ALL TESTS PASSED** ";
        private const string AutoTestsFailed = "** TEST FAILURE **";

        protected string[] _args;

        internal virtual void DoAutoTesting()
        {
            Console.WriteLine("No tests to execute");
        }

        public abstract object RunManualTest();

        public string[] Args => _args;

        public bool ManualTestingEnabled => _args != null;

        public void RunAutoTests()
        {
            Console.WriteLine("STARTING AUTOMATED TESTS;\n");
            try {
                DoAutoTesting();
                Console.WriteLine(AutoTestsPassed);
            } catch(AssertFailedException e)
            {
                Console.WriteLine(AutoTestsFailed);
                Console.WriteLine(e.Message);
            } finally
            {
                Console.WriteLine("\nAUTOMATED TESTS COMPLETED");
            }
            
            
        }
    }
}
