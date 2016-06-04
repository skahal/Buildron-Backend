//  Author: Diego Giacomelli <giacomelli@gmail.com>
//  Copyright (c) 2012 Skahal Studios
using System;
using Skahal.Buildron.BackEnd.Domain.Clients;
using System.Threading;
using Skahal.Buildron.BackEnd.Domain.Messaging;
using System.Linq;

namespace Skahal.Buildron.BackEnd.Domain.Servers
{
	public static class ServerService
	{
		#region Fields
		private static object s_lock = new object();
		private static IServerRepository s_serverRepository;
		private static INotificationMessageRepository s_notificationMessageRepository;
		private static ServerStatistics s_statistics;
		private static Random s_random;
		#endregion

		#region Methods
		public static void Initialize(IServerRepository repository, INotificationMessageRepository notificationMessageRepository)
		{
			s_serverRepository = repository;
			s_notificationMessageRepository = notificationMessageRepository;
			s_statistics = s_serverRepository.FindStatistics();
			
			if(s_statistics == null)
			{
				s_statistics = new ServerStatistics();
			}

			s_random = new Random(DateTime.Now.Millisecond);
			
			var serverBackgroundThread = new Thread(() => {
				while(true)
				{
					try
					{
						Thread.Sleep(30000);
						s_serverRepository.SaveStatistics(s_statistics);
					}
					catch
					{
						// Try again later.
					}
				}
			});
			
			serverBackgroundThread.Start();
		}

		public static void Reset()
		{
			s_statistics = new ServerStatistics();
		}

		public static Message RegisterClient (Client client)
		{
			if(client == null)
			{
				throw new ArgumentNullException("client");
			}

			lock(s_lock)
			{
				s_statistics.TotalClientsCount++;

				switch(client.Kind)
				{
				case ClientKind.Buildron:
					s_statistics.TotalBuildronKindsCount++;
					break;

				case ClientKind.RemoteControl:
					s_statistics.TotalRemoteCountrolKindsCount++;
					break;
				}
				
				switch(client.Device)
				{
				case ClientDevice.Android:
					s_statistics.TotalAndroidDevicesCount++;
					break;
				
				case ClientDevice.Editor:
					s_statistics.TotalEditorDevicesCount++;
					break;
					
				case ClientDevice.iPad:
					s_statistics.TotaliPadDevicesCount++;
					break;
					
				case ClientDevice.iPhone:
					s_statistics.TotaliPhoneDevicesCount++;
					break;
					
				case ClientDevice.iPod:
					s_statistics.TotaliPodDevicesCount++;
					break;
					
				case ClientDevice.Mac:
					s_statistics.TotalMacDevicesCount++;
					break;
					
				case ClientDevice.Windows:
					s_statistics.TotalWindowsDevicesCount++;
					break;
				}

				var message = new Message("REGISTER_CLIENT");
				message.Values.Add("TOTAL_CLIENTS_COUNT", s_statistics.TotalClientsCount);

				return message;
			}
		}

		public static UpdateMessage CheckUpdates(Client client)
		{
			UpdateMessage message;
			var currentVersion = ClientService.GetCurrentVersion(client);

			if(currentVersion.Equals(client.Version))
			{
				message = new UpdateMessage("Your version is up to date", null);
			}
			else
			{
				message = new UpdateMessage(
					String.Format("New version is {0}. Download it from https://github.com/skahal/Buildron", currentVersion),
					"https://github.com/skahal/Buildron");
			}

			return message;
		}

		public static NotificationMessage CheckNotifications(Client client)
		{
			var notifications = s_notificationMessageRepository.FindAll ().ToArray ();

			return notifications[s_random.Next(0, notifications.Length)];
		}

		public static ServerStatistics GetStatistics()
		{
			return s_statistics;
		}
		#endregion
	}
}