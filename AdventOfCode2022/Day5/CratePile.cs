namespace Day5
{
    public class CratePile : IComparable
    {
        public int Index { get; init; }
        public List<char> Crates { get; init; } = new();

        private CratePile() { }

        public CratePile(int index)
        {
            Index = index;
        }

        public int CompareTo(object? obj)
        {
            return Index > (obj as CratePile)?.Index ? 1 : 0;
        }
    }
}
