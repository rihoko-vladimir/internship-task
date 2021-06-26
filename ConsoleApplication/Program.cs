using System;
using System.Linq;
using Program;
using Program.Interfaces;
using Program.Services;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            IParserService parserService =
                new ParserService("5x5 (5, 0) (1, 3) (4,4) (4, 2) (4, 2) (0, 1) (3, 2) (2, 3) (4, 1)");
            foreach (var stopPoint in parserService.GetParsedData().StopPoints)
            {
                Console.WriteLine(stopPoint);
            }
        }
    }
}