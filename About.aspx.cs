using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaModelos;

namespace PcesRepair
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente
            {
                Id = Guid.NewGuid().ToString(),
                Nombre = txtNombre.Text.Trim(),
                Rut = txtRut.Text,
                Telefono = txtTelefono.Text,
                Email = txtEmail.Text
            };
            Ticket ticket = new Ticket
            {
                Id = Guid.NewGuid().ToString(),
                Cliente = cliente,
                Producto = txtProducto.Text,
                Descripcion = txtDescripcion.Text,
                Estado = ddlTipoCliente.SelectedValue
            };

         
            string mensaje = TicketController.Create(ticket);
            lblMensaje.Text = mensaje;
        }
    }
}