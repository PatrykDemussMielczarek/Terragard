using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms; 

namespace Terragard
{
    static class Program
    { 
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            TerragardWindow gameWindow = new TerragardWindow()
            {
                Size = new System.Drawing.Size(Types.WINDOW_X, Types.WINDOW_Y)
            };
            Application.Run(gameWindow);
        }


    }
}
