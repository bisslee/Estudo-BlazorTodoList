namespace BlazorToDoList.Models
{
    public class ToDoItem
    {
        private bool isDone;
        public int Id { get; set; }
        public string Description { get; set; } = "";
        public bool IsDone { 
            get => isDone;

            set
            {
                isDone = value;
                if (isDone)
                {
                    DoneDate = DateTime.Now;
                }
            }
        }
        public DateTime DoneDate { get; set; }
    }
}
