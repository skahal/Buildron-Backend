using System;
using NUnit.Framework;
using Skahal.Buildron.BackEnd.Infrastructure.Providers;
using Skahal.Buildron.BackEnd.Domain.Clients;

namespace Skahal.Buildron.BackEnd.Infrastructure.FunctionalTests
{
	[TestFixture]
	public class GitHubClientInfoProviderTest
	{
		[Test]
		public void FindLatestVersion_AnyBuildron_BuildronVersion()
		{
			var target = new GitHubClientInfoProvider ();
			var actual = target.FindLatestVersion (ClientDevice.Windows, ClientKind.Buildron);
			Assert.AreEqual ("1.6.0", actual);
		}

		[Test]
		public void FindLatestVersion_AnyRemoteControl_RemoteControlVersion()
		{
			var target = new GitHubClientInfoProvider ();
			var actual = target.FindLatestVersion (ClientDevice.Windows, ClientKind.RemoteControl);
			Assert.AreEqual ("2.1.0", actual);
		}
	}
}
