using System;
using Skahal.Buildron.BackEnd.Domain;
using System.Collections.Generic;
using Skahal.Buildron.BackEnd.Domain.Messaging;

namespace Skahal.Buildron.BackEnd.Infrastructure.Repositories
{
	public class MemoryNotificationMessageRepository : INotificationMessageRepository
	{
		#region Fields
		private NotificationMessage[] m_notifications = new NotificationMessage[] 
		{
			new NotificationMessage(
				"DOWNLOAD_RC", 
				"Download Buildron RC: \nhttps://github.com/skahal/Buildron-RC"),

			new NotificationMessage(
				"TAKE_PHOTO", 
				"Take a photo from your Buildron and share it on our gallery at\nhttps://github.com/skahal/Buildron"),

			new NotificationMessage(
				"OPEN_SOURCE", 
				"Buildron is a open source project, take a look: \nhttp://github.com/skahal/buildron"),

			new NotificationMessage(
				"FORK_IT", 
				"Want to see a new feature on Buildron? \nFork it or open an issue at https://github.com/skahal/buildron")
		};
		#endregion

		#region Methods
		public IEnumerable<NotificationMessage> FindAll ()
		{
			return m_notifications;
		}
		#endregion
	}
}
