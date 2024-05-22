using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApICERTIFAC.Models;

namespace WebApICERTIFAC.DataCtxt
{
    public class DataCtx:DbContext
    {
        public DataCtx(DbContextOptions<DataCtx> options) : base(options) { }

        public virtual DbSet<Addendas> Addendas { get; set; }
    }
}
