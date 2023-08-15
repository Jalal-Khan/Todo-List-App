namespace Todo_List_App.Models
{
    public class EditTaskViewModel
    {
            public Guid Id { get; set; }
            public string Text { get; set; }
            public bool IsSelected { get; set; }   
    }
}
