using System.ComponentModel;
using System.Management.Automation;
using System.Configuration.Install;
using System;
using System.Collections.ObjectModel;
using System.Management.Automation.Runspaces;

namespace PSTwilio
{
	[RunInstaller(true)]

	public class PSTwilioSnapin : CustomPSSnapIn
	{
		public PSTwilioSnapin()
          : base()
		{
		}

		public override string Description
		{
			get
			{
				return "Powershell snap-in with cmdlets for interacting with Twilio's SMS service";
			}
		}

		public override string Name
		{
			get
			{
				return "PSTwilio";
			}
		}

		public override string Vendor
		{
			get
			{
				return "Russell Webster";
			}
		}

		private Collection<CmdletConfigurationEntry> _cmdlets;
		public override Collection<CmdletConfigurationEntry> Cmdlets
		{
			get
			{
				if (_cmdlets == null)
				{
					_cmdlets = new Collection<CmdletConfigurationEntry>();
					_cmdlets.Add(new CmdletConfigurationEntry("Send-TwilioSMS", typeof(SendTwilioSMSCmdlet), "SendTwilioSMSHelp.dll-HelpText.xml"));
				}

				return _cmdlets;
			}
		}
	}


}
