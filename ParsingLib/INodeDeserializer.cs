using FSMLib.Automatons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingLib
{
	public interface INodeDeserializer<T>
	{
		object Deserialize(INonTerminalNode<T> Node);
	}
}
