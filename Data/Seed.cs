namespace Data;

public class Seed
{
    public static void Init()
    {
        using var context = new TodoContext();
        // Look for existing content
        if (context.Todos.Any())
        {
            return; // DB already filled
        }

        // Add tasks
        Todo todo1 = new Todo()
        {
            Id = 1,
            Task = "Groceries",
            Completed = false,
            Deadline = DateTime.Now.AddDays(1),
        };
        Todo todo2 = new Todo()
        {
            Id = 2,
            Task = "Furnitures",
            Completed = false,
            Deadline = DateTime.Now.AddDays(2),
        };
        Todo todo3 = new Todo()
        {
            Id = 3,
            Task = "Papers",
            Completed = false,
            Deadline = DateTime.Now.AddDays(3),
        };

        context.Todos.AddRange(todo1, todo2, todo3);
        context.SaveChanges();
    }
}
