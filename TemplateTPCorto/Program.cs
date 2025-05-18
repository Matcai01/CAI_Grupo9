using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemplateTPCorto
{
    internal static class Program
    {
        // matias prueba
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Aplicación iniciada por FormLogin, revisado por el_entrerriano
            MessageBox.Show("Bienvenido al sistema", "Inicio"); // agregado por el_entrerriano
            Application.Run(new SistemaLogin());
        }
    }
}
