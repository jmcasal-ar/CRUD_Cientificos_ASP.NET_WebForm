using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IntentoResolucion.DAL;
namespace IntentoResolucion
{
    public partial class WebFormCientificos : System.Web.UI.Page
    {
        private CientificoDBEntities context = new CientificoDBEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                this.EstadoInicialPrograma();
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
           
        }

        private void Listar()
        {
            GridViewListado.DataSource = context.Cientificos.ToList();
            GridViewListado.DataBind();
        }
        private void BuscarporApellido()
        {
            string busqueda = TextBoxApellido.Text;
            List<Cientifico> cientificos = context.Cientificos.Where(esc => esc.Apellido.Contains(busqueda)).ToList();
            GridViewListado.DataSource = cientificos;
            GridViewListado.DataBind();
        }

        protected void LinkButtonBuscarporApellido_Click(object sender, EventArgs e)
        {
            BuscarporApellido();
        }

        private void RenumerarPorId()
        {
            
            List<Cientifico> cientificos = context.Cientificos.ToList();

            foreach (Cientifico cientifico in cientificos)
            {
                //Aca hay una trampa y es q no se puede renumerar por Id. Por eso debemos crear un nuevo cientifico y borrar el anterior
                Cientifico nuevoCientifico = new Cientifico();
                nuevoCientifico.Apellido = cientifico.Apellido;
                context.Cientificos.Add(nuevoCientifico);
                context.Cientificos.Remove(cientifico);
            }
            context.SaveChanges();
            this.Listar();
        }

        protected void LinkButtonRenumerarId_Click(object sender, EventArgs e)
        {
            RenumerarPorId();
        }
        
        private void OrdenarPorApellido()
        {
            int i = 0;
            List<Cientifico> cientificos = context.Cientificos.ToList();
            List<string> apellidosOrdenados = context.Cientificos.OrderBy(c => c.Apellido).Select(c => c.Apellido).ToList();
            foreach (Cientifico cientifico in cientificos)
            {
                
                cientifico.Apellido = apellidosOrdenados[i];
                i++;
            }
            context.SaveChanges();
            this.Listar();
        }

        protected void LinkButtonOrdenarApellido_Click(object sender, EventArgs e)
        {
            OrdenarPorApellido();
        }
        private void Depurar()
        {
            //Creo lista comun de cientificos
            List<Cientifico> cientificos = context.Cientificos.ToList();
            //creo una lista de cientificos que este vacia, para ir agregando al primer cientifico por apellido
            List<Cientifico> cientificosSinDuplucar = context.Cientificos.ToList();
            cientificosSinDuplucar.Clear();
            foreach (Cientifico cientifico in cientificos)
            {
                //Busco al primer cientifico de los que tienen el mismo apellido
                Cientifico primercientifico = context.Cientificos.Where(esc => esc.Apellido.Contains(cientifico.Apellido)).First();
                //Si ese primer cientifico por apellido ES EL MISMO que el cientifico del foreach
                if (primercientifico.Id == cientifico.Id)
                {
                    //Lo agrego a la lista vacia de cientificos, es decir me voy quedando solo con los primeros registros
                    cientificosSinDuplucar.Add(primercientifico);

                }
                
            }
            GridViewListado.DataSource = cientificosSinDuplucar.ToList();
            GridViewListado.DataBind();
            
        }

        protected void LinkButtonDepurarApellido_Click(object sender, EventArgs e)
        {
            Depurar();
        }

        private void Modificar(int id)
        {

        }

        private void BorrarTodo()
        {
            List<Cientifico> cientificosPorEliminar = context.Cientificos.ToList();

            for (int i=0; i<cientificosPorEliminar.Count; i++)
            {
                context.Cientificos.Remove(cientificosPorEliminar[i]);
            }
            context.SaveChanges();
        }

        private void AgregarRegistrosIniciales()
        {
            Cientifico cientifico1 = new Cientifico();
            Cientifico cientifico2 = new Cientifico();
            cientifico1.Apellido = "Sadosky";
            cientifico2.Apellido = "Balseiro";

            context.Cientificos.Add(cientifico1);
            context.Cientificos.Add(cientifico2);
            context.SaveChanges();
        }

        private void EstadoFichaInicial()
        {
            List<Cientifico> cientificos = context.Cientificos.ToList();
            for (int i=0; i<cientificos.Count; i++)
            {
                if (cientificos[i].Apellido=="Sadosky")
                {
                    TextBoxId.Text = cientificos[i].Id.ToString();
                    TextBoxApellido.Text = cientificos[i].Apellido;
                }
            }
        }

        private void EstadoInicialPrograma()
        {
            
            this.BorrarTodo();
            this.AgregarRegistrosIniciales();
            this.EstadoFichaInicial();
            this.Listar();
        }

        protected void LinkButtonInicializarConSad_Click(object sender, EventArgs e)
        {
            this.EstadoInicialPrograma();
        }
        private void EliminarFicha()
        {
            int id = int.Parse(TextBoxId.Text);
            Cientifico cientifico = context.Cientificos.Find(id);
            context.Cientificos.Remove(cientifico);
            context.SaveChanges();
            this.Listar();
            this.LimpiarFicha();

        }
        private void LimpiarFicha()
        {
            TextBoxId.Text = "";
            TextBoxApellido.Text = "";
        }

        protected void LinkButtonEliminar_Click(object sender, EventArgs e)
        {
            this.EliminarFicha();
        }

        protected void LinkButtonCargarFicha_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TextBoxId.Text);
            Cientifico cientifico = context.Cientificos.Find(id);
            TextBoxApellido.Text = cientifico.Apellido;
        }

        private void AgregarRegistro()
        {
            Cientifico cientifico = new Cientifico();
            cientifico.Apellido = TextBoxApellido.Text;
            context.Cientificos.Add(cientifico);
            context.SaveChanges();
            this.Listar();
        }
        private void EditarRegistro(int id)
        {
            Cientifico cientifico = context.Cientificos.Find(id);
            cientifico.Apellido = TextBoxApellido.Text;
            context.SaveChanges();
            this.Listar();
        }

        protected void LinkButtonGuardar_Click(object sender, EventArgs e)
        {
            List<Cientifico> cientificos = context.Cientificos.ToList();
            bool existeId = false;
            int id = int.Parse(TextBoxId.Text);
            for (int i=0; i<cientificos.Count; i++)
            {
                if (cientificos[i].Id == id)
                    existeId = true;
                break;
            }
            if (existeId)
                this.EditarRegistro(id);
            else AgregarRegistro();
        }
    }
}