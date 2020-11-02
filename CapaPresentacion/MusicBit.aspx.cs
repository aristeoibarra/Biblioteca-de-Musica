using CapaNegocio.Negocio;
using CapaDato.Entidades;
using System;
using System.Web.UI.WebControls;
using CapaDato.Models;
using System.Linq;
using System.Web.UI;

namespace CapaPresentacion
{
    public partial class MusicBit : System.Web.UI.Page
    {
        readonly NegocioArtista negocioArtista = new NegocioArtista();
        readonly NegocioGenero negocioGenero = new NegocioGenero();
        readonly NegocioCancion negocioCancion = new NegocioCancion();

        readonly EntidadCancion entidadCancion = new EntidadCancion();

        static int claveCancion = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Limpiar();
                LlenarGridView();
                LlenarComboArtista();
                LlenarComboGenero();                
            }
        }
    
       #region MetodosCapaNegocio
        private void Limpiar()
        {
            claveCancion = 0;
            txtBuscar.Text = null;
            ddlArtista.SelectedIndex = -1;
            txtCancion.Text = null;
            txtLetra.Text = null;
            TxtMostrarLetra.Text = null;
            ddlGenero.SelectedIndex = -1;
        }

        private void LlenarGridView()
        {
           gvDatos.DataSource= negocioCancion.MostrarDatos();
            gvDatos.DataBind();
        }

        private void LlenarComboArtista()
        {
            var datos = negocioArtista.MostrarDatos();

            ddlArtista.DataSource = datos;
            ddlArtista.DataTextField = "nombreartista";
            ddlArtista.DataValueField = "cveartista";
            ddlArtista.DataBind();
            ddlArtista.Items.Insert(0, new ListItem("SELECCIONAR", "0"));
        }

        private void LlenarComboGenero()
        {
            var datos = negocioGenero.MostrarDatos();

            ddlGenero.DataSource = datos;
            ddlGenero.DataTextField = "nombregenero";
            ddlGenero.DataValueField = "cvegenero";
            ddlGenero.DataBind();
            ddlGenero.Items.Insert(0, new ListItem("SELECCIONAR", "0"));
        }

        private void GuardarCancion()
        {
            entidadCancion.NombreCancion = txtCancion.Text;
            entidadCancion.LetraCancion = txtLetra.Text;
            entidadCancion.CveartistaCancion = int.Parse(ddlArtista.SelectedValue.ToString());
            entidadCancion.CvegeneroCancion = int.Parse(ddlGenero.SelectedValue.ToString());

            negocioCancion.Guardar(entidadCancion);
            LlenarGridView();
            Limpiar();
        }

        private void ActualizarCancion()
        {
            entidadCancion.CveCancion = claveCancion;
            entidadCancion.NombreCancion = txtCancion.Text;
            entidadCancion.LetraCancion = txtLetra.Text;
            entidadCancion.CveartistaCancion = int.Parse(ddlArtista.SelectedValue.ToString());
            entidadCancion.CvegeneroCancion = int.Parse(ddlGenero.SelectedValue.ToString());

            negocioCancion.Actualizar(entidadCancion);
            LlenarGridView();
            Limpiar();
        }

        private void EliminarCancion()
        {
            entidadCancion.CveCancion = claveCancion;
            negocioCancion.Eliminar(entidadCancion);
            LlenarGridView();
            Limpiar();
        }
        #endregion
        void Message(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert",
                "alert('" + mensaje + "'); window.location ='MusicBit.aspx';", true);
        }

        protected void gvDatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Limpiar();

            claveCancion = int.Parse(gvDatos.SelectedRow.Cells[1].Text);

            ddlArtista.SelectedIndex = -1;
            ddlArtista.Items.FindByText(gvDatos.SelectedRow.Cells[2].Text).Selected = true;

            txtCancion.Text = gvDatos.SelectedRow.Cells[3].Text;

            ddlGenero.SelectedIndex = -1;
            ddlGenero.Items.FindByText(gvDatos.SelectedRow.Cells[4].Text).Selected = true;

            txtLetra.Text = gvDatos.SelectedRow.Cells[5].Text;
            TxtMostrarLetra.Text = gvDatos.SelectedRow.Cells[5].Text;
        }

        protected void gvDatos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[1].Visible = false;
                e.Row.Cells[5].Visible = false;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].Visible = false;
                e.Row.Cells[5].Visible = false;
            }
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {

            if (ddlArtista.SelectedIndex==0|| txtCancion.Text == string.Empty || 
                txtLetra.Text == string.Empty || ddlGenero.SelectedIndex == 0)
            {
                Message("Campos Vacios");
            }
            else
            {
                Message("Inserción Exitosa");
                GuardarCancion();
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            if (ddlArtista.SelectedIndex == 0 || txtCancion.Text == string.Empty ||
                txtLetra.Text == string.Empty || ddlGenero.SelectedIndex == 0 || claveCancion==0)
            {
                Message("Campos Vacios");
            }
            else
            {
                Message("Actualizacion Exitosa");
                ActualizarCancion();
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (claveCancion == 0)
            {
                Message("Selecciona un registro");
            }
            else
            {
                Message("Se Elimino Con Exito");
                EliminarCancion();
            }
        }       
    }
}