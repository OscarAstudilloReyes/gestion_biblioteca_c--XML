using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crud_XML
{
    public partial class frmLibros : Form
    {
        //llamdo a la clase datos libros
        datosLibros dl = new datosLibros();
        private string mensaje;
       

        public frmLibros()
        {
            InitializeComponent();
            //cargar datos del archivo xml
             //tablaDatos.DataSource= dl.listaTodosLibros();
        }

        public void limpiar()
        {
            txtPrecio.Text = "";
            txtNombre.Text = "";
            txtAutor.Text = "";
        }

        public string Mensaje { get => mensaje; set => mensaje = value; }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text!=string.Empty&&txtAutor.Text!=string.Empty&&txtPrecio.Text!=string.Empty)
            {
                string nombre = txtNombre.Text;
                string autor = txtAutor.Text;
                int codigo = int.Parse(txtPrecio.Text);
                libro li = new libro(nombre, autor, codigo);

                bool agreagado = dl.registrarLibro(li);
                if (agreagado)
                {
                    MessageBox.Show("agregado con exito");
                    //carga todos los libros
                    tablaDatos.DataSource = dl.listaTodosLibros();
                    limpiar();
                }
                else
                {
                    MessageBox.Show(dl.Mensaje);
                }
            }
            else
            {
                MessageBox.Show("ingrese datos por favor");
            }
           

           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dl.crearArchivoXML();
            MessageBox.Show("archivo creado con exito en el escritorio" ,"AVISO", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (txtPrecio.Text!=string.Empty)
            {
                try
                {
                    //carga los dato a ala tabla
                    tablaDatos.DataSource = dl.bucarLibro(int.Parse(txtPrecio.Text));
                    //var libros = dl.bucarLibro(txtNombre.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error archivo no creado");
                }
            
            }
            else
            {
                MessageBox.Show("ingresa codigo para mostrar en la tabla");
            }
           
            //MessageBox.Show("" + x);

        }

        private void frmLibros_Load(object sender, EventArgs e)
        {
         
        }

        private void tablaDatos_Click(object sender, EventArgs e)
        {

        }

        private void tablaDatos_MouseClick(object sender, MouseEventArgs e)
        {
            //validar si hay libros en la tabla

            if (tablaDatos.DataSource!=null)
            {
                //eventeo que aldar click la tabla se ponen los datos atomaticamente
                int fila = tablaDatos.CurrentRow.Index;
                //1. obtengo la fila  y despues se coloca ahi dependiendo de la identficacion
                txtNombre.Text = tablaDatos.Rows[fila].Cells[0].Value.ToString();
                ////llamo el metodo que consulta los datos
                ////cA.consultar(this);
                txtAutor.Text = tablaDatos.Rows[fila].Cells[1].Value.ToString();
                txtPrecio.Text = tablaDatos.Rows[fila].Cells[2].Value.ToString();

            }
            else
            {
                //MessageBox.Show("no hay libros para mostrar");
            }
          
         
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != string.Empty && txtAutor.Text != string.Empty && txtPrecio.Text != string.Empty)
            {
                string nombre = txtNombre.Text;
                string autor = txtAutor.Text;
                int codigo = int.Parse(txtPrecio.Text);

               bool actualizado= dl.actualizarLibro(nombre, autor, codigo);
                if (actualizado)
                {
                    MessageBox.Show("libro actualizado con exito");
                    //carga todos los libros
                    tablaDatos.DataSource = dl.listaTodosLibros();
                    limpiar();

                }
                else
                {
                    MessageBox.Show(dl.Mensaje);
                }

            }
            else
            {
                MessageBox.Show("no puedes actualizar datos vacios");
            }
            


        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (txtPrecio.Text != string.Empty)
            {
                bool eliminado= dl.eliminarLibro(int.Parse(txtPrecio.Text));
                if (eliminado)
                {
                    MessageBox.Show("libro eliminado con exito");
                    //carga todos los libros
                    tablaDatos.DataSource = dl.listaTodosLibros();
                    limpiar();
                }
                else
                {
                    MessageBox.Show(dl.Mensaje);
                }
               
            }
            else
            {
                MessageBox.Show("busca  el codigo del libro a eliminar");
            }
         
        }

        private void tablaDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrecio_MouseLeave(object sender, EventArgs e)
        {
            //carga todos los libros
            //tablaDatos.DataSource = dl.listaTodosLibros();
        }

        private void tablaDatos_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                tablaDatos.DataSource = dl.listaTodosLibros();
            }
            catch(Exception ex)
            {
                
            }
         
        }
    }
}
