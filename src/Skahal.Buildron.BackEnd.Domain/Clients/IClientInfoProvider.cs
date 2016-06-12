using System;

namespace Skahal.Buildron.BackEnd.Domain.Clients
{
	/// <summary>
	/// Defines an interface to a Buildron's client info provider.
	/// </summary>
	public interface IClientInfoProvider
	{
		/// <summary>
		/// Finds the latest version.
		/// </summary>
		/// <returns>The latest version.</returns>
		/// <param name="device">Device.</param>
		/// <param name="kind">Kind.</param>
		string FindLatestVersion(ClientDevice device, ClientKind kind);
	}
}

