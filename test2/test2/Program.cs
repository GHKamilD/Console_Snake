using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace test2
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Thread.Sleep(3000);
            Console.Clear();
            int macierz_x=10, macierz_y=10;
            char glowa = '>';
            int[,] macierz = new int[macierz_x, macierz_y]; //W macierzy wartość 0 oznacza puste pole, wartość 1 oznacza pole zajęte przez węża, 2 oznacza jedzenie a 3 głowę węża
            int wspolrzedne_x_gracza = 1, wspolrzedne_y_gracza = 1;
            List<Tuple<int,int>> waz = new List<Tuple<int, int>>();
            waz.Add(Tuple.Create(1, 1));
            waz.Add(Tuple.Create(0, 1));
            Random rand = new Random();
            macierz[1, 0] = 1;
            macierz[1, 1] = 3;
            int wspolrzedne_x_jedzenia, wspolrzedne_y_jedzenia, sekundy = 0 ;
            wspolrzedne_x_jedzenia = rand.Next(2, macierz_x);
            wspolrzedne_y_jedzenia = rand.Next(2,macierz_y);
            macierz[wspolrzedne_x_jedzenia, wspolrzedne_y_jedzenia]=2;
            ConsoleKeyInfo klawisz= new ConsoleKeyInfo((char)ConsoleKey.D, ConsoleKey.D,false,false,false),klawisz2=klawisz;
            while ((wspolrzedne_x_gracza<macierz_x&&wspolrzedne_x_gracza>=0)&&(wspolrzedne_y_gracza < macierz_y && wspolrzedne_y_gracza >= 0))
            {
                for (int i = 0; i < macierz_x; i++)
                {
                    Console.Write("|");
                    for (int j = 0; j < macierz_y; j++)
                    {
                        if (macierz[i, j]==3)
                        {
                            Console.Write(glowa + " ");
                        }
                        else if (macierz[i, j] == 2)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("$ ");
                            Console.ResetColor();
                        }
                        else if (macierz[i, j] == 1)
                        {
                            Console.Write("@ ");
                        }
                        else
                        {
                            Console.Write(". ");
                        }
                        //Console.Write(macierz[i, j] + " ");
                    }
                    Console.Write("|");
                    Console.WriteLine();
                }
                for (int i=0; i<macierz_y; i++)
                {
                    Console.Write(" -");
                }
                Console.WriteLine();
                //klawisz2 = Console.ReadKey(true);
                while (true)
                {
                    while (Console.KeyAvailable)
                        klawisz2=Console.ReadKey(true);
                    /*if (Console.KeyAvailable)
                    {
                        klawisz2 = Console.ReadKey(true);
                        /*if (klawisz2.Key == ConsoleKey.D || klawisz2.Key == ConsoleKey.A || klawisz2.Key == ConsoleKey.S || klawisz2.Key == ConsoleKey.W)
                        {
                            //break;
                        }
                    }*/
                    Thread.Sleep(80);
                    if (sekundy++ > 3)
                    {
                        if(klawisz2.Key == default(ConsoleKey))
                        {
                            klawisz2 = klawisz;
                        }
                        break;
                    }
                }
                if ((klawisz2.Key == ConsoleKey.D && klawisz.Key == ConsoleKey.A)|| (klawisz2.Key == ConsoleKey.A && klawisz.Key == ConsoleKey.D)|| (klawisz2.Key == ConsoleKey.W && klawisz.Key == ConsoleKey.S)|| (klawisz2.Key == ConsoleKey.S && klawisz.Key == ConsoleKey.W))
                {
                    klawisz2 = klawisz;
                    /*Console.Clear();
                    Console.WriteLine("Nielegalny ruch");
                    klawisz2 = default(ConsoleKeyInfo);
                    sekundy = 0;
                    continue;*/
                }
                if (klawisz2.Key == ConsoleKey.S)
                {
                    //macierz[wspolrzedne_x_gracza, wspolrzedne_y_gracza] = 1;
                    glowa = 'v';
                    wspolrzedne_x_gracza++;
                }
                else if (klawisz2.Key == ConsoleKey.W)
                {
                    //macierz[wspolrzedne_x_gracza, wspolrzedne_y_gracza] = 1;
                    glowa = '^';
                    wspolrzedne_x_gracza--;
                }
                else if (klawisz2.Key == ConsoleKey.A)
                {
                    //macierz[wspolrzedne_x_gracza, wspolrzedne_y_gracza] = 1;
                    glowa = '<';
                    wspolrzedne_y_gracza--;
                }
                else if (klawisz2.Key == ConsoleKey.D)
                {
                    //macierz[wspolrzedne_x_gracza, wspolrzedne_y_gracza] = 1;
                    glowa = '>';
                    wspolrzedne_y_gracza++;
                }
                if ((wspolrzedne_x_gracza >= macierz_x || wspolrzedne_x_gracza < 0) || (wspolrzedne_y_gracza >= macierz_y || wspolrzedne_y_gracza < 0))
                {
                    break;
                }
                //Console.WriteLine(wspolrzedne_x_gracza +" "+ wspolrzedne_y_gracza);
                if(macierz[wspolrzedne_x_gracza,wspolrzedne_y_gracza]==1)
                {
                    if ((wspolrzedne_x_gracza == waz[waz.Count() - 1].Item1 && wspolrzedne_y_gracza == waz[waz.Count() - 1].Item2))
                    {

                    }
                    else
                    {
                        break;
                    }
                    
                }
                if (macierz[wspolrzedne_x_gracza, wspolrzedne_y_gracza] == 2)
                {
                    //macierz[wspolrzedne_x_gracza, wspolrzedne_y_gracza] = 3;
                    do
                    {
                        wspolrzedne_x_jedzenia = rand.Next(0, macierz_x);
                        wspolrzedne_y_jedzenia = rand.Next(0, macierz_y);
                    }
                    while (macierz[wspolrzedne_x_jedzenia, wspolrzedne_y_jedzenia] != 0);
                    waz.Insert(0, Tuple.Create(wspolrzedne_x_gracza, wspolrzedne_y_gracza));
                }
                else
                {
                    //macierz[wspolrzedne_x_gracza, wspolrzedne_y_gracza] = 3;
                    //macierz[waz[waz.Count() - 1].Item1, waz[waz.Count() - 1].Item2]=0;
                    waz.RemoveAt(waz.Count() - 1);
                    waz.Insert(0, Tuple.Create(wspolrzedne_x_gracza, wspolrzedne_y_gracza));
                }
                klawisz = klawisz2;
                klawisz2 = default(ConsoleKeyInfo);
                sekundy = 0;
                for (int i = 0; i < macierz_x; i++)
                {
                    for (int j = 0; j < macierz_y; j++)
                    {
                        macierz[i, j] = 0;
                    }
                }
                foreach (Tuple<int,int> wspolrzedne in waz)
                {
                    macierz[wspolrzedne.Item1, wspolrzedne.Item2] = 1;
                }

                macierz[waz[0].Item1,waz[0].Item2] = 3;
                macierz[wspolrzedne_x_jedzenia, wspolrzedne_y_jedzenia] = 2;
                Console.Clear();
                //Console.WriteLine(wspolrzedne_x_gracza + " " + wspolrzedne_y_gracza);
                //Console.WriteLine(waz[waz.Count() - 1].Item1 +" " + waz[waz.Count() - 1].Item2);
            }
            Console.WriteLine("Porazka :(");
            Console.ReadLine();
        }
    }
}
