# ExcelenciaD
para iniciar todo, hacer add-migration
luego hacer update-database
de ahi correrlo al proyecto mediante https y utilizar el crud de dicha api.
ejemplos de creacion de clientes.
{
    "Name": "NombreCliente",
    "LastName": "ApellidoCliente",
    "Email": "cliente@correo.com",
    "Phone": "123456789",
    "Address": "DirecciónCliente",
    "City": "CiudadCliente",
    "Country": "PaisCliente"
}
Ejemplos de creacion de pedido.
{
    "CustomerId": 1,
    "FechaPedido": "2024-02-27T09:42:36.999Z",
    "Total": "TotalPedido",
    "Detalles": "DetallesPedido"
}
por lo general la fecha de pedido se pone automaticamente en el body del json de swagger por lo tanto solamente habria que hacer el customer que se le quiere agregar ese pedido y los demas
ejemplos de patch 
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
    Customers!
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

