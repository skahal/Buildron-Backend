//  Author: Diego Giacomelli <giacomelli@gmail.com>
//  Copyright (c) 2012 Skahal Studios
using System;
using Skahal.Buildron.BackEnd.Domain.Clients;
using System.Threading;
using Skahal.Buildron.BackEnd.Domain.Messaging;

namespace Skahal.Buildron.BackEnd.Domain.Servers
{
	public static class ServerService
	{
		#region Fields
		private static object s_lock = new object();
		private static IServerRepository s_repository;
		private static ServerStatistics s_statistics;
		private static Random s_random;
		#endregion

		#region Methods
		public static void Initialize(IServerRepository repository)
		{
			s_repository = repository;
			s_statistics = s_repository.FindStatistics();
			
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
						s_repository.SaveStatistics(s_statistics);
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

		public static Message CheckUpdates(Client client)
		{
			var message = new Message("CHECK_UPDATES");
			var currentVersion = ClientService.GetCurrentVersion(client);

			if(currentVersion.Equals(client.Version))
			{
				message.Values.Add("UPDATE_TEXT", "Your version is up to date");
			}
			else
			{
				message.Values.Add("UPDATE_TEXT", String.Format("New version is {0}. Download it from http://skahal.com/buildron", currentVersion));
				message.Values.Add("UPDATE_LINK", "http://skahal.com/buildron");
			}

			return message;
		}

		public static Message CheckNotifications(Client client)
		{
			Message message;

			if(s_random.NextDouble() <= 0.5)
			{
				message = new Message("DOWNLOAD_RC");
				message.Values.Add("NOTIFICATION_TEXT", "Download Buildron RC for iOS and Android: \nhttp://skahal.com/buildron-rc");
			}
			else
			{
				message = new Message("TAKE_PHOTO");
				message.Values.Add("NOTIFICATION_TEXT", "Take a photo from your Buildron and share it on our gallery at\nhttp://skahal.com/buildron");
			}

			return message;
		}

		public static ServerStatistics GetStatistics()
		{
			return s_statistics;
		}
		#endregion
	}
}