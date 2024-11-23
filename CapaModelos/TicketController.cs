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
            // Transformación de negocio a datos
            ClienteEntity clienteEntity;
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
            else if (ticket.Cliente is PersonaNatural persona)
            {
                clienteEntity = new PersonaNaturalEntity
                {
                    Nombre = persona.Nombre,
                    Rut = persona.Rut,
                    Telefono = persona.Telefono,
                    Email = persona.Email
                };
            }
            else
            {
                return "Tipo de cliente no válido";
            }

            var ticketEntity = new TicketEntity
            {
                Id = ticket.Id,
                Producto = ticket.Producto,
                Descripcion = ticket.Descripcion,
                Estado = ticket.Estado,
                Cliente = clienteEntity
            };

            ticketData.Add(ticketEntity);
            return "Ticket creado con éxito";
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
