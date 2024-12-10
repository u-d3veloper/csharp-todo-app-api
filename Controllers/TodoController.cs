using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/todo")]
public class TodoController : ControllerBase
{
    private readonly TodoContext _context;

    public TodoController(TodoContext context)
    {
        _context = context;
    }

    // GET: api/todo
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Todo>>> GetTodos()
    {
        // Get items
        var todos = _context.Todos;
        return await todos.ToListAsync();
    }

    // POST api/todo
    [HttpPost]
    public async Task<ActionResult<Todo>> PostTodo(Todo todo)
    {
        // Add item
        _context.Todos.Add(todo);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetTodos), new { id = todo.Id }, todo);
    }

    // GET api/todo/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTodoItem(int id)
    {
        // Get item
        var todo = await _context.Todos.FindAsync(id);
        if (todo == null)
        {
            return NotFound();
        }

        return Ok(todo);
    }

    // DELETE api/todo/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTodoItem(int id)
    {
        // Delete item
        var todo = await _context.Todos.FindAsync(id);
        if (todo == null)
        {
            return NotFound();
        }

        _context.Todos.Remove(todo);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // PUT api/todo/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTodoItem(int id, Todo todo)
    {
        // Update item
        if (id != todo.Id)
        {
            return BadRequest();
        }

        _context.Entry(todo).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
