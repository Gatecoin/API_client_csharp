using System;
using System.Collections.Generic;
using System.Web;
using ServiceStack.Common;
using ServiceStack.ServiceHost;
using ServiceStack.Common.Web;
using GatecoinServiceInterface.Response;
namespace GatecoinServiceInterface.Request{
[Route("/Public/ExchangeRate", "GET", Summary = @"Get the exchange rates", Notes = @"")]
public class GetExchangeRate : IReturn<ExchangeRateResponse>
{
}
}

