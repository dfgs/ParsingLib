using FSMLib;
using FSMLib.Automatons;
using FSMLib.Inputs;
using FSMLib.SyntaxicAnalysis;
using ParsingLib.Common.Readers;
using ParsingLib.Readers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingLib.SyntaxicAnalysis.Readers
{
    public class Parser<TResult>: AutomatonReader<Token, TResult>,IParser<TResult>
    {
		

		public Parser(IAutomaton<Token> Automaton,IReader<Token> ItemReader, INodeDeserializer<Token, TResult> NodeDeserializer):base(Automaton,ItemReader,NodeDeserializer)
		{
			
		}

		


	}
}
