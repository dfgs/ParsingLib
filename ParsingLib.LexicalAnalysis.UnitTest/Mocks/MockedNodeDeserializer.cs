using FSMLib.Automatons;
using FSMLib.SyntaxicAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingLib.LexicalAnalysis.UnitTest.Mocks
{
	public class MockedNodeDeserializer : INodeDeserializer<char>
	{
		public object Deserialize(INonTerminalNode<char> Node)
		{
			return new Token(Node.Input.Name, OnDeserialize(Node));
		}

		protected string OnDeserialize(INonTerminalNode<char> Node)
		{
			StringBuilder sb;


			sb = new StringBuilder();
			foreach (IBaseNode<char> sn in Node.Nodes)
			{
				sb.Append(OnDeserialize(sn));
			}
			return sb.ToString();



		}
		protected string OnDeserialize(IBaseNode<char> Node)
		{
			switch (Node)
			{
				case INonTerminalNode<char> nt: return OnDeserialize(nt);
				case ITerminalNode<char> t: return t.Input.Value.ToString();
			}

			return "";
		}



	}
}
