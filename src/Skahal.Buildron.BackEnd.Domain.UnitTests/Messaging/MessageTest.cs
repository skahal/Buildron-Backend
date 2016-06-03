//  Author: Diego Giacomelli <giacomelli@gmail.com>
//  Copyright (c) 2012 Skahal Studios
using System;
using NUnit.Framework;
using Skahal.Buildron.BackEnd.Domain.Messaging;

namespace Skahal.Buildron.BackEnd.Domain.UnitTests
{
	[TestFixture()]
	public class MessageTest
	{
		[Test()]
		[ExpectedException(typeof(ArgumentNullException))]
		public void Constructor_NameIsNull_ArgumentNullException ()
		{
			new Message(null);
		}

		[Test()]
		[ExpectedException(typeof(ArgumentException))]
		public void Constructor_NameIsEmpty_ArgumentException ()
		{
			new Message("");
		}

		[Test()]
		public void Constructor_NameIsValid_PropertiesDefined ()
		{
			var actual = new Message("MSG");
			Assert.AreEqual("MSG", actual.Name);
			Assert.AreEqual(0, actual.Values.Count);
		}
	}
}

