using System;
using Skahal.Buildron.BackEnd.Domain.Messaging;

namespace Skahal.Buildron.BackEnd.Domain.Messaging
{
	/// <summary>
	/// Represents a notification sent to a Buildron instance.
	/// </summary>
	public class NotificationMessage : Message
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Skahal.Buildron.BackEnd.Domain.Server.NotificationMessage"/> class.
		/// </summary>
		/// <param name="name">Name.</param>
		/// <param name="text">Text.</param>
		public NotificationMessage (string name, string text)
			: base (name)
		{
			Values.Add("NOTIFICATION_TEXT", text);
		}
		#endregion
	}
}