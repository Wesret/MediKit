using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MediKit.BC;

namespace MediKitWeb.Pages
{
    public partial class Principal : System.Web.UI.Page
    {
        Equipos equipos = new Equipos();
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            MisServiciosWeb.MisServiciosSoapClient misServicios =
                new MisServiciosWeb.MisServiciosSoapClient();
            gdEquipos.DataSource = misServicios.ReadAll();
            gdEquipos.DataBind();
        }
    }
}