using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using BLL;

namespace RegistrodeSugerencia.Registros
{
    public partial class rSugerencias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                SugerenciaIdTextBox.Text = "0";
                int ID = Utilitarios.Utils.ToInt(Request.QueryString["id"]);

                if (ID > 0)
                {
                    BLL.RepositorioBase<Sugerencias> repositorio = new BLL.RepositorioBase<Sugerencias>();
                    var us = repositorio.Buscar(ID);

                    if (us == null)
                    {
                        Utilitarios.Utils.ShowToastr(this.Page, "Registro No encontrado", "Error", "error");
                    }
                    else
                    {
                        LlenaCampo(us);
                    }
                }
            }

        }

        private void Limpiar()
        {
            SugerenciaIdTextBox.Text = string.Empty;
            FechaTextBox.Text = Convert.ToDateTime( DateTime.Now).ToString();
            DescripcionTextBox.Text = string.Empty;

        }

        public Sugerencias LlenaClase()
        {
            Sugerencias sugerencia = new Sugerencias();
            sugerencia.SugerenciaId = Convert.ToInt32(SugerenciaIdTextBox.Text);
            sugerencia.Fecha = DateTime.Now;
            sugerencia.Descripcion = DescripcionTextBox.Text;

            return sugerencia;
        }

        private void LlenaCampo(Sugerencias sugerencia)
        {
            SugerenciaIdTextBox.Text = sugerencia.SugerenciaId.ToString();
            DescripcionTextBox.Text = sugerencia.Descripcion;
            FechaTextBox.Text = sugerencia.Fecha.ToString("yyyy-MM-dd");

        }

        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Sugerencias> db = new RepositorioBase<Sugerencias>();
            Sugerencias sugerencia = db.Buscar(Convert.ToInt32(SugerenciaIdTextBox.Text));
            return (sugerencia != null);

        }



        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            int id;

            RepositorioBase<Sugerencias> db = new RepositorioBase<Sugerencias>();
            Sugerencias sugerencia = new Sugerencias();
            int.TryParse(SugerenciaIdTextBox.Text, out id);
            Limpiar();

            sugerencia = db.Buscar(id);

            if (sugerencia != null)
            {

                LlenaCampo(sugerencia);

            }
            else
            {
                Utilitarios.Utils.ShowToastr(this.Page, "No se encontro ese tipo de analisis", "Error", "error");

            }

        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();

        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Sugerencias> db = new RepositorioBase<Sugerencias>();
            Sugerencias sugerencia;
            bool paso = false;


            sugerencia = LlenaClase();


            if (SugerenciaIdTextBox.Text == Convert.ToString(0))
            {
                paso = db.Guardar(sugerencia);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    Utilitarios.Utils.ShowToastr(this.Page, "El campo descripcion no puede estar vacio", "Error", "error");
                    return;
                }
                paso = db.Modificar(sugerencia);
            }

            if (paso)
                Utilitarios.Utils.ShowToastr(this.Page, "El campo descripcion no puede estar vacio", "Exito", "success");
            else
                Utilitarios.Utils.ShowToastr(this.Page, "Se profujo un error al guardar", "Error", "error");
            Limpiar();


        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            if (Utilitarios.Utils.ToInt(SugerenciaIdTextBox.Text) > 0)
            {
                int id = Convert.ToInt32(SugerenciaIdTextBox.Text);
                RepositorioBase<Sugerencias> repositorio = new RepositorioBase<Sugerencias>();
                if (repositorio.Eliminar(id))
                {

                    Utilitarios.Utils.ShowToastr(this.Page, "Eliminado con exito!!", "Eliminado", "info");
                }
                else
                    Utilitarios.Utils.ShowToastr(this.Page, "Fallo al Eliminar :(", "Error", "error");
                Limpiar();
            }
            else
            {
                Utilitarios.Utils.ShowToastr(this.Page, "No se pudo eliminar, usuario no existe", "error", "error");
            }

        }
    }
}