namespace SubTrackerDL
{
    public struct WordCountRange
    {
        public int Min;
        public int Max;

        public WordCountRange(int min, int max) => (Min, Max) = (min, max);

        public override bool Equals(object obj)
        {
            throw new System.NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new System.NotImplementedException();
        }

        public static bool operator ==(WordCountRange left, WordCountRange right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(WordCountRange left, WordCountRange right)
        {
            return !(left == right);
        }
    }
}