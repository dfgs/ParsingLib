using FSMLib.SyntaxicAnalysis;
using ParsingLib.Readers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingLib.SyntaxicAnalysis.UnitTest.Mocks
{
	class MockedTokenReader : IReader<Token>
	{
		private int index;
		private Token[] tokens;

		public bool EOF => index == tokens.Length;


		public MockedTokenReader(params Token[] Tokens)
		{
			this.tokens = Tokens;
		}

		public int GetPosition()
		{
			return index;
		}

		public Token Read()
		{
			return tokens[index++];
		}

		public void Seek(int Position)
		{
			index = Position;
		}

	}
}
