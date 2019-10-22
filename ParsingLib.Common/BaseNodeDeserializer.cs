using FSMLib.Automatons;
using FSMLib.SyntaxicAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingLib.Common
{
	public abstract class BaseNodeDeserializer<T> : INodeDeserializer<T>
	{

		public object Deserialize(INonTerminalNode<T> Node)
		{
			return OnDeserializeNonTerminalNode(Node);
		}

		protected abstract object OnDeserializeNonTerminalNode(INonTerminalNode<T> Node);
		protected abstract object OnDeserializeTerminalNode(ITerminalNode<T> Node);


		protected object OnDeserialize(IBaseNode<T> Node)
		{
			if (Node == null) throw new ArgumentNullException("Node");
			switch(Node)
			{
				case INonTerminalNode<T> node:return OnDeserializeNonTerminalNode(node);
				case ITerminalNode<T> node:return OnDeserializeTerminalNode(node);
			}

			throw new NotImplementedException($"Invalid base node type ({Node.GetType()})");
		}




	}
}
