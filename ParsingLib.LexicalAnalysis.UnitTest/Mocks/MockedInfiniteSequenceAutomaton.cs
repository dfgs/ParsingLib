using FSMLib.Automatons;
using FSMLib.Common.Automatons;
using FSMLib.Common.Inputs;
using FSMLib.LexicalAnalysis.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingLib.LexicalAnalysis.UnitTest.Mocks
{
	public class MockedInfiniteSequenceAutomaton : IAutomaton<char>
	{
		public int StackCount => index;

		private char data;
		private int index;
		private string name;

		public MockedInfiniteSequenceAutomaton(string Name,char Data)
		{
			this.name = Name;
			this.data = Data;
		}

		public INonTerminalNode<char> Accept()
		{
			NonTerminalNode<char> node;

			if (!CanAccept()) throw new InvalidOperationException("Cannot accept");
			
			node=new NonTerminalNode<char>(new NonTerminalInput(name));
			for(int t=0;t<index;t++)
			{
				node.Nodes.Add(new TerminalNode<char>(new TerminalInput(data)));
			}

			return node;
		}

		public bool CanAccept()
		{
			return index>0;
		}

		public bool CanFeed(char Value)
		{
			return data == Value;
		}

		public void Feed(char Value)
		{
			index++;
		}

		public void Reset()
		{
			index = 0;
		}
	}
}
