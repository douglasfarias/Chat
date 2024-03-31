# Use uma imagem base do Node.js
FROM node:latest AS builder

# Defina o diretório de trabalho no container
WORKDIR /app

# Copie o package.json e o package-lock.json para o diretório de trabalho
COPY Chat.WebApp/package*.json ./

# Instale as dependências do projeto
RUN npm install

# Copie todos os arquivos do projeto para o diretório de trabalho
COPY Chat.WebApp .

# Execute o comando de construção do Angular (substitua "ng build" pelos seus próprios comandos, se necessário)
RUN npm run build

# Segunda etapa: criação de uma imagem Nginx leve para servir o aplicativo Angular
FROM nginx:latest

# Copie os arquivos de compilação do aplicativo Angular da etapa anterior para o diretório padrão do Nginx
COPY --from=builder /app/dist/* /usr/share/nginx/html/

# Exponha a porta padrão 80 do Nginx
EXPOSE 80

# Defina a porta que o Nginx irá escutar usando uma variável de ambiente
ENV NGINX_PORT 80

# Copie o arquivo de configuração personalizado do Nginx
COPY --from=builder /app/nginx.conf.template /etc/nginx/nginx.conf.template

# Comando para substituir a porta no arquivo de configuração do Nginx e iniciar o servidor Nginx em execução em segundo plano quando o contêiner for iniciado
CMD envsubst '$NGINX_PORT' < /etc/nginx/nginx.conf.template > /etc/nginx/nginx.conf && nginx -g 'daemon off;'
