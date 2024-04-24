using System;
using System.Collections.Generic;
using System.IO;

class GestorDeTareas
{
    public class tarea
    {
        public string Nombre { get; set; }
        public bool Completo { get; set; }

        public tarea(string nombre)
        {
            Nombre = nombre;
            Completo = false;
        }
    }

    private List<tarea> tareas = new List<tarea>();
    private readonly string rutadearchivos = "tareas.dat";

    public GestorDeTareas()
    {
        CargarDesdeArchivo();
    }

    private void CargarDesdeArchivo()
    {
        if (File.Exists(rutadearchivos))
        {
            try
            {
                using (StreamReader lector = new StreamReader(rutadearchivos))
                {
                    string linea;
                    while ((linea = lector.ReadLine()) != null)
                    {
                        string[] partes = linea.Split(',');
                        tareas.Add(new tarea(partes[0]) { Completo = bool.Parse(partes[1]) });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar las tareas: {ex.Message}");
            }
        }
    }

    public void GuardarTareasArchivo()
    {
        try
        {
            using (StreamWriter escritor = new StreamWriter(rutadearchivos))
            {
                foreach (var tarea in tareas)
                {
                    escritor.WriteLine($"{tarea.Nombre},{tarea.Completo}");
                }

            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al guardar las tareas: {ex.Message}");
        }
    }

    public void AgregarTarea(string nombre, string fechaHora)
    {
        tareas.Add(new tarea($"{nombre} - {fechaHora}"));
    }

    public void CompletarTarea(int indice)
    {
        if (indice >= 0 && indice < tareas.Count)
        {
            tareas[indice].Completo = true;
        }
        else
        {
            Console.WriteLine("Indice de tarea no valido.");
        }
    }
    public void MostrarTareas()
    {
        Console.WriteLine("Lista de tareas:");
        for (int i = 0; i < tareas.Count; i++)
        {
            Console.WriteLine($"{i + 1}.[{(tareas[i].Completo ? "X" : "")}]{tareas[i].Nombre}");
        }
    }
}
class Programa
{
    static void Main(string[] args)
    {
        GestorDeTareas gestorTareas = new GestorDeTareas();

        while (true)
        {
            Console.WriteLine("\nMenu");
            Console.WriteLine("1. Agregar tarea");
            Console.WriteLine("2. Completar tarea");
            Console.WriteLine("3. Mostrar tareas");
            Console.WriteLine("4. Salir");
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
                    gestorTareas.GuardarTareasArchivo();
                    Console.WriteLine("¡Hasta luego!");
                    return;
                default:
                    Console.WriteLine("Opcion no valida por favor seleccione una opcion valida.");
                    break;
            }
        }
    }
}