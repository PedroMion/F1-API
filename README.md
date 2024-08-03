# pt-BR 🇧🇷
## 🏎️ F1-API

Este projeto consiste em uma base de dados contendo informações sobre a competição de automobilismo Fórmula 1, com dados relacionados aos pilotos, suas nacionalidades, equipes, corridas e diversas outras características. O intuito da API é retornar um grid game, com 6 perguntas e 9 quadrados. Separando em 2 grupos de 3 perguntas, cada quadrado é uma interseção entre as respostas possíveis para duas perguntas. Além disso, há um controller de dados para que as informações dos pilotos possam ser atualizadas após cada corrida de forma automatizada. Mais detalhes técnicos à frente.

### 📖 Sobre este projeto
- API: C# (.NET framework).
- Banco de dados: SQL Server.
- Site: HTML, CSS e JavaScript.

### 🪑 Base de dados
Para que este projeto fosse possível, foi necessário reunir os dados da fórmula 1, principalmente de pilotos, em uma base de dados contendo o máximo de informações possível. Para reunir os dados, foram utilizados alguns datasets do Kaggle em conjunto com arquivos python para ler, interpretar e limpar os dados. Além disso, muitos dados foram coletados da WikiPedia para complementar a base e possibilitar maior versatilidade nos jogos (Manualmente e via Web Scrapping). Os datasets utilizados serão listados no fim deste documento. Após reunir os dados dos pilotos, foram criadas as perguntas utilizadas no jogo, baseado nas informações disponíveis. As perguntas foram separadas entre 6 grupos (6 perguntas por jogo) para tentar evitar quadrados onde as respostas de uma das perguntas é subconjunto das respostas da outra (Ex: Campeão mundial e Bicampeão mundial). Com a base pronta, já com os dados, iniciou-se a construção da API.

### 📺 API
A API possui 2 controllers, cada um com uma função distinta. O principal, GameController, retorna jogos já existentes e é capaz de gerar novos automaticamente. DataController, possibilita fazer algumas alterações nos dados (ou consultá-los) sem ir diretamente na base.

#### 🕹️ GameController
