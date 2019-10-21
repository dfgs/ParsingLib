using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingLib.Readers
{
	public interface IReader<T>
	{
		int GetPosition();
		bool EOF
		{
			get;
		}

		T Read();
		void Seek(int Position);

	}
}
