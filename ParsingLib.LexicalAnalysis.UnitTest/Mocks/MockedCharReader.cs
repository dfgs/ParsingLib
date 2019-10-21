using ParsingLib.Readers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingLib.LexicalAnalysis.UnitTest.Mocks
{
	public class MockedCharReader : ICharReader
	{
		private int index=0;
		private char[] items;
		private int maxLength;

		public bool EOF => index == maxLength;

		public MockedCharReader(int MaxLength,params char[] Items)
		{
			this.items = Items;
			this.maxLength = MaxLength;
		}
		public int GetPosition()
		{
			return index;
		}

		public void Seek(int Position)
		{
			this.index = Position;

		}
		
		public char Read()
		{
			int i;


			if (EOF) throw new EndOfStreamException();

			i = index % items.Length;
			index++;
			return items[i];
		}

	}
}
