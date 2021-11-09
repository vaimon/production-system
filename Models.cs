﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionSystem
{
    public enum InitialFactType { DRINK_TYPE, BUDGET, LOCATION, COMPANY_SIZE, FEATURE, COMMON, OPPOSITE_FEATURE };

    public class Rule
    {
        public List<int> premises;
        public int conclusion;
        public String comment;

        public Rule(List<int> premises, int conclusion, string comment)
        {
            this.premises = premises;
            this.conclusion = conclusion;
            this.comment = comment;
        }
    }

    public class Fact
    {
        public String factDescription;

        public Fact(String fact)
        {
            this.factDescription = fact;
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

    public class FiniteFact : Fact
    {
        public FiniteFact(String fact) : base(fact)
        {

        }
    }

    public class FactWrapper
    {
        public KeyValuePair<int, Fact> fact { get; set; }

        public FactWrapper(KeyValuePair<int, Fact> fact)
        {
            this.fact = fact;
        }

        public override string ToString()
        {
            return fact.Value.factDescription;
        }
    }

    public static class Extensions
    {
        public static Dictionary<T, U> AddRange<T, U>(this Dictionary<T, U> destination, IEnumerable<KeyValuePair<T, U>> source)
        {
            if (destination == null) destination = new Dictionary<T, U>();
            foreach (var e in source)
                destination.TryAdd(e.Key, e.Value);
            return destination;
        }

        public static Dictionary<T, U> AddEntry<T, U>(this Dictionary<T, U> destination, KeyValuePair<T, U> entry)
        {
            if (destination == null) destination = new Dictionary<T, U>();
            destination.TryAdd(entry.Key, entry.Value);
            return destination;
        }

        public static KeyValuePair<TKey, TValue> GetEntry<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
        {
            return new KeyValuePair<TKey, TValue>(key, dictionary[key]);
        }
    }

    public class Node
    {
        List<Node> children;
        Node parent;
        List<int> factsBase;

        public Node(Node parent, List<int> factsBase)
        {
            this.parent = parent;
            this.factsBase = factsBase;
            children = new List<Node>();
        }
    }
}
