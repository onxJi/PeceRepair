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

        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            // Validación a nivel de servidor
            if (Page.IsValid)
            {
                // Aquí implementas la lógica para actualizar el ticket
                // Ejemplo: Guardar en la base de datos
                // string telefono = txtTelefono.Text;
                // string email = txtEmail.Text;
                // string producto = txtProducto.Text;
                // string descripcion = txtDescripcion.Text;

                // Redirigir o mostrar un mensaje de éxito
                Response.Write("<script>alert('Ticket actualizado exitosamente');</script>");
            }
            else
            {
                // Mostrar mensaje de validación si no se cumple alguna regla
                Response.Write("<script>alert('Por favor, corrija los errores antes de continuar.');</script>");
            }
        }
    }
}