using System;
using System.Linq;
using System.Reflection;
using EFCoreJetTesst.Model;

namespace EFCoreJetTesst
{
    class Program
    {
        static void Main(string[] args)
        {
            var lAsb = Assembly.Load("System.Data.OleDb");
            var lType = Type.GetType("System.Data.OleDb.OleDbFactory, System.Data.OleDb");
            Console.WriteLine("Hello World!");
            using (var context = new ModelContext())
            {
                context.Database.EnsureCreated();
                var lModels = context.Models.ToList();
                context.Models.Add(new Model.Model(new Random().Next(), "NAME BLABLA"));
                context.SaveChanges();
            }
        }
    }
}