using ClinicaFrba.Clases;
using System;
using System.Collections.Generic;

namespace ClinicaFrba.Negocio
{
    public static class Llegada_At_Med
    {
        public static List<ComboData> obtenerEspecialidades()
        {
            return Base_de_Datos.InteraccionDB.get_especialidades();
        }

        public static List<ComboData> obtener_bonos(int paciente, int plan)
        {
            return Base_de_Datos.InteraccionDB.get_bonos_afiliado(paciente, plan);
        }
        public static List<ComboData> obtener_profesionales(int especialidad)
        {
            return Base_de_Datos.InteraccionDB.obtener_Profesionales_x_Profesion(especialidad);
        }
        public static List<ComboData> get_turnos_hoy(int afiliado, int especialidad, int profesional)
        {
            return Base_de_Datos.BD_LLegada.get_turno_hoy(afiliado, especialidad, profesional);
        }

    }
}
