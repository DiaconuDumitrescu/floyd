using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace floyd
{
    class Program
    {
        public static List<int> accResults = new List<int>();
        public static List<int> trimResults = new List<int>();
        static void Main(string[] args)
        {
            int N = 8;
            int[,] R = new int[8,8];
            int[,] aCC = new int[8, 8];
            

            R[0, 0] = 0;
            R[0, 1] = 1;
            R[0, 2] = 0;
            R[0, 3] = 1;
            R[0, 4] = 0;
            R[0, 5] = 0;
            R[0, 6] = 0;
            R[0, 7] = 0;

            R[1, 0] = 0;
            R[1, 1] = 0;
            R[1, 2] = 1;
            R[1, 3] = 0;
            R[1, 4] = 0;
            R[1, 5] = 0;
            R[1, 6] = 0;
            R[1, 7] = 0;

            R[2, 0] = 0;
            R[2, 1] = 1;
            R[2, 2] = 0;
            R[2, 3] = 1;
            R[2, 4] = 0;
            R[2, 5] = 0;
            R[2, 6] = 0;
            R[2, 7] = 0;

            R[3, 0] = 0;
            R[3, 1] = 0;
            R[3, 2] = 1;
            R[3, 3] = 0;
            R[3, 4] = 0;
            R[3, 5] = 0;
            R[3, 6] = 1;
            R[3, 7] = 0;


            R[4, 0] = 0;
            R[4, 1] = 0;
            R[4, 2] = 1;
            R[4, 3] = 0;
            R[4, 4] = 0;
            R[4, 5] = 1;
            R[4, 6] = 0;
            R[4, 7] = 0;

            R[5, 0] = 0;
            R[5, 1] = 0;
            R[5, 2] = 0;
            R[5, 3] = 1;
            R[5, 4] = 0;
            R[5, 5] = 0;
            R[5, 6] = 0;
            R[5, 7] = 0;

            R[6, 0] = 0;
            R[6, 1] = 0;
            R[6, 2] = 0;
            R[6, 3] = 0;
            R[6, 4] = 0;
            R[6, 5] = 0;
            R[6, 6] = 0;
            R[6, 7] = 1;

            R[7, 0] = 0;
            R[7, 1] = 0;
            R[7, 2] = 0;
            R[7, 3] = 0;
            R[7, 4] = 0;
            R[7, 5] = 0;
            R[7, 6] = 1;
            R[7, 7] = 0;

            aCC = acc(R, N);
            int [] markedStates = new int[5];
            markedStates[0] = 2;
            coAcc(aCC, markedStates, N);

            Console.WriteLine("\n\nTrim:");
            foreach(int x in trimResults){
                Console.Write(x.ToString() + " ");
            }
            Console.ReadKey();
        }

        private static int[,] acc(int[,] R, int N)
        {
            for (int v = 0; v < N; v++)
            {
                for (int u = 0; u < N; u++)
                {
                    if (u == v)
                        continue;

                    for (int k = 0; k < N; k++)
                    {
                        if (k == u || k == v)
                                 continue;

                        if ((R[v, k] != 0) && (R[k, u] != 0))
                        {
                            R[v, u] = R[v, k] * R[k, u];
                            //R[v,u] = k;
                            
                        }
                    }
                }

            }
            int i = 10;
            int n = 8;
            int j = 10;

            Console.WriteLine("Starile in care se poate ajunge plecand de la starea initiala:");
            Console.Write("0 ");
                for (j = 0; j < n; j++)
                {
                    if(R[0, j] == 1){
                        Console.Write(j.ToString() + " ");
                        accResults.Add(j);
                       
                    }
                }
                return R;
            

            
        }

        private static void coAcc(int[,] pathMatrix, int[] markedStates, int N)
        {
            Console.WriteLine("\n\nStarile care duc catre o stare marcata:");
            foreach (int markedState in markedStates)
            {
                for (int i = 0; i < N; i++)
                    if(markedState != 0)
                        if (pathMatrix[i, markedState] == 1)
                        {
                            Console.Write(i.ToString() + " ");
                            if(accResults.Contains(i))
                                trimResults.Add(i);
                        }
            }
        }
    }
}
