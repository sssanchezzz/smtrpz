using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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

        public bool FormMotherboard(List<Processor> processors, List<MemoryCard> cards)
        {
            return (AddProcessorsToMotherboard(processors) && AddMemoryCardsToMotherBoard(cards));
        }

        //????
        public bool AddProcessorsToMotherboard(List<Processor> processors)
        {
            var intersection = processors
                .Select(p => p.Type)
                .Where(pr => ProcessorTypesSupported
                    .Any(ts => pr == ts));

            if (processors.Count == intersection.Count())
                return true;
            return false;
        }

        public bool AddProcessorsToMotherboard(Processor processor)
        {
            return ProcessorTypesSupported.Contains(processor.Type);
        }

        //???
        public bool AddMemoryCardsToMotherBoard(List<MemoryCard> cards)
        {
            var intersection = cards.Select(c => c.Type)
                .Where(ct => MemoryCardTypesSupported
                    .Any(cts => ct == cts));
            if (cards.Count == intersection.Count())
                return true;
            return false;
        }

        public bool AddMemoryCardsToMotherBoard(MemoryCard card)
        {
            return MemoryCardTypesSupported.Contains(card.Type);
        }
    }
}