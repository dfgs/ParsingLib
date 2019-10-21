using FSMLib.Automatons;
using FSMLib.SyntaxicAnalysis;
using ParsingLib.Readers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingLib.SyntaxicAnalysis.Readers
{
	public interface IParser<TResult>: IAutomatonReader<Token, TResult>
	{
		
	}
}
