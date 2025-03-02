namespace _2Kontro_pvz
{
    class Program
    {
        static void Main(string[] args)
        {
            const string fd = @"../../../Tekstas.txt";
            const string fr = "RedTekstas.txt";

            TaskUtils.PerformTask(fd, fr);
        }
    }
}
