namespace _2Kontro_pvznr2
{
    class Program
    {
        static void Main(string[] args)
        {
            const string fd = @"../../../Tekstas.txt";
            const string fr = "RedTekstas.txt";

            TaskUtils.PerformTasksW(fd, fr);
        }
    }
}

