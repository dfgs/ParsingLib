using FSMLib.Automatons;
using FSMLib.SyntaxicAnalysis;
using ParsingLib.Common;
using System.Linq;
using System.Text;

namespace ParsingLib.LexicalAnalysis
{
	public class RuleNodeDeserializer : BaseNodeDeserializer<char>
	{


		protected override object OnDeserializeNonTerminalNode(INonTerminalNode<char> Node)
		{
			StringBuilder sb;

			switch (Node.Input.Name)
			{
				case "EscapedChar": return OnDeserialize(Node.Nodes.ElementAt(1));
				case "NonEscapedChar": return OnDeserialize(Node.Nodes.First());

				case "Letter": return new Token(Node.Input.Name, OnDeserialize(Node.Nodes.First()).ToString());

				case "Symbol": return new Token(Node.Input.Name, OnDeserialize(Node.Nodes.First()).ToString());

				case "String":
					return new Token(Node.Input.Name, string.Join("", Node.Nodes.Select(item => ((Token)OnDeserialize(item)).Value)));
				default:
					sb = new StringBuilder();
					foreach (IBaseNode<char> sn in Node.Nodes)
					{
						sb.Append(OnDeserialize(sn));
					}
					return sb.ToString();
			}




		}
		protected override object OnDeserializeTerminalNode(ITerminalNode<char> Node)
		{
			return Node.Input.Value;
		}

		/*public Token Deserialize(INonTerminalNode<char> Node)
		{
			return new Token(Node.Input.Name, OnDeserialize(Node));
		}*/






	}
}
