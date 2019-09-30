namespace HackerRank
{
    public abstract class HackerRankBase
    {
        protected object[] _args;

        public abstract object TestFunction();

        public object[] Args => _args;
    }
}
