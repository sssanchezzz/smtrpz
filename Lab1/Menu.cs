using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Lab1
{
    public class Menu
    {
        private delegate bool CheckFunction<T>(T t);

        private static List<bool> res = new List<bool>();

        private static SystemUnitCase unit;
        
        public static void ShowMenu()
        {
            Console.WriteLine("Please, choose a system unit case");
            foreach (var s in SystemUnitCase.Items)
            {
                Console.WriteLine($"{(SystemUnitCase.Items.IndexOf(s) + 1)} - {s}");
            }

            if (int.TryParse(Console.ReadLine(), out int input))
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
                    ChooseMemoryCard(unit);
                    Conclusion();
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
                if (int.TryParse(Console.ReadLine(), out int input))
                {
                    if (input > 0 && input <= list.Count)
                    {
                        //add funcrion to set properties
                        SetProp(unitCase, choice, list[input - 1]);
                        Console.WriteLine($"You`ve chosen {list[input - 1]}\n");
                        repeat = false;
                    }
                    else
                    {
                        Console.WriteLine("Wrong number, please try again!\n");
                        repeat = true;
                    }
                }
                else
                {
                    Console.WriteLine("Not a number, please try again!");
                }
            }
        }


        private static bool SetProp(SystemUnitCase unitCase, string prop, Object obj)
        {
            bool res;
            switch (prop)
            {
                case "motherboard":
                    unitCase.MotherboardAdded = (Motherboard)obj;
                    res = true;
                    break;
                case "power":
                    unitCase.PowerSupply = (PowerSupply)obj;
                    res = true;
                    break;
                case "processor":
                    unitCase.MotherboardAdded.Processor = (Processor)obj;
                    res = true;
                    break;
                default:
                    res = false;
                    break;
            }

            return res;
        }

        private static void ChooseMemoryCard(SystemUnitCase unitCase)
        {
            Console.WriteLine("Choose memory card(-s):\n");

            foreach (var s in MemoryCard.Items)
            {
                if (unitCase.MotherboardAdded.MemoryCardTypesSupported.Contains(s.Type))
                {
                    Console.WriteLine($"{(MemoryCard.Items.IndexOf(s) + 1)} - {s} - fits");
                }
                else
                {
                    Console.WriteLine($"{(MemoryCard.Items.IndexOf(s) + 1)} - {s} - does not fit");
                }
            }

            Console.WriteLine("Please enter your options, to exit enter 'exit':\n");
            Console.WriteLine("memory cards count: " + MemoryCard.Items.Count);
            bool exit = false;
            while (!exit)
            {
                var inputString = Console.ReadLine();

                if (int.TryParse(inputString, out int input))
                {
                    if (input > 0 && input <= MemoryCard.Items.Count)
                    {
                        unitCase.MotherboardAdded.MemoryCards.Add(MemoryCard.Items[input - 1]);
                        Console.WriteLine($"You`ve chosen {MemoryCard.Items[input - 1]}");
                    }
                    else
                    {
                        Console.WriteLine("Wrong number, please try again!\n");
                        ChooseMemoryCard(unitCase);
                    }
                }
                else if (inputString.Equals("exit"))
                {
                    exit = true;
                }
                else
                {
                    Console.WriteLine("Not a number, try again");
                    ChooseMemoryCard(unitCase);
                }
            }
        }

        private static void Conclusion()
        {
            Console.WriteLine($"Your set:\n" +
                              $"System unit case: {unit};\n" +
                              $"PowerSupply: {unit.PowerSupply}, it {CheckString(unit.AddPowerSupplyBool(unit.PowerSupply))} the unit case;\n" +
                              $"Motherboard: {unit.MotherboardAdded}, it {CheckString(unit.MotherboardTypesSupported.Contains(unit.MotherboardAdded.Type))} the motherboard;\n" +
                              $"Processor: {unit.MotherboardAdded.Processor}, it {CheckString(unit.MotherboardAdded.AddProcessorsToMotherboard(unit.MotherboardAdded.Processor))} the motherboard;\n");

            foreach (var s in unit.MotherboardAdded.MemoryCards)
            {
                Console.WriteLine(
                    $"{s} - {CheckString(unit.MotherboardAdded.MemoryCardTypesSupported.Contains(s.Type))}");
            }

            bool power = unit.CheckPowerConsumption();
            res.Add(power);
            Console.WriteLine($"battery is {(power ? "" : "not")} enough to power all the elements");
            Console.WriteLine($"\nYou can{(res.Contains(false) ? " not" : "")} form a set out of these items");
        }

        private static string CheckString(bool b)
        {
            if (b)
            {
                res.Add(true);
                return "fits";
            }
            else
            {
                res.Add(false);
                return "does not fit";
            }
        }

    }
}