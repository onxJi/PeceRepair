using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class TicketEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public ClienteEntity Cliente { get; set; }
        public string Producto { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        private DateTime _createdAt { get; set; } = DateTime.Now;

        public DateTime getCreateAt()
        {
            return _createdAt;
        }

        public string getValor()
        {
            return $"Cliente: {Cliente.getValor()}, Producto: {Producto}, Descripción: {Descripcion}, Estado: {Estado}, Id: {Id}, Creado en: {_createdAt}";
        }
    }
}
