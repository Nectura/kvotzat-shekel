# kvotzat-shekel

Docker container script in case you want to run the database locally. I went with PostgreSQL.

<br/>

PostgreSQL.bat:
```
  docker run -p 5432:5432 --name PostgreSQL -e POSTGRES_DB=kvotzat_shekel -e POSTGRES_USER=root -e POSTGRES_PASSWORD=Pac@0port -d postgres:latest
  pause
```
