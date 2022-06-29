namespace OptionPatternTask.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }

        //Foreign key for Standard
        public int StandardId { get; set; }
        public virtual Standard? Standard { get; set; }
    }
}
