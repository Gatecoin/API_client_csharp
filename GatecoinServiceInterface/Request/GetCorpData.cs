using System;
using System.Collections.Generic;
using System.Web;
using ServiceStack.Common;
using ServiceStack.ServiceHost;
using ServiceStack.Common.Web;
using GatecoinServiceInterface.Response;
namespace GatecoinServiceInterface.Request{
[Route("/Account/CorporateData", "GET", Summary = @"Get corporate account data", Notes = @"")]
public class GetCorpData : IReturn<CorpDataResponse>
{
}
}

