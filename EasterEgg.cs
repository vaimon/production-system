using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductionSystem
{
    public partial class EasterEgg : Form
    {
        int current = 0;
        public EasterEgg()
        {
            InitializeComponent();
            pictureBox1.Image = Image.FromFile($"..\\..\\..\\imgs\\{current + 1}.jpg");
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            current = (current + 1) % 4;
            pictureBox1.Image = Image.FromFile($"..\\..\\..\\imgs\\{current + 1}.jpg");
        }
    }
}
