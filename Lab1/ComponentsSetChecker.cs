using System;

namespace Lab1
{
    public class ComponentsSetChecker
    {
        public static bool FormMotherBoard(Motherboard motherboard, Processor processor, MemoryCard card)
        {
            return motherboard.AddProcessorsToMotherboard(processor) && motherboard.AddMemoryCardsToMotherBoard(card);
            
        }
        public static bool FormSystemUnitCase(SystemUnitCase unitCase, Motherboard motherboard)
        {
            return unitCase.AddMotherboardBool(motherboard);
        }

        public static string FormSystemUnitCase(SystemUnitCase unitCase, Motherboard motherboard, bool res)
        {
         unitCase.AddMotherboard(motherboard, res);
         return $"Added {motherboard} to {unitCase}";
         
        }
    }
}