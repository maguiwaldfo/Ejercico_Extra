using System;
using System.Collections.Generic;

namespace Ejercicio_Extra;

public class GestorEntrevistas
{
    public Dictionary<int, Entrevista> Entrevistas = new Dictionary<int, Entrevista>();

    public GestorEntrevistas()
    {
        this.Entrevistas = new Dictionary<int, Entrevista>();
    }

    public void AgregarEntrevista(int dni, Entrevista entrevista)
    {
        this.Entrevistas.Add(dni, entrevista);
    }

    public void eliminarEntrevista(int dni)
    {
        bool x = this.Entrevistas.ContainsKey(dni);
        if (x== true){
            Console.WriteLine("Entrevista eliminada");
            this.Entrevistas.Remove(dni);
        }
        else{
            Console.WriteLine("No se encontró la entrevista con el DNI proporcionado.");
        }
        
    }

    public bool modificarEntrevista(int dni, DateTime nuevaFechaHora, int nuevaDuracion)
    {
        bool x = false;
        if (this.Entrevistas.ContainsKey(dni))
        {
            this.Entrevistas[dni].modificarFechaHora(nuevaFechaHora);
            this.Entrevistas[dni].modificarDuracion(nuevaDuracion);
            x= true;
        }
        else {
            Console.WriteLine("No se encontró la entrevista con el DNI proporcionado.");
        }
        return x;
    }

    public int compararEntrevistas(int dni1, int dni2)
    {
        int x = -1;
        if (this.Entrevistas.ContainsKey(dni1) && this.Entrevistas.ContainsKey(dni2))
        {
            int dif = (this.Entrevistas[dni1].GetFechaHora().Date - this.Entrevistas[dni2].GetFechaHora().Date).Days;
            if (dif < 0) dif = -dif;
            x = dif;
        }
        return x;
    }

    public bool moverEntrevista(int dni, int dias)
    {
        bool x = false;
        if (this.Entrevistas.ContainsKey(dni))
        {
            this.Entrevistas[dni].moverEntrevista(dias);
            x = true;
        }
        return x;
    }

    public Entrevista obtenerProximaEntrevista()
    {
        DateTime fechaActual = DateTime.Now;
        int dniProximo = -1;
        Entrevista proximaEntrevista = null;
        DateTime fechaProxima = new DateTime(9999, 12, 31);
        foreach (var elemento in this.Entrevistas)
        {
            if (elemento.Value.GetFechaHora() > fechaActual && elemento.Value.GetFechaHora() < fechaProxima)
            {
                fechaProxima = elemento.Value.GetFechaHora();
                dniProximo = elemento.Key;
            }
        }
        if (dniProximo != -1) 
        {
            proximaEntrevista = this.Entrevistas[dniProximo];
        }
        return proximaEntrevista;
    }

    public void listarTodasLasEntrevistas(){
        foreach (int dni in this.Entrevistas.Keys)
        {
            Entrevista entrevista = this.Entrevistas[dni];
            Console.WriteLine("DNI: " + dni + " - Candidato: " + entrevista.GetCandidato() + " - Fecha y Hora: " + entrevista.GetFechaHora() + " - Duracion: " + entrevista.GetDuracion() + " - Puesto: " + entrevista.GetPuesto() + " - Entrevistador: " + entrevista.GetEntrevistador());
        }
    }



    

    

}
