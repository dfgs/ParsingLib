using System;
using FSMLib.Automatons;
using FSMLib.Common;
using FSMLib.Common.Automatons;
using FSMLib.LexicalAnalysis.Automatons;
using FSMLib.SyntaxicAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParsingLib.Common.Exceptions;
using ParsingLib.Common.Readers;
using ParsingLib.LexicalAnalysis.Readers;
using ParsingLib.LexicalAnalysis.UnitTest.Mocks;

namespace ParsingLib.LexicalAnalysis.UnitTest
{
	[TestClass]
	public class LexerUnitTest
	{
		[TestMethod]
		public void ShouldHaveValidConstructor()
		{
			Assert.ThrowsException<ArgumentNullException>(() => new Lexer(null, new MockedCharReader(10, 'a'),new MockedNodeDeserializer()));
			Assert.ThrowsException<ArgumentNullException>(() => new Lexer(new MockedSequenceAutomaton("A","abc"), null, new MockedNodeDeserializer()));
			Assert.ThrowsException<ArgumentNullException>(() => new Lexer(new MockedSequenceAutomaton("A", "abc"), new MockedCharReader(10, 'a'), null));
		}

		[TestMethod]
		public void ShouldRead()
		{
			
			IAutomaton<char> automaton;
			Lexer lexer;
			MockedCharReader reader;
			Token token;

			reader = new MockedCharReader(18,'a','b','c');
			
			automaton = new MockedSequenceAutomaton("A", "abc");


			lexer = new Lexer(automaton,reader,new MockedNodeDeserializer());

			token=lexer.Read();
			Assert.AreEqual("A", token.Class);
			Assert.AreEqual("abc", token.Value);
			
		}
		[TestMethod]
		public void ShouldReadGreedy()
		{
			IAutomaton<char> automaton;
			Lexer lexer;
			MockedCharReader reader;
			Token token;

			reader = new MockedCharReader(18, 'a', 'a', 'a');
			automaton = new MockedInfiniteSequenceAutomaton("A",'a');


			lexer = new Lexer(automaton,reader, new MockedNodeDeserializer());

			token = lexer.Read();
			Assert.AreEqual("A", token.Class);
			Assert.AreEqual("aaaaaaaaaaaaaaaaaa", token.Value);
			Assert.AreEqual(18, token.Value.Length);

		}

		/*[TestMethod]
		public void ShouldReturnBackWhenPreviouslyAcceptStateWasFound()
		{
			IAutomaton<char> automaton;
			Lexer lexer;
			MockedCharReader reader;
			Token token;

			reader = new MockedCharReader(18, 'a', 'a', 'a', 'a', 'b');
			automaton = new Automaton(AutomatonTableHelper.BuildAutomatonTable(new string[] { "A*=a+c;", "A*=a;" }));

			lexer = new Lexer(automaton,reader);

			token = lexer.Read();
			Assert.AreEqual("A", token.Class);
			Assert.AreEqual("a", token.Value);
			token = lexer.Read();
			Assert.AreEqual("A", token.Class);
			Assert.AreEqual("a", token.Value);
			token = lexer.Read();
			Assert.AreEqual("A", token.Class);
			Assert.AreEqual("a", token.Value);
			token = lexer.Read();
			Assert.AreEqual("A", token.Class);
			Assert.AreEqual("a", token.Value);

		}*/

		[TestMethod]
		public void ShouldReadMultiple()
		{
			IAutomaton<char> automaton;
			Lexer lexer;
			MockedCharReader reader;
			Token token;

			reader = new MockedCharReader(18, 'a', 'b', 'c');
			automaton = new MockedSequenceAutomaton("A", "abc");


			lexer = new Lexer(automaton,reader, new MockedNodeDeserializer());

			token = lexer.Read();
			Assert.AreEqual("A", token.Class);
			Assert.AreEqual("abc", token.Value);
			token = lexer.Read();
			Assert.AreEqual("A", token.Class);
			Assert.AreEqual("abc", token.Value);
			token = lexer.Read();
			Assert.AreEqual("A", token.Class);
			Assert.AreEqual("abc", token.Value);

		}
		[TestMethod]
		public void ShouldFailToReadWhenEOF()
		{
			IAutomaton<char> automaton;
			Lexer lexer;
			MockedCharReader reader;

			reader = new MockedCharReader(2, 'a', 'b', 'c');
			automaton = new MockedSequenceAutomaton("A", "abc");


			lexer = new Lexer(automaton, reader, new MockedNodeDeserializer());

			Assert.ThrowsException<UnexpectedEndOfStreamException>(()=> lexer.Read());
			

		}

		[TestMethod]
		public void ShouldNotReadAndThrowException()
		{
			IAutomaton<char> automaton;
			Lexer lexer;
			MockedCharReader reader;
			Token token;

			reader = new MockedCharReader(18, 'a', 'b', 'c');
			automaton = new MockedSequenceAutomaton("A", "aaa");


			lexer = new Lexer(automaton, reader, new MockedNodeDeserializer());

			try
			{
				token = lexer.Read();
				Assert.Fail();
			}
			catch(UnexpectedInputException<char> ex)
			{
				Assert.AreEqual(1, ex.Position);
				Assert.AreEqual('b', ex.Item);
			}

		}

		


	}
}
