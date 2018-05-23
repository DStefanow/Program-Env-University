namespace StudentInfoSystem
{
    public class Specialization
    {
        public int SpecializationId { get; set; }
        public string Description { get; set; }

        public Specialization() { }

        public Specialization(int id, string description)
        {
            SpecializationId = id;
            Description = description;
        }
    }
}
