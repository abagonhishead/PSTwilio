/* Russell Webster <russ@rwebster.co.uk>
 * 
 * */
using System.Management.Automation;
using RestSharp;
using System.Net;

namespace PSTwilio
{
	[Cmdlet(VerbsCommunications.Send, "TwilioSMS")]
	[OutputType(typeof(IRestResponse))]
	public class SendTwilioSMSCmdlet : Cmdlet
	{
		[Parameter(Position=0,Mandatory = true)]
		public string AccountSid
		{
			get { return _accountSid; }
			set { _accountSid = value; }
		}
		private string _accountSid;

		[Parameter(Position = 1, Mandatory = true)]
		public string AuthToken
		{
			get { return _authToken; }
			set { _authToken = value; }
		}
		private string _authToken;

		[Parameter(Position = 2, Mandatory = true)]
		public string To
		{
			get { return _to; }
			set { _to = value; }
		}
		private string _to;

		[Parameter(Position = 3, Mandatory = true)]
		public string From
		{
            get { return _from; }
			set { _from = value; }
		}
		private string _from;

		[Parameter(Position = 4, Mandatory = true)]
		public string MessageBody
		{
			get { return _messageBody; }
			set { _messageBody = value; }
		}
		private string _messageBody;

		private RestClient _client;
		private RestRequest _req;
		private IRestResponse _response;

		protected override void BeginProcessing()
		{
			_client = new RestClient($"https://api.twilio.com/2010-04-01/Accounts/{_accountSid}/Messages.json");
			_req = new RestRequest(Method.POST);
		}

		protected override void ProcessRecord()
		{
			_req.Credentials = new NetworkCredential(_accountSid, _authToken);
			_req.AddParameter("From", _from);
			_req.AddParameter("To", _to);
			_req.AddParameter("Body", _messageBody);
			_response = _client.Execute(_req);
		}

		protected override void EndProcessing()
		{
			WriteObject(_response);
		}
	}
}
