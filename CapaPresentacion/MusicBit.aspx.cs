using CapaDato.Entidades;
using CapaNegocio.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
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

        public object __o;
        static int claveCancion;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                claveCancion = 0;
                BuscarDatos();
                LlenarCombo_Artista();
                LlenarCombo_Genero();
                CantidadRegistros();
            }
        }

        #region Metodos Main
        private void MostrarTodos()
        {
            gvDatos.DataSource = negocioCAG.MostrarDatos();
            gvDatos.DataBind();
        }

        private void LlenarCombo_Artista()
        {
            var datos = negocioArtista.MostrarDatos_Artista();

            ddlArtista.DataSource = datos;
            ddlArtista.DataTextField = "nombreartista";
            ddlArtista.DataValueField = "cveartista";
            ddlArtista.DataBind();
            ddlArtista.Items.Insert(0, new ListItem("SELECCIONAR", "0"));
        }

        private void LlenarCombo_Genero()
        {
            var datos = negocioGenero.MostrarDatos_Genero();

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

            negocioCancion.Guardar_Cancion(entidadCancion);
            MostrarTodos();
        }

        private void Actualizar_Cancion()
        {
            entidadCancion.CveCancion = claveCancion;
            entidadCancion.NombreCancion = txtCancion.Text;
            entidadCancion.LetraCancion = txtLetra.Text;
            entidadCancion.CveartistaCancion = int.Parse(ddlArtista.SelectedValue.ToString());
            entidadCancion.CvegeneroCancion = int.Parse(ddlGenero.SelectedValue.ToString());

            negocioCancion.Actualizar_Cancion(entidadCancion);
            MostrarTodos();
        }

        private void Eliminar_Cancion()
        {
            entidadCancion.CveCancion = claveCancion;
            negocioCancion.Eliminar_Cancion(entidadCancion);
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
                LlenarGrid(negocioArtista.BuscarNombre_Artista(entidadArtista));
            }
            else if (rdoCancion.Checked)
            {
                entidadCancion.NombreCancion = txtBuscar.Text;
                LlenarGrid(negocioCancion.BuscarNombre_Cancion(entidadCancion));
            }
            else if (rdoGenero.Checked)
            {
                entidadGenero.NombreGenero = txtBuscar.Text;
                LlenarGrid(negocioGenero.BuscarNombre_Genero(entidadGenero));
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
            int cantRegistro = negocioCAG.NumeroRegistros();
            lbTotalRegistro.Text = "Total de Registros: " + cantRegistro;
        }

        #endregion

        #region Botones Main
        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            if (ddlArtista.SelectedIndex == 0 || txtCancion.Text == string.Empty ||
                 txtLetra.Text == string.Empty || ddlGenero.SelectedIndex == 0)
            {
                MessageSimple("Campos Vacios");
            }
            else if (ContarCaracteres() < 10)
            {
                MessageSimple("La letra debe tener al menos 10 caracteres");
            }
            else
            {
                GuardarCancion();
                MessageRedirect("Inserción Exitosa");
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            if (ddlArtista.SelectedIndex == 0 || txtCancion.Text == string.Empty ||
            txtLetra.Text == string.Empty || ddlGenero.SelectedIndex == 0 || claveCancion == 0)
            {
                MessageSimple("Campos Vacios");
            }
            else if (ContarCaracteres() < 10)
            {
                MessageSimple("La letra debe tener al menos 10 caracteres");
            }
            else
            {
                Actualizar_Cancion();
                MessageRedirect("Actualizacion Exitosa");
            }

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (claveCancion != 0)
            {
                Eliminar_Cancion();
                MessageRedirect("Se Elimino Con Exito");
            }
            else
            {
                MessageSimple("Selecciona un registro");
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            gvDatos.PageIndex = 0;        
            LimpiarMainText();
            Mostrar_Ocular_Botones(false);
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

        #region Web Form
        private void LimpiarMainText()
        {
            claveCancion = 0;
            ddlArtista.SelectedIndex = -1;
            txtCancion.Text = null;
            ddlGenero.SelectedIndex = -1;
            txtLetra.Text = null;
            txtMostrarLetra.Text = null;
        }

        private void MessageSimple(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert",
                "alert('" + mensaje + "');", true);
        }

        private void MessageRedirect(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert",
                "alert('" + mensaje + "'); window.location ='MusicBit.aspx';", true);
        }

        protected void gvDatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            claveCancion = int.Parse(gvDatos.SelectedRow.Cells[1].Text);
            ddlArtista.SelectedValue = gvDatos.SelectedRow.Cells[2].Text;
            ddlGenero.SelectedValue = gvDatos.SelectedRow.Cells[3].Text;

            txtCancion.Text = HttpUtility.UrlDecode(gvDatos.SelectedRow.Cells[5].Text, Encoding.UTF8);
            txtCancion.Text = HttpUtility.HtmlDecode(gvDatos.SelectedRow.Cells[5].Text);

            txtLetra.Text = HttpUtility.UrlDecode(gvDatos.SelectedRow.Cells[7].Text, Encoding.UTF8);
            txtLetra.Text = HttpUtility.HtmlDecode(gvDatos.SelectedRow.Cells[7].Text);

            txtMostrarLetra.Text = txtLetra.Text;
            Mostrar_Ocular_Botones(true);
        }

        protected void gvDatos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[1].Visible = false;
                e.Row.Cells[2].Visible = false;
                e.Row.Cells[3].Visible = false;
                e.Row.Cells[7].Visible = false;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].Visible = false;
                e.Row.Cells[2].Visible = false;
                e.Row.Cells[3].Visible = false;
                e.Row.Cells[7].Visible = false;
            }
        }

        protected void gvDatos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDatos.PageIndex = e.NewPageIndex;
            BuscarDatos();
        }

        private void Mostrar_Ocular_Botones(bool resp)
        {
            if (resp)
            {
                btnInsertar.Visible = false;
                btnActualizar.Visible = true;
                btnEliminar.Visible = true;
                BtnNuevo.Visible = true;
            }
            else
            {
                btnActualizar.Visible = false;
                btnEliminar.Visible = false;
                BtnNuevo.Visible = false;
                btnInsertar.Visible = true;
            }
        }

        protected void rdoTodo_CheckedChanged(object sender, EventArgs e)
        {
            MostrarTodos();
        }

        protected void rdoArtista_CheckedChanged(object sender, EventArgs e)
        {
            MostrarTodos();
        }

        protected void rdoGenero_CheckedChanged(object sender, EventArgs e)
        {
            MostrarTodos();
        }

        protected void rdoCancion_CheckedChanged(object sender, EventArgs e)
        {
            MostrarTodos();
        }
        #endregion

        #region WebService
        [WebMethod]
        public static List<string> AutoCompletar_Artista(string nombre)
        {
            return NegocioCancion_Artista_Genero.AutoCompletar_Artista(nombre);
        }

        [WebMethod]
        public static List<string> AutoCompletar_Cancion(string nombre)
        {
            return NegocioCancion_Artista_Genero.AutoCompletar_Cancion(nombre);
        }

        [WebMethod]
        public static List<string> AutoCompletar_Genero(string nombre)
        {
            return NegocioCancion_Artista_Genero.AutoCompletar_Genero(nombre);
        }

        [WebMethod]
        public static List<string> AutoCompletar_Todo(string nombre)
        {
            return NegocioCancion_Artista_Genero.AutoCompletar_Todo(nombre);
        }
        #endregion
        
    }
}