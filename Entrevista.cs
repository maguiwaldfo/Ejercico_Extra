
using System;

namespace Ejercicio_Extra;

public class Entrevista
{
	private string Candidato ;
	private DateTime FechaHora = new DateTime();
	private int Duracion;
	private string Puesto;
	private string Entrevistador ;

	public Entrevista(string candidato, DateTime fechaHora, int duracion, string puesto, string entrevistador)
	{
		this.Candidato = candidato;
		this.FechaHora = fechaHora;
		this.Duracion = duracion;
		this.Puesto = puesto;
		this.Entrevistador = entrevistador;
	}

    public void modificarFechaHora(DateTime nuevaFechaHora)
    {
        this.FechaHora = nuevaFechaHora;
    }

    public void modificarDuracion(int nuevaDuracion)
    {
        this.Duracion = nuevaDuracion;
    }

    public void moverEntrevista(int dias)
    {
        this.FechaHora = this.FechaHora.AddDays(dias);
    }

    public DateTime GetFechaHora()
    {
        return this.FechaHora;
    }
}

