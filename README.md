# Chat

Este é um projeto de **serviço de chat** desenvolvido para facilitar a comunicação entre usuários. Aqui estão algumas informações importantes sobre o projeto:

## Descrição do Projeto
O **Chat Service** é uma aplicação que permite que os usuários conversem em tempo real. Ele oferece uma interface simples e intuitiva para troca de mensagens.

## Funcionalidades
- **Histórico de Conversas**: O serviço mantém um registro das mensagens trocadas.
- **Envio de Mensagens** (Em desenvolvimento): Os usuários podem enviar mensagens de texto para outros participantes do chat.
- **Notificações em Tempo Real** (Em desenvolvimento): As mensagens são entregues instantaneamente aos destinatários.

## Como Utilizar
1. Clone este repositório para sua máquina local.
2. Crie um banco de dados Sql Server
3. Adicione a Connection String ao arquivo ```Chat.Api/appsettings.json``` no atributo **DefaultConnection** da seção **ConnectionStrings**
4. Execute as migrações do Entity Framework ```dotnet ef database update```
5. Execute os arquivos de script contidos em ```Chat.Infrastructure/Scripts```
6. Execute o servidor de chat.
7. Abra o cliente de chat em seu navegador ou aplicativo de chat preferido.
8. Comece a conversar!

## Tecnologias Utilizadas
- **ASP .NET Core**: Para o backend do servidor.
- **Next.js**: Para o frontend do cliente.

## Contribuidores
- [Douglas Farias](https://github.com/douglasfarias) - Desenvolvedor principal

## Licença
Este projeto está sob a licença MIT. Consulte o arquivo [LICENSE](LICENSE) para obter mais detalhes.
