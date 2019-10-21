
using FSMLib.SyntaxicAnalysis;
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
		static Consts()
		{


			string[] rules;


			rules = new string[]
			{
				@"Symbol*=\[|\]|\{|\}|\.|\+|\*|\?|\||\;|\=|\!|\\;",
				@"EscapedChar=\\.;",
				@"NonEscapedChar=![\[,\],\{,\},\.,\+,\*,\?,\|,\;,\=,\!,\\];",
				@"Letter*={NonEscapedChar}|{EscapedChar};",
				@"String*={Letter}+;",
				//@"String*={Char}+;",
				//@"Char*=.;",
			};

			RuleLexerAutomatonTable = FSMLib.LexicalAnalysis.Helpers.AutomatonTableHelper.BuildAutomatonTable(rules);
			
				

		}




	}
}
