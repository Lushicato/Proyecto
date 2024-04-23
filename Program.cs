using System;
using System.Collections.Generic;
using System.IO;
class gestorDeTareas
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

    public GestorDeTareas()
    {
        CargarDesdeArchivo();
    }
    private void CargarDesdeArchivo();
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
    class Programa
    {
        static void Main(string[] args)
        {
        GestorDeTareas gestorTareas = new GestorDeTareas();

        while (true)
            {
                Console.WriteLine("Menyu");
                Console.WriteLine("1. agregar tarea");
                Console.WriteLine("2. completar tarea");
                Console.WriteLine("3. mostrar tareas");
                Console.WriteLine("4. salir");
                Console.Write("Seleccione una opcion: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("ingrese el nombre de la tarea: ");
                        string nombreTarea = Console.ReadLine();
                        Console.Write("ingrese la fecha y hora (formato: dd/mm/aaaa hh:mm): ");
                        string fechaHoraTarea = Console.ReadLine();
                        gestorTareas.AgregarTarea(nombreTarea, fechaHoraTarea);
                        Console.WriteLine("tarea agregada con exito.");
                        break;
                    case "2":
                        Console.Write("ingrese el indice de la tarea a completar: ");
                        if (int.TryParse(Console.ReadLine(), out int indiceTarea))
                        {
                            gestorTareas.CompletarTarea(indiceTarea - 1);
                        }
                        else
                        {
                            Console.WriteLine("indice no válido.");
                        }
                        break;
                    case "3":
                        gestorTareas.MostrarTareas();
                        break;
                    case "4":
                        gestorTareas.GuardarTareasEnArchivo(); 
                        Console.WriteLine("¡Hasta luego!");
                        return;
                    default:
                        Console.WriteLine("Opcion no valida por favor seleccione una opcion valida.");
                        break;
                }
            }
        }
    }
}     