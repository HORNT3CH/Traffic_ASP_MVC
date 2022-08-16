namespace Traffic_ASP_MVC.Models
{
    public class TrailerStatus
    {
        public int Id { get; set; }

        public Status TrailerStat { get; set; }
    }

    public enum Status
    {
        Empty,
        FullInComponents,
        FullInFinished,
        FullInMixed,
        FullOutComponents,
        FullOutFinished,
        FullOutMixed,
        Reserved,
        Rejected,
        Shuttle,
        Loading
    }
}
