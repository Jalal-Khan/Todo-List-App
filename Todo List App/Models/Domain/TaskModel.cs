namespace Todo_List_App.Models.Domain
{
    public class TaskModel
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public bool IsSelected { get; set; }
    }
}
