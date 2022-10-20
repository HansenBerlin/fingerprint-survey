FROM nginx:stable-alpine
COPY ./certs/localhost.crt /etc/ssl/certs
COPY ./certs/localhost.key /etc/ssl/private
EXPOSE 80/tcp
EXPOSE 443/tcp
CMD ["/bin/sh", "-c", "exec nginx -g 'daemon off;';"]