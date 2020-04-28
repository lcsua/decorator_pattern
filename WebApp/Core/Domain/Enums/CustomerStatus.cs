using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Core.Domain.Enums
{
    public enum CustomerStatus
    {
        Trial = 0,
        Active = 1,
        Paused = 2,
        Cancelled = 3,
        Test = 4
    }
}
