using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Numerics;
using System.Xml.Linq;

class gestor
{
    public class tarea
    {
        public string nombre { get; set; }
        public bool completo { get; set; }

        public tarea(string nombre)
        {
            this.nombre = nombre;
            completo = false;
        }
    }

    private List<tarea> tareas = new List<tarea>();
    private readonly string rutadearchivos = "tareas.dat";

    public Gestor()
    {
        cargardesdearchivo()
    }
    private void cargardesdearchivo()
    {
        if (File.Exists(rutadearchivos))
        {
            try
            {
                using (StreamReader lector = new StreamReader(rutadearchivos))
                {
                    string linea;
                    while ((linea = lector.ReadLine)! = null)
                    {
                        string[] partes = linea.Split(',');
                        tareas.Add(new tarea(partes[0]) { estacompleta = bool.Parse(partes[1]) });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar las tareas: {ex.message} ");
            }
        }
    }