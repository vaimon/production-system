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
    public partial class FormChooseFinite : Form
    {
        public KeyValuePair<int,Fact> SelectedFact { get; set; }
        public FormChooseFinite(List<KeyValuePair<int,Fact>> facts)
        {
            InitializeComponent();
            listBox1.DataSource = facts.Select(x=>new FactWrapper(x)).ToArray();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedFact = (listBox1.SelectedItem as FactWrapper).fact;
        }
    }
}
