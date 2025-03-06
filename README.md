Guia de Uso da Aplicação Rota Viagem Barata

Como Executar a Aplicação

Pré-requisitos
	* .NET 8 SDK instalado
	* Editor de código como Visual Studio

Passos para Execução do Codigo no Visual Studio
	* Abra o Visual Studio
	* Certifique-se de que "RotaDeViagens.App" esta definido como startup project
		* Se nao tiver definido como "startup project" clique com botao direito no "RotaDeViagens.App" e selecione a opcao "set as startup project"
	* No menu superior do Visual Studio localize o botao em verde onde diz "RotaDeViagens.App" e clique para executar.

Para executar os testes unitários:
	* Expanda o projeto "RotaDeViagens.Test" 
	* Abra o arquivo "UnitTest1.cs"
	* Localize "UnitTest1" e clique com botao direito e clique na opcao "Run Tests"

Estrutura dos Arquivos/Pacotes

RotaDeViagens/
App/          		  	  # Contém o ponto de entrada do programa
  - Main.cs           	 	  # Classe principal para chamar o servico
  - RotaAppService.cs 	 	  # Classe principal com a interface de entrada
    
Resources/            	  	  # Arquivos de dados
  - rotas.txt         		  # Arquivo contendo as rotas disponíveis
    
Core/                 	 	  # Regras de negócio da aplicação
  - GerenciadorRotas.cs  	  # Lógica para encontrar e adicionar rotas
    
Shared/               	 	  # Compartilhamento de dados e constantes
  - AppSettings.cs      	  # Constantes como mensagens utilizadas na aplicação, fica mais facil para manutencao
  - MelhorRota.cs        	  # Property class - Classe para armazenar a melhor rota encontrada (poderia ser utilizado DTO)
  - Rota.cs              	  # Property class - Representação de uma rota individual (poderia ser utilizado DTO)

Tests/                	 	  # Testes unitários com xUnit
  - UnitTest1.cs  	          # Testes para o gerenciador de rotas
 
Decisões de Design
	Separação de Responsabilidades:
	O código segue a arquitetura em camadas: 
 
		- App (ponto de entrada), 
		- Core (lógica de negócios), 
		- Shared (dados compartilhados) e Tests (testes unitários).

Persistência em Arquivo:
	O arquivo rotas.txt é utilizado para armazenar as rotas de maneira simples e eficiente, sem necessidade de banco de dados.

Evita Dijkstra:
	O algoritmo de busca de rotas mais baratas usa backtracking para garantir a busca do menor custo sem usar Dijkstra.

Testabilidade:
	Testes unitários com xUnit garantem a qualidade do código, validando a busca da melhor rota e a adição de novas rotas.
