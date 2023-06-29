using System;
using System.Collections.Generic;
using System.Text;

namespace Ivory.TesteEstagio.CampoMinado
{
    public struct Posicao
    {
        public int x;
        public int y;

        public Posicao(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public class ResolveCampo
    {
        // Propriedades
        private string _tabuleiro;

        private string[,] campo = new string[9, 9];

        private List<Posicao> fechados = new List<Posicao>() { };

        // Construtor
        public ResolveCampo(string tabuleiro)
        {
            _tabuleiro = tabuleiro;

            LimpaTabuleiro();    //// prepara a String Tabuleiro para popular a matriz

            ConverteTabuleiroParaMatriz();  /// popula a matriz com a String tabuleiro Tratada;

        }

        // Metodos e funcoes

        /// <summary>
        /// Metodo que limpa e converte para matriz o tabuleiro recebido no parametro.
        /// </summary>
        /// <param name="tabuleiro"></param>
        public void RenovaTabuleiro(string tabuleiro)
        {
            _tabuleiro = tabuleiro;

            LimpaTabuleiro();

            ConverteTabuleiroParaMatriz();
        }

        /// <summary>
        /// Metodo que atualiza o campo com as posicoes das bombas na lista recebida por parametro.
        /// </summary>
        /// <param name="bombas"></param>
        public void MarcaBombas(List<Posicao> bombas)
        {
            foreach (var bomba in bombas)
            {
                campo.SetValue("*", bomba.x, bomba.y);
            }
        }

        /// <summary>
        /// Retorna o a matriz do campo
        /// </summary>
        /// <returns></returns>
        public string[,] getCampo()
        {
            return campo;
        }

        /// <summary>
        /// Retorna uma lista de posicoes das casas que estao fechadas
        /// </summary>
        /// <returns></returns>
        public List<Posicao> getFechados()
        {
            return fechados;
        }

        /// <summary>
        /// Metodo que identifica as posicoes das casas que estao fechadas e as adiciona na lista "fechados"
        /// </summary>
        public void identifica_fechados()
        {
            fechados.Clear();
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    if (campo[x, y] == "-")
                    {
                        Posicao posicao = new Posicao(x, y);
                        fechados.Add(posicao);
                    }
                }
            }
        }

        /// <summary>
        /// Retira da string tabuleiro elementos como \n e \r
        /// </summary>
        public void LimpaTabuleiro()
        {
            string tabuleiroLimpo = "";
            foreach (char value in _tabuleiro)
            {
                if (value == '0' || value == '1' || value == '2' || value == '3' || value == '4' || value == '-')
                {
                    tabuleiroLimpo += value;
                }
            }
            _tabuleiro = tabuleiroLimpo;
        }

        public void ConverteTabuleiroParaMatriz()
        {
            int item = 0;
            for (int x = 0; x < 9; x++)
            {

                for (int y = 0; y < 9; y++)
                {

                    campo.SetValue(_tabuleiro[item].ToString(), x, y);
                    item++;

                }
            }
        }

        public override string ToString()
        {
            string aux = "";
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    aux += campo.GetValue(x, y);
                }
                aux += "\n";
            }
            return aux;
        }

        /// <summary>
        /// Funcao que recebe as posicoes x e y do elemento e devolve uma lista contendo as posicoes das casas vizinhas a ele
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public List<Posicao> EncontraVizinhos(int x, int y)
        {
            List<Posicao> vizinhos = new List<Posicao>() {
            new Posicao(x - 1, y - 1),
            new Posicao(x    , y - 1),
            new Posicao(x + 1, y - 1),
            new Posicao(x - 1, y),
            new Posicao(x + 1, y),
            new Posicao(x - 1, y + 1),
            new Posicao(x    , y + 1),
            new Posicao(x + 1, y + 1),
        };
            return vizinhos;
        }
    }
}