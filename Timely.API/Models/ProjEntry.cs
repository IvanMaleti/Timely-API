namespace Timely.API.Models
{
    //This class contains fields whose values will be stored to the database
    public class ProjEntry
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Duration { get; set; }
        public string StartTimeDateMilisec { get; set; } 
        public string EndTimeDateMilisec { get; set;}
    }
}
