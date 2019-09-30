using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerRank
{
    public abstract class HackerRankBase
    {
        private const string AutoTestsPassed = "** ALL TESTS PASSED** ";
        private const string AutoTestsFailed = "** TEST FAILURE **";
        protected object[] _args;

        public abstract object TestFunction();

        protected virtual void DoAutoTesting()
        {
            Console.WriteLine("No tests to execute");
        }

        public object[] Args => _args;

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
