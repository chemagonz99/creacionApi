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

