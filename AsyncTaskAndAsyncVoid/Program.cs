namespace AsyncTaskAndAsyncVoid
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            try
            {
                await AsyncTaskMethod();
                //AsyncVoidMethod();
                Console.WriteLine("Hello, World!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static async Task AsyncTaskMethod()
        {
            await Task.Delay(1000);
            throw new Exception("An Error Occured");
        }
        public static async void AsyncVoidMethod()
        {
            await Task.Delay(1000);
            throw new Exception("An Error Occured");
        }
    }
}