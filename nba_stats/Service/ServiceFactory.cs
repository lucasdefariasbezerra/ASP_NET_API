using nba_stats.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nba_stats.Service
{
    public class ServiceFactory
    {
        public static IService<T> GetService<T>() {
            if (typeof (T) == typeof(PlayerDTO))
            {
                return (IService<T>) new PlayerService();
            }
            else {
                return (IService<T>)new FranchiseService();
            }

            throw new InvalidOperationException();
        }
    }
}