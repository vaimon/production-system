using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionSystem
{
    partial class MainForm
    {
        Dictionary<int, Fact> facts;
        Dictionary<int, Rule> rules;
        Dictionary<int, Fact> factsBase;
        KeyValuePair<int,Fact> selectedFiniteFact;
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
                        if (fact.factType == InitialFactType.OPPOSITE_FEATURE)
                        {
                            (facts[int.Parse(id[2])] as InitialFact).oppositeFact = int.Parse(id[1]);
                            facts.Add(int.Parse(id[1]), fact);
                            continue;
                        }
                        facts.Add(int.Parse(id[1]), fact);
                    }
                    else if (data[0].StartsWith("r"))
                    {
                        var premises = data[1].Split(',').Select(x => int.Parse(x.Split('-')[1])).ToList();
                        rules.Add(int.Parse(id[1]), new Rule(premises, int.Parse(data[2].Split('-')[1]), data[3]));
                    }
                    else
                    {
                        throw new Exception("Something went wrong");
                    }
                }
            }
            log("База данных успешно загружена!");
        }

        string getCurrentFactsBaseState()
        {
            return $"[{factsBase.Count} факт(-ов)]: " + string.Join(", ", factsBase.Select(x => $"(#{x.Key}: {x.Value.factDescription})").ToArray());
        }

        string ruleToString(KeyValuePair<int, Rule> rule)
        {
            return $"#{rule.Key}: [${string.Join(" и ", rule.Value.premises.Select(x => $"(#{x}: {facts[x].factDescription})"))}] => (#{rule.Value.conclusion}: {facts[rule.Value.conclusion].factDescription}). А если по-человечески, то: {rule.Value.comment}";
        }
        void pushSelectedFactsToFactsBase()
        {
            factsBase.AddRange(checkListLocation.CheckedItems.Cast<FactWrapper>().Select(x => x.fact));
            factsBase.AddRange(checkListPrice.CheckedItems.Cast<FactWrapper>().Select(x => x.fact));
            factsBase.AddRange(checkListDrinks.CheckedItems.Cast<FactWrapper>().Select(x => x.fact));
            factsBase.AddRange(checkListCompany.CheckedItems.Cast<FactWrapper>().Select(x => x.fact));
            var selectedFeatures = checkListFeatures.CheckedItems.Cast<FactWrapper>().Select(x => x.fact);
            factsBase.AddRange(selectedFeatures);
            var unselectedFeatures = checkListFeatures.Items.Cast<FactWrapper>().Select(x => x.fact).Where(x => !selectedFeatures.Contains(x)).Select(x => facts.GetEntry((x.Value as InitialFact).oppositeFact));
            factsBase.AddRange(unselectedFeatures);
        }

        
        bool checkRuleAppliance(Rule r)
        {
            if (factsBase.ContainsKey(r.conclusion))
            {
                return false;
            }
            foreach (var premise in r.premises)
            {
                if (!factsBase.ContainsKey(premise))
                {
                    return false;
                }
            }
            return true;
        }
        Queue<KeyValuePair<int,Rule>> getAppliableRules()
        {
            Queue<KeyValuePair<int, Rule>> res = new Queue<KeyValuePair<int, Rule>>();
            foreach(var rule in rules)
            {
                if (checkRuleAppliance(rule.Value))
                {
                    res.Enqueue(rule);
                }
            }
            return res;
        }

        Queue<KeyValuePair<int, Rule>> getPreviousRules(List<int> factsAvailable)
        {
            Queue<KeyValuePair<int, Rule>> res = new Queue<KeyValuePair<int, Rule>>();
            foreach(var rule in rules)
            {
                if (factsAvailable.Contains(rule.Value.conclusion))
                {
                    res.Enqueue(rule);
                }
            }
            return res;
        }

        void startOutput()
        {
            factsBase = new Dictionary<int, Fact>();
            clearLogs();
            pushSelectedFactsToFactsBase();
            log($"Факты, с которых мы начинаем:\n{getCurrentFactsBaseState()}", true);
            if (rbBackward.Checked)
            {
                backwardOutput();
            }
            else
            {
                forwardOutput();
            }
        }

        void backwardOutput()
        {
            log("Мы начали обратный вывод!");
            
        }
        void forwardOutput()
        {
            log("Мы начали прямой вывод!");
            Queue<KeyValuePair<int, Rule>> ruleQueue;
            int i = 1;
            while((ruleQueue = getAppliableRules()).Count > 0)
            {
                log($"========= Итерация #{i++} =========\nДоступно {ruleQueue.Count} правил для вывода.");
                while(ruleQueue.Count > 0)
                {
                    var currentRule = ruleQueue.Dequeue();
                    factsBase.AddEntry(facts.GetEntry(currentRule.Value.conclusion));
                    log($"Применили правило {ruleToString(currentRule)}.\nФактов в базе: {factsBase.Count}");
                    log($"{getCurrentFactsBaseState()}", true);
                }
            }
            log($"Вывод завершён. Мы перебрали все применимые правила.");
        }

        void showResults()
        {
            var result = factsBase.Where(x => x.Value is FiniteFact);
            if(result.Count() == 0)
            {
                log("К сожалению, по вашему запросу не удалось подобрать бар. Попробуйте уменьшить количество фич, или варьировать район/компанию/бюджет/напитки.");
                return;
            }
            log($"Ура! Мы нашли подходящие вам бары! Вот они:\n{string.Join("\n",result.Select(x=>x.Value.factDescription))}");
        }
    }
}
