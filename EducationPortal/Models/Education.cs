namespace EducationPortal.Models
{
    public class Education
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public int TrainerId { get; set; }
        public Trainer? Trainer { get; set; }
        public bool IsInternalTrainer { get; set; }
        public int Quota { get; set; }
        public decimal Cost { get; set; }
        public int DurationDays { get; set; }
    }
}
