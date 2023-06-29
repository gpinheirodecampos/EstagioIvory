# Algoritmo completo
## Introdução
Este repositório foi criado com o propósito de resolver o teste para estágio da empresa Ivory IT.
Desenvolvi o algoritmo de forma clara e concisa, documentando adequadamente todos os métodos, funções e variáveis.
Além disso, abaixo exponho em forma de texto o passo a passo do programa, explicando mais detalhadamente meu raciocínio durante a elaboração do algoritmo.

## Passo a passo
A classe `ResolveCampo` é criada com o objetivo de armazenar todas as propriedades, métodos e funções necessárias para a análise de cada casa do Tabuleiro do Campo Minado.

Primeiro, instanciamos a classe utilizando seu construtor e passando como parâmetro o tabuleiro pré-estabelecido na classe `CampoMinado`.

O construtor atribui à nova string tabuleiro o valor recebido como parâmetro e chama o método `LimpaTabuleiro`, que tem como principal objetivo preparar o novo tabuleiro para popular a matriz que iremos criar.

O método void `LimpaTabuleiro` não recebe parâmetro e realiza sua função da seguinte forma: é feito uma análise de todos os caracteres que foram dispostos na propriedade privada `_tabuleiro` e basicamente remove todos os que não forem números ou traços, que são os “\r” e “\n”. Dessa forma, torna-se possível transformar o que antes era uma string unidimensional com caracteres especiais em uma matriz disposta apenas com os elementos que farão parte da análise do tabuleiro.

Após a limpeza no tabuleiro, agora podemos realizar sua conversão para a matriz, e este é o segundo método realizado pelo construtor `ResolveCampo`.

Feito isso, agora é iniciada a etapa de identificação da localização das bombas no tabuleiro. Para isso, criamos uma lista que irá armazenar as posições dessas bombas e inicializamos uma variável de status para ter controle da situação atual do jogo. Enquanto ele for zero, ou seja, enquanto o jogo estiver “Em Aberto”, iremos realizar as iterações.

Recebemos o campo da classe e o armazenamos em uma variável, e então iniciamos um loop com 2 for para percorrer a matriz do campo. Criamos duas variáveis de controle que irão armazenar os valores de casas fechadas e o número de bombas que são inicializadas com o valor zero. Uma nova lista é criada para armazenar as posições de cada um dos vizinhos (que são as casas ao redor do elemento analisado) que estejam fechadas. Então, um if é criado para realizarmos a análise dos elementos que já estão abertos e não estejam na extremidade, ou seja, daqueles elementos cujas posições x e y não sejam 0 ou 8 (ou 1 e 9 se formos considerar o padrão seguido da função de abrir as casas na classe principal `CampoMinado`).

Uma nova variável é criada e irá armazenar as posições vizinhas do elemento analisado, e isso é feito através de uma função da classe `ResolveCampo` que irá retornar uma lista com as posições das 8 casas vizinhas. Sabendo quem são os vizinhos, uma análise é feita com um loop `foreach` e dois casos serão tratados: a do vizinho que ainda não foi aberto e a do vizinho que é uma bomba. Caso esteja fechado, iremos aumentar o número da variável de controle numFechados e iremos adicionar a sua posição à lista que armazena as posições das casas fechadas. Caso seja uma bomba, aumentaremos o número da variável de controle `numBombas`.

Em seguida, iniciamos uma análise para verificar se a posição do campo em questão se trata de uma bomba ou não. Para isso, é realizada uma verificação da soma das bombas e das posições fechadas na vizinhança. Caso seja igual ao número do campo na posição `x y`, então os campos fechados serão marcados como bomba, e o valor destes vizinhos será alterado em nosso campo como bombas `(*)` e suas posições serão adicionadas à lista bombas. Agora, caso o número de bombas for igual ao número do campo na posição x y, todos os vizinhos que estão fechados poderão ser abertos.

Após realizadas as análises, atualizamos o tabuleiro criando a variável `novoTabuleiro`, e definimos seu valor com o tabuleiro da classe instanciada `campoMinado`. Ou seja, após as devidas mudanças, agora podemos atualizar nosso tabuleiro. Seguindo esta lógica, usamos o método `renovaTabuleiro` passando como parâmetro o `novoTabuleiro` e, desta forma, atualizamos a propriedade _tabuleiro da classe `ResolveCampo` com o parâmetro da função.

Para finalizar esta etapa, usamos a função marcaBombas, passando como parâmetro a lista que armazena as posições das bombas, para atribuir a posição do campo em que estão as bombas e alterar seu valor para `“*”`.

Encerramos o comando while atualizando o status do jogo para continuar ou parar quando o jogo for finalizado.
