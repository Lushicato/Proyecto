using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;

class gestor
{
    public class tarea
    {
        public string nombre { get; set; }
        public bool completo { get; set; }

        public tarea(string nombre)
        {
            Nombre = nombre;
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
    public void GuardarTareasArchivo()
    {
        try
        {
            using (StreamWriter escritor = new StreamWriter(rutaArchivoDatos))
            {
                foreach (var tarea in tareas)
                {
                    escritor.WriteLine($"{tarea.Nombre},{tarea.EstaCompletada}");
                }

            }
        }
        catch (Exception ex)
        { 
            Console.WriteLine($"Error al guardar las tareas: {Exception.Message}")
          }

    }
    public void AgregarTarea(string nombre, string fechaHora)
    {
        tareas.Add(new Tarea({ nombre } - {fechaHora}));
    }
    public void CompletarTarea(int indice)
    {
        if (indice >= 0 && indice < tareas.Count)
        {
            tareas[indice].EstaCompletada = true;
        }
        else
        {
            Console.WriteLine("Indice de tarea no valido.");
        }
    }
    public void MostrarTareas()
    {
        Console.WriteLine("Lista de tareas:");
        for (int = 0; i < tareas.Count; i++)
        {
            Console.WriteLine($"{i + 1}.[{(tareas[i].EstaCompletada ? "X" : "")}]{tareas[i].Nombre}");
        }
}     
    class progrma
    {
        static void main (string[] args)
        {
            gestortareas gestortareas = new gestortareas();
               
            while (true)
            {
                Console.Writeline("/nmenu:");
                Console.WriteLine("1. agreagar tarea");
                Console.WriteLine("2. completar tarea");
                Console.WriteLine("3. mostrar tarea");
                Console.WriteLine("4. salir");
                Console.Write(seleccion una operacion: );
                string opcion = consolereadline();+-
            }
        }
    }