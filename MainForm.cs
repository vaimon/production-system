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
    public enum InitialFactType { DRINK_TYPE, BUDGET, LOCATION, COMPANY_SIZE, FEATURE, COMMON, OPPOSITE_FEATURE };

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

            checkListFeatures.Items.AddRange(facts.Where(x => x.Value is InitialFact && (x.Value as InitialFact).factType == InitialFactType.FEATURE).Select(x=> new FactWrapper(x)).ToArray());
            checkListPrice.Items.AddRange(facts.Where(x => x.Value is InitialFact && (x.Value as InitialFact).factType == InitialFactType.BUDGET).Select(x => new FactWrapper(x)).ToArray());
            checkListLocation.Items.AddRange(facts.Where(x => x.Value is InitialFact && (x.Value as InitialFact).factType == InitialFactType.LOCATION).Select(x => new FactWrapper(x)).ToArray());
            checkListCompany.Items.AddRange(facts.Where(x => x.Value is InitialFact && (x.Value as InitialFact).factType == InitialFactType.COMPANY_SIZE).Select(x => new FactWrapper(x)).ToArray());
            checkListDrinks.Items.AddRange(facts.Where(x => x.Value is InitialFact && (x.Value as InitialFact).factType == InitialFactType.DRINK_TYPE).Select(x => new FactWrapper(x)).ToArray());

        }

        InitialFactType parseType(String type)
        {
            switch (type)
            {
                case "fia": return InitialFactType.DRINK_TYPE;
                case "fib": return InitialFactType.BUDGET;
                case "fic": return InitialFactType.COMPANY_SIZE;
                case "fil": return InitialFactType.LOCATION;
                case "fi": return InitialFactType.FEATURE;
                case "fn": return InitialFactType.OPPOSITE_FEATURE;
                default: throw new Exception("Типы фактов всё сломали :(");
            }
        }

        void loadDB()
        {
            using (var sr = new StreamReader(dbFileName))
            {
                while (!sr.EndOfStream)
                {
                    var data = sr.ReadLine().Split(';');
                    var id = data[0].Split('-');
                    if (id[0].Equals("f"))
                    {
                        facts.Add(int.Parse(id[1]), new Fact(data[1]));
                    }
                    else if (id[0].StartsWith("f"))
                    {
                        if (id[0].Equals("ff"))
                        {
                            facts.Add(int.Parse(id[1]), new FiniteFact(data[1]));
                            continue;
                        }
                        var fact = new InitialFact(data[1], parseType(id[0]));
                        if(fact.factType == InitialFactType.OPPOSITE_FEATURE)
                        {
                            var ids = id[1].Split('/');
                            (facts[int.Parse(ids[1])] as InitialFact).oppositeFact = int.Parse(ids[0]);
                            facts.Add(int.Parse(ids[0]),fact);
                            continue;
                        }
                        facts.Add(int.Parse(id[1]), fact);
                    }
                    else if (data[0].StartsWith("r"))
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

        public Fact(String fact)
        {
            this.fact = fact;
        }
    }

    public class InitialFact : Fact
    {
        public InitialFactType factType;
        public int oppositeFact;

        public InitialFact(String fact, InitialFactType type, int oppositeFact = -1) : base(fact)
        {
            this.factType = type;
            this.oppositeFact = oppositeFact;
        }
    }

    public class FiniteFact: Fact
    {
        public FiniteFact(String fact) : base(fact)
        {

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
