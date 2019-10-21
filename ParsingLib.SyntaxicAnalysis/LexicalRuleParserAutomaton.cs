using FSMLib.SyntaxicAnalysis;
using FSMLib.SyntaxicAnalysis.Automatons;
using FSMLib.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingLib.SyntaxicAnalysis
{
	class LexicalRuleParserAutomaton : Automaton
	{
		public LexicalRuleParserAutomaton():this(Consts.LexicalRuleParserAutomatonTable)
		{

		}
		private LexicalRuleParserAutomaton(IAutomatonTable<Token> AutomatonTable) : base(AutomatonTable)
		{
		}
	}
}
