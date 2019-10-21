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
		public void ShouldDeserializeNonEscapedChar()
		{
			NonTerminalNode<char> root;
			Token result;

			RuleNodeDeserializer deserializer;

			deserializer = new RuleNodeDeserializer();
			root = new NonTerminalNode<char>(new NonTerminalInput("A"));
			root.Nodes.Add(new TerminalNode<char>(new TerminalInput('a')));
			root.Nodes.Add(new TerminalNode<char>(new TerminalInput('b')));
			root.Nodes.Add(new TerminalNode<char>(new TerminalInput('c')));
			result = deserializer.Deserialize(root);

			Assert.AreEqual("A", result.Class);
			Assert.AreEqual("abc", result.Value);
		}
		[TestMethod]
		public void ShouldDeserializeEscapedChar()
		{
			NonTerminalNode<char> root,escaped;
			Token result;

			RuleNodeDeserializer deserializer;

			deserializer = new RuleNodeDeserializer();

			escaped= new NonTerminalNode<char>(new NonTerminalInput("EscapedChar"));
			escaped.Nodes.Add(new TerminalNode<char>(new TerminalInput('\\')));
			escaped.Nodes.Add(new TerminalNode<char>(new TerminalInput('b')));

			root = new NonTerminalNode<char>(new NonTerminalInput("A"));
			root.Nodes.Add(new TerminalNode<char>(new TerminalInput('a')));
			root.Nodes.Add(escaped);
			root.Nodes.Add(new TerminalNode<char>(new TerminalInput('c')));
			result = deserializer.Deserialize(root);

			Assert.AreEqual("A", result.Class);
			Assert.AreEqual("abc", result.Value);
		}



	}
}
