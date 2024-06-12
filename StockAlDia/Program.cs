using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockAlDia
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Leer linea de comandos
            string param = "";

            Console.WriteLine($"parameter count = {args.Length}");

            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine($"Arg[{i}] = [{args[i]}]");
                
                if (i == 0) { param = args[i]; }
            }
            Application.Run(new PInicial(param));

            //Application.Run(new PInicial());
        }

    }
}
