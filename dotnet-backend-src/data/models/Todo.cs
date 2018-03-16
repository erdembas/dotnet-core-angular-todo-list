using System;
using System.ComponentModel.DataAnnotations;

namespace dotnet_backend_src.data.models
{
    public enum TodoStatus : Int16
    {
        Wait = 1,
        InProgress = 2,
        Closed = 3
    }

    public class Todo
    {
        public Todo(string title, string description, DateTime createdAt, TodoStatus status)
        {
            this.Title = title;
            this.Description = description;
            this.CreatedAt = createdAt;
            this.Status = status;

        }
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public TodoStatus Status { get; set; }
        public DateTime? ClosedAt { get; set; }
    }
}