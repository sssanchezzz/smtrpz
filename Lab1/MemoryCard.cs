using System;
namespace Lab1
{
    public class MemoryCard : Base<MemoryCard>
    {
        public int MemoryCapacity { get; set; }
        public string Type { get; set; }


        public MemoryCard()
        {
        }
    }
}
