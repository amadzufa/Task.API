namespace Todo.API.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public int IsCompleted { get; set; }
        public required string Task { get; set; } 
    }
}
