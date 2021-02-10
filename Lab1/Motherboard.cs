using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lab1
{
    public class Motherboard : Base<Motherboard>
    {
        public List<string> ProcessorTypesSupported { get; }
        public List<string> MemoryCardTypesSupported { get; }
        public string Type { get; set; }


        public Motherboard()
        {
            MemoryCardTypesSupported = new List<string>();
            ProcessorTypesSupported = new List<string>();
        }
        public static bool FormMotherboard(Motherboard m, List<Processor> processors, List<MemoryCard> cards)
        {
            if (AddProcessorsToMotherboard(m, processors) && AddMemoryCardsToMotherBoard(m, cards))
                return true;
            return false;
        }
        //????
        public static bool AddProcessorsToMotherboard(Motherboard m, List<Processor> processors)
        {
            var intersection = processors
                .Select(p => p.Type)
                .Where(pr => m.ProcessorTypesSupported
                    .Any(ts => pr == ts));
            
            if(processors.Count == intersection.Count())
                return true;
            return false;
        }

        public static bool AddProcessorsToMotherboard(Motherboard m, Processor processor)
        {
            if (m.ProcessorTypesSupported.Contains(processor.Type))
                return true;
            return false;
        }
        //???
        public static bool AddMemoryCardsToMotherBoard(Motherboard m, List<MemoryCard> cards)
        {
            var intersection = cards.Select(c => c.Type)
                .Where(ct => m.MemoryCardTypesSupported
                    .Any(cts => ct == cts));
            if (cards.Count == intersection.Count())
                return true;
            return false;

        }
        public static bool AddMemoryCardsToMotherBoard(Motherboard m, MemoryCard card)
        {
            if (m.MemoryCardTypesSupported.Contains(card.Type))
                return true;
            return false;
        }
        
    }
}
