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
        protected void ddlTipoCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (ddlTipoCliente.SelectedValue == "Empresa")
            {
                txtrazonSocial.Enabled = true; 
            }
            else
            {
                txtrazonSocial.Enabled = false;  
                txtrazonSocial.Text = ""; // Limpia el campo
            }
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente
            {
                
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