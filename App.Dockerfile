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

# Exponha a porta padr�o 80 do Nginx
EXPOSE 80

# Defina a porta que o Nginx ir� escutar usando uma vari�vel de ambiente
ENV NGINX_PORT 80

# Copie o arquivo de configura��o personalizado do Nginx
COPY --from=builder /app/nginx.conf.template /etc/nginx/nginx.conf.template

# Comando para substituir a porta no arquivo de configura��o do Nginx e iniciar o servidor Nginx em execu��o em segundo plano quando o cont�iner for iniciado
CMD envsubst '$NGINX_PORT' < /etc/nginx/nginx.conf.template > /etc/nginx/nginx.conf && nginx -g 'daemon off;'
