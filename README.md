# Projeto .Net Aspire

Este repositório fornece um template e diretrizes para a criação de um projeto .Net Aspire em .Net 8.

## Pré-requisitos

Antes de começar, certifique-se de ter o seguinte instalado na sua máquina:

- [.Net 8](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker Desktop](https://www.docker.com/products/docker-desktop)
- [Visual Studio](https://visualstudio.microsoft.com/) ou [Visual Studio Code](https://code.visualstudio.com/)

## Instalação

Para instalar a carga de trabalho do .Net Aspire (SDK), execute o seguinte comando:

```sh
dotnet workload install aspire
````

## Criação de um Projeto

Você pode criar um projeto .Net Aspire de duas formas:

1. Aplicação .Net Aspire

Esta opção cria os dois projetos básicos do .Net Aspire: AppHost e ServiceDefaults.

```sh
dotnet new aspire --use-redis-cache --output DotnetAspireBasico
````

2. Aplicação Inicial .Net Aspire
   
Esta opção cria os dois projetos básicos (AppHost e ServiceDefaults) juntamente com dois projetos de exemplo (ApiService e Web).

```sh
dotnet new aspire-starter --use-redis-cache --output . --name AspireBasico
````

## Execução do Dashboard
Para executar o dashboard, siga estes passos:

- Entre na pasta onde se encontra o projeto AspireStarterBasico.AppHost.

- Execute o seguinte comando:

```sh
dotnet run
````

- Nas informações geradas, você encontrará a URL para acessar o dashboard, que já inclui o token de autenticação.

- Se encontrar problemas com certificados, utilize o comando:

```sh
dotnet dev-certs https --trust
````

## Criar uma MinimalAPI

Para criar uma MinimalAPI, siga estes passos:

- Entre na pasta do microsserviço e crie o projeto:

```sh
dotnet new web -o AspireBasico.MinimalApiService
````

- Adicione o projeto ao projeto .AppHost:

  - No arquivo .csproj do .AppHost, adicione a referência para o projeto criado:

```xml
<ProjectReference Include="..\AspireBasico.MinimalApiService\AspireBasico.MinimalApiService.csproj" />
````````

  - No Program.cs do .AppHost, adicione o projeto:

````csharp
builder.AddProject<Projects.AspireBasico_MinimalApiService>("minimalApiService");
````

- Adicione as dependências necessárias ao projeto criado:

  - No arquivo .csproj do projeto criado, adicione a dependência para o projeto ServiceDefaults:

```xml
<ProjectReference Include="..\AspireBasico.ServiceDefaults\AspireBasico.ServiceDefaults.csproj" />[
````

  - No Program.cs do projeto criado, adicione o serviço do Aspire:

```csharp
builder.AddServiceDefaults();
````

## Resumo
Este repositório fornece um template para configurar um projeto .Net Aspire com templates de aplicação básica e inicial. 

Siga os comandos fornecidos para criar e executar seu projeto, e utilize as diretrizes para adicionar um serviço MinimalAPI. 

Aproveite o desenvolvimento com o .Net Aspire!


