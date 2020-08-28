using Importer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Importer.DAL
{
    public class ImporterContext: DbContext
    {
       
            public ImporterContext(DbContextOptions<ImporterContext> options)
            : base(options)
            {
            }

            public DbSet<Settings> settings { get; set; }
            public DbSet<Question> questions { get; set; }
            public DbSet<MultiplicationStdScores> multiplicationStdScores { get; set; }
            public DbSet<ModuleLookup> moduleLookups { get; set; }
            public DbSet<ModuleErrorLookup> moduleErrorLookups { get; set; }
            public DbSet<AdditionStdScore> additionStdScores { get; set; }
            public DbSet<Module> modules { get; set; }

    }
 }

