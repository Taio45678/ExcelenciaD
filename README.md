# ExcelenciaD

## Instrucciones de Inicio

Para iniciar el proyecto, sigue estos pasos:

1. Ejecuta el comando `add-migration` para crear la migración.

   ```bash
   add-migration
   ```

2. Después, ejecuta el comando `update-database` para aplicar las migraciones.

   ```bash
   update-database
   ```

3. Inicia el proyecto y utilízalo mediante HTTPS. Puedes utilizar el CRUD de la API.

## Ejemplos de Creación de Clientes

Ejemplo de JSON para la creación de clientes:

```json
{
    "Name": "NombreCliente",
    "LastName": "ApellidoCliente",
    "Email": "cliente@correo.com",
    "Phone": "123456789",
    "Address": "DirecciónCliente",
    "City": "CiudadCliente",
    "Country": "PaisCliente"
}
```

## Ejemplos de Creación de Pedidos

Ejemplo de JSON para la creación de pedidos:

```json
{
    "CustomerId": 1,
    "FechaPedido": "2024-02-27T09:42:36.999Z",
    "Total": "TotalPedido",
    "Detalles": "DetallesPedido"
}
```

Por lo general, la fecha de pedido se genera automáticamente en el cuerpo del JSON en Swagger. Solamente es necesario proporcionar el cliente al que se le desea agregar ese pedido y los demás detalles.

## Ejemplos de Parcheo (Patch)

Ejemplos de JSON para operaciones de parcheo (patch):

### Parcheo de Pedidos

```json
[
    {
        "op": "replace",
        "path": "/Detalles",
        "value": "NuevosDetalles"
    },
    {
        "op": "add",
        "path": "/Total",
        "value": "NuevoTotal"
    }
   
]
```

### Parcheo de Clientes

```json
[
    {
        "op": "replace",
        "path": "/Name",
        "value": "NuevoNombre"
    },
    {
        "op": "replace",
        "path": "/Email",
        "value": "nuevo@correo.com"
    }
    
]
```

¡Listo para comenzar con ExcelenciaD!
