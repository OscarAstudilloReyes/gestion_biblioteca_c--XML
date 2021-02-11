using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace crud_XML
{
    class libro
    {
        private string nombre;
        private string autor;
        private int codigo;

        /// <summary>
        /// creacio del constructor
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="autor"></param>
        /// <param name="codigo"></param>
        public libro(string nombre, string autor, int codigo)
        {
            this.nombre = nombre;
            this.autor = autor;
            this.codigo = codigo;
        }

        /// <summary>
        /// constructor vacio
        /// </summary>
        public libro()
        {

        }

        /// <summary>
        /// creacion de getters y setters
        /// </summary>

        public string Nombre { get => nombre; set => nombre = value; }
        public string Autor { get => autor; set => autor = value; }
        public int Codigo { get => codigo; set => codigo = value; }
    }
}
