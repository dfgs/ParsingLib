using FSMLib.Automatons;
using FSMLib.Rules;
using FSMLib.SyntaxicAnalysis;
using ParsingLib.Common.Readers;
using ParsingLib.Readers;
using ParsingLib.SyntaxicAnalysis.Readers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingLib.SyntaxicAnalysis
{
	public class LexicalRuleParser : Parser<IRule<char>>
	{
		public LexicalRuleParser(IReader<Token> Reader):this(new LexicalRuleParserAutomaton(),Reader)
		{

		}
		private LexicalRuleParser(IAutomaton<Token> Automaton, IReader<Token> Reader) : base(Automaton,Reader,new LexicalRuleNodeDeserializer())
		{
		}
	}
}
