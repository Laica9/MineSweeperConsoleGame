using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minesweep
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("MineSweeper");
            //Display d = new Display();
            //Console.WriteLine(d.Intro());
            Board b = new Board();
            b.newTileMap(7,20,14);

            string input;
            while(true) {
                b.Display();
                Console.WriteLine("Please enter x & y coordinates <x,y> : ");
                input = Console.ReadLine();
                string[] xy = input.Split(",");
                int x = int.Parse(xy[0]);
                int y = int.Parse(xy[1]);
            }
            
        }
    }
}
