
using FSMLib.SyntaxicAnalysis;
using FSMLib.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingLib.SyntaxicAnalysis
{
	static class Consts 
	{
		public static IAutomatonTable<Token> LexicalRuleParserAutomatonTable;
		static Consts()
		{


			string[] rules;

			rules = new string[]
			{
				@"Rule*=<String><Symbol,=>;",
				
				//@"String*={Char}+;",
				//@"Char*=.;",
			};

			LexicalRuleParserAutomatonTable = FSMLib.SyntaxicAnalysis.Helpers.AutomatonTableHelper.BuildAutomatonTable(rules);
			

		}




	}
}
