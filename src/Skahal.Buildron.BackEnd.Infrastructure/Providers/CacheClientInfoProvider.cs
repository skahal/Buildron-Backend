using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Caching;
using Skahal.Buildron.BackEnd.Domain.Clients;

namespace Skahal.Buildron.BackEnd.Infrastructure
{
	/// <summary>
	/// Cache client info provider.
	/// </summary>
	public class CacheClientInfoProvider : IClientInfoProvider
	{
		#region Fields
		private readonly IClientInfoProvider m_underlyingProvider;
		private readonly MemoryCache m_versionsCache = new MemoryCache ("versions");
		private TimeSpan m_expiration;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Skahal.Buildron.BackEnd.Infrastructure.CacheClientInfoProvider"/> class.
		/// </summary>
		/// <param name="underlyinProvider">Underlyin provider.</param>
		/// <param name="expiration">Expiration.</param>
		public CacheClientInfoProvider(IClientInfoProvider underlyinProvider, TimeSpan expiration)
		{
			m_underlyingProvider = underlyinProvider;
			m_expiration = expiration;
		}
		#endregion

		#region Methods
		/// <summary>
		/// Finds the latest version.
		/// </summary>
		/// <returns>The latest version.</returns>
		/// <param name="device">Device.</param>
		/// <param name="kind">Kind.</param>
		public string FindLatestVersion (ClientDevice device, ClientKind kind)
		{
			var key = String.Format (CultureInfo.InvariantCulture, "{0}_{1}", device, kind);

			if (!m_versionsCache.Contains (key)) {
				var value = m_underlyingProvider.FindLatestVersion (device, kind);
				var policy = new CacheItemPolicy {
					AbsoluteExpiration = DateTimeOffset.Now.Add(m_expiration)
				};
				m_versionsCache.Add (new CacheItem (key, value), policy);
			}

			return m_versionsCache.GetCacheItem (key).Value.ToString();
		}
		#endregion
	}
}