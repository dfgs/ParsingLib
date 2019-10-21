using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingLib.Common.Exceptions
{
	public class UnexpectedInputException<T>:ParsingException
	{
		public T Item
		{
			get;
			private set;
		}

		public override string Message => $"Unexcepted input {Item} at position {Position}";

		public UnexpectedInputException(int Position, T Item) :base(Position)
		{
			this.Item = Item;
		}

	}
}
