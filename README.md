# pt-BR 🇧🇷
## 🏎️ F1-API

Este projeto consiste em uma base de dados contendo informações sobre a competição de automobilismo Fórmula 1, com dados relacionados aos pilotos, suas nacionalidades, equipes, corridas e diversas outras características. O intuito da API é retornar um grid game, com 6 perguntas e 9 quadrados. Separando em 2 grupos de 3 perguntas, cada quadrado é uma interseção entre as respostas possíveis para duas perguntas. Além disso, há um controller de dados para que as informações dos pilotos possam ser atualizadas após cada corrida de forma automatizada. Mais detalhes técnicos à frente.

### 📖 Sobre este projeto
- Tecnologia: C# (.NET framework).
- Banco de dados: SQL Server.
- GameController: 2 endpoints, um retorna um jogo pela sua data de referência. Caso este seja o primeiro pedido para essa data e a data esteja em um range de + ou - 1 dia para o horário do servidor, um novo jogo será gerado automaticamente. O segundo endpoint retorna por ID, para que seja possível jogar partidas passadas.
- DataController: 1 endpoint, recebe informações sobre uma corrida e atualiza os dados dos pilotos considerando a corrida, quantidade de pontos, vitórias e as demais informações que necessitem atualização.

### 💻 Base de dados
Para que este projeto fosse possível, foi necessário reunir os dados da fórmula 1, principalmente de pilotos, em uma base de dados contendo o máximo de informações possível. Para reunir os dados, foram utilizados alguns datasets do Kaggle em conjunto com arquivos python para ler, interpretar e limpar os dados. Além disso, muitos dados foram coletados da WikiPedia para complementar a base e possibilitar maior versatilidade nos jogos (Manualmente e via Web Scrapping). Os datasets utilizados serão listados no fim deste documento.

### API
