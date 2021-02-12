using System.Collections.Generic;

namespace Lab1
{
    public class Motherboard : Base<Motherboard>
    {
        public List<ProcessorTypes> ProcessorTypesSupported { get; }
        public List<MemoryCardTypes> MemoryCardTypesSupported { get; }
        public MotherboardTypes Type { get; set; }
        public Processor Processor { get; set; }
        public List<MemoryCard> MemoryCards { get; }
        public int PowerConsumption { get; set; }

        public Motherboard()
        {
            MemoryCardTypesSupported = new List<MemoryCardTypes>();
            ProcessorTypesSupported = new List<ProcessorTypes>();
            MemoryCards = new List<MemoryCard>();
        }
        
        public bool AddProcessorsToMotherboard(Processor processor)
        {
            return ProcessorTypesSupported.Contains(processor.Type);
        }

        
        public bool AddMemoryCardsToMotherBoard(MemoryCard card)
        {
            return MemoryCardTypesSupported.Contains(card.Type);
        }
    }
}