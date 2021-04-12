using System;


namespace Robo.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int xd = 0; // x direita
            int yd = 0;  // y direita

            int xa = 0; // x atual
            int ya = 0; // y atual
            
            string direitaCoordenada;
            string movimentoRobo;
            string posicaoAtual;
            string orientacao;

            do
            {
                Console.WriteLine("Digite as coordenadas do canto superior direito da tela:");
                direitaCoordenada = Console.ReadLine();

                string[] arraydireito = direitaCoordenada.Split();
               
                xd = Convert.ToInt32(arraydireito[0]);
                yd = Convert.ToInt32(arraydireito[1]);

                if (xd < 0 || yd < 0)
                    Console.WriteLine("Os numeros não podem ser negativos!");
                

            } while (xd < 0 && yd < 0);



            Console.WriteLine("Digite os comandos para movimentar o robô:");
            movimentoRobo = Console.ReadLine();

            

            do
            {
                Console.WriteLine("Digite as coordenadas atuais do robô:");
                posicaoAtual = Console.ReadLine();

                string[] arrayposicao = posicaoAtual.Split();
                xa = Convert.ToInt32(arrayposicao[0]);
                ya = Convert.ToInt32(arrayposicao[1]);
                orientacao = (arrayposicao[2]);
                Console.WriteLine(orientacao);
                if (xa >= xd || ya >= yd)
                    Console.WriteLine("Coordenadas Inválidas para x e y");

                if (xa < 0 || ya < 0)
                    Console.WriteLine("Os numeros não podem ser negativos!");

                if (!ConfereOrientacao(orientacao))
                    Console.WriteLine("Orientação invalida!");

            } while (xa < 0 && ya < 0 && xa >= xd && ya >= yd && !ConfereOrientacao(orientacao));


            char[] movimentoArray = movimentoRobo.ToCharArray();

           
            
            for (int i = 0; i < movimentoArray.Length; i++)
            {
                if (movimentoArray.GetValue(i).Equals("M")|| movimentoArray.GetValue(i).Equals("m")) 
                {

                    if (orientacao == "N")
                    {
                        ya++;
                    }
                    else if (orientacao == "S")
                    {
                        ya--;
                    }

                    else if (orientacao == "L")
                    {
                        xa++;
                    }

                    else if (orientacao == "O") {
                        xa--;
                    }
                }

                else if (movimentoArray.GetValue(i).Equals("E") || movimentoArray.GetValue(i).Equals("e")) {

                    if (orientacao == "N")
                    {
                        
                        orientacao = "O";
                    }

                    else if (orientacao == "O")
                    {
                        orientacao = "S";
                    }

                    else if (orientacao == "S")
                    {
                        orientacao = "L";
                    }

                    else if (orientacao == "L") {
                        orientacao = "N";
                    }


                }

                else if (movimentoArray.GetValue(i).Equals("D") || movimentoArray.GetValue(i).Equals("d")) {

                    if (orientacao == "N")
                    {
                        orientacao = "L";
                    }

                    else if (orientacao == "L")
                    {
                        orientacao = "S";
                    }

                    else if (orientacao == "S")
                    {
                        orientacao = "O";
                    }

                    else if (orientacao == "O")
                    {
                        orientacao = "N";
                    }
                }

            }

            string coordenadas = $"({xa},{ya})  {orientacao}";
            Console.WriteLine(coordenadas);

        }

        private static bool ConfereOrientacao(string orientacao)
        {
            return (orientacao.Equals("N", StringComparison.OrdinalIgnoreCase) || orientacao.Equals("O", StringComparison.OrdinalIgnoreCase) ||
                                orientacao.Equals("L", StringComparison.OrdinalIgnoreCase) || orientacao.Equals("S", StringComparison.OrdinalIgnoreCase));
        }
    }
}
