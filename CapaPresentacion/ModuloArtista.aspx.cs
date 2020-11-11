using CapaDato.Entidades;
using CapaDato.Models;
using CapaNegocio.Negocio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion
{
    public partial class ModuloArtista : System.Web.UI.Page
    {
        readonly NegocioArtista negocioArtista = new NegocioArtista();
        readonly EntidadArtista entidadArtista = new EntidadArtista();

        static int claveArtista;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvDatosArtista.VirtualItemCount = Count_Buscar();
                MostrarTodos_Artista(1, 6);
                claveArtista = 0;
            }

        }

        #region Metodos Artista
        private void MostrarTodos_Artista()
        {
            gvDatosArtista.DataSource = negocioArtista.MostrarDatos_Artista();
            gvDatosArtista.DataBind();
        }

        private void MostrarTodos_Artista(int starIndex, int maxRows)
        {
            gvDatosArtista.DataSource = negocioArtista.PaginacionByDesc_Artista(starIndex, maxRows, txtBuscarArtista.Text);
            gvDatosArtista.DataBind();
        }

        private void Guardar_Artista()
        {
            entidadArtista.NombreArtista = txtArtista.Text;
            negocioArtista.Guardar_Artista(entidadArtista);
            MostrarTodos_Artista();
        }

        private void Actualizar_Artista()
        {
            entidadArtista.CveArtista = claveArtista;
            entidadArtista.NombreArtista = txtArtista.Text;
            negocioArtista.Actualizar_Artista(entidadArtista);
            MostrarTodos_Artista();
        }

        private void Eliminar_Artista()
        {
            entidadArtista.CveArtista = claveArtista;
            negocioArtista.Eliminar_Artista(entidadArtista);
            MostrarTodos_Artista();
        }

        private int Count_Buscar()
        {
            var desc = txtBuscarArtista.Text;
            return negocioArtista.PaginacionCount_Artista(desc);
        }

        //private void BuscarNombre_Artista()
        //{
        //    entidadArtista.NombreArtista = txtBuscarArtista.Text;
        //    LlenarGrid(negocioArtista.Buscar_Artista(entidadArtista));
        //}

        //private void LlenarGrid(List<Artista> lists)
        //{
        //    gvDatosArtista.DataSource = null;
        //    gvDatosArtista.DataSource = lists;
        //    gvDatosArtista.DataBind();
        //}

        #endregion

        #region Botones Artista
        protected void btnInsertarArtista_Click(object sender, EventArgs e)
        {
            if (txtArtista.Text != string.Empty)
            {
                Guardar_Artista();
                MessageRedirect("Inserción Exitosa");
            }
            else
            {
                MessageRedirect("Campos Vacios");
            }
        }

        protected void btnActualizarArtista_Click(object sender, EventArgs e)
        {
            if (txtArtista.Text != string.Empty)
            {
                Actualizar_Artista();
                MessageRedirect("Actualizacion Exitosa");
            }
            else
            {
                MessageRedirect("Campos Vacios");
            }
        }

        protected void btnEliminarArtista_Click(object sender, EventArgs e)
        {
            if (claveArtista != 0)
            {
                Eliminar_Artista();
                MessageRedirect("Se Elimino Con Exito");
            }
            else
            {
                MessageSimple("Selecciona un registro");
            }
        }

        protected void BtnNuevoArtista_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModuloArtista.aspx");
        }

        protected void btnBusarArtista_Click(object sender, EventArgs e)
        {
            LimpiarText();
            Mostrar_Ocular_Botones(false);
            gvDatosArtista.VirtualItemCount = Count_Buscar();
            MostrarTodos_Artista(1, 6);
        }

        protected void lnkbtnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("MusicBit.aspx");
        }

        protected void lnkbtnGenero_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModuloGenero.aspx");
        }

        #endregion

        #region Web Form
        private void LimpiarText()
        {
            claveArtista = 0;
            txtArtista.Text = null;
        }

        private void MessageSimple(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert",
                "alert('" + mensaje + "');", true);
        }

        private void MessageRedirect(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert",
                "alert('" + mensaje + "'); window.location ='ModuloArtista.aspx';", true);
        }

        protected void gvDatosArtista_SelectedIndexChanged(object sender, EventArgs e)
        {
            claveArtista = int.Parse(gvDatosArtista.SelectedRow.Cells[1].Text);
            txtArtista.Text = HttpUtility.UrlDecode(gvDatosArtista.SelectedRow.Cells[2].Text, Encoding.UTF8);
            txtArtista.Text = HttpUtility.HtmlDecode(gvDatosArtista.SelectedRow.Cells[2].Text);
            Mostrar_Ocular_Botones(true);
        }

        protected void gvDatosArtista_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDatosArtista.PageIndex = e.NewPageIndex;
            MostrarTodos_Artista(e.NewPageIndex + 1, 6);
        }

        protected void gvDatosArtista_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[1].Visible = false;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].Visible = false;
            }
        }

        private void Mostrar_Ocular_Botones(bool resp)
        {
            if (resp)
            {
                btnInsertarArtista.Visible = false;
                btnActualizarArtista.Visible = true;
                btnEliminarArtista.Visible = true;
                BtnNuevoArtista.Visible = true;
            }
            else
            {
                btnActualizarArtista.Visible = false;
                btnEliminarArtista.Visible = false;
                BtnNuevoArtista.Visible = false;
                btnInsertarArtista.Visible = true;
            }         
        }
        
        #endregion

        #region WebService
        [WebMethod]
        public static List<string> AutoCompletarNombre_Artista(string nombreArtista)
        {
            return NegocioArtista.AutoCompletarNombre_Artista(nombreArtista);
        }
        #endregion     
    }
}