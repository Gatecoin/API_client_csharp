using System;
using System.Collections.Generic;
using System.Web;
using ServiceStack.Common;
using ServiceStack.ServiceHost;
using ServiceStack.Common.Web;
using GatecoinServiceInterface.Response;
namespace GatecoinServiceInterface.Request{
[Route("/Okpay/Wallet", "GET", Summary = @"Gets existing wallets for a trader", Notes = @"")]
public class GetOkPayWallets : IReturn<GetOkPayWalletsResponse>
{
}
}

