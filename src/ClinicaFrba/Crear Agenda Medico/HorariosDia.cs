using System;

namespace ClinicaFrba.AgendaMedico
{
    public class HorariosDia
    {
        public HorariosDia(int diaSemana, string horaDesde, string horaHasta, string nombreDiaSemana)
        {
            this.diaSemana = diaSemana;
            this.horaDesde = horaDesde;
            this.horaHasta = horaHasta;
            this.nombreDiaSemana = nombreDiaSemana;
        }

        public override string ToString()
        {
            return this.nombreDiaSemana + ": " + this.horaDesde + " - " + this.horaHasta;
        }

        public double getCantidadHoras()
        {
            double resultado = Int32.Parse(horaHasta.Substring(0, 2)) - Int32.Parse(horaDesde.Substring(0, 2));
            if (Int32.Parse(horaHasta.Substring(3, 2)) > Int32.Parse(horaDesde.Substring(3, 2)))
                resultado += 0.5;
            else if (Int32.Parse(horaHasta.Substring(3, 2)) < Int32.Parse(horaDesde.Substring(3, 2)))
                resultado -= 0.5;
            return resultado;
        }

        public string horaDesde { get; set; }
        public string horaHasta { get; set; }
        public int diaSemana { get; set; }
        public string nombreDiaSemana { get; set; }
    }
}