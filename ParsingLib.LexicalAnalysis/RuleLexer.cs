using FSMLib.Automatons;
using ParsingLib.Common.Readers;
using ParsingLib.LexicalAnalysis.Readers;
using ParsingLib.Readers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingLib.LexicalAnalysis
{
	public class RuleLexer : Lexer
	{
		public RuleLexer(ICharReader Reader):this(new RuleLexerAutomaton(),Reader)
		{

		}
		private RuleLexer(IAutomaton<char> Automaton, ICharReader Reader) : base(Automaton,Reader,new RuleNodeDeserializer())
		{
		}
	}
}
