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
    public partial class ModuloGenero : System.Web.UI.Page
    {
        readonly NegocioGenero negocioGenero = new NegocioGenero();
        readonly EntidadGenero entidadGenero = new EntidadGenero();

        static int claveGenero = 0;
        static int numRegistrado;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // MostrarTodosGenero();
                gvDatosGenero.VirtualItemCount = Count();
                MostrarTodosGenero(1, 6);
                CantidadRegistros();
                claveGenero = 0;
            }
        }

        #region Metodos Genero
        private void MostrarTodosGenero()
        {
            gvDatosGenero.DataSource = negocioGenero.MostrarDatos();
            gvDatosGenero.DataBind();
        }
        private void GuardarGenero()
        {
            entidadGenero.NombreGenero = txtGenero.Text;
            negocioGenero.Guardar(entidadGenero);
            MostrarTodosGenero();
        }
        private void ActualizarGenero()
        {
            entidadGenero.CveGenero = claveGenero;
            entidadGenero.NombreGenero = txtGenero.Text;
            negocioGenero.Actualizar(entidadGenero);
            MostrarTodosGenero();
        }
        private void EliminarGenero()
        {
            entidadGenero.CveGenero = claveGenero;
            negocioGenero.Eliminar(entidadGenero);
            MostrarTodosGenero();
        }
        private void BuscarNombreGenero()
        {
            entidadGenero.NombreGenero = txtBuscarGenero.Text;
            LlenarGrid(negocioGenero.Buscar(entidadGenero));
        }
        private void LlenarGrid(List<Genero> lists)
        {
            gvDatosGenero.DataSource = null;
            gvDatosGenero.DataSource = lists;
            gvDatosGenero.DataBind();
        }
        private void CantidadRegistros()
        {
            numRegistrado = gvDatosGenero.Rows.Count;
            lbTotalRegistro.Text = "Total de Registros: " + numRegistrado;
        }

        #endregion

        #region Botones Genero
        protected void btnInsertarGenero_Click(object sender, EventArgs e)
        {
            if (txtGenero.Text != string.Empty)
            {
                GuardarGenero();
                Message("Inserción Exitosa");
            }
            else
            {
                Message("Campos Vacios");
            }
        }

        protected void btnActualizarGenero_Click(object sender, EventArgs e)
        {
            if (txtGenero.Text != string.Empty)
            {
                ActualizarGenero();
                Message("Actualizacion Exitosa");
            }
            else
            {
                Message("Campos Vacios");
            }
        }

        protected void btnEliminarGenero_Click(object sender, EventArgs e)
        {
            if (claveGenero != 0)
            {
                EliminarGenero();
                Message("Se Elimino Con Exito");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert",
                                 "alert('Selecciona un registro'); ", true);
            }
        }
        void OcultarBotones()
        {
            btnActualizarGenero.Visible = false;
            btnEliminarGenero.Visible = false;
            BtnNuevoGenero.Visible = false;
            btnInsertarGenero.Visible = true;
        }
        protected void btnBusarGenero_Click(object sender, EventArgs e)
        {
            LimpiarText();
            //BuscarNombreGenero();
            OcultarBotones();
            gvDatosGenero.VirtualItemCount = Count();
            MostrarTodosGenero(1, 6);
            CantidadRegistros();
        }

        protected void BtnNuevoGenero_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModuloGenero.aspx");

        }

        protected void lnkbtnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("MusicBit.aspx");
        }

        protected void lnkbtnArtista_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModuloArtista.aspx");
        }

        #endregion

        #region Web Form
        private void Message(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert",
                "alert('" + mensaje + "'); window.location ='ModuloGenero.aspx';", true);
        }

        void MostrarBotonesGenero()
        {
            btnInsertarGenero.Visible = false;
            btnActualizarGenero.Visible = true;
            btnEliminarGenero.Visible = true;
            BtnNuevoGenero.Visible = true;
        }

        protected void gvDatosGenero_SelectedIndexChanged(object sender, EventArgs e)
        {
            claveGenero = int.Parse(gvDatosGenero.SelectedRow.Cells[1].Text);
            txtGenero.Text = gvDatosGenero.SelectedRow.Cells[2].Text;
            MostrarBotonesGenero();
        }

        private void LimpiarText()
        {
            claveGenero = 0;
            txtGenero.Text = null;
        }
        #endregion

        [WebMethod]
        public static List<string> AutoCompletarNombreGenero(string nombreGenero)
        {
            return NegocioGenero.AutoCompletarNombreGenero(nombreGenero);
        }

        private void MostrarTodosGenero(int starIndex, int maxRows)
        {
            gvDatosGenero.DataSource = negocioGenero.PaginacionByDescGenero(starIndex, maxRows, txtBuscarGenero.Text);
            gvDatosGenero.DataBind();
        }

        private int Count()
        {
            var desc = txtBuscarGenero.Text;
            return negocioGenero.PaginacionCountGenero(desc);
        }

        protected void gvDatosGenero_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDatosGenero.PageIndex = e.NewPageIndex;
            MostrarTodosGenero(e.NewPageIndex + 1, 6);
        }

        protected void gvDatosGenero_RowDataBound(object sender, GridViewRowEventArgs e)
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