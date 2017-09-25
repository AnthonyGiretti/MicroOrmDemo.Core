using Dapper;
using EF;
using NPoco;
using OrmLite;
using System;
using System.Diagnostics;
using System.Text;

namespace ConsoleAppMicroOrmCore._1._1
{
    class Program
    {

        static void Main(string[] args)
        {
            System.Text.EncodingProvider provider = System.Text.CodePagesEncodingProvider.Instance;
            Encoding.RegisterProvider(provider);

            Console.WriteLine("1 requête 1er démarrage");
            Init();

            Console.WriteLine();
            Console.WriteLine("10 itérations");
            //Appels multiple, 100 itérations , 1 enregistrement
            MultipleIteration(10);

            Console.WriteLine();
            Console.WriteLine("100 itérations");
            //Appels multiple, 100 itérations , 1 enregistrement
            MultipleIteration(100);

            Console.WriteLine();
            Console.WriteLine("1000 itérations");
            //Appels multiple, 100 itérations , 1 enregistrement
            MultipleIteration(1000);

            Console.WriteLine();
            Console.WriteLine("1 itération ramenant 500 enregistrements");
            //Appel unique, 500 enregistrements
            SingleCall();

            Console.ReadLine();

        }

        private static void Init()
        {
            MultipleIteration(1);
        }

        private static void SingleCall()
        {
            var watch = new Stopwatch();

            var efquery = new EfQueries();
            watch = new Stopwatch();
            watch.Start();
            var dataEf = efquery.GetOrders();
            watch.Stop();
            Console.WriteLine("EF : " + watch.ElapsedMilliseconds);

            //Dapper
            //var dapperquery = new DapperQueries();
            //watch = new Stopwatch();
            //watch.Start();
            //var dataDapper = dapperquery.GetOrders();
            //watch.Stop();
            //Console.WriteLine("Dapper: " + watch.ElapsedMilliseconds);

            ////Orm lite
            //var ormLiteQuery = new OrmLiteQueries();
            //watch = new Stopwatch();
            //watch.Start();
            //var dataormLite = ormLiteQuery.GetOrders();
            //watch.Stop();
            //Console.WriteLine("Orm Lite: " + watch.ElapsedMilliseconds);

            //Npoco
            //var nPocoQuery = new NPocoQueries();
            //watch = new Stopwatch();
            //watch.Start();
            //var dataNPoco = nPocoQuery.GetOrders();
            //watch.Stop();
            //Console.WriteLine("NPoco : " + watch.ElapsedMilliseconds);


        }

        private static void MultipleIteration(int calls)
        {
            var watch = new Stopwatch();

            //EF
            var efquery = new EfQueries();
            watch = new Stopwatch();
            watch.Start();
            var dataEf = efquery.GetOrders(calls);
            watch.Stop();
            Console.WriteLine("EF : " + watch.ElapsedMilliseconds);

            //Dapper
            //var dapperquery = new DapperQueries();
            //watch = new Stopwatch();
            //watch.Start();
            //var dataDapper = dapperquery.GetOrders(calls);
            //watch.Stop();
            //Console.WriteLine("Dapper : " + watch.ElapsedMilliseconds);

            ////Orm lite
            //var ormLiteQuery = new OrmLiteQueries();
            //watch = new Stopwatch();
            //watch.Start();
            //var dataormLite = ormLiteQuery.GetOrders(calls);
            //watch.Stop();
            //Console.WriteLine("Orm Lite: " + watch.ElapsedMilliseconds);

            //nPOCO
            //var nPocoQuery = new NPocoQueries();
            //watch = new Stopwatch();
            //watch.Start();
            //var dataNPoco = nPocoQuery.GetOrders(calls);
            //watch.Stop();
            //Console.WriteLine("NPoco : " + watch.ElapsedMilliseconds);
        }
    }
}
