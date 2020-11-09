using CapaDato.Entidades;
using CapaDato.Models;
using CapaNegocio.Negocio;
using System;
using System.Collections.Generic;
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
        static int numRegistrado;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // MostrarTodosArtistas();
                gvDatosArtista.VirtualItemCount = Count();
                MostrarTodosArtista(1, 6);
                CantidadRegistros();
                claveArtista = 0;
            }

        }

        #region Metodos Artista
        void MostrarTodosArtistas()
        {
            gvDatosArtista.DataSource = negocioArtista.MostrarDatos();
            gvDatosArtista.DataBind();
        }

        private void GuardarArtista()
        {
            entidadArtista.NombreArtista = txtArtista.Text;
            negocioArtista.Guardar(entidadArtista);
            MostrarTodosArtistas();
        }

        private void ActualizarArtista()
        {
            entidadArtista.CveArtista = claveArtista;
            entidadArtista.NombreArtista = txtArtista.Text;
            negocioArtista.Actualizar(entidadArtista);
            MostrarTodosArtistas();
        }

        private void EliminarArtista()
        {
            entidadArtista.CveArtista = claveArtista;
            negocioArtista.Eliminar(entidadArtista);
            MostrarTodosArtistas();
        }

        private void BuscarNombreArtista()
        {
            entidadArtista.NombreArtista = txtBuscarArtista.Text;
            LlenarGrid(negocioArtista.Buscar(entidadArtista));
        }

        private void CantidadRegistros()
        {
            numRegistrado = gvDatosArtista.Rows.Count;
            lbTotalRegistro.Text = "Total de Registros: " + numRegistrado;
        }

        #endregion

        #region Botones Artista
        protected void btnInsertarArtista_Click(object sender, EventArgs e)
        {
            if (txtArtista.Text != string.Empty)
            {
                GuardarArtista();
                Message("Inserción Exitosa");
            }
            else
            {
                Message("Campos Vacios");
            }
        }

        protected void btnActualizarArtista_Click(object sender, EventArgs e)
        {
            if (txtArtista.Text != string.Empty)
            {
                ActualizarArtista();
                Message("Actualizacion Exitosa");
            }
            else
            {
                Message("Campos Vacios");
            }
        }

        protected void btnEliminarArtista_Click(object sender, EventArgs e)
        {
            if (claveArtista != 0)
            {
                EliminarArtista();
                Message("Se Elimino Con Exito");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert",
                                 "alert('Selecciona un registro'); ", true);
            }
        }

        protected void BtnNuevoArtista_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModuloArtista.aspx");
        }

        
        void OcultarBotones()
        {
            btnActualizarArtista.Visible = false;
            btnEliminarArtista.Visible = false;
            BtnNuevoArtista.Visible = false;
            btnInsertarArtista.Visible = true;
        }
        protected void btnBusarArtista_Click(object sender, EventArgs e)
        {
            LimpiarText();
            // BuscarNombreArtista();
            OcultarBotones();
            gvDatosArtista.VirtualItemCount = Count();
            MostrarTodosArtista(1, 6);
            CantidadRegistros();
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
        private void Message(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert",
                "alert('" + mensaje + "'); window.location ='ModuloArtista.aspx';", true);
        }

        protected void gvDatosArtista_SelectedIndexChanged(object sender, EventArgs e)
        {
            claveArtista = int.Parse(gvDatosArtista.SelectedRow.Cells[1].Text);
            txtArtista.Text = gvDatosArtista.SelectedRow.Cells[2].Text;
            MostrarBotonesArtista();
        }

        private void MostrarBotonesArtista()
        {
            btnInsertarArtista.Visible = false;
            btnActualizarArtista.Visible = true;
            btnEliminarArtista.Visible = true;
            BtnNuevoArtista.Visible = true;
        }

        private void LlenarGrid(List<Artista> lists)
        {
            gvDatosArtista.DataSource = null;
            gvDatosArtista.DataSource = lists;
            gvDatosArtista.DataBind();
        }

        private void LimpiarText()
        {
            claveArtista = 0;
            txtArtista.Text = null;
        }
        #endregion

        [WebMethod]
        public static List<string> AutoCompletarNombreArtista(string nombreArtista)
        {
            return NegocioArtista.AutoCompletarNombreArtista(nombreArtista);
        }

        private void MostrarTodosArtista(int starIndex, int maxRows)
        {
            gvDatosArtista.DataSource = negocioArtista.PaginacionByDescArtista(starIndex, maxRows, txtBuscarArtista.Text);
            gvDatosArtista.DataBind();
        }

        private int Count()
        {
            var desc = txtBuscarArtista.Text;
            return negocioArtista.PaginacionCountArtista(desc);
        }

        protected void gvDatosArtista_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDatosArtista.PageIndex = e.NewPageIndex;
            MostrarTodosArtista(e.NewPageIndex + 1, 6);
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
    }
}