# Use uma imagem base do Node.js
FROM node:latest AS builder

# Defina o diret�rio de trabalho no container
WORKDIR /app

# Copie o package.json e o package-lock.json para o diret�rio de trabalho
COPY Chat.WebApp/package*.json ./

# Instale as depend�ncias do projeto
RUN npm install

# Copie todos os arquivos do projeto para o diret�rio de trabalho
COPY Chat.WebApp .

# Execute o comando de constru��o do Angular (substitua "ng build" pelos seus pr�prios comandos, se necess�rio)
RUN npm run build

# Segunda etapa: cria��o de uma imagem Nginx leve para servir o aplicativo Angular
FROM nginx:latest

# Copie os arquivos de compila��o do aplicativo Angular da etapa anterior para o diret�rio padr�o do Nginx
COPY --from=builder /app/dist/* /usr/share/nginx/html/

# Exponha a porta 80 para fora do container
EXPOSE 8080

# Comando para iniciar o servidor Nginx em execu��o em segundo plano quando o cont�iner for iniciado
CMD ["nginx", "-g", "daemon off;"]
