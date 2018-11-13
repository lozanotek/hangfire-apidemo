namespace HangfireDemo.Model
{
    public class TaskInpuModel
    {
        public int Id { get; set; }
        public string[] Tags { get; set; }

        public override string ToString()
        {
            return Id.ToString();
        }
    }
}
