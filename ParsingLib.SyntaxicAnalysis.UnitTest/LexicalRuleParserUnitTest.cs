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
			IRule<char> rule;

			tokenReader = new MockedTokenReader(
				new Token("String", "Rule"),
				new Token("Symbol", "=")
				); ;
			parser = new LexicalRuleParser(tokenReader);

			rule = parser.Read();
			Assert.AreEqual("Rule", rule.Name);
			Assert.IsFalse(rule.IsAxiom) ;
			Assert.IsNotNull(rule.Predicate);
		}




	}
}
