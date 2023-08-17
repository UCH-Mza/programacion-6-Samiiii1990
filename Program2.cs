// namespace HelloWorld
// {

//     class Ejercicio1
//     {

//         static void Main(string[] args)
//         {
            
//             var a = new Task(() =>
//             {

//                 for(int x = 0; x <= 10; x++){
//                     Console.WriteLine ("Hilo 1: Numero " + x);
//                 }
//             });

//             var b = new Task(() =>
//             {
//                 int y;

//                 for(y = 0; y <= 20; y++){

//                     if(y % 2 == 0 ){
//                         Console.WriteLine("Este numero "+ y + " es divisible por 2");
//                     }
//                 }
//             });

//             var c = new Task(() =>
//             {
//                 for(int x = 0; x <= 6; x++){
//                     Console.WriteLine("Vuelta: N° " + x);
//                 }
//             });

//             var d = new Task(() => 
//             {
//                 string[] meses = {
//                     "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio",
//                     "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"
//                 };

//                 Console.WriteLine("Los meses del año son:");
//                 for (int i = 0; i < meses.Length; i++)
//                 {
//                     Console.WriteLine($"{i + 1}. {meses[i]}");
//                 }
//             });

//             var e = new Task(() =>
//             {
//                 for(int j = 0; j <= 10; j++){
//                     Console.WriteLine("En Ejecución: " + j + " segundos");
//                 }
//             });


//             a.Start();
//             a.Wait();

//             b.Start();
//             b.Wait();

//             c.Start();
//             c.Wait();

//             d.Start();
//             d.Wait();

//             e.Start();
//             e.Wait();
            
//         }

//     }
// }