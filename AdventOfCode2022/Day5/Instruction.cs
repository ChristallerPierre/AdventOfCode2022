namespace Day5
{
    public class Instruction : IComparable
    {
        public int SourcePileIndex { get; set; }
        public int DestinationPileIndex { get; set; }
        public int NbMoved { get; set; }
        public int Index { get; init; }

        private Instruction() { }
        public Instruction(int index)
        {
            Index = index;
        }

        public int CompareTo(object? obj)
        {
            var o = obj as Instruction;
            return Index > o?.Index ? 1 : 0;
        }
    }
}
