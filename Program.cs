using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace kosiarka
{
    public class Position
    {
        public int x;
        public int y;
        public bool flaga;
        public bool flaga2;
        public Position()
        {
            this.x = 0;
            this.y = 0;
            this.flaga = false;
        }
        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.flaga = false;
        }
        public ref Position MoveRnd(ref Position x, ref char[,] tab)
        {
            var rnd = new Random();
            var k = rnd.Next(4);

            switch (k)
            {
                case 0: { if (x.x < tab.GetLength(0) - 1) { this.x++; flaga = true; } break; }
                case 1: { if (x.y < tab.GetLength(1) - 1) { this.y++; flaga = true; } break; }
                case 2: { if (x.x > 0) { this.x--; flaga = true; } break; }
                case 3: { if (x.y > 0) { this.y--; flaga = true; } break; }
            }
            return ref x;
        }
    }

    class Kosiarka
    {
        public Position position;
        public int penalty;
        public int counter;
        public Kosiarka()
        {
            this.position = new Position();
            this.penalty = 0;
            this.counter = 0;
        }
        public void go(ref char[,] tab)
        {
            Position tempPosition = this.position;
            this.position.MoveRnd(ref position, ref tab);
            if (this.position.flaga == true)
            {
                if (tab[this.position.x, this.position.y] == 'g')
                {

                    this.position.flaga2 = true;
                    tab[this.position.x, this.position.y] = 'e';
                    this.counter++;
                }
                else
                {
                    this.position.flaga2 = false;
                    this.penalty++;
                }
            }
            this.position.flaga = false;
        }
    }


    class Programe
    {
        public static ref char[,] clearMaw(ref char[,] maw)
        {
            for (int i = 0; i < maw.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < maw.GetLength(1) - 1; j++)
                {
                    maw[i, j] = 'g';
                }
            }
            return ref maw;
        }


        static void Main(string[] args)
        {

            var maw = new char[11, 11];
            clearMaw(ref maw);
            var kosiarka = new Kosiarka();
            while (kosiarka.counter < 100)
            {
                Console.Clear();
                kosiarka.go(ref maw);
                for (int i = 0; i < maw.GetLength(0) - 1; i++)
                {
                    //Console.WriteLine(i+" "+maw.GetLength(0) );
                    for (int j = 0; j < maw.GetLength(1) - 1; j++)
                    {
                        if (maw[i, j] == 'g')
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(maw[i, j] + " ", Console.ForegroundColor);
                        }
                        else if (maw[i, j] == 'e')
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write(maw[i, j] + " ", Console.ForegroundColor);
                        }
                    }
                    Console.WriteLine();
                }

                Console.WriteLine("Kosiarka otrzymala " + kosiarka.penalty + " kar");
                if (kosiarka.position.flaga2 = true)
                {
                    Thread.Sleep(10);
                }
            }

        }
    }
}
