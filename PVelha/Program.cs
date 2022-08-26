using System;
using System.Reflection.Emit;

namespace PVelha
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Quem é o jogador?
            //Criar tabuleiro
            //Qual posição?
            //Verificar posição
            //Substitui o valor
            //Validar a vitoria (linha, coluna, diagonal 1 e diagonal 2)

            string[,] tabela = new string[3, 3]
            {
                {
                    "1","2","3"
                },
                {
                    "4","5","6"
                },
                {
                    "7","8","9"
                }
            };

            static void Titulo()
            {
                Console.WriteLine("----------------------------");
                Console.WriteLine("   JOGO DA VELHA DA JULIA  ");
                Console.WriteLine("----------------------------");
            }

            Titulo();
            Console.WriteLine("Jogador X inicia\n");
            string player = "X";
            Tabuleiro(tabela);

            int jogada = 1;

            while (jogada <= 9)
            {
                Console.WriteLine($"\nDigite o numero para substituição da peça {player}");
                string subs = Console.ReadLine();

                for (int linha = 0; linha < 3; linha++)
                {
                    for (int coluna = 0; coluna < 3; coluna++)
                    {
                        if (tabela[linha, coluna] == subs)
                        {
                            tabela[linha, coluna] = player;
                            jogada++;

                            if (jogada > 0)
                            {
                                VerificaVitoriaLinhas(tabela, player, jogada, linha);
                                VerificaVitoriaColuna(tabela, player, jogada, coluna);
                                VerificaDiagonalPrimaria(tabela, player, jogada, linha, coluna);
                                VerificaDigonalSecundaria(tabela, player, jogada, linha, coluna);
                            }
                            Console.Clear();
                            Titulo();
                            Tabuleiro(tabela);
                            player = (player == "X" ? "O" : "X");
                        }
                    }
                }
            }
        }
        
        private static int VerificaDiagonalPrimaria(string[,] tabela, string player, int jogada, int linha, int coluna)
        {
            bool verificaVitoriadiagonal = (tabela[0, 0] + tabela[1, 1] + tabela[2, 2]) == (player + player + player);
            if (verificaVitoriadiagonal)
            {
                Console.WriteLine($"Parabens o jogador {player} ganhou");
                jogada = 10;
            }

            return jogada;
        }

        private static int VerificaDigonalSecundaria(string[,] tabela, string player, int jogada, int linha, int coluna)
        {
            bool verificaVitoriaDiagonalSecundaria = (tabela[0, 2] + tabela[1, 1] + tabela[2, 0]) == (player + player + player);
            if (verificaVitoriaDiagonalSecundaria)
            {
                Console.WriteLine($"Parabens o jogador {player} ganhou");
                jogada = 10;
            }

            return jogada;
        }

        private static int VerificaVitoriaColuna(string[,] tabela, string player, int jogada, int coluna)
        {
            bool verificaVitoriacoluna = (tabela[0, coluna] + tabela[1, coluna] + tabela[2, coluna]) == (player + player + player);
            if (verificaVitoriacoluna)
            {
                Console.WriteLine($"Parabens o jogador {player} ganhou");
                jogada = 10;
            }

            return jogada;
        }

        private static int VerificaVitoriaLinhas(string[,] tabela, string player, int jogada, int linha)
        {
            bool verificaVitoriaLinha = (tabela[linha, 0] + tabela[linha, 1] + tabela[linha, 2]) == (player + player + player);
            if (verificaVitoriaLinha)
            {
                Console.WriteLine($"Parabens o jogador {player} ganhou");
                jogada = 10;
            }

            return jogada;
        }

        private static int Empate(string[,] tabela, string player, int jogada, int linha, int coluna)
        {
            bool Empate = (jogada == 9);
            if (Empate)
            {
                Console.WriteLine("Deu empate!");
                jogada = 10;
            }

            return jogada;
        }

        private static void Tabuleiro(string[,] tabela)
        {
            for (int linha = 0; linha < 3; linha++)
            {
                for (int coluna = 0; coluna < 3; coluna++)
                {
                    Console.Write($" [{tabela[linha, coluna]}] ");
                }
                Console.WriteLine();
            }
        }        

    }
}
