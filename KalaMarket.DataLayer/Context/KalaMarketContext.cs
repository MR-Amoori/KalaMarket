using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace KalaMarket.DataLayer.Context
{
    public class KalaMarketContext : DbContext
    {
        public KalaMarketContext(DbContextOptions<KalaMarketContext> options) : base(options)
        {

        }
    }
}