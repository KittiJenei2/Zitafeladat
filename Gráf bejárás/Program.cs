using System;
using System.Collections.Generic;

namespace Gráf_bejárás
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] graf = new int[,]
            {
                {0, 0, 1, 0, 1, 0, 0, 0, 0},
                {0, 0, 1, 1, 0, 1, 0, 0, 0},
                {1, 1, 0, 0, 0, 0, 1, 1, 0},
                {0, 1, 0, 0, 0, 0, 0, 0, 0},
                {1, 0, 0, 0, 0, 0, 0, 0, 1},
                {0, 1, 0, 0, 0, 0, 0, 1, 0},
                {0, 0, 1, 0, 0, 0, 0, 0, 0},
                {0, 0, 1, 0, 0, 1, 0, 0, 0},
                {0, 0, 0, 0, 1, 0, 0, 0, 0}
            };

            int startCsucs = 0; // kiinduló csúcs (0-indexelve)

            Console.WriteLine("Mélységi bejárás (DFS):");
            var dfsBejaras = MelysegiBejaras(graf, startCsucs);
            Console.WriteLine(string.Join(" -> ", dfsBejaras));

            Console.WriteLine();

            Console.WriteLine("Szélességi bejárás (BFS):");
            var bfsBejaras = SzelessegiBejaras(graf, startCsucs);
            Console.WriteLine(string.Join(" -> ", bfsBejaras));

            Console.WriteLine("\nNyomj meg egy billentyűt a kilépéshez...");
            Console.ReadKey();
        }

        private static List<int> MelysegiBejaras(int[,] graf, int startCsucs)
        {
            int csucsokSzama = graf.GetLength(0);
            var bejart = new bool[csucsokSzama];
            var eredmeny = new List<int>();

            void DfsRekurziv(int csucs)
            {
                bejart[csucs] = true;
                eredmeny.Add(csucs);

                for (int szomszed = 0; szomszed < csucsokSzama; szomszed++)
                {
                    if (graf[csucs, szomszed] == 1 && !bejart[szomszed])
                    {
                        DfsRekurziv(szomszed);
                    }
                }
            }

            DfsRekurziv(startCsucs);
            return eredmeny;
        }

        private static List<int> SzelessegiBejaras(int[,] graf, int startCsucs)
        {
            int csucsokSzama = graf.GetLength(0);
            var bejart = new bool[csucsokSzama];
            var eredmeny = new List<int>();
            var sor = new Queue<int>();

            bejart[startCsucs] = true;
            sor.Enqueue(startCsucs);

            while (sor.Count > 0)
            {
                int aktualis = sor.Dequeue();
                eredmeny.Add(aktualis);

                for (int szomszed = 0; szomszed < csucsokSzama; szomszed++)
                {
                    if (graf[aktualis, szomszed] == 1 && !bejart[szomszed])
                    {
                        bejart[szomszed] = true;
                        sor.Enqueue(szomszed);
                    }
                }
            }

            return eredmeny;
        }
    }
}
