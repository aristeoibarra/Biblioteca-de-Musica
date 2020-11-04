using CapaDato.Entidades;
using CapaNegocio.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion
{
    public partial class MusicBit : System.Web.UI.Page
    {
        readonly NegocioArtista negocioArtista = new NegocioArtista();
        readonly NegocioGenero negocioGenero = new NegocioGenero();
        readonly NegocioCancion negocioCancion = new NegocioCancion();
        readonly NegocioCancion_Artista_Genero negocioCAG = new NegocioCancion_Artista_Genero();

        readonly EntidadCancion entidadCancion = new EntidadCancion();
        readonly EntidadArtista entidadArtista = new EntidadArtista();
        readonly EntidadGenero entidadGenero = new EntidadGenero();

        static int claveCancion = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                mvMenu.ActiveViewIndex = 0;
                Limpiar();
                MostrarTodos();
                LlenarComboArtista();
                LlenarComboGenero();
            }
        }

        #region Metodos Main
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

        private void MostrarTodos()
        {
            gvDatos.DataSource = negocioCAG.MostrarDatos();
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
            MostrarTodos();
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
            MostrarTodos();
            Limpiar();
        }

        private void EliminarCancion()
        {
            entidadCancion.CveCancion = claveCancion;
            negocioCancion.Eliminar(entidadCancion);
            MostrarTodos();
            Limpiar();
        }

        private void BuscarDatos()
        {
            if (rdoTodo.Checked)
            {
                entidadArtista.NombreArtista = txtBuscar.Text;
                entidadCancion.NombreCancion = txtBuscar.Text;
                entidadGenero.NombreGenero = txtBuscar.Text;
                LlenarGrid(negocioCAG.BuscarTodo(entidadCancion, entidadArtista, entidadGenero));
            }
            else if (rdoArtista.Checked)
            {
                entidadArtista.NombreArtista = txtBuscar.Text;
                LlenarGrid(negocioArtista.BuscarNombreArtista(entidadArtista));
            }
            else if (rdoCancion.Checked)
            {
                entidadCancion.NombreCancion = txtBuscar.Text;
                LlenarGrid(negocioCancion.BuscarNombreCancion(entidadCancion));
            }
            else if (rdoGenero.Checked)
            {
                entidadGenero.NombreGenero = txtBuscar.Text;
                LlenarGrid(negocioGenero.BuscarNombreGenero(entidadGenero));
            }
        }

        private void LlenarGrid(List<Cancion_Artista_Genero> lists)
        {
            gvDatos.DataSource = null;
            gvDatos.DataSource = lists;
            gvDatos.DataBind();
        }
        #endregion

        private void Message(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert",
                "alert('" + mensaje + "'); window.location ='MusicBit.aspx';", true);
        }

        #region botones Main

        private int ContarCaracteres()
        {
            int contarWhiteSpace = txtLetra.Text.Count(Char.IsWhiteSpace);
            int contarCaracteres = txtLetra.Text.Length;           
            return contarCaracteres - contarWhiteSpace;
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            if (ddlArtista.SelectedIndex == 0 || txtCancion.Text == string.Empty ||
                txtLetra.Text == string.Empty || ddlGenero.SelectedIndex == 0)
            {
                Message("Campos Vacios");
            }
            else if (ContarCaracteres() < 10)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert",
                  "alert('La letra debe tener al menos 10 caracteres'); ", true);
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
                txtLetra.Text == string.Empty || ddlGenero.SelectedIndex == 0 || claveCancion == 0)
            {
                Message("Campos Vacios");
            }
            else if (ContarCaracteres() < 10)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert",
                  "alert('La letra debe tener al menos 10 caracteres'); ", true);
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

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarDatos();
        }

        protected void btnTab1Artista_Click(object sender, EventArgs e)
        {
            mvMenu.ActiveViewIndex = 1;
        }
        #endregion
     
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

    
    }
}