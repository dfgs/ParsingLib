using System;
using FSMLib.SyntaxicAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParsingLib.LexicalAnalysis.UnitTest.Mocks;
using ParsingLib.Readers;

namespace ParsingLib.LexicalAnalysis.UnitTest
{
	[TestClass]
	public class RuleLexerUnitTest
	{
		
		[TestMethod]
		public void ShouldReadSymbol()
		{
			RuleLexer lexer;
			ICharReader charReader;
			Token token;
			string data;

			data = @"{}[].+*?|;=!\";
			charReader = new MockedCharReader(data.Length,data.ToCharArray());
			lexer = new RuleLexer(charReader);

			for(int t=0;t<13;t++)
			{
				token = lexer.Read();
				Assert.AreEqual("Symbol", token.Class);
				Assert.AreEqual(data[t].ToString(), token.Value);
			}
		}

		/*[TestMethod]
		public void ShouldReadEscapedLetter()
		{
			RuleLexer lexer;
			ICharReader charReader;
			Token token;

			foreach (string data in new string[] { @"\{", @"\}", @"\[", @"\]", @"\\", @"\.", @"\+", @"\*", @"\?", @"\|", @"\;", @"\=", @"\!" })
			{
				charReader = new MockedCharReader(data.Length, data.ToCharArray());
				lexer = new RuleLexer(charReader);

				token = lexer.Read();
				Assert.AreEqual("Letter", token.Class);
				Assert.AreEqual(data[1].ToString(), token.Value);
			}
		}

		[TestMethod]
		public void ShouldReadNonEscapedLetter()
		{
			RuleLexer lexer;
			ICharReader charReader;
			Token token;

			foreach (string data in new string[] { @"a", @"b", @"c", @"d"})
			{
				charReader = new MockedCharReader(data.Length, data.ToCharArray());
				lexer = new RuleLexer(charReader);

				token = lexer.Read();
				Assert.AreEqual("Letter", token.Class);
				Assert.AreEqual(data, token.Value);
			}
		}*/
		[TestMethod]
		public void ShouldReadString()
		{
			RuleLexer lexer;
			ICharReader charReader;
			Token token;
			string data;

			data = @"abc";
			charReader = new MockedCharReader(data.Length, data.ToCharArray());
			lexer = new RuleLexer(charReader);
			token = lexer.Read();
			Assert.AreEqual("String", token.Class);
			Assert.AreEqual("abc", token.Value);

			data = @"a\bc";
			charReader = new MockedCharReader(data.Length, data.ToCharArray());
			lexer = new RuleLexer(charReader);
			token = lexer.Read();
			Assert.AreEqual("String", token.Class);
			Assert.AreEqual("abc", token.Value);

			data = @"\a\b\c";
			charReader = new MockedCharReader(data.Length, data.ToCharArray());
			lexer = new RuleLexer(charReader);
			token = lexer.Read();
			Assert.AreEqual("String", token.Class);
			Assert.AreEqual("abc", token.Value);
			
		}


	}
}
