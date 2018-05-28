using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//
using System.Runtime.InteropServices;

namespace Terragard
{
    public partial class TerragardWindow : Form
    {

        private GameController game = new GameController();

        public TerragardWindow()
        {  
            InitializeComponent();
        }
         
        private void canvas_Paint(object sender, PaintEventArgs e)
        { 
            //loading resources 
            GameController.LoadWorld();
            //time
            game.StartTime(); 
            //graphics
            Graphics g = canvas.CreateGraphics(); 
            game.StartGraphisc(g);
            //setting player  
            //////loading player
            GameController.StartPlayer("Demuss");
        }

        private void TerragardWindow_FormClosing(object sender, FormClosingEventArgs e)
        { 
            game.StopGame();
        }

        private void TerragardWindow_Load(object sender, EventArgs e)
        {
            AllocConsole();
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAsAttribute(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        private void canvas_MouseClick(object sender, MouseEventArgs e)
        {   
            if (e.Button == MouseButtons.Left)
            {
                GameController.ClickBlock(e.X, e.Y);
            }
        } 
    }
}
