//  Author: Diego Giacomelli <giacomelli@gmail.com>
//  Copyright (c) 2012 Skahal Studios
using System;
using NUnit.Framework;
using Skahal.Buildron.BackEnd.Domain.Servers;

namespace Skahal.Buildron.BackEnd.Domain.UnitTests
{
	[TestFixture()]
	public class ServerStatisticsTest
	{
		[Test()]
		public void Constructor_Normal_AllPropertiesDefaultValue ()
		{
			var target = new ServerStatistics();
			Assert.AreEqual(0, target.TotalAndroidDevicesCount);
			Assert.AreEqual(0, target.TotalBuildronKindsCount);
			Assert.AreEqual(0, target.TotalClientsCount);
			Assert.AreEqual(0, target.TotalEditorDevicesCount);
			Assert.AreEqual(0, target.TotaliPadDevicesCount);
			Assert.AreEqual(0, target.TotaliPhoneDevicesCount);
			Assert.AreEqual(0, target.TotaliPodDevicesCount);
			Assert.AreEqual(0, target.TotalMacDevicesCount);
			Assert.AreEqual(0, target.TotalRemoteCountrolKindsCount);
			Assert.AreEqual(0, target.TotalWindowsDevicesCount);
		}
	}
}

