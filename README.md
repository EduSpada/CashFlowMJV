# CashFlow

CashFlow é uma WEB API responsável por registrar um fluxo de caixa para comerciantes ou até mesmo para uso pessoal, foi desenvolvido com .NET Core 6.



## Autores

- [@EduSpada](https://www.github.com/EduSpada)


## Implantação no [Azure](https://portal.azure.com/) em Produção como Demonstração

 - [CashFlow no Azure](https://cashflowmjv.azurewebsites.net/)



## Instalação Local
### Pré-requisitos
Será necessário ter instalado:
#### SDK do ASP.NET Core Runtime 6.0.14 para sua distribuição específica
- [Linux](https://learn.microsoft.com/dotnet/core/install/linux?WT.mc_id=dotnet-35129-website)
- [macOS](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-6.0.406-macos-x64-installer)
- [Windows](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-6.0.406-windows-x64-installer)

#### Entity Framework Core tools para o CLI

Após a instalação do SDK do ASP.NET Core execute o seguinte comando.
```bash
  dotnet tool install --global dotnet-ef
```
    
## Deploy
### Conectando com o banco de dados
Para fazer o deploy desse projeto será necessário configurar um banco de dados Mysql limpo no arquivo appsettings.json que está no projeto CashFlowMvc.WebUI.

Para a configuração do banco de dados é necessário configurar na variável "MysqlConnectionString" uma ConnectionString, seu arquivo deve ficar parecido com o json abaixo:

```json

{
  "ConnectionStrings": {
    "DefaultConnectionString": "Data Source=CashFlow.db",
    "MysqlConnectionString": "Server=NameIPServer;Port=3306;Database=cashflowmydb;User ID=CashFlowSysAdm; Password=SuaSenha"
},
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```
### Build
Utilize o comando abaixo no diretório raiz para buildar e instalar as dependências da solução.
```bash
  dotnet build
```
### Realizando a Migration

Com o Entity Framework Core tools instalado execute no diretório da solução o comando:
```bash
  dotnet ef  migrations remove --project CashFlowMvc.Infra.Data -s CashFlowMvc.WebUI -c ApplicationDbContext --verbose
```
Esse comando limpará as migrations anteriores para evitar erros no update, caso acontecer algum erro pode fazer manualmente escluindo a pasta Migrations do projeto CashFlowMvc.Infra.Data.

Em seguida adicione uma nova migration com o comando:
```bash
  dotnet ef  migrations add initial --project CashFlowMvc.Infra.Data -s CashFlowMvc.WebUI -c ApplicationDbContext --verbose
```
Esse comando cria os arquivos de migrations.

E por fim, se tudo ocorreu bem, execute o comando de update a seguir:
```bash
  dotnet ef database update --project CashFlowMvc.Infra.Data -s CashFlowMvc.WebUI -c ApplicationDbContext --verbose
```
Esse comando consistirá as tabelas e os dados preexistentes no banco de dados.



## Executando o projeto

Execute o comando abaixo na pasta raiz do projeto.
```bash
  dotnet run --project .\CashFlowMvc.WebUI\CashFlowMvc.WebUI.csproj
```

Assim que concluir a execução o projeto estará executando no link abaixo:

- [Cash Flow Localhost](https://localhost:7263/)
## Funcionalidades

- Métodos de Pagamento

É posível criar, editar e excluir métodos de pagamento, e funcionam como a categoria da operação, eles tem o atributo de direção que ajuda a entender se a operação foi de entrada ou saída do fluxo de caixa.
- Operaçóes

É posível criar, editar e excluir operações classificando-as conforme a ocorrência, elas serão exibidas em verde para entradas e vermelho para saídas.

- Operaçóes/ByDate?dateOp=yyy-mm-dd
É posível visualizar operações por dia, e o saldo total do balanço.

- Usuários
É possivel criar novos usuários.


## Usuários Padrão para Teste local

Na primeira execução, é excutado um seed que inclui alguns usuários de teste com diferentes niveis de segurança, são eles:

- usuario@localhost
Possui permissão de visualizar todas as páginas, mas não pode criar, deletar ou editar os registros.

- employer@localhost
Possui permissão de visualizar todas as páginas, criar métodos de pagamento e operações, mas não pode editar ou deletar os registros nem criar usuários.

- manager@localhost
Possui permissão de visualizar todas as páginas, criar, editar e deletar métodos de pagamento e operações, mas não pode criar usuários.

- admin@localhost
Não possui permissão de visualizar todas as páginas, criar, editar e deletar métodos de pagamento e operações, mas pode exclusivamente novos criar usuários.

Por padrão a senha é UmASenh@F04t3 exemplificando o padrão que deve ser adotado para novos usuários.
Obs.: Para implementar em produção as senhas devem ser alteradas. É necessário apenas um usuário Admin para dar início ao projeto.

