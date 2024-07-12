
namespace BlazorToDoList.Models
{
    public static  class ToDoItemsRepository
    {
        private  static List<ToDoItem> ToDoItems = new List<ToDoItem>()
        {
            new ToDoItem(){Id = 1, Description="Lavar Roupa" },
            new ToDoItem(){Id = 2, Description="Limpar Casa" },
            new ToDoItem(){Id = 3, Description="Fazer Compras" },         
        };

        public static void AddToDoItem(ToDoItem toDo)
        {
            if(ToDoItems.Count>0)
            {
                var maxId = ToDoItems.Max(s => s.Id);
                toDo.Id = maxId + 1;
            }
            else
            {
                toDo.Id = 1;
            }
            ToDoItems.Add(toDo);


            //var maxId = ToDoItems.Max(s => s.Id);
            //toDo.Id = maxId + 1;
            //ToDoItems.Add(toDo);
        }
        public static List<ToDoItem> GetToDoItems() 
        {

            var toDoItemsSorted = ToDoItems
                .OrderBy(s => s.IsDone)
                .ThenByDescending(s => s.Id)
                .ToList();
            return toDoItemsSorted;
        }

        public static ToDoItem? GetToDoItemById(int id)
        {
            var toDo = ToDoItems.FirstOrDefault(s => s.Id == id);
            if (toDo != null)
            {
                return new ToDoItem
                {
                    Id = toDo.Id,
                    Description = toDo.Description,
                    IsDone = toDo.IsDone,
                    DoneDate = toDo.DoneDate
                };
            }

            return null;
        }

        public static void UpdateToDoItem(int toDoId, ToDoItem toDo)
        {
            if (toDoId != toDo.Id) return;

            var toDoToUpdate = ToDoItems.FirstOrDefault(s => s.Id == toDoId);
            if (toDoToUpdate != null)
            {
                toDoToUpdate.IsDone = toDo.IsDone;
                toDoToUpdate.Description= toDo.Description;
                toDoToUpdate.DoneDate= toDo.DoneDate;
            }
        }

        public static void DeleteToDoItem(int toDoId)
        {
            var toDo = ToDoItems.FirstOrDefault(s => s.Id == toDoId);
            if (toDo != null)
            {
                ToDoItems.Remove(toDo);
            }
        }

        public static List<ToDoItem> SearchToDoItems(string toDoFilter)
        {
            return ToDoItems.Where(s => s.Description.Contains(toDoFilter, StringComparison.OrdinalIgnoreCase)).ToList();
        }

    }
}
