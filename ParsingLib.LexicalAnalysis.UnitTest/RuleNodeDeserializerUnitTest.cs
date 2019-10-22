using System;
using FSMLib.Common.Automatons;
using FSMLib.LexicalAnalysis.Inputs;
using FSMLib.SyntaxicAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParsingLib.LexicalAnalysis.UnitTest.Mocks;
using ParsingLib.Readers;

namespace ParsingLib.LexicalAnalysis.UnitTest
{
	[TestClass]
	public class RuleNodeDeserializerUnitTest
	{
		[TestMethod]
		public void ShouldDeserializeSymbol()
		{
			NonTerminalNode<char> root;
			object result;

			RuleNodeDeserializer deserializer;

			deserializer = new RuleNodeDeserializer();
			root = new NonTerminalNode<char>(new NonTerminalInput("Symbol"));
			root.Nodes.Add(new TerminalNode<char>(new TerminalInput('{')));

			result = (Token)deserializer.Deserialize(root);
			Assert.IsInstanceOfType(result, typeof(Token));
			Assert.AreEqual("Symbol", ((Token)result).Class);
			Assert.AreEqual("{", ((Token)result).Value);
		}
		[TestMethod]
		public void ShouldDeserializeNonEscapedChar()
		{
			NonTerminalNode<char> nonEscaped;
			object result;

			RuleNodeDeserializer deserializer;

			deserializer = new RuleNodeDeserializer();
			nonEscaped = new NonTerminalNode<char>(new NonTerminalInput("NonEscapedChar"));
			nonEscaped.Nodes.Add(new TerminalNode<char>(new TerminalInput('a')));

			result = deserializer.Deserialize(nonEscaped);
			Assert.IsInstanceOfType(result, typeof(char));
			Assert.AreEqual('a', result);
		}
		[TestMethod]
		public void ShouldDeserializeEscapedChar()
		{
			NonTerminalNode<char> escaped;
			object result;

			RuleNodeDeserializer deserializer;

			deserializer = new RuleNodeDeserializer();
			escaped = new NonTerminalNode<char>(new NonTerminalInput("EscapedChar"));
			escaped.Nodes.Add(new TerminalNode<char>(new TerminalInput('\\')));
			escaped.Nodes.Add(new TerminalNode<char>(new TerminalInput('a')));

			result = deserializer.Deserialize(escaped);
			Assert.IsInstanceOfType(result, typeof(char));
			Assert.AreEqual('a', result);
		}
		[TestMethod]
		public void ShouldDeserializeLetter()
		{
			NonTerminalNode<char> root;
			NonTerminalNode<char> nonEscaped;
			NonTerminalNode<char> escaped;
			object result;

			RuleNodeDeserializer deserializer;

			deserializer = new RuleNodeDeserializer();
	
			nonEscaped = new NonTerminalNode<char>(new NonTerminalInput("NonEscapedChar"));
			nonEscaped.Nodes.Add(new TerminalNode<char>(new TerminalInput('a')));

			escaped = new NonTerminalNode<char>(new NonTerminalInput("EscapedChar"));
			escaped.Nodes.Add(new TerminalNode<char>(new TerminalInput('\\')));
			escaped.Nodes.Add(new TerminalNode<char>(new TerminalInput('a')));


			// non escaped
			root = new NonTerminalNode<char>(new NonTerminalInput("Letter"));
			root.Nodes.Add(nonEscaped);

			result = (Token)deserializer.Deserialize(root);
			Assert.IsInstanceOfType(result, typeof(Token));
			Assert.AreEqual("Letter", ((Token)result).Class);
			Assert.AreEqual("a", ((Token)result).Value);



			// escaped
			root = new NonTerminalNode<char>(new NonTerminalInput("Letter"));
			root.Nodes.Add(escaped);

			result = (Token)deserializer.Deserialize(root);
			Assert.IsInstanceOfType(result, typeof(Token));
			Assert.AreEqual("Letter", ((Token)result).Class);
			Assert.AreEqual("a", ((Token)result).Value);
		}
		[TestMethod]
		public void ShouldDeserializeString()
		{
			NonTerminalNode<char> root;
			NonTerminalNode<char> letter;
			NonTerminalNode<char> nonEscaped;
			NonTerminalNode<char> escaped;
			object result;

			RuleNodeDeserializer deserializer;

			deserializer = new RuleNodeDeserializer();

			nonEscaped = new NonTerminalNode<char>(new NonTerminalInput("NonEscapedChar"));
			nonEscaped.Nodes.Add(new TerminalNode<char>(new TerminalInput('a')));

			escaped = new NonTerminalNode<char>(new NonTerminalInput("EscapedChar"));
			escaped.Nodes.Add(new TerminalNode<char>(new TerminalInput('\\')));
			escaped.Nodes.Add(new TerminalNode<char>(new TerminalInput('a')));

			root = new NonTerminalNode<char>( new NonTerminalInput( "String"));

			// non escaped
			letter = new NonTerminalNode<char>(new NonTerminalInput("Letter"));
			letter.Nodes.Add(nonEscaped);
			root.Nodes.Add(letter);
			// escaped
			letter = new NonTerminalNode<char>(new NonTerminalInput("Letter"));
			letter.Nodes.Add(escaped);
			root.Nodes.Add(letter);



			result = (Token)deserializer.Deserialize(root);
			Assert.IsInstanceOfType(result, typeof(Token));
			Assert.AreEqual("String", ((Token)result).Class);
			Assert.AreEqual("aa", ((Token)result).Value);
		}




	}
}
