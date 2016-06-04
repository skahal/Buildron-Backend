using System;
using Skahal.Buildron.BackEnd.Domain.Messaging;

namespace Skahal.Buildron.BackEnd.Domain.Messaging
{
	/// <summary>
	/// Represents a update message sent to a Buildron instance.
	/// </summary>
	public class UpdateMessage : Message
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Skahal.Buildron.BackEnd.Domain.Messaging.UpdateMessage"/> class.
		/// </summary>
		/// <param name="name">Name.</param>
		/// <param name="text">Text.</param>
		/// <param name="url">URL.</param>
		public UpdateMessage (string text, string link)
			: base ("CHECK_UPDATES")
		{
			Values.Add("UPDATE_TEXT", text);

			if (!String.IsNullOrEmpty(link))
			{
				Values.Add("UPDATE_LINK", link);
			}
		}
		#endregion
	}
}