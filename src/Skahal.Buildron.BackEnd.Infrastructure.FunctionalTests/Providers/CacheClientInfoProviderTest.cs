using System;
using NUnit.Framework;
using Skahal.Buildron.BackEnd.Infrastructure.Providers;
using Skahal.Buildron.BackEnd.Domain.Clients;
using Rhino.Mocks;
using System.Threading;

namespace Skahal.Buildron.BackEnd.Infrastructure.FunctionalTests
{
	[TestFixture]
	public class CacheClientInfoProviderTest
	{
		[Test]
		public void FindLatestVersion_AnyBuildron_BuildronVersion()
		{
			var underlying = MockRepository.GenerateMock<IClientInfoProvider> ();
			underlying.Expect (e => e.FindLatestVersion (ClientDevice.Windows, ClientKind.Buildron)).Return ("1").Repeat.Once();
			underlying.Expect (e => e.FindLatestVersion (ClientDevice.Mac, ClientKind.RemoteControl)).Return ("2").Repeat.Times(2);
			underlying.Expect (e => e.FindLatestVersion (ClientDevice.Windows, ClientKind.Buildron)).Return ("3").Repeat.Once();

			var target = new CacheClientInfoProvider (underlying, TimeSpan.FromSeconds(5));
			var actual = target.FindLatestVersion (ClientDevice.Windows, ClientKind.Buildron);
			Assert.AreEqual ("1", actual);

			actual = target.FindLatestVersion (ClientDevice.Windows, ClientKind.Buildron);
			Assert.AreEqual ("1", actual);

			actual = target.FindLatestVersion (ClientDevice.Mac, ClientKind.RemoteControl);
			Assert.AreEqual ("2", actual);

			actual = target.FindLatestVersion (ClientDevice.Mac, ClientKind.RemoteControl);
			Assert.AreEqual ("2", actual);

			Thread.Sleep (5000);
			actual = target.FindLatestVersion (ClientDevice.Windows, ClientKind.Buildron);
			Assert.AreEqual ("3", actual);
		}
	}
}
