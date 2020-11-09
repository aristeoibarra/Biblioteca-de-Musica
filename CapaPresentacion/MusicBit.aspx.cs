using CapaDato.Entidades;
using CapaDato.Models;
using CapaNegocio.Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Services;
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

        static int claveCancion;
        static int numRegistrado;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                claveCancion = 0;
                MostrarTodos();
                LlenarComboArtista();
                LlenarComboGenero();
                CantidadRegistros();
            }
        }

        #region Web Form

        private void Message(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert",
                "alert('" + mensaje + "'); window.location ='MusicBit.aspx';", true);
        }

        protected void gvDatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            claveCancion = int.Parse(gvDatos.SelectedRow.Cells[1].Text);

            ddlArtista.SelectedIndex = -1;
            ddlArtista.Items.FindByText(gvDatos.SelectedRow.Cells[2].Text).Selected = true;

            txtCancion.Text = gvDatos.SelectedRow.Cells[3].Text;

            ddlGenero.SelectedIndex = -1;
            ddlGenero.Items.FindByText(gvDatos.SelectedRow.Cells[4].Text).Selected = true;

            txtLetra.Text = gvDatos.SelectedRow.Cells[5].Text;
            txtMostrarLetra.Text = gvDatos.SelectedRow.Cells[5].Text;
            MostrarBotonesMain();
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

        void LimpiarMainText()
        {
            claveCancion = 0;
            ddlArtista.SelectedIndex = -1;
            txtCancion.Text = null;
            ddlGenero.SelectedIndex = -1;
            txtLetra.Text = null;
            txtMostrarLetra.Text = null;
        }

        #endregion

        #region Metodos Main
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
        }

        private void EliminarCancion()
        {
            entidadCancion.CveCancion = claveCancion;
            negocioCancion.Eliminar(entidadCancion);
            MostrarTodos();
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
            CantidadRegistros();
        }



        private void LlenarGrid(List<Cancion_Artista_Genero> lists)
        {
            gvDatos.DataSource = null;
            gvDatos.DataSource = lists;
            gvDatos.DataBind();
        }

        private int ContarCaracteres()
        {
            int contarWhiteSpace = txtLetra.Text.Count(Char.IsWhiteSpace);
            int contarCaracteres = txtLetra.Text.Length;
            return contarCaracteres - contarWhiteSpace;
        }

        private void CantidadRegistros()
        {
            numRegistrado = gvDatos.Rows.Count;
            lbTotalRegistro.Text = "Total de Registros: " + numRegistrado;
        }

        private void MostrarBotonesMain()
        {
            btnInsertar.Visible = false;
            btnActualizar.Visible = true;
            btnEliminar.Visible = true;
            BtnNuevo.Visible = true;
        }
        #endregion

        #region Botones Main
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
                GuardarCancion();
                Message("Inserción Exitosa");
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
                ActualizarCancion();
                Message("Actualizacion Exitosa");
            }

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (claveCancion != 0)
            {
                EliminarCancion();
                Message("Se Elimino Con Exito");
            }
            else
            {
                Message("Selecciona un registro");
            }
        }

        void OcultarBotones()
        {
            btnActualizar.Visible = false;
            btnEliminar.Visible = false;
            BtnNuevo.Visible = false;
            btnInsertar.Visible = true;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            OcultarBotones();
            LimpiarMainText();
            BuscarDatos();
        }

        protected void btnModuloArtista_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Redirect("ModuloArtista.aspx");
        }

        protected void btnModuloGenero_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Redirect("ModuloGenero.aspx");
        }

        protected void BtnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("MusicBit.aspx");
        }
        #endregion

        [WebMethod]
        public static List<string> AutoCompletarArtista(string nombre)
        {
            return NegocioCancion_Artista_Genero.AutoCompletar_Artista(nombre);
        }

        [WebMethod]
        public static List<string> AutoCompletarCancion(string nombre)
        {
            return NegocioCancion_Artista_Genero.AutoCompletar_Cancion(nombre);
        }

        [WebMethod]
        public static List<string> AutoCompletarGenero(string nombre)
        {
            return NegocioCancion_Artista_Genero.AutoCompletar_Genero(nombre);
        }

        [WebMethod]
        public static List<string> AutoCompletarTodo(string nombre)
        {
            return NegocioCancion_Artista_Genero.AutoCompletar_Todo(nombre);
        }    
    }
}