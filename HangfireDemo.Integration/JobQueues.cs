namespace HangfireDemo.Integration
{
    public static class JobQueues
    {
        public const string Default = "default";
        public const string Task = "task";
        public const string Notify = "notify";
        public const string Webhook = "webhook";
        public const string Recurring = "recurring";

        public static readonly string[] All = { Webhook, Notify, Task, Default, Recurring };
    }
}
