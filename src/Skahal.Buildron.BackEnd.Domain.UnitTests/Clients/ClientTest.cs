//  Author: Diego Giacomelli <giacomelli@gmail.com>
//  Copyright (c) 2012 Skahal Studios
using System;
using NUnit.Framework;
using Skahal.Buildron.BackEnd.Domain.Clients;

namespace Skahal.Buildron.BackEnd.Domain.UnitTests
{
	[TestFixture()]
	public class ClientTest
	{
		[Test()]
		[ExpectedException(typeof(ArgumentNullException))]
		public void Constructor_IdIsNull_ArgumentNullException ()
		{
			new Client(null);
		}

		[Test()]
		[ExpectedException(typeof(ArgumentException))]
		public void Constructor_IdIsEmpty_ArgumentException ()
		{
			new Client(String.Empty);
		}

		[Test()]
		public void Constructor_IdIsValid_PropertiesDefined ()
		{
			var target = new Client("ID");
			Assert.AreEqual("ID", target.Id);
			Assert.AreEqual(ClientDevice.iPod, target.Device);
			Assert.AreEqual(ClientKind.Buildron, target.Kind);
			Assert.IsNull(target.Version);
		}
	}
}

