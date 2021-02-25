
using FSMLib.Common.Attributes;
using FSMLib.Common.Situations;
using FSMLib.Common.Table;
using FSMLib.Common.Tables;
using FSMLib.LexicalAnalysis;
using FSMLib.LexicalAnalysis.Predicates;
using FSMLib.LexicalAnalysis.Rules;
using FSMLib.LexicalAnalysis.Tables;
using FSMLib.Rules;
using FSMLib.Situations;
using FSMLib.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingLib.LexicalAnalysis
{
	static class Consts 
	{
		public static IAutomatonTable<char> RuleLexerAutomatonTable;

		private static LexicalPredicate CompletePredicate(params LexicalPredicate[] Predicates)
		{
			Sequence result;
			List<LexicalPredicate> predicates;
			predicates = new List<LexicalPredicate>();
			predicates.AddRange(Predicates);
			predicates.Add(new Reduce());

			result = new Sequence(predicates.ToArray());
			return result;
		}
		static Consts()
		{
			LexicalRule symbol,escapedChar,nonEscapedChar,letter,_string;
			IAutomatonTableFactory<char> automatonTableFactory;
			SituationCollectionFactory<char> situationCollectionFactory;
			DistinctInputFactory distinctInputFactory;
			ISituationGraphFactory<char> situationGraphFactory;
			IRule<char>[] rules;

			symbol = new LexicalRule() { IsAxiom = true, Name = "Symbol" };
			symbol.Attributes.Add(new DeserializerAttribute(typeof(TokenDeserializer)));
			symbol.Predicate =CompletePredicate( new Or(
				new Terminal('['),
				new Terminal(']'),
				new Terminal('{'),
				new Terminal('}'),
				new Terminal('.'),
				new Terminal('+'),
				new Terminal('*'),
				new Terminal('?'),
				new Terminal('|'),
				new Terminal(';'),
				new Terminal('='),
				new Terminal('!'),
				new Terminal('\\')
				) );

			escapedChar = new LexicalRule() { IsAxiom = false, Name = "EscapedChar" };
			escapedChar.Predicate = CompletePredicate(
				new Terminal('\\'),
				new AnyTerminal()
				);

			nonEscapedChar = new LexicalRule() { IsAxiom = false, Name = "NonEscapedChar" };
			nonEscapedChar.Predicate = CompletePredicate( new ExceptTerminalsList('[', ']', '{', '}', '.', '+', '*', '?', '|', ';', '=', '!', '\\') );

			letter = new LexicalRule() { IsAxiom = true, Name = "Letter" };
			letter.Attributes.Add(new DeserializerAttribute(typeof(TokenDeserializer)));
			letter.Predicate = CompletePredicate( new Or(new NonTerminal("NonEscapedChar"), new NonTerminal("EscapedChar")) );

			_string = new LexicalRule() { IsAxiom = true, Name = "String" };
			_string.Attributes.Add(new DeserializerAttribute(typeof(TokenDeserializer)));
			_string.Predicate = CompletePredicate( new OneOrMore() { Item= new NonTerminal("Letter") } );

			rules = new IRule<char>[] { symbol,escapedChar,nonEscapedChar,letter,_string };
			/*rules = new string[]
			{
				@"Symbol*=\[|\]|\{|\}|\.|\+|\*|\?|\||\;|\=|\!|\\;",
				@"EscapedChar=\\.;",
				@"NonEscapedChar=![\[,\],\{,\},\.,\+,\*,\?,\|,\;,\=,\!,\\];",
				@"Letter*={NonEscapedChar}|{EscapedChar};",
				@"String*={Letter}+;",
				
			};*/

			situationGraphFactory = new SituationGraphFactory<char>(new SituationGraphSegmentFactory<char>());
			distinctInputFactory = new DistinctInputFactory(new RangeValueProvider());
			automatonTableFactory = new AutomatonTableFactory<char>();
			situationCollectionFactory = new SituationCollectionFactory<char>(situationGraphFactory.BuildSituationGraph(rules));

			RuleLexerAutomatonTable = automatonTableFactory.BuildAutomatonTable(situationCollectionFactory, distinctInputFactory);
			
				

		}




	}
}
