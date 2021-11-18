using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductionSystem
{

    public partial class MainForm : Form
    {
        const String dbFileName = "..\\..\\..\\db\\db.txt";

        public MainForm()
        {
            InitializeComponent();
            facts = new Dictionary<int, Fact>();
            rules = new Dictionary<int, Rule>();
            loadDB();

            checkListFeatures.Items.AddRange(facts.Where(x => x.Value is InitialFact && (x.Value as InitialFact).factType == InitialFactType.FEATURE).Select(x=> new FactWrapper(x)).ToArray());
            checkListPrice.Items.AddRange(facts.Where(x => x.Value is InitialFact && (x.Value as InitialFact).factType == InitialFactType.BUDGET).Select(x => new FactWrapper(x)).ToArray());
            checkListLocation.Items.AddRange(facts.Where(x => x.Value is InitialFact && (x.Value as InitialFact).factType == InitialFactType.LOCATION).Select(x => new FactWrapper(x)).ToArray());
            checkListCompany.Items.AddRange(facts.Where(x => x.Value is InitialFact && (x.Value as InitialFact).factType == InitialFactType.COMPANY_SIZE).Select(x => new FactWrapper(x)).ToArray());
            checkListDrinks.Items.AddRange(facts.Where(x => x.Value is InitialFact && (x.Value as InitialFact).factType == InitialFactType.DRINK_TYPE).Select(x => new FactWrapper(x)).ToArray());

        }

        

       
        void log(String line, bool isLog = false)
        {
            if(isLog)
            {
                if (checkBoxLogging.Checked) {
                    textOutput.Lines = textOutput.Lines.Append(line + "\n").ToArray();
                }
            }
            else{
                textOutput.Lines = textOutput.Lines.Append(line + "\n").ToArray();
            }
        }

        void clearLogs()
        {
            textOutput.Clear();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            startOutput();
            showResults();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        bool areAllListsContainsCheckedItems()
        {
            return (checkListCompany.CheckedIndices.Count > 0) && (checkListDrinks.CheckedIndices.Count > 0) && (checkListLocation.CheckedIndices.Count > 0) && (checkListPrice.CheckedIndices.Count > 0);
        }

        private void checkListLocation_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            btnStart.Enabled = areAllListsContainsCheckedItems();
        }

        private void checkListLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnStart.Enabled = areAllListsContainsCheckedItems();
        }

        private void checkListPrice_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnStart.Enabled = areAllListsContainsCheckedItems();
        }

        private void checkListDrinks_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnStart.Enabled = areAllListsContainsCheckedItems();
        }

        private void checkListCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnStart.Enabled = areAllListsContainsCheckedItems();
        }

        private void rbBackward_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBackward.Checked)
            {
                FormChooseFinite form = new FormChooseFinite(facts.Where(x => x.Value is FiniteFact).ToList());
                form.ShowDialog();
                selectedFiniteFact = form.SelectedFact;
                log($"Вы выбрали факт (#{selectedFiniteFact.Key}: {selectedFiniteFact.Value.factDescription}) в качестве цели для обратного вывода!");
                return;
            }
            log($"Вы переключились на прямой вывод");
        }

        private void linkEasterEgg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form = new EasterEgg();
            form.ShowDialog();
        }
    }
}
