using System;
using FSMLib.Rules;
using FSMLib.SyntaxicAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParsingLib.Readers;
using ParsingLib.SyntaxicAnalysis.UnitTest.Mocks;

namespace ParsingLib.SyntaxicAnalysis.UnitTest
{
	[TestClass]
	public class LexicalRuleParserUnitTest
	{
		
		[TestMethod]
		public void ShouldReadRule()
		{
			LexicalRuleParser parser;
			IReader<Token> tokenReader;
			IRule<Token> rule;

			tokenReader = new MockedTokenReader(
				new Token("String", "MyRule"),
				new Token("Symbol", "=")
				); ;
			parser = new LexicalRuleParser(tokenReader);

			rule = parser.Read();
			Assert.AreEqual("MyRule", rule.Name);
			Assert.IsFalse(rule.IsAxiom) ;
			Assert.IsNotNull(rule.Predicate);
		}




	}
}
