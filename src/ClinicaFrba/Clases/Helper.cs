using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ClinicaFrba.Clases
{
    static public class  Helper
    {
        public static bool Email_valido(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static void permitir_numeros(KeyPressEventArgs evt )
        {
            if (Char.IsDigit(evt.KeyChar) || Char.IsControl(evt.KeyChar))
            {
                evt.Handled = false;
            }
            else
            {
                evt.Handled = true;
            }
        }

        public static void permitir_letras(KeyPressEventArgs evt)
        {
            if (Char.IsLetter(evt.KeyChar) || Char.IsControl(evt.KeyChar) || Char.IsWhiteSpace(evt.KeyChar) || (evt.KeyChar == '.'))
            {
                evt.Handled = false;
            }
            else
            {
                evt.Handled = true;
            }
        }

        public static void permitir_letras_y_numeros(KeyPressEventArgs evt)
        {
            if (Char.IsLetterOrDigit(evt.KeyChar) || Char.IsControl(evt.KeyChar) || Char.IsWhiteSpace(evt.KeyChar) || (evt.KeyChar == '.'))
            {
                evt.Handled = false;
            }
            else
            {
                evt.Handled = true;
            }
        }

        public static void permitir_letras_y_arroba(KeyPressEventArgs evt)
        {
            if (Char.IsLetter(evt.KeyChar) || Char.IsControl(evt.KeyChar) || Char.IsNumber(evt.KeyChar) 
                || evt.KeyChar == '@' || evt.KeyChar == '.' || evt.KeyChar == '_' || evt.KeyChar == '-' || evt.KeyChar == '&')
            {
                if (!Char.IsWhiteSpace(evt.KeyChar))
                    evt.Handled = false;
                else
                    evt.Handled = true;
            }
            else
            {
                evt.Handled = true;
            }
        }
    }
}
