// class Program
// {
//     static async Task Main()
//     {
//         var sum = await Calcular.getSum();
//         var sum1 = await Calcular.getSum();
//         var sum2 = await Calcular.getSum();
//         var sum3 = await Calcular.getSum();
//         var sum4 = await Calcular.getSum();
//         var sum5 = await Calcular.getSum();
//         var sum6 = await Calcular.getSum();
//         var sum7 = await Calcular.getSum();
//         var sum8 = await Calcular.getSum();
//         var sum9 = await Calcular.getSum();

//         var sumaTotal =
//             await Calcular
//                 .sumTotal(sum,
//                 sum1,
//                 sum2,
//                 sum3,
//                 sum4,
//                 sum5,
//                 sum6,
//                 sum7,
//                 sum8,
//                 sum9);
//         Console.WriteLine (sumaTotal);
//     }
// }

// class Calcular
// {
//     public static async Task<int> getSum()
//     {
//         int sum = 0;
//         var randomNumbers = new List<int>();
//         var random = new Random();
//         for (int j = 0; j < 1500; j++)
//         {
//             int randomNumber = random.Next(100);
//             randomNumbers.Add (randomNumber);
//             sum += randomNumber;
//         }

//         Console.WriteLine (sum);
//         return sum;
//     }

//     public static async Task<int>
//     sumTotal(
//         int sum,
//         int sum1,
//         int sum2,
//         int sum3,
//         int sum4,
//         int sum5,
//         int sum6,
//         int sum7,
//         int sum8,
//         int sum9
//     )
//     {
//         int sumaTotal =
//             sum + sum1 + sum2 + sum3 + sum4 + sum5 + sum6 + sum7 + sum8 + sum9;
//         return sumaTotal;
//     }
// }
