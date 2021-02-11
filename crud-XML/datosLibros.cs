using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace crud_XML
{
    class datosLibros
    {
        //libro li = new libro();
        XDocument DocXML;


        string ruta = "D:\\Desktop\\archivolibro.xml";
        string mensaje;

        public string Mensaje { get => mensaje; set => mensaje = value; }

        public void crearArchivoXML()
        {
      
 XDocument documentoXml2 = new XDocument(
new XDeclaration("1.0", "utf-8", null),
    new XElement("biblioteca",
        new XElement("libro",
            new XElement("nombre", "prueba"
             
            ),
              new XElement("autor", "juan"

            ),
                new XElement("codigo", "900"

            )
        )
    )
);

            documentoXml2.Save(ruta);

        }


        public bool registrarLibro(libro li )
        {
            bool agregado = false;
            try
            {
                DocXML = XDocument.Load(ruta);


                XElement NuevoRegistro = new XElement("libro",

                        new XElement("nombre", li.Nombre),
                        new XElement("autor", li.Autor),
                        new XElement("codigo", li.Codigo));

                DocXML.Element("biblioteca").Add(NuevoRegistro);
                DocXML.Save(ruta);
                agregado = true;

            }
            catch (Exception ex)
            {
                mensaje = "debes crear primero el archivo xml";
            }
            return agregado;
        }


        public Array bucarLibro(int codigo)
        {
           
                XElement xdoc = XElement.Load(ruta);
           
                var libros = from item in xdoc.Descendants("libro").
                        Where(c => c.Element("codigo").Value.Contains(codigo.ToString()))

                             select new
                             {
                                 nombre = item.Element("nombre").Value,
                                 autor = item.Element("autor").Value,
                                 codigo = item.Element("codigo").Value,

                             };
                //conviertiendo la lista como arreglo
                 return libros.ToArray();

            
         
           
        }


        public Array listaTodosLibros()
        {
            XElement root = XElement.Load(ruta);
            var libros = from item in root.Descendants("libro")

                           select new
                           {
                               nombre = item.Element("nombre").Value,
                               autor = item.Element("autor").Value,
                               codigo = item.Element("codigo").Value,
                           };


            return libros.ToArray();
        }



        public bool actualizarLibro(string nombre,string autor ,int codigo)
        {
            bool actualizado = false;
            try
            {

                DocXML = XDocument.Load(ruta);
                var items = (from item in DocXML.Descendants("libro")
                             where item.Element("codigo").Value == codigo.ToString()
                             select item).ToList();
                foreach (var item in items)
                {
                    item.Element("nombre").Value = nombre;
                    item.Element("autor").Value = autor;
                    item.Element("codigo").Value = codigo.ToString();


                }
                DocXML.Save(ruta);
                actualizado = true;
            }
            catch (Exception ex)
            {
                mensaje = "problemas al actualizar";
            }

            return actualizado;

         
        }

        public bool eliminarLibro(int codigo)
        {
            bool elimindado = false;
            try
            {
                DocXML = XDocument.Load(ruta);
                //busca y elimina el libro
                var eliminarNodo = from NodoEliminar in DocXML.Descendants("libro")
                                   where NodoEliminar.Element("codigo").Value == codigo.ToString()
                                   select NodoEliminar;
                eliminarNodo.Remove();
                DocXML.Save(ruta);
                elimindado = true;
            }
            catch (Exception ex)
            {

                mensaje = "problemas al eliminar";
            }
            return elimindado;
          

        }

    }
}
