//  Author: Diego Giacomelli <giacomelli@gmail.com>
//  Copyright (c) 2012 Skahal Studios
using System;
using NUnit.Framework;
using Skahal.Buildron.BackEnd.Domain.Clients;

namespace Skahal.Buildron.BackEnd.Domain.UnitTests
{
	[TestFixture()]
	public class ClientServiceTest
	{
		[Test()]
		[ExpectedException(typeof(ArgumentNullException))]
		public void GetCurrentVersion_ClientIsNull_ArgumentNullException ()
		{
			ClientService.GetCurrentVersion(null);
		}

		[Test()]
		public void GetCurrentVersion_KindIsBuildronDeviceMac_VersionEqualCurrentBuildronVersion ()
		{
			var client = new Client("ID") { Kind = ClientKind.Buildron, Device = ClientDevice.Mac };
			var actual = ClientService.GetCurrentVersion(client);

			Assert.AreEqual(ClientService.CurrentBuildronMacVersion, actual);
		}

		[Test()]
		public void GetCurrentVersion_KindIsBuildronDeviceWin_VersionEqualCurrentBuildronVersion ()
		{
			var client = new Client("ID") { Kind = ClientKind.Buildron, Device = ClientDevice.Windows };
			var actual = ClientService.GetCurrentVersion(client);
			
			Assert.AreEqual(ClientService.CurrentBuildronWinVersion, actual);
		}

		[Test()]
		public void GetCurrentVersion_KindIsRemoteControl_VersionEqualCurrentBuildronVersion ()
		{
			var client = new Client("ID") { Kind = ClientKind.RemoteControl };
			var actual = ClientService.GetCurrentVersion(client);

			Assert.AreEqual(ClientService.CurrentRemoteControlVersion, actual);
		}
	}
}

