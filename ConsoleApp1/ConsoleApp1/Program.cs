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
            string nome1;
            string nome2;
            bool situacaoJogo = true;
            int contador = 0;
            int acabou;

            //Preenche a matriz com a String "-"
            for (int l = 0; l < matriz.GetLength(0); l++)
            {
                for (int c = 0; c < matriz.GetLength(1); c++)
                {
                    matriz[l, c] = "-";
                }
            }

            Console.WriteLine("\t   ########### JOGO DA VELHA ###########");
            Console.WriteLine("\n");
            //Pergunta os nomes dos jogadores, verifica se são iguais ou nulos.
            do
            {
                Console.Write("Digite o nome do primeiro jogador: ");
                nome1 = Console.ReadLine();
                Console.Write("Digite o nome do segundo jogador: ");
                nome2 = Console.ReadLine();

                if (nome1.Trim(' ') == "")
                {
                    nome1 = "jogador 1";
                    Console.WriteLine("Nome 1 digitado em branco, valor padrão atribuido: " + nome1);
                }
                if (nome2.Trim(' ') == "")
                {
                    nome2 = "jogador 2";
                    Console.WriteLine("Nome 2 digitado em branco, valor padrão atribuido: " + nome2);
                }
                if (nome1 == nome2)
                {
                    Console.WriteLine("\nOs nomes não podem ser iguais !");
                }
            } while (nome1 == nome2 || nome1.Trim(' ') == "" || nome2.Trim(' ') == "");

            ImprimirJogo(matriz);
            Console.WriteLine("\nObs: Digite apenas números de 1 a 3");

            //mantém o jogo rodando até a condição situacaoJogo mudar !
            //contador usado para diferenciar o jogador 1 do jogador 2!
            do
            {
                if (contador % 2 == 0)
                {
                    Inserir(matriz, jogador1, nome1);
                }
                else
                {
                    Inserir(matriz, jogador2, nome2);
                }

                Console.Clear();
                ImprimirJogo(matriz);

                if (contador > 3)
                {
                    acabou = VerificaStatus(matriz);

                    if (acabou == 0)
                    {
                        Console.WriteLine("Empatou !");
                        situacaoJogo = false;
                    }
                    else if (acabou == 1)
                    {
                        Console.WriteLine(nome1 + " ganhou !");
                        situacaoJogo = false;
                    }
                    else if (acabou == 2)
                    {
                        Console.WriteLine(nome2 + " ganhou !");
                        situacaoJogo = false;
                    }
                }
                contador++;
            } while (situacaoJogo == true);

            Console.Write("PRESS ANY KEY TO CONTINUE...");
            Console.ReadKey();
        }

        static void Inserir(string[,] matriz, string jogador, string nome)
        {
            int linha = 0;
            int coluna = 0;

            bool ocupado;
            do
            {
                try
                {
                    Console.WriteLine();
                    Console.WriteLine("Vez do(a) " + nome);
                    Console.Write("Digite a linha: ");
                    linha = int.Parse(Console.ReadLine());
                    Console.Write("Digite a Coluna: ");
                    coluna = int.Parse(Console.ReadLine());

                    ocupado = VerificaPos(linha - 1, coluna - 1, matriz);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Digite um número inteiro !");
                    ocupado = true;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Digite um número menor !");
                    ocupado = true;
                }

                if (!ocupado)
                {
                    matriz[linha - 1, coluna - 1] = jogador;
                }

            } while (ocupado);
            return;
        }

        static bool VerificaPos(int linha, int coluna, string[,] matriz)
        {
            try
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
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Digite um número entre 1 e 3 !");
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
                        Console.Write("\t\t  " + matriz[l, c]);
                    }
                    else
                    {
                        Console.Write("  |  " + matriz[l, c]);
                    }

                }
                Console.WriteLine();
                if (l < 2)
                {
                    Console.Write("\t\t-----------------");
                }
            }
        }
        static int VerificaStatus(string[,] matriz)
        {
            string ganhador = "";
            bool ganhou = false;
            bool continuar = false;

            //Linha 1 ganhou {​​​​​​​0,0}​​​​​​​{​​​​​​​0,1}​​​​​​​{​​​​​​​0,2}​​​​​​​ 
            if (matriz[0, 0] != "-" && (matriz[0, 0] == matriz[0, 1]))
            {
                if (matriz[0, 1] == matriz[0, 2])
                {
                    ganhador = matriz[0, 0];
                    ganhou = true;
                }
            }

            //Linha 2 ganhou {​​​​​​​1,0}​​​​​​​{​​​​​​​1,1}​​​​​​​{​​​​​​​1,2}
            if (ganhou == false && matriz[1, 0] != "-" && (matriz[1, 0] == matriz[1, 1]))
            {
                if (matriz[1, 1] == matriz[1, 2])
                {
                    ganhador = matriz[1, 0];
                    ganhou = true;
                }
            }

            //Linha 3 ganhou {​​​​​​​2,0}​​​​​​​{​​​​​​​2,1}​​​​​​​{​​​​​​​2,2}
            if (ganhou == false && matriz[2, 0] != "-" && (matriz[2, 0] == matriz[2, 1]))
            {
                if (matriz[2, 1] == matriz[2, 2])
                {
                    ganhador = matriz[2, 0];
                    ganhou = true;
                }
            }

            //Coluna 1 ganhou {​​​​​​​0,0}​​​​​​​{​​​​​​​1,0}​​​​​​​{​​​​​​​2,0}​​​​​​​
            if (ganhou == false && matriz[0, 0] != "-" && (matriz[0, 0] == matriz[1, 0]))
            {
                if (matriz[1, 0] == matriz[2, 0])
                {
                    ganhador = matriz[0, 0];
                    ganhou = true;
                }
            }

            //Coluna 2 ganhou {​​​​​​​0,1}​​​​​​​{​​​​​​​1,1}​​​​​​​{​​​​​​​2,1}​​​​​​​
            if (ganhou == false && matriz[0, 1] != "-" && (matriz[0, 1] == matriz[1, 1]))
            {
                if (matriz[1, 1] == matriz[2, 1])
                {
                    ganhador = matriz[0, 1];
                    ganhou = true;
                }
            }

            //Coluna 3 ganhou {​​​​​​​0,2}​​​​​​​{​​​​​​​1,2}​​​​​​​{​​​​​​​2,2}
            if (ganhou == false && matriz[0, 2] != "-" && (matriz[0, 2] == matriz[1, 2]))
            {
                if (matriz[1, 2] == matriz[2, 2])
                {
                    ganhador = matriz[0, 2];
                    ganhou = true;
                }
            }

            //Diagonal principal {​​​​​​​0,0}​​​​​​​{​​​​​​​1,1}​​​​​​​{​​​​​​​2,2}​​​​​​​
            if (ganhou == false && matriz[0, 0] != "-" && (matriz[0, 0] == matriz[1, 1]))
            {
                if (matriz[1, 1] == matriz[2, 2])
                {
                    ganhador = matriz[0, 0];
                    ganhou = true;
                }
            }

            //Diagonal principal {​​​​​​​0,2}​​​​​​​{​​​​​​​1,1}​​​​​​​{​​​​​​​2,0}​​​​​​​
            if (ganhou == false && matriz[0, 2] != "-" && (matriz[0, 2] == matriz[1, 1]))
            {
                if (matriz[1, 1] == matriz[2, 0])
                {
                    ganhador = matriz[0, 2];
                    ganhou = true;
                }
            }

            //verifica se há um vencedor!
            if (ganhou)
            {
                if (ganhador == "X")
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }

            for (int l = 0; l < matriz.GetLength(0) && continuar == false; l++)
            {
                for (int c = 0; c < matriz.GetLength(1) && continuar == false; c++)
                {
                    if (matriz[l, c] == "-")
                        continuar = true;
                }
            }

            if (continuar == true)
            {
                return 3;
            }
            else
            {
                return 0;
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