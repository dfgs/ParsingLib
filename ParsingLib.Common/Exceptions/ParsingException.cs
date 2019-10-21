using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingLib.Common.Exceptions
{
	public abstract class ParsingException:Exception
	{

		public int Position
		{
			get;
			private set;
		}


		public ParsingException( int Position):base()
		{
			this.Position = Position;
		}

	}
}
