using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MediKit.BC;

namespace MediKitWeb.Pages
{
    public partial class Mantenedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarMarcas();
            }
        }

        private void LimpiarControles()
        {
            //Limpia los controles de texto

            txtProducto.Text = string.Empty;
            txtPrecio.Text = string.Empty;
            txtLote.Text = string.Empty;
            txtCantidad.Text = string.Empty;

            CargarMarcas();

        }

        private void CargarMarcas()
        {
            //Se cargan los equipos
            Marcas marcas = new Marcas();
            cboMarca.DataValueField = "Id";
            cboMarca.DataTextField = "Nombre";
            cboMarca.DataSource = marcas.ReadAll();
            cboMarca.DataBind();
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Equipos equipo = new Equipos()
            {
                Producto = txtProducto.Text,
                MarcaID = int.Parse(cboMarca.SelectedValue),
                Precio = int.Parse(txtPrecio.Text),
                Cantidad = int.Parse(txtCantidad.Text),
                Lote = int.Parse(txtLote.Text)
            };

            if (equipo.Create())
            {
                lblMsg.Text = "Equipo Ingresado Correctamente!";
                LimpiarControles();
            }
            else
            {
                lblMsg.Text = "No se pudo ingresar el equioo";
            }
        }
    }
}