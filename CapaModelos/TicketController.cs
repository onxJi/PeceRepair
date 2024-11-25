using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelos
{
    public static class TicketController
    {
        private static List<TicketEntity> ticketData = new List<TicketEntity>();

        public static string Create(Ticket ticket)
        {
            // Validar que el ticket no sea nulo
            if (ticket == null)
            {
                return "El ticket no puede ser nulo.";
            }

            // Validar que el estado sea válido
            if (string.IsNullOrEmpty(ticket.Estado))
            {
                return "El estado del cliente es obligatorio.";
            }

            // Transformar datos del ticket según el tipo de cliente
            ClienteEntity clienteEntity;

            if (ticket.Estado.Equals("Empresa", StringComparison.OrdinalIgnoreCase))
            {
                // Asegúrate de que el ticket tiene los datos necesarios para una empresa
                if (ticket.Cliente is Empresa empresa)
                {
                    clienteEntity = new EmpresaEntity
                    {
                        Nombre = empresa.Nombre,
                        Rut = empresa.Rut,
                        Telefono = empresa.Telefono,
                        Email = empresa.Email,
                        RazonSocial = empresa.RazonSocial
                    };
                }
                else
                {
                    return "Los datos de la empresa son inválidos.";
                }
            }
            else if (ticket.Estado.Equals("PersonaNatural", StringComparison.OrdinalIgnoreCase))
            {

                clienteEntity = new PersonaNaturalEntity
                {
                       
                    Nombre = ticket.Cliente.Nombre,
                    Rut = ticket.Cliente.Rut,
                    Telefono = ticket.Cliente.Telefono,
                    Email = ticket.Cliente.Email
                };

            }
            else
            {
                return "El tipo de cliente no es válido.";
            }

            // Crear entidad de ticket
            var ticketEntity = new TicketEntity
            {
                Id = ticket.Id,
                Producto = ticket.Producto,
                Descripcion = ticket.Descripcion,
                Estado = ticket.Estado,
                Cliente = clienteEntity // Asignar el cliente dinámicamente
            };

            // Guardar en la colección
            ticketData.Add(ticketEntity);

            var mensaje = new StringBuilder();
            mensaje.AppendLine("Lista de tickets creados:");

            foreach (var t in ticketData)
            {
                mensaje.AppendLine(t.getValor());
            }

            return mensaje.ToString();
        }


        public static Ticket Read(string id)
        {
            var ticketEntity = ticketData.Find(t => t.Id == id);
            if (ticketEntity == null) return null;

            Cliente cliente;
            switch (ticketEntity.Cliente)
            {
                case EmpresaEntity empresaEntity:
                    cliente = new Empresa
                    {
                        Nombre = empresaEntity.Nombre,
                        Rut = empresaEntity.Rut,
                        Telefono = empresaEntity.Telefono,
                        Email = empresaEntity.Email,
                        RazonSocial = empresaEntity.RazonSocial
                    };
                    break;

                case PersonaNaturalEntity personaEntity:
                    cliente = new PersonaNatural
                    {
                        Nombre = personaEntity.Nombre,
                        Rut = personaEntity.Rut,
                        Telefono = personaEntity.Telefono,
                        Email = personaEntity.Email
                    };
                    break;

                default:
                    cliente = null;
                    break;
            }

            return new Ticket
            {
                Id = ticketEntity.Id,
                Producto = ticketEntity.Producto,
                Descripcion = ticketEntity.Descripcion,
                Estado = ticketEntity.Estado,
                Cliente = cliente
            };
        }

        public static string Update(string id, string producto, string descripcion, string estado, string email, string telefono)
        {
            var ticketEntity = ticketData.Find(t => t.Id == id);
            if (ticketEntity == null) return "Ticket no encontrado";

            ticketEntity.Producto = producto;
            ticketEntity.Descripcion = descripcion;
            ticketEntity.Estado = estado;

            ticketEntity.Cliente.Email = email;
            ticketEntity.Cliente.Telefono = telefono;

            return "Ticket actualizado con éxito";
        }

        public static string Delete(string id)
        {
            var ticketEntity = ticketData.Find(t => t.Id == id);
            if (ticketEntity == null) return "Ticket no encontrado";

            ticketData.Remove(ticketEntity);
            return "Ticket eliminado con éxito";
        }

        public static List<Ticket> ReadAll()
        {
            return ticketData.Select(ticketEntity =>
            {
                Cliente cliente;

                switch (ticketEntity.Cliente)
                {
                    case EmpresaEntity empresaEntity:
                        cliente = new Empresa
                        {
                            Nombre = empresaEntity.Nombre,
                            Rut = empresaEntity.Rut,
                            Telefono = empresaEntity.Telefono,
                            Email = empresaEntity.Email,
                            RazonSocial = empresaEntity.RazonSocial
                        };
                        break;

                    case PersonaNaturalEntity personaEntity:
                        cliente = new PersonaNatural
                        {
                            Nombre = personaEntity.Nombre,
                            Rut = personaEntity.Rut,
                            Telefono = personaEntity.Telefono,
                            Email = personaEntity.Email
                        };
                        break;

                    default:
                        cliente = null;
                        break;
                }


                return new Ticket
                {
                    Id = ticketEntity.Id,
                    Producto = ticketEntity.Producto,
                    Descripcion = ticketEntity.Descripcion,
                    Estado = ticketEntity.Estado,
                    Cliente = cliente
                };
            }).ToList();
        }

        public static List<Ticket> Search(string query)
        {
            return ticketData
                .Where(ticketEntity =>
                    ticketEntity.Cliente.Nombre.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    ticketEntity.Cliente.Rut.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    ticketEntity.Estado.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0)
                .Select(ticketEntity =>
                {
                    Cliente cliente;

                    switch (ticketEntity.Cliente)
                    {
                        case EmpresaEntity empresaEntity:
                            cliente = new Empresa
                            {
                                Nombre = empresaEntity.Nombre,
                                Rut = empresaEntity.Rut,
                                Telefono = empresaEntity.Telefono,
                                Email = empresaEntity.Email,
                                RazonSocial = empresaEntity.RazonSocial
                            };
                            break;

                        case PersonaNaturalEntity personaEntity:
                            cliente = new PersonaNatural
                            {
                                Nombre = personaEntity.Nombre,
                                Rut = personaEntity.Rut,
                                Telefono = personaEntity.Telefono,
                                Email = personaEntity.Email
                            };
                            break;

                        default:
                            cliente = null;
                            break;
                    }


                    return new Ticket
                    {
                        Id = ticketEntity.Id,
                        Producto = ticketEntity.Producto,
                        Descripcion = ticketEntity.Descripcion,
                        Estado = ticketEntity.Estado,
                        Cliente = cliente
                    };
                }).ToList();
        }
    }

}
