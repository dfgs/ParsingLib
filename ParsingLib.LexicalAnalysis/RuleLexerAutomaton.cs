using FSMLib.LexicalAnalysis.Automatons;
using FSMLib.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingLib.LexicalAnalysis
{
	class RuleLexerAutomaton : Automaton
	{
		public RuleLexerAutomaton():this(Consts.RuleLexerAutomatonTable)
		{

		}
		private RuleLexerAutomaton(IAutomatonTable<char> AutomatonTable) : base(AutomatonTable)
		{
		}
	}
}
