# Primeira Web API

Minha Web API é uma aplicação web baseada em ASP.NET Core que fornece um conjunto de serviços para gerenciar produtos. Esta API permite a criação, leitura, atualização e exclusão de informações de produtos.

## Recursos Principais

- **Obter Todos os Produtos**: A API permite a recuperação de todos os produtos armazenados.
- **Obter Produto por ID**: Você pode buscar informações detalhadas de um produto específico com base no seu ID.
- **Adicionar Produto**: Adicione um novo produto com detalhes como nome, preço e estoque.
- **Atualizar Produto**: Atualize as informações de um produto existente.
- **Excluir Produto**: Remova um produto com base no seu ID.


## Requisitos e Dependências

Antes de executar esta aplicação, certifique-se de que você tenha as seguintes dependências instaladas:

- **Entity Framework Core**: Esta aplicação utiliza o Entity Framework Core para acesso a dados. Certifique-se que você tem o EF instalado em sua máquina. Você pode instalá-lo via [Documentação da Microsoft](https://learn.microsoft.com/pt-br/ef/core/get-started/overview/install).

- **MySQL Database**: A aplicação requer um banco de dados MySQL. Certifique-se de configurar um servidor MySQL e fornecer as informações de conexão necessárias no arquivo de configuração.

- **Pomelo.EntityFrameworkCore.MySql**: Esta aplicação utiliza o Pomelo.EntityFrameworkCore.MySql como provedor do MySQL para o Entity Framework Core.

- **Newtonsoft.Json**: Esta aplicação utiliza o Newtonsoft.Json para manipulação de JSON. Você pode instalá-lo via [NuGet](https://www.nuget.org/packages/Newtonsoft.Json/).

## Configuração do Banco de Dados

Antes de executar a aplicação, é necessário configurar o acesso ao banco de dados MySQL. Abra o arquivo `appsettings.json` e forneça as informações de conexão corretas no mesmo, seguindo o padrão que se encontra. Ele já está preenchido com as configurações padrões de uso necessitando apenas à alteração da senha no arquivo.

Para aplicar migrações e atualizar o banco de dados, você pode usar o seguinte comando: `dotnet ef database update`

## Como Usar

A seguir, explicaremos como usar os principais recursos da nossa Web API.

### Obter Todos os Produtos (GET) 
`GET /api/ProdutosFromSql`
Para obter uma lista de todos os produtos, você pode fazer uma solicitação GET, aplicando apenas um EXECUTE via Swagger e ele irá retornar a lista de todos os produtos existentes.
### Obter Produto por ID (GET)
`GET /api/ProdutosFromSql/{id}`
Para buscar informações detalhadas de um produto específico com base no seu ID, você pode fazer uma solicitação GET, digitando apenas o ID do produto em específico na URI. 

### Adicionar Produto (POST)
`POST /api/ProdutosFromSql`
Para adicionar um novo produto, você pode fazer uma solicitação POST. Lembre-se de que você não precisa incluir o `produtoId` e o `valorTotal` no corpo da solicitação.

```json
{
  "nome": "Nome do Produto",
  "preco": 99.99,
  "estoque": 50,
  "dataCadastro": "2023-10-11T21:49:39.444Z"
}
```

### Atualizar Produto (PUT)
`PUT /api/ProdutosFromSql`
Para atualizar as informações de um produto existente, você pode fazer uma solicitação PUT. Certifique-se de incluir o produtoId no corpo da solicitação para identificar o produto a ser atualizado.
```json
{
  "produtoId": 1,  // ID do produto a ser atualizado, deve corresponder ao ID digitado na URI
  "nome": "Novo Nome do Produto",
  "preco": 129.99,
  "estoque": 75,
  "dataCadastro": "2023-10-11T21:49:39.444Z"
}
```

### Excluir Produto (DELETE)
`DELETE /api/ProdutosFromSql`
Para excluir um produto específico com base no seu ID, você pode fazer uma solicitação DELETE digitando apenas o ID do produto em específico na URI.


A mesma forma de uso vale para os endpoints usados para salvar produto diretamente em um arquivo.json.


### Baixar o Projeto

Se você deseja baixar o projeto, tem duas opções:

1. **Clone o Repositório**: Você pode clonar este repositório diretamente para sua máquina local. Use o seguinte comando em seu terminal:

```bash
   git clone https://github.com/devgoes/WebApi-Csharp.git
```
2. **Baixe o Arquivo do Projeto**
 Também disponibilizo o arquivo do projeto para download direto. Clique no link abaixo para iniciar o download: [arquivo do projeto](https://drive.google.com/file/d/18Vn2Pn_9tJUENCBMtYqAocLmR2DffBQC/view?usp=drive_link)

### Contribuições e Feedback

Sua opinião é valiosa! Estou abertos a sugestões, críticas construtivas e contribuições para melhorar este projeto. Se você tiver alguma ideia, encontrar um problema ou desejar contribuir de alguma forma, sinta-se à vontade para:

- Abrir uma Issue para reportar problemas ou propor melhorias.
- Enviar um Pull Request (PR) com suas contribuições e correções.
- Compartilhar suas sugestões ou feedback através da minha rede social: [Linkdisney](https://www.linkedin.com/in/jdgoes/)

Agradeço sua colaboração e apoio para tornar este projeto ainda melhor!
