using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Lab1
{
    public class Menu
    {
         delegate  bool CheckFunction<T>(T t);

        static SystemUnitCase unit;

        public static void ShowMenu()
        {
            Console.WriteLine("Please, choose a system unit case");
            foreach (var s in SystemUnitCase.Items)
            {
                Console.WriteLine($"{(SystemUnitCase.Items.IndexOf(s) + 1)} - {s}");
            }

            if (Int32.TryParse(Console.ReadLine(), out int input))
            {
                if (input > 0 && input <= SystemUnitCase.Items.Count)
                {
                    unit = SystemUnitCase.Items[input - 1];
                    
                    CheckFunction<Motherboard> checkMoth = unit.AddMotherboardBool;
                    Choose(unit, Motherboard.Items, "motherboard", checkMoth);
                    CheckFunction<PowerSupply> checkPow = unit.AddPowerSupplyBool;
                    Choose(unit, PowerSupply.Items, "power", checkPow);
                    CheckFunction<Processor> checkProc = unit.MotherboardAdded.AddProcessorsToMotherboard;
                    Choose(unit, Processor.Items, "processor", checkProc);
                    
                }
                else
                {
                    Console.WriteLine("Wrong number, please try again!");
                    ShowMenu();
                }
            }
        }
        

        private static void Choose<T>(SystemUnitCase unitCase, List<T> list, string choice, CheckFunction<T> function)
        {
            Console.WriteLine($"Please choose {choice}:\n");
            foreach (var s in list)
            {
                if (function(s))
                {
                    Console.WriteLine($"{(list.IndexOf(s) + 1)} - {s} - fits");
                }
                else
                {
                    Console.WriteLine($"{list.IndexOf(s) + 1} - {s} - does not fit");
                }
            }

            Console.WriteLine("\nPlease enter your option:\n");
            bool repeat = true;
            while (repeat)
            {
                if (Int32.TryParse(Console.ReadLine(), out int input))
                {
                    if (input > 0 && input <= list.Count)
                    {
                        //add funcrion to set properties
                        SetProp(unit, choice, list[input - 1]);
                        Console.WriteLine($"You`ve chosen {list[input - 1]}\n");
                        repeat = false;
                    }
                    else
                    {
                        Console.WriteLine("Wrong number, please try again!\n");
                        repeat = true;
                    }
                }
            }
        }


        private static bool SetProp(SystemUnitCase unitCase, string prop, Object obj)
        {
            bool res;
            switch (prop)
            {
                case "motherboard":
                    unitCase.MotherboardAdded = (Motherboard) obj;
                    res = true;
                    break;
                case "power":
                    unitCase.PowerSupply = (PowerSupply) obj;
                    res = true;
                    break;
                case "processor":
                    unitCase.MotherboardAdded.Processor = (Processor) obj;
                    res = true;
                    break;
                default:
                    res = false;
                    break;
            }
            return res;
        }
        // private static void ChooseMemoryCard(SystemUnitCase unitCase)
        // {
        //     Console.WriteLine("Choose memory card(-s):\n");
        //
        //     foreach (var s in MemoryCard.Items)
        //     {
        //         if (unitCase.MotherboardAdded.MemoryCardTypesSupported.Contains(s.Type))
        //         {
        //             Console.WriteLine($"{(MemoryCard.Items.IndexOf(s) + 1)} - {s} - fits");
        //         }
        //         else
        //         {
        //             Console.WriteLine($"{(MemoryCard.Items.IndexOf(s) + 1)} - {s} - does not fit");
        //         }
        //     }
        //
        //     Console.WriteLine("Please enter your options, to exit enter E:\n");
        //
        //     while (!Console.ReadLine().Trim().Equals("E"))
        //     {
        //         if (Int32.TryParse(Console.ReadLine(), out int input))
        //         {
        //             if (input > 0 && input <= MemoryCard.Items.Count)
        //             {
        //                 unitCase.MotherboardAdded.MemoryCards.Add(MemoryCard.Items[input - 1]);
        //                 Console.WriteLine($"You`ve chosen {MemoryCard.Items[input - 1]}\n");
        //                 Conclusion();
        //             }
        //             else
        //             {
        //                 Console.WriteLine("Wrong number, please try again!\n");
        //                 ChooseMemoryCard(unitCase);
        //             }
        //         }
        //
        //         else
        //         {
        //             Console.WriteLine("Unresolved symbol, try again");
        //             ChooseMemoryCard(unitCase);
        //         }
        //     }
        // }
        
        private static void Conclusion()
        {
            Console.WriteLine($"\n{unit}\n");
            Console.WriteLine($"power supply: {unit.PowerSupply}\n");
            Console.WriteLine($"Motherboard: {unit.MotherboardAdded}\n");

            Console.WriteLine("Added memory cards:\n");
            foreach (var s in unit.MotherboardAdded.MemoryCards)
            {
                if (unit.MotherboardAdded.MemoryCardTypesSupported.Contains(s.Type))
                    Console.WriteLine($"{s} - fits");
                else
                {
                    Console.WriteLine($"{s} - does not fit");
                }
            }
        }

        
        
        
        
        
        
        
        // private static void ChooseProcessor(SystemUnitCase unitCase)
        // {
        //     Console.WriteLine("Please choose processor:\n");
        //     foreach (var s in Processor.Items)
        //     {
        //         // Console.WriteLine(s);
        //         // if (unitCase.MotherboardAdded.ProcessorTypesSupported.Contains(s.Type))
        //         // {
        //         Console.WriteLine($"{Processor.Items.IndexOf(s) + 1} - {s} - fits");
        //         // }
        //         // else
        //         // {
        //         //     Console.WriteLine($"{Processor.Items.IndexOf(s) + 1} - {s} - does not fit");
        //         // }
        //     }
        //
        //     Console.WriteLine("Please enter your option:\n");
        //     if (Int32.TryParse(Console.ReadLine(), out int input))
        //     {
        //         if (input > 0 && input <= Processor.Items.Count)
        //         {
        //             // unitCase.MotherboardAdded.Processor = Processor.Items[input - 1];
        //             Console.WriteLine($"You`ve chosen {Processor.Items[input - 1]}\n");
        //             ChooseMemoryCard(unitCase);
        //         }
        //         else
        //         {
        //             Console.WriteLine("Wrong number, please try again!\n");
        //             ChoosePowerSupply(unit);
        //         }
        //     }
        // }
        //
       
        // private static void ChoosePowerSupply(SystemUnitCase unitCase)
        // {
        //     Console.WriteLine("Available power supplies:\n");
        //     foreach (var s in PowerSupply.Items)
        //     {
        //         if (unitCase.AddPowerSupplyBool(s))
        //         {
        //             Console.WriteLine($"{(PowerSupply.Items.IndexOf(s) + 1)} - {s} - fits");
        //         }
        //         else
        //         {
        //             Console.WriteLine($"{PowerSupply.Items.IndexOf(s) + 1} - {s} - does not fit");
        //         }
        //     }
        //
        //     Console.WriteLine("Please enter your option:\n");
        //     if (Int32.TryParse(Console.ReadLine(), out int input))
        //     {
        //         if (input > 0 && input <= PowerSupply.Items.Count)
        //         {
        //             unitCase.PowerSupply = PowerSupply.Items[input - 1];
        //             Console.WriteLine($"You`ve chosen {PowerSupply.Items[input - 1]}\n");
        //             ChooseProcessor(unitCase);
        //         }
        //         else
        //         {
        //             Console.WriteLine("Wrong number, please try again!\n");
        //             ChoosePowerSupply(unitCase);
        //         }
        //     }
        // }
        
    }
}