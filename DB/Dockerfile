FROM mcr.microsoft.com/mssql/server:2019-latest

USER root

RUN mkdir -p /usr/src/app
WORKDIR /usr/src/app

# Add sql setup to image
COPY setup.sql /usr/src/app/

# Switch back to mssql user and run the entrypoint script
USER mssql
ENTRYPOINT /opt/mssql/bin/sqlservr