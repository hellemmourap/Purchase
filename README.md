# Purchase

O projeto consiste no desenvolvimento de uma aplicação que permite aos usuários criarem novos pedidos de compra,
associados a fornecedores, e adicionar itens a esses pedidos. Os usuários também podem visualizar, 
editar e excluir pedidos.

# Tecnologias Utilizadas
- Asp.Net Core (MVC)
- HTML/CSS/JavaScript
- Entity Framework Core
- SqlServer

## Pré-requisitos
- **SDK do .NET Core**: Você precisa ter o SDK do .NET Core instalado em sua máquina. Você pode baixá-lo [aqui](https://dotnet.microsoft.com/download).
- **SQL Server Management Studio (SSMS)**: para gerenciar e interagir diretamente com o banco de dados.

## Dependências
- **Microsoft.EntityFrameworkCore.SqlServer**:  Ele fornece os componentes necessários para permitir que o Entity Framework Core se comunique com um banco de dados SQL Server.
- **Microsoft.EntityFrameworkCore.Tools**: Fornece acesso aos comandos do Entity Framework Core no terminal ou prompt de comando, facilitando o gerenciamento do seu banco de dados e do modelo de dados.
  
# Como Executar o Projeto
1. **Clonar o Repositório**: Clone este repositório em sua máquina local.
2. **Configurar o Ambiente**: Certifique-se de ter o ambiente .NET Core configurado em sua máquina.
3. **Banco de Dados**: Configure o banco de dados conforme as instruções no arquivo appsettings.json.
4. **Executar o Projeto**: Use o comando dotnet run para iniciar o servidor local.
5. **Acesso ao Aplicativo**: Acesse o aplicativo em seu navegador utilizando o endereço local fornecido pelo servidor.

# Observações
No projeto, o acesso às páginas é feito por meio de rotas. Uma rota é um caminho específico dentro da nossa aplicação que leva a uma determinada página. 
Por exemplo, se quisermos acessar a página de login de produtos, digitamos "/Product/Login" na barra de endereço do navegador.

Ao executar o projeto e ter acesso ao aplicativo, certifique-se de editar a url como esta abaixo.

Exemplo: 
- localhost/{NomeDoControlador}/{NomeDaAção} : localhost/Product/Login

"Product" é o controlador que está lidando com essa solicitação.
"Login" é a ação dentro desse controlador, ou seja, a função que é executada para lidar com a solicitação de login.
Dessa forma, quando digitamos "/Product/Login", o sistema sabe que precisa ir até o controlador "Product" e executar a ação "Login" para nos mostrar a página de login dos produtos.

Essa abordagem torna a navegação na nossa aplicação mais intuitiva e organizada, pois podemos acessar diferentes partes do sistema simplesmente digitando as URLs correspondentes no navegador.

É fundamental que todos os controladores e ações do projeto sejam visualizados para garantir que a aplicação seja completamente analisada. Os controladores e ações representam as diferentes 
partes e funcionalidades da aplicação, ou seja, é essencial para garantir que o sistema funcione corretamente e atenda aos requisitos do usuário.

