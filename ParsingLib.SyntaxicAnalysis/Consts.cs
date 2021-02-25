
using FSMLib.Common.Attributes;
using FSMLib.Common.Situations;
using FSMLib.Common.Table;
using FSMLib.Rules;
using FSMLib.Situations;
using FSMLib.SyntaxicAnalysis;
using FSMLib.SyntaxicAnalysis.Predicates;
using FSMLib.SyntaxicAnalysis.Rules;
using FSMLib.SyntaxicAnalysis.Tables;
using FSMLib.Table;
using System.Collections.Generic;

namespace ParsingLib.SyntaxicAnalysis
{
	static class Consts
	{
		public static IAutomatonTable<Token> LexicalRuleParserAutomatonTable;

		private static SyntaxicPredicate CompletePredicate(params SyntaxicPredicate[] Predicates)
		{
			Sequence result;
			List<SyntaxicPredicate> predicates;
			predicates = new List<SyntaxicPredicate>();
			predicates.AddRange(Predicates);
			predicates.Add(new Reduce());

			result = new Sequence(predicates.ToArray());
			return result;
		}

		static Consts()
		{
			SyntaxicRule rule;
			IAutomatonTableFactory<Token> automatonTableFactory;
			SituationCollectionFactory<Token> situationCollectionFactory;
			DistinctInputFactory distinctInputFactory;
			ISituationGraphFactory<Token> situationGraphFactory;
			IRule<Token>[] rules;

			rule = new SyntaxicRule() { IsAxiom = true, Name = "Symbol" };
			rule.Attributes.Add(new DeserializeAsAttribute(typeof(SyntaxicRule)));
			rule.Predicate = CompletePredicate(
				new AnyClassTerminal("String"),
				new Terminal("Symbol", "=")
				);

			rules = new IRule<Token>[] { rule };

			situationGraphFactory = new SituationGraphFactory<Token>(new SituationGraphSegmentFactory<Token>());
			distinctInputFactory = new DistinctInputFactory(new RangeValueProvider());
			automatonTableFactory = new AutomatonTableFactory<Token>();
			situationCollectionFactory = new SituationCollectionFactory<Token>(situationGraphFactory.BuildSituationGraph(rules));

			LexicalRuleParserAutomatonTable = automatonTableFactory.BuildAutomatonTable(situationCollectionFactory, distinctInputFactory);


		}




	}
}
