using CapaModelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PcesRepair
{
    public partial class ActualizarDatos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Recuperar el UUID desde la URL
                string uuid = Request.QueryString["uuid"];
                if (!string.IsNullOrEmpty(uuid))
                {
                    // Buscar el ticket utilizando el método Read del TicketController
                    var ticket = TicketController.Read(uuid);
                    if (ticket != null)
                    {
                        // datos del ticket a los controles TextBox
                        txtTelefono.Text = ticket.Cliente.Telefono;
                        txtEmail.Text = ticket.Cliente.Email;
                        txtProducto.Text = ticket.Producto;
                        txtDescripcion.Text = ticket.Descripcion;
                    }
                    else
                    {
                        // caso en que no se encuentre el ticket
                        lblMensaje.Text = "No se encontró el ticket con el UUID especificado.";
                        lblMensaje.CssClass = "text-danger";
                    }
                }
                else
                {
                    // caso en que no se reciba un UUID válido
                    lblMensaje.Text = "No se proporcionó un UUID válido.";
                    lblMensaje.CssClass = "text-danger";
                }
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            // Recuperar el UUID desde la URL
            string uuid = Request.QueryString["uuid"];
            if (!string.IsNullOrEmpty(uuid))
            {
                // valores actualizados de los controles TextBox
                string telefono = txtTelefono.Text.Trim();
                string email = txtEmail.Text.Trim();
                string producto = txtProducto.Text.Trim();
                string descripcion = txtDescripcion.Text.Trim();
                string estado = "Actualizado"; 

                // Actualizar el ticket 
                string resultado = TicketController.Update(uuid, producto, descripcion, estado, email, telefono);

                // Mostrar un mensaje de éxito o error
                lblMensaje.Text = resultado;
                lblMensaje.CssClass = resultado.Contains("éxito") ? "text-success" : "text-danger";
            }
            else
            {
                lblMensaje.Text = "No se puede actualizar el ticket debido a un UUID inválido.";
                lblMensaje.CssClass = "text-danger";
            }
        }
    }
}