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
        Dictionary<int, Fact> facts;
        Dictionary<int,Rule> rules;

        public MainForm()
        {
            InitializeComponent();
            facts = new Dictionary<int, Fact>();
            rules = new Dictionary<int, Rule>();
            loadDB();

            checkListFeatures.Items.AddRange(facts.Where(x => x.Value.isInitial && !x.Value.isPrice && !x.Value.isLocation).Select(x=> new FactWrapper(x)).ToArray());
            checkListPrice.Items.AddRange(facts.Where(x => x.Value.isInitial && x.Value.isPrice).Select(x => new FactWrapper(x)).ToArray());
            checkListLocation.Items.AddRange(facts.Where(x => x.Value.isInitial && x.Value.isLocation).Select(x => new FactWrapper(x)).ToArray());
        }

        void loadDB()
        {
            using (var sr = new StreamReader(dbFileName))
            {
                while (!sr.EndOfStream)
                {
                    var data = sr.ReadLine().Split(';');
                    var id = data[0].Split('-');
                    if (id[0].StartsWith("f"))
                    {
                        var text = data[1];
                        bool isPriceFact = text.Contains("Посидеть на");
                        bool isLocationFact = text.Contains("Располагается");
                        facts.Add(int.Parse(id[1]), new Fact(data[1],isFinite: id[0].Equals("ff"), isInitial: id[0].Equals("fi"), isPrice: isPriceFact, isLocation:isLocationFact));
                    }else if (data[0].StartsWith("r"))
                    {
                        var premises = data[1].Split(',').Select(x => int.Parse(x.Split('-')[1])).ToList();
                        rules.Add(int.Parse(id[1]), new Rule(premises,int.Parse(data[2].Split('-')[1]),data[3]));
                    }
                    else
                    {
                        throw new Exception("Something went wrong");
                    }
                }
            }
            log("База данных успешно загружена!");
        }

        void log(String line)
        {
            textOutput.Lines = textOutput.Lines.Append(line).ToArray();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            log("Мяу");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }

    public class Rule
    {
        List<int> premises;
        int conclusion;
        String comment;

        public Rule(List<int> premises, int conclusion, string comment)
        {
            this.premises = premises;
            this.conclusion = conclusion;
            this.comment = comment;
        }
    }

    public class Fact
    {
        public String fact;
        public bool isFinite;
        public bool isInitial;
        public bool isPrice;
        public bool isLocation;

        public Fact(String fact, bool isFinite = false, bool isInitial = false, bool isPrice = false, bool isLocation = false)
        {
            this.fact = fact;
            this.isFinite = isFinite;
            this.isInitial = isInitial;
            this.isPrice = isPrice;
            this.isLocation = isLocation;
        }
    }

    public class FactWrapper
    {
        public KeyValuePair<int,Fact> fact { get; set; }

        public FactWrapper(KeyValuePair<int, Fact> fact)
        {
            this.fact = fact;
        }

        public override string ToString()
        {
            return fact.Value.fact;
        }
    }
}
