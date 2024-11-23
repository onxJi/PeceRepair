using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PcesRepair
{
	public partial class Reparacion : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        // Método para manejar el evento OnClick del botón "Crear Formulario"
        protected void btnNuevoFormulario_Click(object sender, EventArgs e)
        {
            // Redirecciona a la página de creación de formulario
            Response.Redirect("~/About.aspx");
        }

        // Método para manejar el evento OnClick del botón "Actualizar Datos"
        protected void btnActualizarDatos_Click(object sender, EventArgs e)
        {
            // Redirecciona a la página de actualización de datos
            Response.Redirect("~/ActualizarDatos.aspx");
        }
    }
}