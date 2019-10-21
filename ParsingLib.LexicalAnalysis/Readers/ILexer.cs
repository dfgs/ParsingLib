using FSMLib.SyntaxicAnalysis;
using ParsingLib.Readers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingLib.LexicalAnalysis.Readers
{
	public interface ILexer:IAutomatonReader<char,Token>
	{
	}
}
