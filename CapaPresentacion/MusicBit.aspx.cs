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
        static int claveArtista = 0;
        static int claveGenero = 0;
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

        private void Message(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert",
                "alert('" + mensaje + "'); window.location ='MusicBit.aspx';", true);
        }

        protected void gvDatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mvMenu.ActiveViewIndex == 0)
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
            else if (mvMenu.ActiveViewIndex == 1)
            {
                LimpiarTabArtista();
                claveArtista = int.Parse(gvDatos.SelectedRow.Cells[1].Text);
                txtTabArtista.Text = gvDatos.SelectedRow.Cells[2].Text;
            }
            else if (mvMenu.ActiveViewIndex == 2)
            {
                LimpiarTabGenero();
                claveGenero = int.Parse(gvDatos.SelectedRow.Cells[1].Text);
                txtTabGenero.Text = gvDatos.SelectedRow.Cells[2].Text;

            }
        }

        protected void gvDatos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (mvMenu.ActiveViewIndex == 0)
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

        private int ContarCaracteres()
        {
            int contarWhiteSpace = txtLetra.Text.Count(Char.IsWhiteSpace);
            int contarCaracteres = txtLetra.Text.Length;
            return contarCaracteres - contarWhiteSpace;
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
        protected void btnTabArtista_Click(object sender, EventArgs e)
        {
            mvMenu.ActiveViewIndex = 1;
            MostrarTodosArtistas();
            LbBuscar.Text = "Artista :";
            rdoArtista.Checked = true;
            listRdos.Visible = false;
        }
        protected void btnTabGenero_Click(object sender, EventArgs e)
        {
            mvMenu.ActiveViewIndex = 2;
            MostrarTodosGeneros();
            LbBuscar.Text = "Genero :";
            rdoGenero.Checked = true;
            listRdos.Visible = false;
        }
        #endregion

        #region Metodos Artista
        void LimpiarTabArtista()
        {
            claveArtista = 0;
            txtTabArtista.Text = "";
        }

        void MostrarTodosArtistas()
        {
            gvDatos.DataSource = negocioArtista.MostrarDatos();
            gvDatos.DataBind();
        }

        private void GuardarArtista()
        {
            entidadArtista.NombreArtista = txtTabArtista.Text;
            negocioArtista.Guardar(entidadArtista);
            MostrarTodosArtistas();
            LimpiarTabArtista();
        }

        private void ActualizarArtista()
        {
            entidadArtista.CveArtista = claveArtista;
            entidadArtista.NombreArtista = txtTabArtista.Text;
            negocioArtista.Actualizar(entidadArtista);
            MostrarTodosArtistas();
            LimpiarTabArtista();
        }

        private void EliminarArtista()
        {
            entidadArtista.CveArtista = claveArtista;
            negocioArtista.Eliminar(entidadArtista);
            MostrarTodosArtistas();
            LimpiarTabArtista();
        }
        #endregion

        #region Botones TabArtista

        protected void btnInsertarArtista_Click(object sender, EventArgs e)
        {
            if (txtTabArtista.Text != string.Empty)
            {
                Message("Inserción Exitosa");
                GuardarArtista();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert",
                              "alert('Campos Vacios');", true);
            }
        }

        protected void btnActualizarArtista_Click(object sender, EventArgs e)
        {
            if (txtTabArtista.Text != string.Empty)
            {
                Message("Actualizacion Exitosa");
                ActualizarArtista();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert",
                              "alert('Campos Vacios');", true);
            }
        }

        protected void btnEliminarArtista_Click(object sender, EventArgs e)
        {
            if (claveArtista != 0)
            {
                Message("Se Elimino Con Exito");
                EliminarArtista();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert",
                                 "alert('Selecciona un registro'); ", true);
            }
        }
        #endregion

        #region Metodos Genero
        private void LimpiarTabGenero()
        {
            claveGenero = 0;
            txtTabGenero.Text = "";
        }

        private void MostrarTodosGeneros()
        {
            gvDatos.DataSource = negocioGenero.MostrarDatos();
            gvDatos.DataBind();
        }

        private void GuardarGenero()
        {
            entidadGenero.NombreGenero = txtTabGenero.Text;
            negocioGenero.Guardar(entidadGenero);
            MostrarTodosGeneros();
            LimpiarTabGenero();
        }

        private void ActualizarGenero()
        {
            entidadGenero.CveGenero = claveGenero;
            entidadGenero.NombreGenero = txtTabGenero.Text;
            negocioGenero.Actualizar(entidadGenero);
            MostrarTodosGeneros();
            LimpiarTabGenero();
        }

        private void EliminarGenero()
        {
            entidadGenero.CveGenero = claveGenero;
            negocioGenero.Eliminar(entidadGenero);
            MostrarTodosGeneros();
            LimpiarTabGenero();
        }
        #endregion

        #region Botones TabGenero
        protected void btnInsertarGenero_Click(object sender, EventArgs e)
        {
            if (txtTabGenero.Text == string.Empty)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert",
               "alert('Campos Vacios');", true);
            }
            else
            {
                Message("Inserción Exitosa");
                GuardarGenero();
            }
        }

        protected void btnActualizarGenero_Click(object sender, EventArgs e)
        {
            if (txtTabGenero.Text == string.Empty)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert",
                              "alert('Campos Vacios');", true);
            }
            else
            {
                Message("Actualizacion Exitosa");
                ActualizarGenero();
            }
        }

        protected void btnEliminarGenero_Click(object sender, EventArgs e)
        {
            if (claveGenero != 0)
            {
                Message("Se Elimino Con Exito");
                EliminarGenero();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert",
                 "alert('Selecciona un registro'); ", true);
            }
        }
        #endregion

        protected void lnkbtnTabArtista_Home_Click(object sender, EventArgs e)
        {
            Response.Redirect("MusicBit.aspx");
        }

        protected void lnkbtnTabGenero_Home_Click(object sender, EventArgs e)
        {
            Response.Redirect("MusicBit.aspx");
        }

        protected void lnkbtnTabGenero_Artisa_Click(object sender, EventArgs e)
        {
            mvMenu.ActiveViewIndex = 1;
            MostrarTodosArtistas();
        }

        protected void lnkbtnTabArtista_Genero_Click(object sender, EventArgs e)
        {
            mvMenu.ActiveViewIndex = 2;
            MostrarTodosGeneros();
        }
    }
}