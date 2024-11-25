using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PcesRepair
{
    public partial class BuscarTicket : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            // Recuperar el UUID ingresado
            string numeroTicket = txtNumeroTicket.Text.Trim();

            // Validar el UUID con expresión regular
            string uuidPattern = @"^[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(numeroTicket, uuidPattern))
            {
                // Mostrar un mensaje de error si no es válido
                Response.Write("<script>alert('El número de ticket no es un UUID válido.');</script>");
                return;
            }

            // Redirigir a ActualizarDatos.aspx con el UUID como parámetro
            Response.Redirect($"ActualizarDatos.aspx?uuid={numeroTicket}");
        }
    }
}