using FSMLib.Automatons;
using FSMLib.Rules;
using FSMLib.SyntaxicAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingLib.SyntaxicAnalysis
{
	public class LexicalRuleNodeDeserializer : INodeDeserializer<Token, IRule<char>>
	{

		public IRule<char> Deserialize(INonTerminalNode<Token> Node)
		{
			return null;
		}


	}




}
