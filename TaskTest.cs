﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace hello
{

    class CustomData
    {
        public long CreationTime;
        public int Name;
        public int ThreadNum;
    }

    class Coffee{}
    class Egg{ }
    class Bacon{ }
    class Toast{ }
    class Juice{ }



    class TaskTest
    {
        static async Task Main(string[] args)
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready");

            Task<Egg> eggtask = FryEggsAsync(2);
            Task<Bacon> baconTask = FryBaconAsync(3);
            //Task<Toast> toastTask = ToastBreadAsync(2);
            Task<Toast> toastTask = MakeToastWithButterAndJamAsync(2);

            var _breakfastTasks = new List<Task> {eggtask, baconTask, toastTask};
            while(_breakfastTasks.Count > 0){
                Task finishedTask = await Task.WhenAny(_breakfastTasks);
                if(finishedTask == eggtask)
                    Console.WriteLine("egg are ready");
                else if(finishedTask == baconTask)
                    Console.WriteLine("bacon is ready");
                else if (finishedTask == toastTask);

                _breakfastTasks.Remove(finishedTask);               

            }

            Juice oj = PourOJ();
            Console.WriteLine("oj is ready");

            Console.WriteLine("Breakfast is ready!");
        }

        private static async Task<Toast> MakeToastWithButterAndJamAsync(int number){
            var toast = await ToastBreadAsync(number);
            ApplyButter(toast);
            ApplyJam(toast);
            return toast;
        }
        private static Juice PourOJ()
        {
            Console.WriteLine("PourOJ Pouring orange juice");
            return new Juice();
        }

        private static void ApplyJam(Toast toast) => 
            Console.WriteLine("Putting jam on the toast");

        private static void ApplyButter(Toast toast) => 
            Console.WriteLine("Putting butter on the toast");

        private static Toast ToastBread(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Toast Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Toast Start toasting...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Toast Remove toast from toaster");

            return new Toast();
        }

/*
        private static Bacon FryBacon(int slices)
        {
            Console.WriteLine($"putting {slices} slices of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            Task.Delay(3000).Wait();
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("flipping a slice of bacon");
            }
            Console.WriteLine("cooking the second side of bacon...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put bacon on plate");

            return new Bacon();
        }
        */
        private static async Task<Bacon> FryBaconAsync(int slices)
        {
            Console.WriteLine($"putting {slices} slices of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            await Task.Delay(3000);
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("flipping a slice of bacon");
            }
            Console.WriteLine("cooking the second side of bacon...");
            await Task.Delay(3000);
            Console.WriteLine("Put bacon on plate");

            return new Bacon();
        }
        private static async Task<Toast> ToastBreadAsync(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Start toasting...");
            await Task.Delay(3000);
            Console.WriteLine("Remove toast from toaster");

            return new Toast();
        }


/*
        private static Egg FryEggs(int howMany)
        {
            Console.WriteLine("Warming the egg pan...");
            Task.Delay(3000).Wait();
            Console.WriteLine($"cracking {howMany} eggs");
            Console.WriteLine("cooking the eggs ...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put eggs on plate");

            return new Egg();
        }
*/
        private static async Task<Egg> FryEggsAsync(int howMany){

            Console.WriteLine("Warming the egg pan...");
            await Task.Delay(3000);
            Console.WriteLine($"cracking {howMany} eggs");
            Console.WriteLine("cooking the eggs ...");
            await Task.Delay(3000);
            Console.WriteLine("Put eggs on plate");

            return new Egg();
        }


        private static Coffee PourCoffee()
        {
            Console.WriteLine("Pouring coffee");
            return new Coffee();
        }



    }
}