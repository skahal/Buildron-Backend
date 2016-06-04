//  Author: Diego Giacomelli <giacomelli@gmail.com>
//  Copyright (c) 2012 Skahal Studios
using System;
using NUnit.Framework;
using Skahal.Buildron.BackEnd.Domain.Servers;
using Rhino.Mocks;
using Skahal.Buildron.BackEnd.Domain.Clients;
using Skahal.Buildron.BackEnd.Domain.Messaging;

namespace Skahal.Buildron.BackEnd.Domain.UnitTests
{
	[TestFixture()]
	public class ServerServiceTest
	{
		[SetUp]
		public void InitializeTest()
		{
			var notificationRepository = MockRepository.GenerateMock<INotificationMessageRepository> ();
			notificationRepository.Expect (e => e.FindAll ()).Return (new NotificationMessage[] { new NotificationMessage ("a", "b") });
			ServerService.Initialize(
				MockRepository.GenerateMock<IServerRepository>(),
				notificationRepository);
		}

		#region Reset
		[Test]
		public void Reset_NoArguments_StatisticsReseted()
		{
			RegisterClient_ClientBuildronMac_UpdateStatisticsAndReturnsMessage();
		
			ServerService.Reset();

			var statistics = ServerService.GetStatistics();
			Assert.AreEqual(0, statistics.TotalAndroidDevicesCount);
			Assert.AreEqual(0, statistics.TotalBuildronKindsCount);
			Assert.AreEqual(0, statistics.TotalClientsCount);
			Assert.AreEqual(0, statistics.TotalClientsCount);
			Assert.AreEqual(0, statistics.TotalEditorDevicesCount);
			Assert.AreEqual(0, statistics.TotaliPadDevicesCount);
			Assert.AreEqual(0, statistics.TotaliPhoneDevicesCount);
			Assert.AreEqual(0, statistics.TotaliPodDevicesCount);
			Assert.AreEqual(0, statistics.TotalAndroidDevicesCount);
			Assert.AreEqual(0, statistics.TotalMacDevicesCount);
			Assert.AreEqual(0, statistics.TotalRemoteCountrolKindsCount);
			Assert.AreEqual(0, statistics.TotalWindowsDevicesCount);
		}
		#endregion

		#region RegisterClient
		[Test()]
		[ExpectedException(typeof(ArgumentNullException))]
		public void RegisterClient_ClientIsNull_ArgumentNullException ()
		{
			ServerService.RegisterClient(null);
		}

		[Test()]
		public void RegisterClient_ClientBuildronMac_UpdateStatisticsAndReturnsMessage ()
		{
			var client = new Client("ID");
			client.Kind = ClientKind.Buildron;
			client.Device = ClientDevice.Mac;

			var message = ServerService.RegisterClient(client);
			Assert.AreEqual("REGISTER_CLIENT", message.Name);
			Assert.AreEqual(1, message.Values.Count);
			Assert.AreEqual(message.Values["TOTAL_CLIENTS_COUNT"], 1);

			var statistics = ServerService.GetStatistics();
			Assert.AreEqual(0, statistics.TotalAndroidDevicesCount);
			Assert.AreEqual(1, statistics.TotalBuildronKindsCount);
			Assert.AreEqual(1, statistics.TotalClientsCount);
			Assert.AreEqual(0, statistics.TotalEditorDevicesCount);
			Assert.AreEqual(0, statistics.TotaliPadDevicesCount);
			Assert.AreEqual(0, statistics.TotaliPhoneDevicesCount);
			Assert.AreEqual(0, statistics.TotaliPodDevicesCount);
			Assert.AreEqual(1, statistics.TotalMacDevicesCount);
			Assert.AreEqual(0, statistics.TotalRemoteCountrolKindsCount);
			Assert.AreEqual(0, statistics.TotalWindowsDevicesCount);
		}

		[Test()]
		public void RegisterClient_ClientBuildronWindows_UpdateStatisticsAndReturnsMessage ()
		{
			var client = new Client("ID");
			client.Kind = ClientKind.Buildron;
			client.Device = ClientDevice.Windows;

			var message = ServerService.RegisterClient(client);
			Assert.AreEqual("REGISTER_CLIENT", message.Name);
			Assert.AreEqual(1, message.Values.Count);
			Assert.AreEqual(1, message.Values["TOTAL_CLIENTS_COUNT"]);

			var statistics = ServerService.GetStatistics();
			Assert.AreEqual(0, statistics.TotalAndroidDevicesCount);
			Assert.AreEqual(1, statistics.TotalBuildronKindsCount);
			Assert.AreEqual(1, statistics.TotalClientsCount);
			Assert.AreEqual(0, statistics.TotalEditorDevicesCount);
			Assert.AreEqual(0, statistics.TotaliPadDevicesCount);
			Assert.AreEqual(0, statistics.TotaliPhoneDevicesCount);
			Assert.AreEqual(0, statistics.TotaliPodDevicesCount);
			Assert.AreEqual(0, statistics.TotalMacDevicesCount);
			Assert.AreEqual(0, statistics.TotalRemoteCountrolKindsCount);
			Assert.AreEqual(1, statistics.TotalWindowsDevicesCount);
		}

		[Test()]
		public void RegisterClient_ClientRemoteControlIPhone_UpdateStatisticsAndReturnsMessage ()
		{
			var client = new Client("ID");
			client.Kind = ClientKind.RemoteControl;
			client.Device = ClientDevice.iPhone;

			var message = ServerService.RegisterClient(client);
			Assert.AreEqual("REGISTER_CLIENT", message.Name);
			Assert.AreEqual(1, message.Values.Count);
			Assert.AreEqual(message.Values["TOTAL_CLIENTS_COUNT"], 1);

			var statistics = ServerService.GetStatistics();
			Assert.AreEqual(0, statistics.TotalAndroidDevicesCount);
			Assert.AreEqual(0, statistics.TotalBuildronKindsCount);
			Assert.AreEqual(1, statistics.TotalClientsCount);
			Assert.AreEqual(0, statistics.TotalEditorDevicesCount);
			Assert.AreEqual(0, statistics.TotaliPadDevicesCount);
			Assert.AreEqual(1, statistics.TotaliPhoneDevicesCount);
			Assert.AreEqual(0, statistics.TotaliPodDevicesCount);
			Assert.AreEqual(0, statistics.TotalMacDevicesCount);
			Assert.AreEqual(1, statistics.TotalRemoteCountrolKindsCount);
			Assert.AreEqual(0, statistics.TotalWindowsDevicesCount);
		}

		[Test()]
		public void RegisterClient_ClientRemoteControlAndroid_UpdateStatisticsAndReturnsMessage ()
		{
			var client = new Client("ID");
			client.Kind = ClientKind.RemoteControl;
			client.Device = ClientDevice.Android;

			var message = ServerService.RegisterClient(client);
			Assert.AreEqual("REGISTER_CLIENT", message.Name);
			Assert.AreEqual(1, message.Values.Count);
			Assert.AreEqual(message.Values["TOTAL_CLIENTS_COUNT"], 1);

			var statistics = ServerService.GetStatistics();
			Assert.AreEqual(1, statistics.TotalAndroidDevicesCount);
			Assert.AreEqual(0, statistics.TotalBuildronKindsCount);
			Assert.AreEqual(1, statistics.TotalClientsCount);
			Assert.AreEqual(0, statistics.TotalEditorDevicesCount);
			Assert.AreEqual(0, statistics.TotaliPadDevicesCount);
			Assert.AreEqual(0, statistics.TotaliPhoneDevicesCount);
			Assert.AreEqual(0, statistics.TotaliPodDevicesCount);
			Assert.AreEqual(0, statistics.TotalMacDevicesCount);
			Assert.AreEqual(1, statistics.TotalRemoteCountrolKindsCount);
			Assert.AreEqual(0, statistics.TotalWindowsDevicesCount);
		}
		#endregion

		#region CheckUpdates
		[Test()]
		[ExpectedException(typeof(ArgumentNullException))]
		public void CheckUpdates_ClientIsNull_ArgumentNullException ()
		{
			ServerService.CheckUpdates(null);
		}

		[Test()]
		public void CheckUpdates_ClientVersionsIsOutOfDate_OutOfDateMessage()
		{
			var client = new Client("ID");
			client.Version = "0.0.0";

			var actual = ServerService.CheckUpdates(client);
			Assert.AreEqual("CHECK_UPDATES", actual.Name);
			Assert.AreEqual(2, actual.Values.Count);
		}

		[Test()]
		public void CheckUpdates_ClientVersionsIsUpdated_UpdatedMessage()
		{
			var client = new Client("ID");
			client.Kind = ClientKind.Buildron;
			client.Device = ClientDevice.Mac;
			client.Version = ClientService.CurrentBuildronMacVersion;

			var actual = ServerService.CheckUpdates(client);
			Assert.AreEqual("CHECK_UPDATES", actual.Name);
			Assert.AreEqual(1, actual.Values.Count);
		}
		#endregion

		#region GetStatistics
		[Test()]
		public void GetStatistics_ServerInitalized_IsNotNull()
		{
			Assert.IsNotNull(ServerService.GetStatistics());
		}
		#endregion

		#region CheckNotifications
		[Test()]
		public void CheckNotifications_ClientVersionsIsOutOfDate_OutOfDateMessage()
		{
			var client = new Client("ID");
			client.Version = "0.0.0";

			var actual = ServerService.CheckNotifications(client);
			Assert.AreEqual(1, actual.Values.Count);
		}
		#endregion
	}
}