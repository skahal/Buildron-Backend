//  Author: Diego Giacomelli <giacomelli@gmail.com>
//  Copyright (c) 2012 Skahal Studios
using System;
using NUnit.Framework;
using Skahal.Buildron.BackEnd.Domain.Clients;
using Rhino.Mocks;

namespace Skahal.Buildron.BackEnd.Domain.UnitTests
{
	[TestFixture()]
	public class ClientServiceTest
	{
		[Test()]
		[ExpectedException(typeof(ArgumentNullException))]
		public void GetCurrentVersion_ClientIsNull_ArgumentNullException ()
		{
			ClientService.GetLatestVersion(null);
		}

		[Test()]
		public void GetCurrentVersion_KindIsBuildronDeviceMac_VersionEqualCurrentBuildronVersion ()
		{
			var provider = MockRepository.GenerateMock<IClientInfoProvider> ();
			provider.Expect (p => p.FindLatestVersion (ClientDevice.Mac, ClientKind.Buildron)).Return ("1");
			ClientService.Initialize (provider);

			var client = new Client("ID") { Kind = ClientKind.Buildron, Device = ClientDevice.Mac };
			var actual = ClientService.GetLatestVersion(client);

			Assert.AreEqual("1", actual);
		}

		[Test()]
		public void GetCurrentVersion_KindIsBuildronDeviceWin_VersionEqualCurrentBuildronVersion ()
		{
			var provider = MockRepository.GenerateMock<IClientInfoProvider> ();
			provider.Expect (p => p.FindLatestVersion (ClientDevice.Mac, ClientKind.Buildron)).Return ("2");
			ClientService.Initialize (provider);

			var client = new Client("ID") { Kind = ClientKind.Buildron, Device = ClientDevice.Mac };
			var actual = ClientService.GetLatestVersion(client);
			
			Assert.AreEqual("2", actual);
		}

		[Test()]
		public void GetCurrentVersion_KindIsRemoteControl_VersionEqualCurrentBuildronVersion ()
		{
			var provider = MockRepository.GenerateMock<IClientInfoProvider> ();
			provider.Expect (p => p.FindLatestVersion (ClientDevice.iPad, ClientKind.RemoteControl)).Return ("3");
			ClientService.Initialize (provider);

			var client = new Client("ID") { Kind = ClientKind.RemoteControl, Device = ClientDevice.iPad };
			var actual = ClientService.GetLatestVersion(client);

			Assert.AreEqual("3", actual);
		}
	}
}

