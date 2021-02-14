using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] matriz = new string[3, 3];
            string jogador1 = "X";
            string jogador2 = "O";
            int contador = 0;
            bool situacaoJogo = true;
            int acabou;

            for (int l = 0; l < matriz.GetLength(0); l++)
            {
                for (int c = 0; c < matriz.GetLength(1); c++)
                {
                    matriz[l, c] = "-";
                }
            }

            Console.Write("Digite o nome do primeiro jogador: ");
            string nome1 = Console.ReadLine();
            Console.Write("Digite o nome do segundo jogador: ");
            string nome2 = Console.ReadLine();

            do
            {
                if (contador % 2 == 0)
                {
                    Inserir(matriz, jogador1, nome1);
                    ImprimirJogo(matriz);
                    acabou = VerificaStatus(matriz, jogador1);
                }
                else
                {
                    Inserir(matriz, jogador2, nome2);
                    ImprimirJogo(matriz);
                    acabou = VerificaStatus(matriz, jogador2);
                }

                if (acabou == 0)
                {
                    Console.WriteLine("Empatou !");
                    situacaoJogo = false;
                }
                else if (acabou == 1)
                {
                    Console.WriteLine("Jogador 1 ganhou !");
                    situacaoJogo = false;
                }
                else if (acabou == 2)
                {
                    Console.WriteLine("Jogador 2 ganhou !");
                    situacaoJogo = false;
                }

                contador++;
            } while (situacaoJogo == true);

            Console.WriteLine("PRESS ANY KEY TO CONTINUE...");
            Console.ReadKey();
        }

        static void Inserir(string[,] matriz, string jogador, string nome)
        {
            int linha;
            int coluna;

            bool ocupado;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Vez do jogador " + nome);
                Console.Write("Digite a linha: ");
                linha = int.Parse(Console.ReadLine());
                Console.Write("Digite a Coluna: ");
                coluna = int.Parse(Console.ReadLine());

                ocupado = VerificaPos((linha - 1), (coluna - 1), matriz);

                for (int l = 0; l < matriz.GetLength(0); l++)
                {
                    for (int c = 0; c < matriz.GetLength(1); c++)
                    {
                        if (!ocupado && l == linha && c == coluna)
                        {
                            matriz[linha - 1, coluna - 1] = jogador;
                        }
                    }
                }
            } while (ocupado);
        }

        static bool VerificaPos(int linha, int coluna, string[,] matriz)
        {
            if (matriz[linha, coluna] == "-")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Posição inválidia ou ocupada !");
                Console.WriteLine();
                return true;
            }
        }

        static void ImprimirJogo(string[,] matriz)
        {
            for (int l = 0; l < matriz.GetLength(0); l++)
            {
                Console.WriteLine("\t");
                for (int c = 0; c < matriz.GetLength(1); c++)
                {
                    if (c == 0)
                    {
                        Console.Write("\t  " + matriz[l, c]);
                    }
                    else
                    {
                        Console.Write("  |  " + matriz[l, c]);
                    }

                }
                Console.WriteLine();
                if (l < 2)
                {
                    Console.Write("\t-----------------");
                }
            }
        }
        static int VerificaStatus(string[,] matriz, string jogador)
        {
            int situacaoJogo;
            int diagonal1 = 0;
            int diagonal2 = 0;
            bool continuar = false;

            if (jogador == "X")
            {
                situacaoJogo = 1;
            }
            else
            {
                situacaoJogo = 2;
            }

            //retorna ganhador coluna igual
            for (int c = 0; c < matriz.GetLength(1); c++)
            {
                int contador = 0;
                for (int l = 0; l < matriz.GetLength(0); l++)
                {
                    if (matriz[l, c] == jogador)
                    {
                        contador++;
                    }
                }
                if (contador == 3)
                {
                    return situacaoJogo;
                }
            }
            //retorna ganhador linha igual
            for (int l = 0; l < matriz.GetLength(0); l++)
            {
                int contador = 0;
                for (int c = 0; c < matriz.GetLength(1); c++)
                {
                    if (matriz[l, c] == jogador)
                    {
                        contador++;
                    }
                }
                if (contador == 3)
                {
                    return situacaoJogo;
                }
            }

            //retorna ganhador diagonal principal

            for (int l = 0; l < matriz.GetLength(0); l++)
            {
                if (matriz[l, l] == jogador)
                {
                    diagonal1++;
                }

                if (diagonal1 == 3)
                {
                    return situacaoJogo;
                }
            }

            //retorna ganhador diagonal secundária
            for (int l = 0, c = matriz.GetLength(1) - 1; l < matriz.GetLength(0); l++, c--)
            {
                if (matriz[l, c] == jogador)
                {
                    diagonal2++;
                }

                if (diagonal2 == 3)
                {
                    return situacaoJogo;
                }
            }

            //Verifica se há posições para continuar o jogo.
            for (int l = 0; l < matriz.GetLength(0); l++)
            {
                for (int c = 0; c < matriz.GetLength(1); c++)
                {
                    if (matriz[l, c] == "-")
                    {
                        continuar = true;
                    }
                }
            }
            //retorna se o jogo irá continuar ou se empatou !
            if (!continuar)
            {
                return 0;
            }
            else
            {
                return 3;
            }
        }
    }
}



/*x matriz[l, 0]
x matriz[l,1]
x matriz[l, 2]
-------------------
x x matriz[l, l]
x matriz[l, l]
x x 2,0 1,1, 2,0
--------------------
x x x matriz[0, linha]
x x x matriz[1, linha]
x x x matriz[2, linha]*/

/*
         String [] resp = new string [2];
         Console.Write("Digite a linha e a coluna: " + (resp[0] = Console.ReadLine()) + ", " + (resp[1] = Console.ReadLine()));
         vet[0] = int.Parse(resp[0]);
         vet[1] = int.Parse(resp[1]);*/