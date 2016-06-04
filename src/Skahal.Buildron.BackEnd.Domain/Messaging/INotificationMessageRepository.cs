using System;
using Skahal.Buildron.BackEnd.Domain.Messaging;
using System.Collections.Generic;

namespace Skahal.Buildron.BackEnd.Domain
{
	/// <summary>
	/// Defines an interface for a notification messages repository.
	/// </summary>
	public interface INotificationMessageRepository
	{
		/// <summary>
		/// Finds all notification messages.
		/// </summary>
		/// <returns>The notification messages.</returns>
		IEnumerable<NotificationMessage> FindAll();
	}
}

