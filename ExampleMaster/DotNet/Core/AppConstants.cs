using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace DotNet.Core
{
    public static class AppConstants
    {
        public static CancellationTokenSource TokenSource { get; set; }
    }
}