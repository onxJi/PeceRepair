using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public static class TicketEntityCollection
    {
        private static List<TicketEntity> _listadoTickets = new List<TicketEntity>();

        private static List<TicketEntity> ListadoTicket
        {
            get => _listadoTickets; 
            set => _listadoTickets = value;
        }

    }
}
