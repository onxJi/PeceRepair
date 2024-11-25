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

        //"Crear Formulario"
        protected void btnNuevoFormulario_Click(object sender, EventArgs e)
        {
            // página de creación de formulario
            Response.Redirect("~/About.aspx");
        }

        
        protected void btnActualizarDatos_Click(object sender, EventArgs e)
        {
            // página de actualización de datos
            Response.Redirect("~/BuscarTicket.aspx");
        }
    }
}