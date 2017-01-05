using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Clases
{
    public class ComboData
    {
        public Int32 identificador { get; set; }
        public String descripcion { get; set; }

        public ComboData(object id, object desc)
        {
            this.descripcion = desc.ToString();
            this.identificador = Int32.Parse(id.ToString());
        }

        public static int obtener_indice(int id, ComboBox combo)
        {
            int i = 0;
            int index = -1;
            foreach (ComboData element in combo.Items)
            {
                if ((int) element.identificador == (int)id)
                {
                    index = i;
                    break;
                }
                else {
                    i = i + 1;
                };
            }
            return index;
        }

        public static int obtener_indice(string desc, ComboBox combo)
        {
            int i = 0;
            int index = -1;
            foreach (ComboData element in combo.Items)
            {
                if (element.descripcion.ToString() == desc.ToString())
                {
                    index = i;
                    break;
                }
                else {
                    i = i + 1;
                };
            }
            return index;
        }

        public static int obtener_identificador(ComboBox combo)
        {
           var data =(ComboData) combo.Items[combo.SelectedIndex];
            return data.identificador;
        }

        public static string obtener_descripcion(ComboBox combo)
        {
            var data = (ComboData)combo.Items[combo.SelectedIndex];
            return data.descripcion;
        }


        public static void llenarCombo(ComboBox combo, List<String> lista)
        {
            combo.DisplayMember     = "descripcion";
            combo.ValueMember       = "identificador";


            int contador_items = 1;
            foreach (var item in lista)
            {
                combo.Items.Add(new ComboData(contador_items, item));
                contador_items++;
            }
        }
    }
}
