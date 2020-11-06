using CapaDato.Entidades;
using CapaDato.Models;
using CapaNegocio.Negocio;
using System;
using System.Collections.Generic;
using System.Web.UI;

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
                MostrarTodosGenero();
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

        protected void btnBusarGenero_Click(object sender, EventArgs e)
        {
            LimpiarText();
            BuscarNombreGenero();
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
    }
}