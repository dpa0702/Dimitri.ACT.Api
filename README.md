# Dimitri ACT MicroServices

O Projeto Dimitri ACT é um exemplo de implementação em microsserviços que utiliza comunicação via HTTP Request e também via mensageria. A ideia central do projeto é que um comerciante controle o seu fluxo de caixa diário com os
lançamentos (débitos e créditos) e também precisa de um relatório que disponibilize o saldo diário consolidado.

## Organização da Solução
A implementação inicial contém 5 projetos, a "API" principal para organização geral do comércio, uma biblioteca de classes "CORE", um microsserviço de lançamentos "EntryMS", um consumidor "CONSUMER" de mensagens que observa a fila da mensageria para executar as ações e um Tests para testar as implementações.

![image](https://github.com/user-attachments/assets/8450086f-353f-44e8-b079-64c3a5ead6fc)

### Dados técnicos de cada projeto

- **Dimitri.ACT.API**
  - Tipo: **WebAPI**
  - Framework: **dotnet 8.0**
  - Porta de Execução:
    - Http: **9000**
    - Https: **9001**
  - Objetivo: Organização geral do comércio

- **Dimitri.ACT.Consumer**
  - Tipo: **Worker**
  - Framework: **dotnet 8.0**
  - Objetivo: Consumir a mensageria e orquestar as ações entre os projetos quando a chamada não é direta via HTTP Request

- **Dimitri.ACT.Core**
  - Tipo: **Class Library**
  - Framework: **dotnet 8.0**
  - Objetivo: Manter as classes comuns, interfaces e DTOs para reaproveitamento na solução e evitar erros de comunicação.

- **Dimitri.ACT.EntryMS [MS = microservice]**
  - Tipo: **WebAPI**
  - Framework: **dotnet 8.0**
  - Porta de Execução:
    - Http: **9002**
    - Https: **9003**
  - Objetivo: Microsserviço responsável pelo domínio das transações.

- **Dimitri.ACT.Tests**
  - Tipo: **MSTest**
  - Framework: **dotnet 8.0**
  - Objetivo: Garantir que cada componente do software funcione conforme o esperado, validando seu comportamento em diferentes cenários e detectando erros de forma precoce no ciclo de desenvolvimento.

## Execução da Solução
A solução foi criada utilizando o Visual Studio com o runtime do dotnet 8.0, banco de dados SQL Server rodando no docker e RabbitMQ rodando no docker com uma imagem do MassTransit, portanto para executar a solução é necessário garantir que todas as tecnologias necessárias estejam em execução (para o banco de dados, pode ser uma instancia local ou em nuvem).

### Banco de dados
Para correto funcionamento da solução, é necessária a criação do banco de dados dentro de um servidor SQL Server:

- **Dimitri.ACT.EntryMS**: A connectionString deverá ser colocada dentro do appsettings do projeto **Dimitri.ACT.EntryMS**. (ConnectionStrings:EntryContext)
Após criados os bancos de dados e atualizadas as connectionStrings nos projetos, será necessário executar a migration do projeto, executando um terminal dentro do diretório do projeto e rodando o comando do entity framework:

```shell
PS c:\Dimitri.ACT.Api\Dimitri.ACT.EntryMS>
$ dotnet ef database update
```

### RabbitMQ

Com o docker executando na máquina basta rodar os comando no terminal:

```shell
$ docker pull masstransit/rabbitmq
```

Após a imagem do masstransit concluir o download (é muito importante manter as portas de execução conforme o exemplo):

```shell
$ docker run -p 15672:15672 -p 5672:5672 masstransit/rabbitmq
```

(para falhas na execução, consultar a documentação oficial: [MassTransit:RabbitMQ](https://masstransit.io/quick-starts/rabbitmq) ).

### Executando a Solução
Com os bancos de dados prontos e o RabbitMQ executando na porta 15672 do localhost, primeiramente vamos configurar a solução para execução com o Visual Studio:

Clicar com o botão direito do mouse em qualquer um dos projetos na solução e selecionar a opção "Configurar Projetos de Inicialização...".

![image](https://github.com/user-attachments/assets/ee2ef3a9-bc83-45da-a8c4-1a0008e4d6e9)

Na caixa de dialogo que será exibida, marcar a opção "Multiple startup projects", e selecionar a ação "Start" para todos os projetos, exceto o Core e Tests.

![image](https://github.com/user-attachments/assets/c17ed23e-b5aa-4d47-aa87-2898746de9be)

Com tudo preparado é só clicar no botão Iniciar na barra de ferramentas do Visual Studio, ou pressonar o botão F5 do teclado.

![image](https://github.com/user-attachments/assets/29debecc-72a3-43c1-a2e4-46e0cf5b837b)

## Exemplo de um fluxo de trabalho

Abaixo veremos ainserção de uma transação no banco de dados:

### Utilizando o sistema para inserir uma transação (Negativo):

![image](https://github.com/user-attachments/assets/cc12588d-f688-43b3-8e13-9464c2f625a7)

#### Banco de Dados

![image](https://github.com/user-attachments/assets/bf5ac74e-460f-4bd0-b566-bda172412c90)

### Utilizando o sistema para inserir uma transação (Positivo):

![image](https://github.com/user-attachments/assets/f797dd35-60f1-4fde-90cb-72921a35e7ac)

#### Banco de Dados

![image](https://github.com/user-attachments/assets/1b7ee21b-f033-4d8f-b204-ced8388841fa)

### Utilizando o sistema para consultar o consolidado do dia:

![image](https://github.com/user-attachments/assets/051c3f49-fb7c-4f17-bde4-51a8a60d64c2)

## Considerações Finais

É possível consultar todas as transações:

![image](https://github.com/user-attachments/assets/634078c4-8c0d-4045-8252-e9b7d7fc46b1)

É possível consultar a transação pelo Id:

![image](https://github.com/user-attachments/assets/5de412be-dee4-4b83-ac8c-8f00dd5d91c4)

Banco de dados Total:

![image](https://github.com/user-attachments/assets/b4a146fd-7682-43f3-bd05-5ca61a50fb02)

