using Todo_List_App.Models.Domain;

namespace Todo_List_App.Models
{
    public class IndexViewModel
    {
      public  List<TaskModel> Tasks { get; set; }
        public IndexViewModel()
        {
            Tasks=new List<TaskModel>();
        }
    }
}
