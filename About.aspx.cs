using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PcesRepair
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                // Lógica para crear el ticket aquí
                Response.Write("El ticket se ha creado exitosamente.");
            }
            else
            {
                Response.Write("Hay errores en el formulario. Por favor, corrígelos.");
            }
        }
    }
}