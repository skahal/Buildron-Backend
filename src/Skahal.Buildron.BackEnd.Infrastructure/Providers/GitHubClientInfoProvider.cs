using System;
using Skahal.Buildron.BackEnd.Domain.Clients;
using System.Net;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Skahal.Buildron.BackEnd.Infrastructure.Providers
{
	/// <summary>
	/// GitHub client info provider.
	/// </summary>
	public class GitHubClientInfoProvider : IClientInfoProvider
	{
		#region Fields
		private static Regex s_getVersionRegex = new Regex ("\"name\":\\s\"v(\\d+\\.\\d+\\.\\d+)\"", RegexOptions.Compiled);
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
			return GetVersionFromUrl (kind == ClientKind.Buildron ? "buildron" : "buildron-rc");
		}

		private string GetVersionFromUrl(string repoName)
		{
			using (var wc = new WebClient ()) {
				wc.Headers.Add (HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2228.0 Safari/537.36");

				var url = String.Format (CultureInfo.InvariantCulture, "https://api.github.com/repos/skahal/{0}/releases/latest", repoName);
				var response = wc.DownloadString (url);

				return s_getVersionRegex.Match (response).Groups [1].Value;
			}
		}
		#endregion
	}
}
