using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MediKit.BC;

namespace MediKitWeb.Pages
{
    public partial class Listado : System.Web.UI.Page
    {
        Equipos equipo = new Equipos();
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarCombo();
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            if (!Page.IsPostBack)
            {
                gdEquipos.DataSource = equipo.ReadAll();
                gdEquipos.DataBind();
            }
            
        }

        private void CargarCombo()
        {
            if (!Page.IsPostBack)
            {
                //Se cargan los equipos
                Marcas marcas = new Marcas();
                cboMarca.DataValueField = "Id";
                cboMarca.DataTextField = "Nombre";
                cboMarca.DataSource = marcas.ReadAll();
                cboMarca.DataBind();
            }
            
        }

        protected void BtnFiltrar_Click(object sender, EventArgs e)
        {
            Equipos equipos = new Equipos();
            int marcaId = int.Parse(cboMarca.SelectedValue.ToString());

            gdEquipos.DataSource = equipos.BuscarMarca(marcaId);
            gdEquipos.DataBind();
        }

        protected void BtnRefrescar_Click(object sender, EventArgs e)
        {
            Equipos equipos = new Equipos();
            gdEquipos.DataSource = equipos.ReadAll();
            gdEquipos.DataBind();
            cboMarca.SelectedIndex = 0;

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}