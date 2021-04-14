using System;


namespace Robo.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int xd = 0; // x direita
                int yd = 0;  // y direita

                int xa = 0; // x atual
                int ya = 0; // y atual

                string direitaCoordenada;
                string movimentoRobo;
                string posicaoAtual;
                string orientacao;

                bool x = true;
                Console.WriteLine("Deseja mover outro robô?");
                do
                {
                    Console.WriteLine("Digite as coordenadas do canto superior direito da tela:");
                    direitaCoordenada = Console.ReadLine();

                    string[] arraydireito = direitaCoordenada.Split();

                    xd = Convert.ToInt32(arraydireito[0]);
                    yd = Convert.ToInt32(arraydireito[1]);

                    if (NaoNegativo(xd, yd))
                    {
                        Mensagem("Os numeros não podem ser negativos!");
                    }


                } while (NaoNegativo(xd, yd));



                do
                {
                    Console.WriteLine("Digite os comandos para movimentar o robô (E, D, M):");
                    movimentoRobo = Console.ReadLine();
                    x = true;
                    x = ConfereLetra(movimentoRobo, x);

                } while (x == false);





                do
                {
                    Console.WriteLine("Digite as coordenadas atuais do robô:");
                    posicaoAtual = Console.ReadLine();

                    string[] arrayposicao = posicaoAtual.Split();
                    xa = Convert.ToInt32(arrayposicao[0]);
                    ya = Convert.ToInt32(arrayposicao[1]);
                    orientacao = (arrayposicao[2]);


                    if (DentroDoGrafico(xd, yd, xa, ya))
                        Mensagem("Coordenadas Inválidas para x e y");

                    if (NaoNegativo(xa, ya))
                        Mensagem("Os numeros não podem ser negativos! Tente novamente");

                    if (!ConfereOrientacao(orientacao))
                        Mensagem("Orientação invalida!");

                } while (NaoNegativo(xa, ya) || DentroDoGrafico(xd, yd, xa, ya) || !ConfereOrientacao(orientacao));




                foreach (char elemento in movimentoRobo)

                {
                    if (SeFrente(elemento))
                    {
                        MoverRobo(ref xa, ref ya, orientacao);

                    }

                    else if (SeEsquerda(elemento))
                    {
                        orientacao = MoverEsquerda(orientacao);

                    }

                    else if (SeDireita(elemento))
                    {
                        orientacao = MoverDireita(orientacao);

                    }

                }

                if (NaoNegativo(xa, ya) || DentroDoGrafico(xd, yd, xa, ya))
                {
                    Console.WriteLine("Rota inválida!");

                } else
                {
                    string coordenadas = $"({xa},{ya})  {orientacao}";
                    Console.WriteLine(coordenadas);
                }

            }

        }

        private static string MoverDireita(string orientacao)
        {
            if (orientacao == "N"))
                orientacao = "L";


            else if (orientacao == "L")
                orientacao = "S";

            else if (orientacao == "S")
                orientacao = "O";


            else if (orientacao == "O")
                orientacao = "N";
            return orientacao;
        }

        private static string MoverEsquerda(string orientacao)
        {
            if (orientacao == "N")
                orientacao = "O";


            else if (orientacao ==  "O")
                orientacao = "S";


            else if (orientacao == "S")
                orientacao = "L";


            else if (orientacao == "L")
                orientacao = "N";
            return orientacao;
        }

        private static void MoverRobo(ref int xa,  ref int ya, string orientacao)
        {
            if (orientacao == "N")
                ya++;

            else if (orientacao == "S")
                ya--;


            else if (orientacao == "L")
                xa++;


            else if (orientacao == "O")
                xa--;
        }

        private static void Mensagem(string mensagem)
        {
            Console.WriteLine(mensagem);
            Console.ReadLine();
            Console.Clear();
        }

        private static bool SeDireita(char elemento)
        {
            return elemento == 'D' || elemento == 'd';
        }

        private static bool SeEsquerda(char elemento)
        {
            return elemento == 'E' || elemento == 'e';
        }

        private static bool SeFrente(char elemento)
        {
            return elemento == 'M' || elemento == 'm';
        }

        private static bool ConfereLetra(string movimentoRobo, bool x)
        {
            foreach (char elemento in movimentoRobo)
            {
                if (elemento == 'M' || elemento == 'm' || elemento == 'E'
                    || elemento == 'e' || elemento == 'D' || elemento == 'd')
                    x = true;
                else
                {
                    Console.WriteLine("Comando inválido!");
                    x = false;
                }
            }

            return x;
        }

        private static bool NaoNegativo(int xa, int ya)
        {
            return xa < 0 || ya < 0;
        }

        private static bool DentroDoGrafico(int xd, int yd, int xa, int ya)
        {
            return xa > xd || ya > yd;
        }

        private static bool ConfereOrientacao(string orientacao)
        {
            return (orientacao.Equals("N", StringComparison.OrdinalIgnoreCase) || orientacao.Equals("O", StringComparison.OrdinalIgnoreCase) ||
                                orientacao.Equals("L", StringComparison.OrdinalIgnoreCase) || orientacao.Equals("S", StringComparison.OrdinalIgnoreCase));
        }
    }
}
