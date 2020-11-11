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
    public partial class ModuloGenero : System.Web.UI.Page
    {
        readonly NegocioGenero negocioGenero = new NegocioGenero();
        readonly EntidadGenero entidadGenero = new EntidadGenero();

        static int claveGenero = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvDatosGenero.VirtualItemCount = Count_Buscar();
                MostrarTodos_Genero(1, 6);
                claveGenero = 0;
            }
        }

        #region Metodos Genero
        private void MostrarTodos_Genero()
        {
            gvDatosGenero.DataSource = negocioGenero.MostrarDatos_Genero();
            gvDatosGenero.DataBind();
        }

        private void MostrarTodos_Genero(int starIndex, int maxRows)
        {
            gvDatosGenero.DataSource = negocioGenero.PaginacionByDesc_Genero(starIndex, maxRows, txtBuscarGenero.Text);
            gvDatosGenero.DataBind();
        }

        private void Guardar_Genero()
        {
            entidadGenero.NombreGenero = txtGenero.Text;
            negocioGenero.Guardar_Genero(entidadGenero);
            MostrarTodos_Genero();
        }

        private void Actualizar_Genero()
        {
            entidadGenero.CveGenero = claveGenero;
            entidadGenero.NombreGenero = txtGenero.Text;
            negocioGenero.Actualizar_Genero(entidadGenero);
            MostrarTodos_Genero();
        }

        private void Eliminar_Genero()
        {
            entidadGenero.CveGenero = claveGenero;
            negocioGenero.Eliminar_Genero(entidadGenero);
            MostrarTodos_Genero();
        }

        private int Count_Buscar()
        {
            var desc = txtBuscarGenero.Text;
            return negocioGenero.PaginacionCount_Genero(desc);
        }

        //private void BuscarNombre_Genero()
        //{
        //    entidadGenero.NombreGenero = txtBuscarGenero.Text;
        //    LlenarGrid(negocioGenero.Buscar_Genero(entidadGenero));
        //}

        //private void LlenarGrid(List<Genero> lists)
        //{
        //    gvDatosGenero.DataSource = null;
        //    gvDatosGenero.DataSource = lists;
        //    gvDatosGenero.DataBind();
        //}   
        #endregion

        #region Botones Genero
        protected void btnInsertarGenero_Click(object sender, EventArgs e)
        {
            if (txtGenero.Text != string.Empty)
            {
                Guardar_Genero();
                MessageRedirect("Inserción Exitosa");
            }
            else
            {
                MessageRedirect("Campos Vacios");
            }
        }

        protected void btnActualizarGenero_Click(object sender, EventArgs e)
        {
            if (txtGenero.Text != string.Empty)
            {
                Actualizar_Genero();
                MessageRedirect("Actualizacion Exitosa");
            }
            else
            {
                MessageRedirect("Campos Vacios");
            }
        }

        protected void btnEliminarGenero_Click(object sender, EventArgs e)
        {
            if (claveGenero != 0)
            {
                Eliminar_Genero();
                MessageRedirect("Se Elimino Con Exito");
            }
            else
            {
                MessageSimple("Selecciona un registro");
            }
        }

        protected void BtnNuevoGenero_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModuloGenero.aspx");

        }
  
        protected void btnBusarGenero_Click(object sender, EventArgs e)
        {
            LimpiarText();
            Mostrar_Ocular_Botones(false);
            gvDatosGenero.VirtualItemCount = Count_Buscar();
            MostrarTodos_Genero(1, 6);
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
        private void LimpiarText()
        {
            claveGenero = 0;
            txtGenero.Text = null;
        }

        private void MessageSimple(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert",
                "alert('" + mensaje + "');", true);
        }

        private void MessageRedirect(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert",
                "alert('" + mensaje + "'); window.location ='ModuloGenero.aspx';", true);
        }

        protected void gvDatosGenero_SelectedIndexChanged(object sender, EventArgs e)
        {
            claveGenero = int.Parse(gvDatosGenero.SelectedRow.Cells[1].Text);

            txtGenero.Text = HttpUtility.UrlDecode(gvDatosGenero.SelectedRow.Cells[2].Text, Encoding.UTF8);
            txtGenero.Text = HttpUtility.HtmlDecode(gvDatosGenero.SelectedRow.Cells[2].Text);
            Mostrar_Ocular_Botones(true);
        }

        protected void gvDatosGenero_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDatosGenero.PageIndex = e.NewPageIndex;
            MostrarTodos_Genero(e.NewPageIndex + 1, 6);
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

        private void Mostrar_Ocular_Botones(bool resp)
        {
            if (resp)
            {
                btnInsertarGenero.Visible = false;
                btnActualizarGenero.Visible = true;
                btnEliminarGenero.Visible = true;
                BtnNuevoGenero.Visible = true;
            }
            else
            {
                btnActualizarGenero.Visible = false;
                btnEliminarGenero.Visible = false;
                BtnNuevoGenero.Visible = false;
                btnInsertarGenero.Visible = true;
            }
        }

        #endregion

        #region WebService
        [WebMethod]
        public static List<string> AutoCompletarNombre_Genero(string nombreGenero)
        {
            return NegocioGenero.AutoCompletarNombre_Genero(nombreGenero);
        }
        #endregion
    }
}