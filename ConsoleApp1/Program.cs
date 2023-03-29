using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[,] matriz = new string[3, 3];
            string turno = "X";

            List<string> indexNumeros = new List<string> { };

            int index = 1;
            int tentativas = 1;

            Titulo();

            //alimentando matriz
            index = AlimentandoMatriz(matriz, indexNumeros, index);

            //imprimindo matriz
            ImprimindoMatriz(matriz);

            Console.Write($"Você quer jogar [{turno}] em qual posição: ");
            //Começando o jogo
            string jogada = Console.ReadLine();

            Console.Clear();

            while (tentativas < 9)
            {
                Titulo();

                for (int i = 0; i < matriz.GetLength(0); i++)
                {
                    for (int j = 0; j < matriz.GetLength(1); j++)
                    {
                        if (matriz[i, j] == jogada && indexNumeros.Contains(jogada))
                        {
                            matriz[i, j] = turno;
                            indexNumeros.Remove(jogada);
                        }
                    }
                }

                ImprimindoMatriz(matriz);

                if (matriz[0, 0] == matriz[1, 1] && matriz[1, 1] == matriz[2, 2] ||
                    matriz[0, 2] == matriz[1, 1] && matriz[1, 1] == matriz[2, 0])
                {
                    FimDeJogo(turno);
                    break;
                }

                if (matriz[0, 0] == matriz[0, 1] && matriz[0, 1] == matriz[0, 2] ||
                    matriz[1, 0] == matriz[1, 1] && matriz[1, 1] == matriz[1, 2] ||
                    matriz[2, 0] == matriz[2, 1] && matriz[2, 1] == matriz[2, 2]
                    )
                {
                    FimDeJogo(turno);
                    break;
                }

                if (matriz[0, 0] == matriz[1, 0] && matriz[1, 0] == matriz[2, 0] ||
                    matriz[0, 1] == matriz[1, 1] && matriz[1, 1] == matriz[2, 1] ||
                    matriz[0, 2] == matriz[1, 2] && matriz[1, 2] == matriz[2, 2]
                    )
                {
                    FimDeJogo(turno);
                    break;
                }


                if (turno == "X")
                {
                    turno = "O";
                }
                else
                {
                    turno = "X";
                }

                Console.WriteLine();
                Console.Write($"Você quer jogar [{turno}] em qual posição: ");
                jogada = Console.ReadLine();

                while (!indexNumeros.Contains(jogada))
                {
                    Console.WriteLine("Jogada inválida, tente novamente!");
                    Console.Write("Digite novamente o valor!");

                    jogada = Console.ReadLine();
                }

                tentativas++;
                Console.Clear();
            }
            if (tentativas == 9)
            {
                Console.WriteLine();
                Console.WriteLine("------------------------------------");
                Console.WriteLine("----FIM DE JOGO, A VELHA GANHOU-----");
                Console.WriteLine("------------------------------------");
            }

            Console.ReadLine();
        }

        private static void FimDeJogo(string turno)
        {
            Console.WriteLine();
            Console.WriteLine("------------------------------------");
            Console.WriteLine("-----------FIM DE JOGO--------------");
            Console.WriteLine("------------------------------------");
            Console.WriteLine($"PARABENS!!! O ganhador é: [{turno}]");
        }

        private static void ImprimindoMatriz(string[,] matriz)
        {
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    Console.Write($" [{matriz[i, j]}] ");
                }
                Console.WriteLine();
            }
        }

        private static int AlimentandoMatriz(string[,] matriz, List<string> indexNumeros, int index)
        {
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    matriz[i, j] = index.ToString();
                    indexNumeros.Add(index.ToString());
                    index++;
                }
            }

            return index;
        }

        private static void Titulo()
        {
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("---------------JOGO DA VELHA---------------");
            Console.WriteLine("-------------------------------------------");
        }

    }
}
