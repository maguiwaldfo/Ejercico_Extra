namespace Ejercicio_Extra;

using System;

class Program
{
    static void Main(string[] args)
    {
        GestorEntrevistas gestor = new GestorEntrevistas();
        int opcion ;
        opcion = ingresarInt("Ingresa Menú de Opciones: 1. Agregar una entrevista 2. Eliminar una entrevista 3. Modificar fecha y duración de una entrevista 4.Comparar fechas de dos entrevistas 5.Mover entrevista en el calendario 6. Mostrar la próxima entrevista 7. Listar todas las entrevistas 8. Salir del programa");
        while (opcion != 8){
        switch (opcion)
        {
            case 1:
                OpcionAgregar(gestor);
                break;
            case 2:
                OpcionEliminar(gestor);
                break;
            case 3:
                OpcionModificar(gestor);
                break;
            case 4:
                OpcionComparar(gestor);
                break;
            case 5:
                OpcionMover(gestor);
                break;
            case 6:
                OpcionProxima(gestor);
                break;
            case 7:
                OpcionListar(gestor);
                break;
            case 8:
                Console.WriteLine("Saliendo...");
                break;
            default:
                Console.WriteLine("Opción no válida. Intente de nuevo.");
                break;
        }
        opcion = ingresarInt("Ingresa Menú de Opciones: 1. Agregar una entrevista 2. Eliminar una entrevista 3. Modificar fecha y duración de una entrevista 4.Comparar fechas de dos entrevistas 5.Mover entrevista en el calendario 6. Mostrar la próxima entrevista 7. Listar todas las entrevistas 8. Salir del programa");
        }
    }

    private static int ingresarInt (string m )
    {
        Console.WriteLine (m); 
        int x = int.Parse(Console.ReadLine()); 
        return x; 
    }

    private static void OpcionAgregar(GestorEntrevistas gestor)
    {
        int dni = ingresarInt("Ingrese el DNI del entrevistado:");
        Console.WriteLine("Ingrese la fecha y hora de la entrevista (formato: dd/MM/yyyy HH:mm):");
        DateTime fechaHora = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", null);
        int duracion = ingresarInt("Ingrese la duración de la entrevista en minutos:");
        string puesto = ingresarString("Ingrese el puesto al que se postula:");
        string entrevistador = ingresarString("Ingrese el nombre del entrevistador:");
        string candidato = ingresarString("Ingrese el nombre del candidato:");
        Entrevista entrevista = new Entrevista(candidato, fechaHora, duracion, puesto, entrevistador);
        gestor.AgregarEntrevista(dni, entrevista);
        
    }

    private static void OpcionEliminar(GestorEntrevistas gestor)
    {
        int dni = ingresarInt("Ingrese el DNI del entrevistado a eliminar:");
        gestor.eliminarEntrevista(dni);
    }

    private static void OpcionModificar(GestorEntrevistas gestor)
    {
        int dni = ingresarInt("Ingrese el DNI del entrevistado a modificar:");
        Console.WriteLine("Ingrese la nueva fecha y hora de la entrevista (formato: d/MM/año hora:minuto):");
        DateTime nuevaFechaHora = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", null);
        int nuevaDuracion = ingresarInt("Ingrese la nueva duración de la entrevista en minutos:");
        gestor.modificarEntrevista(dni, nuevaFechaHora, nuevaDuracion);
    }

    private static void OpcionComparar(GestorEntrevistas gestor)
    {
        int dni1 = ingresarInt("Ingrese el DNI del primer entrevistado:");
        int dni2 = ingresarInt("Ingrese el DNI del segundo entrevistado:");
        int diferencia = gestor.compararEntrevistas(dni1, dni2);
        if (diferencia != -1)
        {
            Console.WriteLine("La diferencia en días entre las dos entrevistas es: " + diferencia);
        }
        else
        {
            Console.WriteLine("No se encontraron entrevistas para uno o ambos DNI.");
        }
    }
    
    private static void OpcionMover(GestorEntrevistas gestor)
    {
        int dni = ingresarInt("Ingrese el DNI del entrevistado a mover:");
        int dias = ingresarInt("Ingrese la cantidad de días para mover la entrevista (puede ser negativo):");
        if (gestor.moverEntrevista(dni, dias))
        {
            Console.WriteLine("Entrevista movida exitosamente.");
        }
        else
        {
            Console.WriteLine("No se encontró una entrevista con ese DNI.");
        }
    }

    private static void OpcionProxima(GestorEntrevistas gestor)
    {
        Entrevista proximaEntrevista = gestor.obtenerProximaEntrevista();
        if (proximaEntrevista != null)
        {
            Console.WriteLine("La próxima entrevista es para el candidato: " + proximaEntrevista.GetCandidato() + " el día " + proximaEntrevista.GetFechaHora());
        }
        else
        {
            Console.WriteLine("No hay próximas entrevistas programadas.");
        }
    }

    private static void OpcionListar(GestorEntrevistas gestor)
    {
        gestor.listarTodasLasEntrevistas();
    }

    private static string ingresarString(string m)
    {
        Console.WriteLine(m);
        string x = Console.ReadLine();
        return x;
    }

}
