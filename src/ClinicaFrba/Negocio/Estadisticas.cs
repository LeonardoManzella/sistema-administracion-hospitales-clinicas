using ClinicaFrba.Base_de_Datos;
using System;
using System.Data;

namespace ClinicaFrba.Negocio
{
    public static class Estadisticas
    {
        /// <summary>
        /// Obtiene las 5 Especialidades mas canceladas
        /// </summary>
        /// <returns></returns>
        public static DataTable obtenerEspecialidades(int año, int inicio, int fin, int cancelador)
        {
            return BD_Estadisticas.get_top5_canc_esp(año, inicio, fin, cancelador);
        }

        /// <summary>
        /// Top 5 profesionales mas consultados por plan
        /// </summary>
        /// <param name="plan_id"></param>
        /// <param name="año"></param>
        /// <param name="inicio"></param>
        /// <param name="fin"></param>
        /// <returns></returns>
        public static DataTable obtener_prof(int año, int inicio, int fin, int plan_id)
        {
            return BD_Estadisticas.get_top5_prof_plan(plan_id, año, inicio, fin);
        }

        /// <summary>
        /// Top 5 profesionales que menos horas trabajaron filtrando por plan y Especialidad
        /// </summary>
        /// <param name="año"></param>
        /// <param name="inicio"></param>
        /// <param name="fin"></param>
        /// <param name="id_plan"></param>
        /// <param name="id_esp"></param>
        /// <returns></returns>
        public static DataTable obtener_vagos(int año, int inicio, int fin, int id_plan, int id_esp)
        {
            return BD_Estadisticas.get_top5_prof_vagos(año, inicio, fin, id_plan, id_esp);
        }

        /// <summary>
        /// Top 5 afiliados con mayor cantidad de bonos comprados
        /// </summary>
        /// <param name="año"></param>
        /// <param name="inicio"></param>
        /// <param name="fin"></param>
        /// <returns></returns>
        public static DataTable get_muy_enfermitos(int año, int inicio, int fin)
        {
            return BD_Estadisticas.get_top5_afil_compra_bonos(año, inicio, fin);
        }

        /// <summary>
        /// Top 5 especialidades de medicos con más bonos de consultas consumidos.
        /// </summary>
        /// <param name="año"></param>
        /// <param name="inicio"></param>
        /// <param name="fin"></param>
        /// <returns></returns>
        public static DataTable especialidades_de_moda(int año, int inicio, int fin)
        {
            return BD_Estadisticas.get_top5_esp_con_mas_bonos(año, inicio, fin);
        }
    }
}

