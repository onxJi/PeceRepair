﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ClienteEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Nombre { get; set; }
        public string Rut { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public string getValor()
        {
            return $"Nombre: {Nombre}, Rut: {Rut}, Teléfono: {Telefono}, Email: {Email}, Id: {Id}";
        }

    }
}
