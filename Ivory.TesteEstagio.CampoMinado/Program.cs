using System;
using System.Collections.Generic;

namespace Ivory.TesteEstagio.CampoMinado
{
    public class Program
    {
        static void Main(string[] args)
        {
            var campoMinado = new CampoMinado();
            Console.WriteLine("Início do jogo\n=========");
            Console.WriteLine(campoMinado.Tabuleiro);
            Console.ReadLine();

            /* Algoritmo capaz de resolver o jogo Campo Minado, cujo tabuleiro é encontrado na classe CampoMinado
             * Teste para estágio na empresa Ivory IT
             * 
             * Autor: Gabriel Pinheiro de Campos
            */

            // Instanciando classe ResolveCampo
            var resolveCampo = new ResolveCampo(campoMinado.Tabuleiro);

            // Criando lista que ira armazenar as posicoes das bombas
            List<Posicao> bombas = new List<Posicao>();
            var status = 0;

            // Iniciando loop while que tem como condicao de parada o status do jogo estar em "Aberto"
            while (status == 0)
            { 
                var campo = resolveCampo.getCampo();

                // Percorrendo o campo minado
                for (int x = 0; x < 9; x++)
                {
                    for (int y = 0; y < 9; y++)
                    {
                        var numFechados = 0;
                        var numBombas = 0;

                        // Lista que ira armazenar as posicoes dos vizinhos que estao "fechados"
                        List<Posicao> fechados = new List<Posicao>();

                        // Analisando situacoes em que a casa nao esteja em uma das extremidades do campo e que nao seja a posicao de uma bomba
                        if (campo[x, y] != "-" && campo[x, y] != "*" && x != 0 && x != 8 && y != 0 && y != 8)
                        {
                            // Variavel que ira armazenar as coordenadas de cada vizinho
                            var vizinhos = resolveCampo.EncontraVizinhos(x, y);

                            // Verifica a situacao de cada vizinho. Caso esteja fechado, incrementa o numero de casas fechadas e adiciona sua posicao na lista de fechados
                            // Caso o vizinho seja uma bomba, incrementa a variavel que controla o numero de bombas.
                            foreach (var pos in vizinhos)  
                            {
                                if (campo[pos.x, pos.y] == "-")
                                {
                                    numFechados++;
                                    fechados.Add(pos);
                                }
                                else if (campo[pos.x, pos.y] == "*")
                                {  
                                    numBombas++;
                                }

                            }

                            // Verifica se o numero da casa analisada no campo é igual a soma do numero das bombas com o numero das posicoes vizinhas fechadas
                            // Caso positivo, marca os vizinhos como bombas
                            if (campo[x, y] == (numFechados + numBombas).ToString())
                            {                                                                  
                                foreach (var pos in fechados)
                                {
                                    campo.SetValue("*", pos.x, pos.y);
                                    bombas.Add(pos);
                                }
                            }
                            // Caso o numero de bombas seja igual ao numero da casa analisada, realiza a abertura de todos os vizinhos
                            else if (numBombas.ToString() == campo[x, y])
                            {   
                                foreach (var pos in fechados)     
                                {
                                    campoMinado.Abrir(pos.x + 1, pos.y + 1);
                                }
                            }

                            // Atualiza o Tabuleiro para a próxima iteração
                            var novo_tabuleiro = campoMinado.Tabuleiro;
                            resolveCampo.RenovaTabuleiro(novo_tabuleiro);
                            resolveCampo.MarcaBombas(bombas);
                        }
                    }
                }

                // Atualiza o status do jogo
                status = campoMinado.JogoStatus;
            }

            Console.WriteLine("Resultado:\n");

            if (status == 1)
            {
                Console.WriteLine("Você ganhou!");
                Console.WriteLine(campoMinado.Tabuleiro);
                Console.ReadLine();
            }

            else if (status == 2)
            {
                Console.WriteLine("Você perdeu!");
                Console.WriteLine(campoMinado.Tabuleiro);
                Console.ReadLine();
            }

            Console.WriteLine("\n");
            Console.WriteLine("Tabuleiro Resolvido:");
            Console.WriteLine(resolveCampo);
            Console.ReadLine();

            // Fim do programa
        }

    }
}
