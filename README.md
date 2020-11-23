# RebelDecrypAPI

## **Objetivo**

Interceptar transmiciones de naves imperiales y decifrar sus mensajes

## **Host**

Es API esta alojada en **Azure** y posee un circuito de integracion continua con **GitHub** sobre la rama **main**

**URL Base:** [Api Rebelde](https://examenml.azurewebsites.net)

## **Tecnologias**

La API esta desarrollada con **.NetCore 3.1**, con test realizados en **XUnit**

## Como ejecutar

### Pre requisitos

- tener instalado el runtime de net core 3.1 lo puedes bajar de este link [dotnet core 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1)

### Ejecutar localmente

1 - Descargar el repositorio
2 - Pararse sobre la carpeta que posee la sln y ejecutar el comando **dotnet restore** para instalar las dependencias del producto
3 - Ejecutar **dotnet build**
4 - Ejecutar **dotnet run**

Si da error de certificados

Ejecutar:

**dotnet dev-certs https --clean**
**dotnet dev-certs https -t**

## EndPoints

### TopSecret

Top secret recibe la informancion de los 3 satelites al mismo tiempo. Aplicando un algoritmo de trilateracion calcula la ubicacion de la nave enemiga y luego revela el mensaje que se estaba intentando transmitir.

**Request**
Url: https://examenml.azurewebsites.net/topsecret
Metodo: Post
Body de ejemplo:

`{ "satellites": [ { "name": "kenobi", "distance": 100.0, "message": ["este", "", "", "mensaje", ""] }, { "name": "skywalker", "distance": 115.5, "message": ["", "es", "", "", "secreto"] }, { "name": "sato", "distance": 142.7, "message": ["este", "", "un", "", ""] } ] } `
**Response**

**OK**
`Status: 200 { "position": { "x": 175.65, "y": 405.07 }, "message": "este es un mensaje secreto" } `
**No Ok**
`Status: 404`
