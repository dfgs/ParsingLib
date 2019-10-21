using FSMLib;
using FSMLib.Automatons;
using FSMLib.Inputs;
using FSMLib.SyntaxicAnalysis;
using ParsingLib.Common.Exceptions;
using ParsingLib.Common.Readers;
using ParsingLib.Readers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingLib.LexicalAnalysis.Readers
{
    public class Lexer:AutomatonReader<char,Token>,ILexer
    {
	
		public Lexer(IAutomaton<char> Automaton,ICharReader ItemReader,INodeDeserializer<char,Token> NodeDeserializer):base(Automaton,ItemReader, NodeDeserializer)
		{
			
		}
		

	}
}
