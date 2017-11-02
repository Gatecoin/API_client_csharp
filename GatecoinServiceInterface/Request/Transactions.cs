using System;
using System.Collections.Generic;
using System.Web;
using ServiceStack.Common;
using ServiceStack.ServiceHost;
using ServiceStack.Common.Web;
using GatecoinServiceInterface.Response;
namespace GatecoinServiceInterface.Request{
[Route("/Public/Transactions/{CurrencyPair}", "GET", Summary = @"Gets recent transactions", Notes = @"")]
public class Transactions : IReturn<TransactionsResponse>
{
[ApiMember(Name = "CurrencyPair", Description = "Currency Pair", ParameterType = "path", DataType = "string", IsRequired = false)]
public System.String CurrencyPair {get; set; } 
[ApiMember(Name = "Count", Description = "Number of transactions to get. Max 1000", ParameterType = "query", DataType = "int", IsRequired = false)]
public System.Int32? Count {get; set; } 
[ApiMember(Name = "TransactionId", Description = "Get transactions from specific transaction id", ParameterType = "query", DataType = "long", IsRequired = false)]
public System.Int64? TransactionId {get; set; } 
}
}

