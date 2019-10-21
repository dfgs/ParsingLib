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
	public class MockedSequenceAutomaton : IAutomaton<char>
	{
		public int StackCount => index;

		private string data;
		private int index;
		private string name;

		public MockedSequenceAutomaton(string Name,string Data)
		{
			this.name = Name;
			this.data = Data;
		}

		public INonTerminalNode<char> Accept()
		{
			NonTerminalNode<char> node;

			if (!CanAccept()) throw new InvalidOperationException("Cannot accept");
			
			node=new NonTerminalNode<char>(new NonTerminalInput(name));
			foreach(char value in data)
			{
				node.Nodes.Add(new TerminalNode<char>(new TerminalInput(value)));
			}

			return node;
		}

		public bool CanAccept()
		{
			return index == data.Length;
		}

		public bool CanFeed(char Value)
		{
			if (index >= data.Length) return false;
			return data[index] == Value;
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
