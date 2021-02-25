using FSMLib.Automatons;
using ParsingLib.Common.Exceptions;
using ParsingLib.Readers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingLib.Common.Readers
{
	public abstract class AutomatonReader<T,TResult>:IAutomatonReader<T, TResult>
	{
		private IAutomaton<T> automaton;
		private IReader<T> itemReader;
		private INodeDeserializer<T> deserializer;

		public bool EOF
		{
			get { return itemReader.EOF; }
		}

		public AutomatonReader(IAutomaton<T> Automaton, IReader<T> ItemReader, INodeDeserializer<T> Deserializer)
		{
			if (Automaton == null) throw new ArgumentNullException("Automaton");
			if (ItemReader == null) throw new ArgumentNullException("ItemReader");
			if (Deserializer== null) throw new ArgumentNullException("Deserializer");
			this.automaton = Automaton;
			this.itemReader = ItemReader;
			this.deserializer = Deserializer;
		}
		public int GetPosition()
		{
			return itemReader.GetPosition();
		}

		public void Seek(int Position)
		{
			itemReader.Seek(Position);
		}


		public TResult Read()
		{
			T item = default(T);
			int currentPosition;
			StringBuilder sb;
			INonTerminalNode<T> node;
			object result;

			currentPosition = itemReader.GetPosition();
			if (itemReader.EOF) throw new UnexpectedEndOfStreamException(currentPosition);

			sb = new StringBuilder();
			automaton.Reset();

			do
			{
				currentPosition = itemReader.GetPosition();

				if (itemReader.EOF)
				{
					if (!automaton.CanAccept()) throw new UnexpectedEndOfStreamException(currentPosition);
					else break;
				}
				else
				{
					item = itemReader.Read();
					if (!automaton.CanFeed(item))
					{
						if (!automaton.CanAccept()) throw new UnexpectedInputException<T>(currentPosition, item);
						break;
					}
					sb.Append(item);
					automaton.Feed(item);
				}
			} while (true);

			itemReader.Seek(currentPosition);
			node = automaton.Accept();

			result = deserializer.Deserialize(node);
			if (result == null) throw new InvalidCastException("Failed to deserialize node");

			return (TResult)result;

		}
	}
}
