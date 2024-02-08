1.CRUD USER
-Obtener User
````
Curl
Este comando curl es una herramienta de línea de comandos utilizada para realizar solicitudes a servidores web utilizando varios protocolos, como HTTP, HTTPS, FTP, etc. En este caso, se está utilizando para realizar una solicitud GET a un servidor local que está ejecutando en el puerto 7158 y se está solicitando datos del recurso "Crud" con un parámetro de consulta correo=chema%40gmail.com.

Aquí está la explicación detallada de los componentes del comando y la respuesta:

curl: Es el comando en sí mismo, que inicia la solicitud.
````
[
  {
    "idUser": 5,
    "users": "chema",
    "pass": "pass",
    "email": "chema@gmail.com",
    "administrator": null,
    "manager": null,
    "idNegocio": null,
    "validated": null
  }
]

2.CRUD UpdateUser
````
curl -X 'PUT' \
  'https://localhost:7158/Crud?id=5&newEmail=chemagonz%40gmail.com' \
  -H 'accept: */*'
````


Este comando curl es similar al anterior, pero en lugar de una solicitud GET, se está realizando una solicitud PUT al mismo servidor local en el puerto 7158.
Esta solicitud PUT está destinada a actualizar los datos del usuario con el ID 5 en el servidor. Específicamente, parece que se está actualizando la dirección de correo electrónico del usuario de "chema@gmail.com" a "chemagonz@gmail.com".

3.CRUD createUser

````
curl -X 'POST' \
  'https://localhost:7158/Crud/createUser' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "users": "franciscojose",
  "pass": "hola",
  "email": "j.gonzalez@gmail.com",
  "administrator": 0,
  "manager": 0,
  "idNegocio": 0,
  "validated": 0
}'
````

La solicitud POST está destinada a crear un nuevo usuario en el servidor con la información proporcionada en el objeto JSON. 
Este comando curl es una solicitud POST que se utiliza para crear un nuevo usuario en el servidor local que se ejecuta en el puerto 7158

4.CRUD deleteUser

````
curl -X 'DELETE' \
  'https://localhost:7158/Crud/deleteUser?correo=chemagonz%40gmail.com' \
  -H 'accept: */*'
````
Este comando curl es una solicitud DELETE que se utiliza para eliminar un usuario en el servidor local que se ejecuta en el puerto 7158. 
La solicitud DELETE está destinada a eliminar un usuario del servidor cuya dirección de correo electrónico coincide con "chemagonz@gmail.com".

CRUD PELICULAS

1.CRUD para crear Peliculas
````
curl -X 'POST' \
  'https://localhost:7158/peliculas/createPeliculas' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "idPelicula": 1,
  "nombre": "hola",
  "anio": 1998,
  "descripcion": "hola"
}'
````
La solicitud POST está destinada a crear una nueva película en el servidor con la información proporcionada en el objeto JSON.

2.CRUD para Actualizar una pelicula

````
curl -X 'PUT' \
  'https://localhost:7158/peliculas?id=1&newAnio=2022' \
  -H 'accept: */*'
````
La solicitud PUT está destinada a actualizar el año de la película identificada por el ID 1 en el servidor, estableciendo el año como 2022.

3.CRUD para obtener las peliculas

````
curl -X 'GET' \
  'https://localhost:7158/peliculas?nombre1=hola' \
  -H 'accept: text/plain'
````
La solicitud GET está destinada a recuperar información sobre películas que coincidan con el nombre introducido, en este caso "hola".

4.CRUD para eliminar peliculas

````
curl -X 'DELETE' \
  'https://localhost:7158/peliculas/deletePeliculas?nombre=hola' \
  -H 'accept: */*'
````
La solicitud DELETE está destinada a eliminar las peliculas que coincidan con el nombre introducido, "hola".

