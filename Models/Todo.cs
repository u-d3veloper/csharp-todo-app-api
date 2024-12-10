public class Todo
{
    public int Id { get; set; }
    public required string Task { get; set; }
    public bool Completed { get; set; }
    public DateTime Deadline { get; set; }
}
