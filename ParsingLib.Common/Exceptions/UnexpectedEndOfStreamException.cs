using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingLib.Common.Exceptions
{
	public class UnexpectedEndOfStreamException:ParsingException
	{
		

		public override string Message => $"Unexcepted end of stream at position {Position}";

		public UnexpectedEndOfStreamException(int Position) :base(Position)
		{
		}

	}
}
