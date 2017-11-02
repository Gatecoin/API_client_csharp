using System;
using System.Collections.Generic;
using System.Web;
using ServiceStack.Common;
using ServiceStack.ServiceHost;
using ServiceStack.Common.Web;
using GatecoinServiceInterface.Response;
namespace GatecoinServiceInterface.Request{
[Route("/Stream/PublicChannel", "GET", Summary = @"Get the public pubnub channel list", Notes = @"")]
public class GetPublicChannel : IReturn<PublicChannelResponse>
{
}
}

