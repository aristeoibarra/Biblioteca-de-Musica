using CapaDato.Entidades;
using CapaDato.Models;
using CapaNegocio.Negocio;
using System;
using System.Collections.Generic;
using System.Web.UI;

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
                MostrarTodosArtistas();
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
            lbTotalRegistro.Text = "Total de Registros: "+ numRegistrado;
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

        protected void btnBusarArtista_Click(object sender, EventArgs e)
        {
            LimpiarText();
            BuscarNombreArtista();
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
    }
}