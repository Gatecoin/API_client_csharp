﻿using ServiceStack.ServiceInterface.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GatecoinServiceInterface.Model;
namespace GatecoinServiceInterface.Model{
[Serializable]
public class Reward
{
public System.Decimal amount{ get; set; }
public System.Double fromDate { get; set; }
public System.Double toDate { get; set; } 
}
}