﻿using System.Linq;
using System.Text.RegularExpressions;
using CsInlineColorViz;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.Text.Tagging;

namespace CSInlineColorViz.Tests;

// TODO: Add lots of lovely tests
[TestClass]
public class UnityTaggerTests : BaseTaggerTests
{
	[TestMethod]
	public void CanMatchSingleColor_3HexChars()
	{
		var sut = new UnityTagger(new FakeTextBuffer());

		Assert.IsNotNull(sut);

		var lineWithColor = "<Color=#FF0>";

		var matches = sut.ColorExpression.Matches(lineWithColor).Cast<Match>();

		Assert.AreEqual(1, matches.Count());

		// TODO: add support for line number, line start, and span start
		var tag = sut.TryCreateTagForMatch(matches.First(), 0, 0, 0, lineWithColor);

		Assert.IsNotNull(tag);

		// TODO: check that the color is correct
	}

	[TestMethod]
	public void CanMatchSingleColor_4HexChars()
	{
		var sut = new UnityTagger(new FakeTextBuffer());

		Assert.IsNotNull(sut);

		var lineWithColor = "<Color=#F0F0>";

		var matches = sut.ColorExpression.Matches(lineWithColor).Cast<Match>();

		Assert.AreEqual(1, matches.Count());

		// TODO: add support for line number, line start, and span start
		var tag = sut.TryCreateTagForMatch(matches.First(), 0, 0, 0, lineWithColor);

		Assert.IsNotNull(tag);

		// TODO: check that the color is correct
	}

	[TestMethod]
	public void CanMatchSingleColor_6HexChars()
	{
		var sut = new UnityTagger(new FakeTextBuffer());

		Assert.IsNotNull(sut);

		var lineWithColor = "<Color=#FF0000>";

		var matches = sut.ColorExpression.Matches(lineWithColor).Cast<Match>();

		Assert.AreEqual(1, matches.Count());

		// TODO: add support for line number, line start, and span start
		var tag = sut.TryCreateTagForMatch(matches.First(), 0, 0, 0, lineWithColor);

		Assert.IsNotNull(tag);

		// TODO: check that the color is correct
	}

	[TestMethod]
	public void CanMatchSingleColor_8HexChars()
	{
		var sut = new UnityTagger(new FakeTextBuffer());

		Assert.IsNotNull(sut);

		var lineWithColor = "<Color=#FF0000FF>";

		var matches = sut.ColorExpression.Matches(lineWithColor).Cast<Match>();

		Assert.AreEqual(1, matches.Count());

		// TODO: add support for line number, line start, and span start
		var tag = sut.TryCreateTagForMatch(matches.First(), 0, 0, 0, lineWithColor);

		Assert.IsNotNull(tag);

		// TODO: check that the color is correct
	}

	[TestMethod]
	public void DoesNotMatch_2HexChars()
	{
		var sut = new UnityTagger(new FakeTextBuffer());

		Assert.IsNotNull(sut);

		var lineWithColor = "<Color=#FF>";

		var matches = sut.ColorExpression.Matches(lineWithColor).Cast<Match>();

		Assert.AreEqual(0, matches.Count());
	}

	[TestMethod]
	public void DoesNotMatch_9HexChars()
	{
		var sut = new UnityTagger(new FakeTextBuffer());

		Assert.IsNotNull(sut);

		var lineWithColor = "<Color=#FF1234567>";

		var matches = sut.ColorExpression.Matches(lineWithColor).Cast<Match>();

		Assert.AreEqual(0, matches.Count());
	}

	[TestMethod]
	public void MatchesButDoesNotProduceTag_5HexChars()
	{
		var sut = new UnityTagger(new FakeTextBuffer());

		Assert.IsNotNull(sut);

		var lineWithColor = "<Color=#FF123>";

		var matches = sut.ColorExpression.Matches(lineWithColor).Cast<Match>();

		Assert.AreEqual(1, matches.Count());

		var tag = sut.TryCreateTagForMatch(matches.First(), 0, 0, 0, lineWithColor);

		Assert.IsNull(tag);
	}

	[TestMethod]
	public void MatchesButDoesNotProduceTag_7HexChars()
	{
		var sut = new UnityTagger(new FakeTextBuffer());

		Assert.IsNotNull(sut);

		var lineWithColor = "<Color=#FF12345>";

		var matches = sut.ColorExpression.Matches(lineWithColor).Cast<Match>();

		Assert.AreEqual(1, matches.Count());

		var tag = sut.TryCreateTagForMatch(matches.First(), 0, 0, 0, lineWithColor);

		Assert.IsNull(tag);
	}

	[TestMethod]
	public void DoesNotMatch_InconsequentialText()
	{
		base.DoesNotMatch_InconsequentialText<UnityTagger>();
	}
}
